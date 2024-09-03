using Microsoft.AspNetCore.Mvc;

namespace SurfsUpWebApp.Controllers
{
    [Route("kurv")]
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}