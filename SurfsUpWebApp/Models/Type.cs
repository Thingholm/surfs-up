using System.ComponentModel.DataAnnotations;

namespace SurfsUpWebApp.Models
{
    public class Type
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
    }
}