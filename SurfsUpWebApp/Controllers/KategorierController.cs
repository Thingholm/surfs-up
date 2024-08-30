using Microsoft.AspNetCore.Mvc;

namespace SurfsUpWebApp.Controllers
{
    [Route("kategorier")]
    public class KategorierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
