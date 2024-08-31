using Microsoft.AspNetCore.Mvc;

namespace SurfsUpWebApp.Controllers
{
    [Route("lokationer")]
    public class LocationsrController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
