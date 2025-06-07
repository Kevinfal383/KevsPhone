using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using KevinfalsPhone.Models;

namespace KevinfalsPhone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Vérifier si l'utilisateur est connecté
            var userId = HttpContext.Session.GetString("UserId");
            var userRole = HttpContext.Session.GetString("UserRole");

            if (!string.IsNullOrEmpty(userId))
            {
                // Rediriger vers la liste des produits si connecté
                return RedirectToAction("Index", "Product");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}