namespace KevinfalsPhone.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Prix { get; set; }
        public int Quantite { get; set; }
        public string Image { get; set; }
        public string CategoryName { get; set; }
        
        public decimal Total => Prix * Quantite;
    }
}