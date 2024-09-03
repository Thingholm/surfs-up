using Microsoft.AspNetCore.Mvc;

namespace SurfsUpWebApp.Controllers
{
    [Route("lokationer")]
    public class LocationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
