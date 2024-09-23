using Microsoft.AspNetCore.Mvc;

namespace SurfsUpWebApp.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        public IActionResult Login() 
        {
            return View();
        }
         /*public IActionResult Register()
         {
             return View();
         }*/
    }
}