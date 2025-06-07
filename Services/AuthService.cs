using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using KevinfalsPhone.Models;

namespace KevinfalsPhone.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> AuthenticateAsync(string email, string motDePasse)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            
            if (user != null && VerifyPassword(motDePasse, user.MotDePasse))
            {
                return user;
            }
            return null;
        }

        public async Task<bool> RegisterAsync(RegisterViewModel model)
        {
            if (await EmailExistsAsync(model.Email))
                return false;

            if (CalculateAge(model.DateNaissance) < 8)
                return false;

            var user = new User
            {
                Nom = model.Nom,
                Prenom = model.Prenom,
                Email = model.Email,
                DateNaissance = model.DateNaissance,
                Ville = model.Ville,
                Pays = model.Pays,
                MotDePasse = HashPassword(model.MotDePasse),
                Role = "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return HashPassword(password) == hashedPassword;
        }

        public int CalculateAge(DateTime dateNaissance)
        {
            var today = DateTime.Today;
            var age = today.Year - dateNaissance.Year;
            if (dateNaissance.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}