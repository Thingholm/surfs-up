using System.Xml.Linq;

namespace SurfsUpWebApp.Models
{
   public class RentDetails
    {
        public List<CartItem> Cart { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public TimeSpan GetDuration() 
        {
            TimeSpan duration = EndDateTime - StartDateTime;

            return duration;
        }

   }
}
     