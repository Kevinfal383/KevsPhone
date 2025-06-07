using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using KevinfalsPhone.Models;
using KevinfalsPhone.Services;

namespace KevinfalsPhone.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPdfService _pdfService;

        public OrderController(ApplicationDbContext context, IPdfService pdfService)
        {
            _context = context;
            _pdfService = pdfService;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            // Vérifier si l'utilisateur est connecté
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                return RedirectToAction("Login", "Auth");
            }

            var cartItems = GetCartItems();
            if (!cartItems.Any())
            {
                TempData["Error"] = "Votre panier est vide.";
                return RedirectToAction("Index", "Cart");
            }

            return View(cartItems);
        }

        [HttpPost]
        public async Task<IActionResult> ProcessOrder(string adresseLivraison)
        {
            var userIdString = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdString))
            {
                return RedirectToAction("Login", "Auth");
            }

            var userId = int.Parse(userIdString);
            var cartItems = GetCartItems();

            if (!cartItems.Any())
            {
                TempData["Error"] = "Votre panier est vide.";
                return RedirectToAction("Index", "Cart");
            }

            if (string.IsNullOrWhiteSpace(adresseLivraison))
            {
                TempData["Error"] = "L'adresse de livraison est requise.";
                return RedirectToAction("Checkout");
            }

            // Vérifier le stock des produits
            foreach (var cartItem in cartItems)
            {
                var product = await _context.Products.FindAsync(cartItem.ProductId);
                if (product == null || product.Stock < cartItem.Quantite)
                {
                    TempData["Error"] = $"Stock insuffisant pour le produit {cartItem.ProductName}.";
                    return RedirectToAction("Index", "Cart");
                }
            }

            // Créer la commande
            var order = new Order
            {
                UserId = userId,
                DateCommande = DateTime.Now,
                AdresseLivraison = adresseLivraison,
                PrixTotal = cartItems.Sum(x => x.Total),
                NombreProduits = cartItems.Sum(x => x.Quantite),
                NumeroFacture = GenerateInvoiceNumber()
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Créer les éléments de commande et mettre à jour le stock
            foreach (var cartItem in cartItems)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = cartItem.ProductId,
                    Quantite = cartItem.Quantite,
                    PrixUnitaire = cartItem.Prix
                };

                _context.OrderItems.Add(orderItem);

                // Mettre à jour le stock
                var product = await _context.Products.FindAsync(cartItem.ProductId);
                if (product != null)
                {
                    product.Stock -= cartItem.Quantite;
                }
            }

            await _context.SaveChangesAsync();

            // Générer et télécharger la facture PDF
            var user = await _context.Users.FindAsync(userId);
            
            // Correction de l'avertissement CS8604
            if (user != null)
            {
                var pdfBytes = _pdfService.GenerateInvoicePdf(order, cartItems, user);
                
                // Vider le panier
                HttpContext.Session.Remove("Cart");

                TempData["Success"] = "Commande validée avec succès !";

                // Retourner le PDF
                return File(pdfBytes, "application/pdf", $"Facture_{order.NumeroFacture}.pdf");
            }
            else
            {
                TempData["Error"] = "Utilisateur introuvable.";
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> MyOrders()
        {
            var userIdString = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdString))
            {
                return RedirectToAction("Login", "Auth");
            }

            var userId = int.Parse(userIdString);
            var orders = await _context.Orders
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.DateCommande)
                .ToListAsync();

            return View(orders);
        }

        public async Task<IActionResult> OrderDetails(int id)
        {
            var userIdString = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdString))
            {
                return RedirectToAction("Login", "Auth");
            }

            var userId = int.Parse(userIdString);
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                        .ThenInclude(p => p!.Category)
                .FirstOrDefaultAsync(o => o.Id == id && o.UserId == userId);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        private List<CartItem> GetCartItems()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cartJson))
            {
                return new List<CartItem>();
            }
            return JsonConvert.DeserializeObject<List<CartItem>>(cartJson) ?? new List<CartItem>();
        }

        private string GenerateInvoiceNumber()
        {
            return $"FAC-{DateTime.Now:yyyyMMdd}-{DateTime.Now.Ticks.ToString().Substring(10)}";
        }
    }
}