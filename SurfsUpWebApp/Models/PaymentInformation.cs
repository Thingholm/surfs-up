namespace SurfsUpWebApp.Models
{
    public class PaymentInformation
    {
        public int PaymentId { get; set; }
        public string CardHolderName { get; set; }
        public int CardNumber { get; set; }
        public DateOnly ExpireDate { get; set; }
        public string CVC {  get; set; }
    }
}
