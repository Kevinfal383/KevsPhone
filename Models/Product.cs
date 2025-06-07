using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KevinfalsPhone.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nom { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Prix { get; set; }

        [Required]
        public int Stock { get; set; }

        [StringLength(500)]
        public string? Image { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public DateTime DateCreation { get; set; } = DateTime.Now;
    }
}