using SurfsUpWebApp.Models;
using ProductType = SurfsUpWebApp.Models.ProductType;

namespace SurfsUpWebApp.Repositories
{
    public static class ProductTypeRepository
    {
        private static List<ProductType> types = new List<ProductType>()
        {
            new ProductType
            {
                Id = 1,
                Name = "Shortboard",
                ImageUrl = "category-1.jpg"
            },
            new ProductType
            {
                Id = 2,
                Name = "Funboard",
                ImageUrl = "s326152794241300969_p327_i17_w1168.png"
            },
            new ProductType
            {
                Id = 3,
                Name = "Fish",
                ImageUrl = "surfboard4.png"
            },
            new ProductType
            {
                Id = 4,
                Name = "Longboard",
                ImageUrl = "s326152794241300969_p285_i27_w333.jpeg" 
            },
            new ProductType
            {
                Id = 5,
                Name = "SUP",
                ImageUrl = "category-3.jpg"
            }

        };
        public static List<ProductType> GetAllTypes()
        {
            return types;
        }
    }
}