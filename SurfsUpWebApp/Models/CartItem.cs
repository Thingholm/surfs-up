using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace SurfsUpWebApp.Models
{
    public class CartItem
    {
        public int Id {get; set;}
        public Product Product {get; set;}
        public int Amount {get; set;}

        public override string ToString()
        {
            return $"Id: {Id}, Product: {Product}, Amount: {Amount}";
        }
    }

    class CartItemDb : DbContext 
    {
        public CartItemDb(DbContextOptions options) : base(options) {}
        public DbSet<CartItem> CartItems { get; set; } = null!;
    }
}
        