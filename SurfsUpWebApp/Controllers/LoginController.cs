using EntityFramework.Infrastructure;
using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace SurfsUpWebApp.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;
        public LoginController(AppDbContext appContext)
        {

            _context = appContext;
        }
        public IActionResult Login() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.Where(x => x.Email == login.Email & x.Password == login.Password).FirstOrDefault();
                if (user != null)
                {
                    // create cookie

                    var claims = new List<Claim>();
                    {
                        new Claim(ClaimTypes.Name, user.Email);
                        new Claim("Name", user.Name);
                        new Claim(ClaimTypes.Role, "User");

                    };


                }
                else
                {
                    ModelState.AddModelError("", "Forkert kodeord !!");
                }
            }

            return View(login);
        }
        /*public IActionResult Register()
        {
            return View();
        }*/
    }
}