using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using KevinfalsPhone.Models;

namespace KevinfalsPhone.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                return RedirectToAction("Login", "Auth");
            }

            var cartItems = GetCartItems();
            return View(cartItems);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                return RedirectToAction("Login", "Auth");
            }

            var product = await _context.Products.Include(p => p.Category)
                                                .FirstOrDefaultAsync(p => p.Id == productId);
            
            if (product == null)
            {
                TempData["Error"] = "Produit introuvable.";
                return RedirectToAction("Index", "Product");
            }

            if (product.Stock < quantity)
            {
                TempData["Error"] = "Stock insuffisant.";
                return RedirectToAction("Details", "Product", new { id = productId });
            }

            var cartItems = GetCartItems();
            var existingItem = cartItems.FirstOrDefault(x => x.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantite += quantity;
                if (existingItem.Quantite > product.Stock)
                {
                    existingItem.Quantite = product.Stock;
                    TempData["Warning"] = "Quantité ajustée selon le stock disponible.";
                }
            }
            else
            {
                var categoryName = product.Category?.Nom ?? "Catégorie inconnue";
                
                cartItems.Add(new CartItem
                {
                    ProductId = productId,
                    ProductName = product.Nom,
                    Prix = product.Prix,
                    Quantite = quantity,
                    Image = product.Image ?? string.Empty,
                    CategoryName = categoryName
                });
            }

            SaveCartItems(cartItems);
            TempData["Success"] = "Produit ajouté au panier.";
            
            return RedirectToAction("Index", "Product");
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int quantity)
        {
            if (quantity <= 0)
            {
                return RemoveFromCart(productId);
            }

            var cartItems = GetCartItems();
            var item = cartItems.FirstOrDefault(x => x.ProductId == productId);

            if (item != null)
            {
                item.Quantite = quantity;
                SaveCartItems(cartItems);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var cartItems = GetCartItems();
            var item = cartItems.FirstOrDefault(x => x.ProductId == productId);

            if (item != null)
            {
                cartItems.Remove(item);
                SaveCartItems(cartItems);
                TempData["Success"] = "Produit supprimé du panier.";
            }

            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            HttpContext.Session.Remove("Cart");
            TempData["Success"] = "Panier vidé.";
            return RedirectToAction("Index");
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

        private void SaveCartItems(List<CartItem> cartItems)
        {
            var cartJson = JsonConvert.SerializeObject(cartItems);
            HttpContext.Session.SetString("Cart", cartJson);
        }
    }
}