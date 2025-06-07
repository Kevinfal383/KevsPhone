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

            // Données de test pour les catégories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Nom = "Huawei" },
                new Category { Id = 2, Nom = "Samsung" },
                new Category { Id = 3, Nom = "Apple" },
                new Category { Id = 4, Nom = "GooglePixel" }
            );

            // Produits de test
            modelBuilder.Entity<Product>().HasData(
                // Huawei
                new Product { Id = 1, Nom = "Huawei P50 Pro", Description = "Smartphone haut de gamme", Prix = 899.99m, Stock = 10, CategoryId = 1, Image = "huawei-p50.jpg" },
                new Product { Id = 2, Nom = "Huawei MatePad", Description = "Tablette performante", Prix = 449.99m, Stock = 5, CategoryId = 1, Image = "huawei-matepad.jpg" },
                
                // Samsung
                new Product { Id = 3, Nom = "Samsung Galaxy S24", Description = "Dernier flagship Samsung", Prix = 1099.99m, Stock = 8, CategoryId = 2, Image = "samsung-s24.jpg" },
                new Product { Id = 4, Nom = "Samsung Galaxy Tab S9", Description = "Tablette premium", Prix = 649.99m, Stock = 6, CategoryId = 2, Image = "samsung-tabs9.jpg" },
                
                // Apple
                new Product { Id = 5, Nom = "iPhone 15 Pro", Description = "iPhone dernière génération", Prix = 1299.99m, Stock = 12, CategoryId = 3, Image = "iphone15pro.jpg" },
                new Product { Id = 6, Nom = "MacBook Air M2", Description = "Ordinateur portable léger", Prix = 1499.99m, Stock = 4, CategoryId = 3, Image = "macbook-air.jpg" },
                
                // Google Pixel
                new Product { Id = 7, Nom = "Google Pixel 8 Pro", Description = "Smartphone Google avec IA", Prix = 999.99m, Stock = 7, CategoryId = 4, Image = "pixel8pro.jpg" },
                new Product { Id = 8, Nom = "Google Pixel Buds", Description = "Écouteurs sans fil", Prix = 199.99m, Stock = 15, CategoryId = 4, Image = "pixel-buds.jpg" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}