using System.ComponentModel.DataAnnotations;

namespace SurfsUpWebApp.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? ImageUrl { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}