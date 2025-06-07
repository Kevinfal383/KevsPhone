using KevinfalsPhone.Models;

namespace KevinfalsPhone.Services
{
    public interface IPdfService
    {
        byte[] GenerateInvoicePdf(Order order, List<CartItem> cartItems, User user);
    }
}