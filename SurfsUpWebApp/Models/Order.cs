namespace SurfsUpWebApp.Models
{
    public class Order
    {
        public RentDetails RentDetails { get; set; }
        public CustomerInformation CustomerInformation { get; set; }
        public string OrderStatus { get; set; }
        public PaymentInformation PaymentInformation { get; set; }
    }
}
