using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SurfsUpWebApp.Models
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
    }

    //  class ProductTypeDb : DbContext 
    // {
    //     public ProductTypeDb(DbContextOptions options) : base(options) {}
    //     public DbSet<ProductType> ProductTypes { get; set; } = null!;
    // }
}