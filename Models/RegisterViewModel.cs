using System.ComponentModel.DataAnnotations;

namespace KevinfalsPhone.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères")]
        public required string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom est requis")]
        [StringLength(50, ErrorMessage = "Le prénom ne peut pas dépasser 50 caractères")]
        public required string Prenom { get; set; }

        [Required(ErrorMessage = "L'email est requis")]
        [EmailAddress(ErrorMessage = "Format d'email invalide")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "La date de naissance est requise")]
        public DateTime DateNaissance { get; set; }

        [Required(ErrorMessage = "La ville est requise")]
        public required string Ville { get; set; }

        [Required(ErrorMessage = "Le pays est requis")]
        public required string Pays { get; set; }

        [Required(ErrorMessage = "Le mot de passe est requis")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Le mot de passe doit contenir au moins 6 caractères")]
        public required string MotDePasse { get; set; }

        [Required(ErrorMessage = "Veuillez confirmer le mot de passe")]
        [Compare("MotDePasse", ErrorMessage = "Les mots de passe ne correspondent pas")]
        public required string ConfirmerMotDePasse { get; set; }
    }
}