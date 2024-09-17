using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SurfsUpWebApp.Models;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace SurfsUpWebApp.Data
{
    public class Seeddata
    {
        public static void Initialize(AppDataContext context)
        {
            if (context.Products.Any())
            {
                // If there are existing products, remove them
                var surfboards = context.Products.ToList();
                context.RemoveRange(surfboards);
                context.SaveChanges();
                return;
            }

            // Check if product types exist and only add them if they don't
            if (!context.ProductTypes.Any())
            {
                var productTypes = new List<ProductType>
        {
            new ProductType { ProductTypeId = 1, Name = "Shortboard", ImageUrl = "category-1.jpg" },
            new ProductType { ProductTypeId = 2, Name = "Funboard", ImageUrl = "category-2.jpg" },
            new ProductType { ProductTypeId = 3, Name = "Fish", ImageUrl = "category-3.jpg" },
            new ProductType { ProductTypeId = 4, Name = "Longboard", ImageUrl = "category-4.jpg" },
            new ProductType { ProductTypeId = 5, Name = "SUP", ImageUrl = "category-5.jpg" }
        };

                context.ProductTypes.AddRange(productTypes);
                context.SaveChanges();
            }
            var products = new List<Product>()
{
    new Product
    {
        ProductId = 1,
        Name = "The Minilog",
        Length = 6.0,
        Width = 21.0,
        Thickness = 2.75,
        Volume = 38.8,
        Type = context.ProductTypes.FirstOrDefault(pt => pt.ProductTypeId == 1), // Shortboard
        Price = 565.0,
        Equipment = new List<string>(),
        ImageUrl = "s326152794241300969_p345_i3_w5000.webp"
    },
    new Product
    {
        ProductId = 2,
        Name = "The Wide Glider",
        Length = 7.1,
        Width = 21.75,
        Thickness = 2.75,
        Volume = 44.16,
        Type = context.ProductTypes.FirstOrDefault(pt => pt.ProductTypeId == 2), // Funboard
        Price = 685.0,
        Equipment = new List<string>(),
        ImageUrl = "s326152794241300969_p327_i17_w1168.png"
    },
    new Product
    {
        ProductId = 3,
        Name = "The Golden Ratio",
        Length = 6.3,
        Width = 21.85,
        Thickness = 2.9,
        Volume = 43.22,
        Type = context.ProductTypes.FirstOrDefault(pt => pt.ProductTypeId == 2), // Funboard
        Price = 695.0,
        Equipment = new List<string>(),
        ImageUrl = "s326152794241300969_p327_i17_w1168.png"
    },
    new Product
    {
        ProductId = 4,
        Name = "Mahi Mahi",
        Length = 5.4,
        Width = 20.75,
        Thickness = 2.3,
        Volume = 29.39,
        Type = context.ProductTypes.FirstOrDefault(pt => pt.ProductTypeId == 3), // Fish
        Price = 645.0,
        Equipment = new List<string>(),
        ImageUrl = "s326152794241300969_p332_i22_w1116.png"
    },
    new Product
    {
        ProductId = 5,
        Name = "The Emerald Glider",
        Length = 9.2,
        Width = 22.8,
        Thickness = 2.8,
        Volume = 65.4,
        Type = context.ProductTypes.FirstOrDefault(pt => pt.ProductTypeId == 4), // Longboard
        Price = 895.0,
        Equipment = new List<string>(),
        ImageUrl = "s326152794241300969_p336_i55_w5000.webp"
    },
    new Product
    {
        ProductId = 6,
        Name = "The Bomb",
        Length = 5.5,
        Width = 21.0,
        Thickness = 2.5,
        Volume = 33.7,
        Type = context.ProductTypes.FirstOrDefault(pt => pt.ProductTypeId == 1), // Shortboard
        Price = 645.0,
        Equipment = new List<string>(),
        ImageUrl = "s326152794241300969_p6_i6_w741.jpeg"
    },
    new Product
    {
        ProductId = 7,
        Name = "Walden Magic",
        Length = 9.6,
        Width = 19.4,
        Thickness = 3.0,
        Volume = 80.0,
        Type = context.ProductTypes.FirstOrDefault(pt => pt.ProductTypeId == 4), // Longboard
        Price = 1025.0,
        Equipment = new List<string>(),
        ImageUrl = "s326152794241300969_p285_i27_w333.jpeg"
    },
    new Product
    {
        ProductId = 8,
        Name = "Naish One",
        Length = 12.6,
        Width = 30.0,
        Thickness = 6.0,
        Volume = 301.0,
        Type = context.ProductTypes.FirstOrDefault(pt => pt.ProductTypeId == 5), // SUP
        Price = 854.0,
        Equipment = new List<string> { "Paddle" },
        ImageUrl = "naish-nalu-10-6-s26-inflatable-sup.jpg"
    },
    new Product
    {
        ProductId = 9,
        Name = "Six Tourer",
        Length = 11.6,
        Width = 32.0,
        Thickness = 6.0,
        Volume = 270.0,
        Type = context.ProductTypes.FirstOrDefault(pt => pt.ProductTypeId == 5), // SUP
        Price = 611.0,
        Equipment = new List<string> { "Fin", "Paddle", "Pump", "Leash" },
        ImageUrl = "stx-tourer-11-6-2022-2023-inflatable-sup-package.jpg"
    },
    new Product
    {
        ProductId = 10,
        Name = "Naish Maliko",
        Length = 14.0,
        Width = 25.0,
        Thickness = 6.0,
        Volume = 330.0,
        Type = context.ProductTypes.FirstOrDefault(pt => pt.ProductTypeId == 5), // SUP
        Price = 1304.0,
        Equipment = new List<string> { "Fin", "Paddle", "Pump", "Leash" },
        ImageUrl = "naish-maliko-carbon-14-x-27-2024-inflatable-sup.jpg"
    }
};

            // Add products to the context
            context.Products.AddRange(products);

            // Save the changes to persist the data in the database
            context.SaveChanges();
        }
    }
}
