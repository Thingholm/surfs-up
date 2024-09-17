using Microsoft.EntityFrameworkCore;

namespace SurfsUpWebApp.Models
{
    public class AppDataContext : DbContext 
    {
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }   

        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
        }
    }

}