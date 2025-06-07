using System.ComponentModel.DataAnnotations;

namespace KevinfalsPhone.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Nom { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}