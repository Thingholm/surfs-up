using EntityFramework.Infrastructure;
using EntityFramework.Members;
using EntityFramework.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurfsUpWebApp.Models;
using SurfsUpWebApp.Repositories;
using System.Security.Claims;

namespace SurfsUpWebApp.Controllers
{
    [Route("registration")]
    public class RegistrationController : Controller
    {
        private readonly AppDbContext _context;
        public RegistrationController(AppDbContext appContext)
        {
            _context = appContext;
        }
        [HttpPost]
        public IActionResult Registration(CreateUser model)
        {
            if(ModelState.IsValid)
            {
             User user = new User();
              user.Email = model.Email;
              user.Name = model.Name;
            user.Password = model.Password;
                try
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    ModelState.Clear();

                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "skriv email og kode");

                }
                return View();

            }
            return View(model);

        }
        public IActionResult Index()
        {
            return View(_context.Users.ToList());
        }
       

        [Authorize]
        public IActionResult SecurePage()
        {
            ViewBag.Name = HttpContext.User.Identity?.Name;
        return View();
        }


            //  List<Product>? products = _dbContext.Products.Take(4).ToList();
           // return View(products);
    }

          
        }
    

