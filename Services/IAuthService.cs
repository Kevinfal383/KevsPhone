using KevinfalsPhone.Models;

namespace KevinfalsPhone.Services
{
    public interface IAuthService
    {
        Task<User?> AuthenticateAsync(string email, string motDePasse);
        Task<bool> RegisterAsync(RegisterViewModel model);
        Task<bool> EmailExistsAsync(string email);
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
        int CalculateAge(DateTime dateNaissance);
    }
}