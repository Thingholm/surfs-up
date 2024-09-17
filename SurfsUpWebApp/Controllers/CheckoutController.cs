using Microsoft.AspNetCore.Mvc;

namespace SurfsUpWebApp.Controllers
{
    public class CheckoutController : Controller
    {
        [Route("kurv/kontaktoplysninger")]
        public IActionResult Index()
        {
            return View();
        }
    }
}