using Microsoft.AspNetCore.Mvc;
using KevinfalsPhone.Models;
using KevinfalsPhone.Services;

namespace KevinfalsPhone.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            // Si déjà connecté, rediriger
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _authService.AuthenticateAsync(model.Email, model.MotDePasse);
                
                if (user != null)
                {
                    // Créer la session
                    HttpContext.Session.SetString("UserId", user.Id.ToString());
                    HttpContext.Session.SetString("UserName", user.Prenom + " " + user.Nom);
                    HttpContext.Session.SetString("UserRole", user.Role);
                    HttpContext.Session.SetString("UserEmail", user.Email);

                    // Rediriger selon le rôle
                    if (user.Role == "Admin")
                    {
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Product");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email ou mot de passe incorrect.");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            // Si déjà connecté, rediriger
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _authService.EmailExistsAsync(model.Email))
                {
                    ModelState.AddModelError("Email", "Cet email est déjà utilisé.");
                    return View(model);
                }

                if (_authService.CalculateAge(model.DateNaissance) < 8)
                {
                    ModelState.AddModelError("DateNaissance", "Vous devez avoir au moins 8 ans pour vous inscrire.");
                    return View(model);
                }

                var result = await _authService.RegisterAsync(model);
                
                if (result)
                {
                    TempData["Success"] = "Inscription réalisée avec succès. Vous pouvez maintenant vous connecter.";
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Erreur lors de l'inscription.");
                }
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}