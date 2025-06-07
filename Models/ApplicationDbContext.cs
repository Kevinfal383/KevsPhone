using Microsoft.EntityFrameworkCore;

namespace KevinfalsPhone.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration des relations
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);
            
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Nom = "Admin",
                    Prenom = "Admin",
                    Email = "admin@gmail.com",
                    DateNaissance = new DateTime(1990, 1, 1),
                    Ville = "Antananarivo",
                    Pays = "Madagasikara",
                    MotDePasse = "jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=", // 123456
                    Role = "Admin",
                    DateCreation = DateTime.Now
                }
            );

            // Données de test pour les catégories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Nom = "Huawei" },
                new Category { Id = 2, Nom = "Samsung" },
                new Category { Id = 3, Nom = "Apple" },
                new Category { Id = 4, Nom = "GooglePixel" }
            );

            // Produits de test
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Nom = "Huawei P50 Pro", Description = "Smartphone haut de gamme", Prix = 899.99m, Stock = 10, CategoryId = 1, Image = "h1.jpg" },
                new Product { Id = 2, Nom = "Huawei Mate 40 Pro", Description = "Smartphone puissant et élégant", Prix = 799.99m, Stock = 8, CategoryId = 1, Image = "h2.jpg" },
                new Product { Id = 3, Nom = "Huawei Nova 11", Description = "Excellent rapport qualité-prix", Prix = 499.99m, Stock = 12, CategoryId = 1, Image = "h3.jpg" },
                new Product { Id = 4, Nom = "Huawei P40 Lite", Description = "Smartphone milieu de gamme", Prix = 299.99m, Stock = 20, CategoryId = 1, Image = "h4.jpg" },
                new Product { Id = 5, Nom = "Huawei Y9a", Description = "Écran FullView et bonne autonomie", Prix = 259.99m, Stock = 15, CategoryId = 1, Image = "h5.jpg" },
                new Product { Id = 6, Nom = "Huawei P60 Pro", Description = "Nouveauté avec caméra avancée", Prix = 999.99m, Stock = 6, CategoryId = 1, Image = "h6.jpg" },
                new Product { Id = 7, Nom = "Huawei Nova 10 SE", Description = "Design moderne et performant", Prix = 379.99m, Stock = 9, CategoryId = 1, Image = "h7.jpg" },
                new Product { Id = 8, Nom = "Huawei Mate 50", Description = "Flagship innovant", Prix = 1099.99m, Stock = 5, CategoryId = 1, Image = "h8.jpg" },

                // Samsung
                new Product { Id = 9, Nom = "Samsung Galaxy S24 Ultra", Description = "Smartphone haut de gamme", Prix = 1399.99m, Stock = 10, CategoryId = 2, Image = "s1.jpg" },
                new Product { Id = 10, Nom = "Samsung Galaxy Z Fold5", Description = "Écran pliable", Prix = 1799.99m, Stock = 3, CategoryId = 2, Image = "s2.webp" },
                new Product { Id = 11, Nom = "Samsung Galaxy S23", Description = "Excellent en photo", Prix = 999.99m, Stock = 7, CategoryId = 2, Image = "s3.webp" },
                new Product { Id = 12, Nom = "Samsung Galaxy A54", Description = "Milieu de gamme puissant", Prix = 449.99m, Stock = 14, CategoryId = 2, Image = "s4.jpg" },
                new Product { Id = 13, Nom = "Samsung Galaxy M14", Description = "Bonne autonomie", Prix = 199.99m, Stock = 18, CategoryId = 2, Image = "s5.jpg" },
                new Product { Id = 14, Nom = "Samsung Galaxy Z Flip5", Description = "Design pliable compact", Prix = 1199.99m, Stock = 6, CategoryId = 2, Image = "s6.jpg" },
                new Product { Id = 15, Nom = "Samsung Galaxy S22 Ultra", Description = "Stylet intégré", Prix = 1249.99m, Stock = 4, CategoryId = 2, Image = "s7.jpg" },
                new Product { Id = 16, Nom = "Samsung Galaxy Note 20", Description = "Productivité et performance", Prix = 949.99m, Stock = 5, CategoryId = 2, Image = "s8.webp" },

                // Apple
                new Product { Id = 17, Nom = "iPhone 15 Pro Max", Description = "Dernier modèle haut de gamme", Prix = 1599.99m, Stock = 10, CategoryId = 3, Image = "a1.webp" },
                new Product { Id = 18, Nom = "iPhone 15", Description = "Modèle standard 2023", Prix = 1099.99m, Stock = 8, CategoryId = 3, Image = "a2.jpeg" },
                new Product { Id = 19, Nom = "iPhone 14 Pro", Description = "Technologie avancée", Prix = 1299.99m, Stock = 6, CategoryId = 3, Image = "a3.jpg" },
                new Product { Id = 20, Nom = "iPhone 13", Description = "Performance et autonomie", Prix = 899.99m, Stock = 10, CategoryId = 3, Image = "a4.jpeg" },
                new Product { Id = 21, Nom = "iPhone SE (2022)", Description = "Compact et rapide", Prix = 479.99m, Stock = 12, CategoryId = 3, Image = "a5.webp" },
                new Product { Id = 22, Nom = "iPhone 12", Description = "Bon rapport qualité/prix", Prix = 749.99m, Stock = 9, CategoryId = 3, Image = "a6.webp" },
                new Product { Id = 23, Nom = "iPhone 11", Description = "Encore performant", Prix = 599.99m, Stock = 11, CategoryId = 3, Image = "a7.jpg" },
                new Product { Id = 24, Nom = "iPhone XR", Description = "Coloré et accessible", Prix = 399.99m, Stock = 7, CategoryId = 3, Image = "a8.webp" },

                // Google Pixel
                new Product { Id = 25, Nom = "Google Pixel 8 Pro", Description = "IA intégrée et caméra top", Prix = 1099.99m, Stock = 7, CategoryId = 4, Image = "g1.png" },
                new Product { Id = 26, Nom = "Google Pixel 8", Description = "Version compacte", Prix = 799.99m, Stock = 10, CategoryId = 4, Image = "g2.webp" },
                new Product { Id = 27, Nom = "Google Pixel 7 Pro", Description = "Caméra exceptionnelle", Prix = 899.99m, Stock = 6, CategoryId = 4, Image = "g3.webp" },
                new Product { Id = 28, Nom = "Google Pixel 7a", Description = "Bon prix et performances", Prix = 499.99m, Stock = 12, CategoryId = 4, Image = "g4.webp" },
                new Product { Id = 29, Nom = "Google Pixel 6 Pro", Description = "Excellent appareil photo", Prix = 799.99m, Stock = 8, CategoryId = 4, Image = "g5.webp" },
                new Product { Id = 30, Nom = "Google Pixel 6a", Description = "Petit prix, grande valeur", Prix = 399.99m, Stock = 13, CategoryId = 4, Image = "g6.png" },
                new Product { Id = 31, Nom = "Google Pixel 5", Description = "Bonne autonomie", Prix = 349.99m, Stock = 10, CategoryId = 4, Image = "g7.jpg" },
                new Product { Id = 32, Nom = "Google Pixel 4a", Description = "Compact et fluide", Prix = 299.99m, Stock = 14, CategoryId = 4, Image = "g8.jpg" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}