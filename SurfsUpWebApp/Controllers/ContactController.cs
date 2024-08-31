using Microsoft.AspNetCore.Mvc;

namespace SurfsUpWebApp.Controllers
{
    [Route("kontakt")]
    public class KontaktController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
