using Microsoft.AspNetCore.Mvc;

namespace SurfsUpWebApp.Controllers
{
    public class CheckoutController : Controller 
    {
        public IActionResult CustomerInformation()
        {
            return View();
        }
        public IActionResult PaymentInformation()
        {
            return View();
        }
        public IActionResult OrderConfirmation()
        {
            return View();
        }
    }
}
