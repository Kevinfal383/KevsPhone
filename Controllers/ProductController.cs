using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KevinfalsPhone.Models;

namespace KevinfalsPhone.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? categoryId)
        {
            // Vérifier si l'utilisateur est connecté
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                return RedirectToAction("Login", "Auth");
            }

            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories;

            IQueryable<Product> productsQuery = _context.Products.Include(p => p.Category);

            if (categoryId.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.CategoryId == categoryId.Value);
                ViewBag.SelectedCategory = await _context.Categories.FindAsync(categoryId.Value);
            }

            var products = await productsQuery.ToListAsync();
            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            // Vérifier si l'utilisateur est connecté
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                return RedirectToAction("Login", "Auth");
            }

            var product = await _context.Products.Include(p => p.Category)
                                                .FirstOrDefaultAsync(p => p.Id == id);
            
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}