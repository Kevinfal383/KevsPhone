using System.ComponentModel.DataAnnotations;

namespace KevinfalsPhone.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Nom { get; set; }

        [Required]
        [StringLength(50)]
        public required string Prenom { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public required string Email { get; set; }

        [Required]
        public DateTime DateNaissance { get; set; }

        [Required]
        [StringLength(100)]
        public required string Ville { get; set; }

        [Required]
        [StringLength(100)]
        public required string Pays { get; set; }

        [Required]
        [StringLength(255)]
        public required string MotDePasse { get; set; }

        [Required]
        [StringLength(10)]
        public required string Role { get; set; } = "User"; // Admin ou User

        public DateTime DateCreation { get; set; } = DateTime.Now;
    }
}