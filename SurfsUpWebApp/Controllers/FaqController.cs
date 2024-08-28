using Microsoft.AspNetCore.Mvc;

namespace SurfsUpWebApp.Controllers
{
    [Route("faq")]
    public class FaqController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
