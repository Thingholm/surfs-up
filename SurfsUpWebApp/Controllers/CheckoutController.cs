using Microsoft.AspNetCore.Mvc;

namespace SurfsUpWebApp.Controllers
{
    public class CheckoutController : Controller
    {
        [Route("kurv/checkout")]
        public IActionResult Index()
        {
            return View();
        }
    }
}