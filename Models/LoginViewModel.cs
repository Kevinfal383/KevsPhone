using System.ComponentModel.DataAnnotations;

namespace KevinfalsPhone.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "L'email est requis")]
        [EmailAddress(ErrorMessage = "Format d'email invalide")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est requis")]
        public required string MotDePasse { get; set; }
    }
}