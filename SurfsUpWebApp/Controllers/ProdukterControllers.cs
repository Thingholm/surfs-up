using Microsoft.AspNetCore.Mvc;

namespace SurfsUpWebApp.Controllers
{
    [Route("produkter")]
    public class ProdukterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
