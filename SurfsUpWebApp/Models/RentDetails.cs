using System.ComponentModel.DataAnnotations;

namespace SurfsUpWebApp.Models
{
    public class RentDetails 
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [MinLength(1)]
        public List<CartItem> Cart { get; set; }
    }
}