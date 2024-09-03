using SurfsUpWebApp.Models;
using Type = SurfsUpWebApp.Models.Type;

namespace SurfsUpWebApp.Repositories
{
    public static class TypeRepository
    {
        private static List<Type> types = new List<Type>()
        {
            new Type
            {
                Id = 1,
                Name = "Shortboard",
                ImageUrl = "a"
            },
            new Type
            {
                Id = 2,
                Name = "Funboard",
                ImageUrl = "a"
            },
            new Type
            {
                Id = 3,
                Name = "Fish",
                ImageUrl = "a"
            },
            new Type
            {
                Id = 4,
                Name = "Longboard",
                ImageUrl = "a"
            },
            new Type
            {
                Id = 5,
                Name = "SUP",
                ImageUrl = "a"
            }

        };
        public static List<Type> GetAllTypes()
        {
            return types;
        }
    }
}