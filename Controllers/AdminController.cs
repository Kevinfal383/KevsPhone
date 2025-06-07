using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KevinfalsPhone.Models;
using KevinfalsPhone.Services;

namespace KevinfalsPhone.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(ApplicationDbContext context, IAuthService authService, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _authService = authService;
            _webHostEnvironment = webHostEnvironment;
        }

        private bool IsAdmin()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            return userRole == "Admin";
        }

        public IActionResult Dashboard()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Auth");
            }

            ViewBag.TotalUsers = _context.Users.Count();
            ViewBag.TotalProducts = _context.Products.Count();
            ViewBag.TotalOrders = _context.Orders.Count();
            ViewBag.TotalRevenue = _context.Orders.Sum(o => o.PrixTotal);

            return View();
        }

        // Gestion des utilisateurs
        public async Task<IActionResult> Users()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Auth");

            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Auth");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Auth");

            if (ModelState.IsValid)
            {
                if (await _authService.EmailExistsAsync(user.Email))
                {
                    ModelState.AddModelError("Email", "Cet email est déjà utilisé.");
                    return View(user);
                }

                user.MotDePasse = _authService.HashPassword(user.MotDePasse);
                user.DateCreation = DateTime.Now;

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Utilisateur créé avec succès.";
                return RedirectToAction("Users");
            }

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Auth");

            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(User user)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Auth");

            if (ModelState.IsValid)
            {
                var existingUser = await _context.Users.FindAsync(user.Id);
                if (existingUser == null) return NotFound();

                // Vérifier l'email unique sauf pour l'utilisateur actuel
                if (await _context.Users.AnyAsync(u => u.Email == user.Email && u.Id != user.Id))
                {
                    ModelState.AddModelError("Email", "Cet email est déjà utilisé.");
                    return View(user);
                }

                existingUser.Nom = user.Nom;
                existingUser.Prenom = user.Prenom;
                existingUser.Email = user.Email;
                existingUser.DateNaissance = user.DateNaissance;
                existingUser.Ville = user.Ville;
                existingUser.Pays = user.Pays;
                existingUser.Role = user.Role;

                await _context.SaveChangesAsync();
                TempData["Success"] = "Utilisateur modifié avec succès.";
                return RedirectToAction("Users");
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Auth");

            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Utilisateur supprimé avec succès.";
            }

            return RedirectToAction("Users");
        }

        // Gestion des produits
        public async Task<IActionResult> Products()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Auth");

            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Auth");

            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product, IFormFile? imageFile)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Auth");

            if (ModelState.IsValid)
            {
                // Gestion de l'upload d'image
                if (imageFile != null && imageFile.Length > 0)
                {
                    var fileName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
                    var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "products");
                    
                    if (!Directory.Exists(uploadPath))
                        Directory.CreateDirectory(uploadPath);

                    var filePath = Path.Combine(uploadPath, fileName);
                    
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    product.Image = fileName;
                }

                product.DateCreation = DateTime.Now;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Produit créé avec succès.";
                return RedirectToAction("Products");
            }

            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Auth");

            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(Product product, IFormFile? imageFile)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Auth");

            if (ModelState.IsValid)
            {
                var existingProduct = await _context.Products.FindAsync(product.Id);
                if (existingProduct == null) return NotFound();

                // Gestion de l'upload d'image
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Supprimer l'ancienne image
                    if (!string.IsNullOrEmpty(existingProduct.Image))
                    {
                        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "products", existingProduct.Image);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    var fileName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
                    var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "products");
                    
                    if (!Directory.Exists(uploadPath))
                        Directory.CreateDirectory(uploadPath);

                    var filePath = Path.Combine(uploadPath, fileName);
                    
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    existingProduct.Image = fileName;
                }

                existingProduct.Nom = product.Nom;
                existingProduct.Description = product.Description;
                existingProduct.Prix = product.Prix;
                existingProduct.Stock = product.Stock;
                existingProduct.CategoryId = product.CategoryId;

                await _context.SaveChangesAsync();
                TempData["Success"] = "Produit modifié avec succès.";
                return RedirectToAction("Products");
            }

            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Auth");

            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                // Supprimer l'image
                if (!string.IsNullOrEmpty(product.Image))
                {
                    var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "products", product.Image);
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Produit supprimé avec succès.";
            }

            return RedirectToAction("Products");
        }

        // Gestion des commandes
        public async Task<IActionResult> Orders()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Auth");

            var orders = await _context.Orders
                .Include(o => o.User)
                .OrderByDescending(o => o.DateCommande)
                .ToListAsync();

            return View(orders);
        }

        public async Task<IActionResult> OrderDetails(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Auth");

            var order = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                        .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Auth");

            var order = await _context.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == id);
            if (order != null)
            {
                _context.OrderItems.RemoveRange(order.OrderItems);
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Commande supprimée avec succès.";
            }

            return RedirectToAction("Orders");
        }
    }
}