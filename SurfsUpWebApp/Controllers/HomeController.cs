using Microsoft.AspNetCore.Mvc;

namespace SurfsUpWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
