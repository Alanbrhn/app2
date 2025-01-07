using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Server.Models;

namespace ProductManagementAPI.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", PasswordHash = "adminhash" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Sample Product",
                    Description = "This is a sample product.",
                    Price = 99.99M,
                    CreatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = 2,
                    Name = "Advanced Product",
                    Description = "This is an advanced product.",
                    Price = 199.99M,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }

        public void SeedData()
        {
            if (!Products.Any())
            {
                Products.AddRange(
                    new Product
                    {
                        Id = 3,
                        Name = "New Product",
                        Description = "This is a new product.",
                        Price = 49.99M,
                        CreatedAt = DateTime.UtcNow
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Special Product",
                        Description = "This is a special product.",
                        Price = 150.00M,
                        CreatedAt = DateTime.UtcNow
                    }
                );
                SaveChanges(); 
            }
        }
    }
}
