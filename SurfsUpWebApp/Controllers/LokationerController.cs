using Microsoft.AspNetCore.Mvc;

namespace SurfsUpWebApp.Controllers
{
    [Route("lokationer")]
    public class LokationerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
