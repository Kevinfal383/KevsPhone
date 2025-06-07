using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KevinfalsPhone.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public DateTime DateCommande { get; set; } = DateTime.Now;

        [Required]
        [StringLength(500)]
        public string AdresseLivraison { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PrixTotal { get; set; }

        [Required]
        public int NombreProduits { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroFacture { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}