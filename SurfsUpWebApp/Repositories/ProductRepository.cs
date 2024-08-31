using SurfsUpWebApp.Models;

namespace SurfsUpWebApp.Repositories
{
    public static class ProductRepository
    {
        private static List<Product> products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "The Minilog",
                Length = 6.0,
                Width = 21.0,
                Thickness = 2.75,
                Volume = 38.8,
                Type = "Shortboard",
                Price = 565.0,
                Equipment = new List<string>(),
                ImageUrl = "s326152794241300969_p345_i3_w5000.webp"
            },
            new Product
            {
                Id = 2,
                Name = "The Wide Glider",
                Length = 7.1,
                Width = 21.75,
                Thickness = 2.75,
                Volume = 44.16,
                Type = "Funboard",
                Price = 685.0,
                Equipment = new List<string>(),
                ImageUrl = "s326152794241300969_p335_i10_w5000.webp"
            },
            new Product
            {
                Id = 3,
                Name = "The Golden Ratio",
                Length = 6.3,
                Width = 21.85,
                Thickness = 2.9,
                Volume = 43.22,
                Type = "Funboard",
                Price = 695.0,
                Equipment = new List<string>(),
                ImageUrl = "s326152794241300969_p327_i17_w1168.png"
            },
            new Product
            {
                Id = 4,
                Name = "Mahi Mahi",
                Length = 5.4,
                Width = 20.75,
                Thickness = 2.3,
                Volume = 29.39,
                Type = "Fish",
                Price = 645.0,
                Equipment = new List<string>(),
                ImageUrl = "s326152794241300969_p332_i22_w1116.png"
            },
            new Product
            {
                Id = 5,
                Name = "The Emerald Glider",
                Length = 9.2,
                Width = 22.8,
                Thickness = 2.8,
                Volume = 65.4,
                Type = "Longboard",
                Price = 895.0,
                Equipment = new List<string>(),
                ImageUrl = "s326152794241300969_p336_i55_w5000.webp"
            },
            new Product
            {
                Id = 6,
                Name = "The Bomb",
                Length = 5.5,
                Width = 21.0,
                Thickness = 2.5,
                Volume = 33.7,
                Type = "Shortboard",
                Price = 645.0,
                Equipment = new List<string>(),
                ImageUrl = "s326152794241300969_p6_i6_w741.jpeg"
            },
            new Product
            {
                Id = 7,
                Name = "Walden Magic",
                Length = 9.6,
                Width = 19.4,
                Thickness = 3.0,
                Volume = 80.0,
                Type = "Longboard",
                Price = 1025.0,
                Equipment = new List<string>(),
                ImageUrl = "s326152794241300969_p285_i27_w333.jpeg"
            },
            new Product
            {
                Id = 8,
                Name = "Naish One",
                Length = 12.6,
                Width = 30.0,
                Thickness = 6.0,
                Volume = 301.0,
                Type = "SUP",
                Price = 854.0,
                Equipment = new List<string> { "Paddle" },
                ImageUrl = "naish-nalu-10-6-s26-inflatable-sup.jpg"
            },
            new Product
            {
                Id = 9,
                Name = "Six Tourer",
                Length = 11.6,
                Width = 32.0,
                Thickness = 6.0,
                Volume = 270.0,
                Type = "SUP",
                Price = 611.0,
                Equipment = new List<string> { "Fin", "Paddle", "Pump", "Leash" },
                ImageUrl = "stx-tourer-11-6-2022-2023-inflatable-sup-package.jpg"
            },
            new Product
            {
                Id = 10,
                Name = "Naish Maliko",
                Length = 14.0,
                Width = 25.0,
                Thickness = 6.0,
                Volume = 330.0,
                Type = "SUP",
                Price = 1304.0,
                Equipment = new List<string> { "Fin", "Paddle", "Pump", "Leash" },
                ImageUrl = "naish-maliko-carbon-14-x-27-2024-inflatable-sup.jpg"
            }
        };

        public static void AddProduct(Product product)
        {
            products.Add(product);
        }
        public static void Update(Product product)
        {
            if(product == null)
                return;

            Product productToUpdate = GetProductById(product.Id);
            if (productToUpdate == null)
                return;
            productToUpdate = product;   

        }

        public static Product GetProductById(int Id)
        {
            foreach (Product product in products)
            {
                if(product.Id == Id)
                    return product;

            }

            return null;
         
        }

        public static List<Product> GetAllProducts()
        {
            if (products == null || products.Count < 1)
            {
                return null;
            }

            return products;
        }


        public static List<Product> GetProductsByType(string type)
        {
            if (type == null || products?.Any(p => p.Type == type) == null)
            {
                return null;
            }

            return products.Where(p => p.Type == type).ToList();
        }


        public static void DeleteProduct(Product product)
        {
           products.Remove(product);
        }
    }
}

