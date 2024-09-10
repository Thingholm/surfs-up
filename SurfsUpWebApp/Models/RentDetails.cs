using System.Xml.Linq;

namespace SurfsUpWebApp.Models
{
   public class RentDetails
    {
        public List<CartItem> Cart { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public DateTime GetDuration() 
        {
            GetDuration = StartDateTime -EndDateTime

        }

   }
}
     