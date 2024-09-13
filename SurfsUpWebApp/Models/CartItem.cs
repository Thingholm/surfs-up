using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace SurfsUpWebApp.Models
{
    public class CartItem
    {
        public int CartItemId {get; set;}
        public Product Product {get; set;}
        public int Amount {get; set;}

        public override string ToString()
        {
            return $"Id: {CartItemId}, Product: {Product}, Amount: {Amount}";
        }
    }

    // class CartItemDb : DbContext 
    // {
    //     public CartItemDb(DbContextOptions<CartItemDb> options) : base(options) {}
    //     public DbSet<CartItem> CartItems { get; set; } = null!;
    // }
}
        