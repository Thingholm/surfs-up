using Microsoft.AspNetCore.Mvc;

namespace SurfsUpWebApp.Controllers
{
    [Route("om-os")]
    public class OmOsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
