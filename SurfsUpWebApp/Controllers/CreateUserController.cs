using EntityFramework.Infrastructure;
using EntityFramework.Members;
using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurfsUpWebApp.Models;
using SurfsUpWebApp.Repositories;

namespace SurfsUpWebApp.Controllers
{
    public class CreateUserController : Controller
    {
        private readonly AppDbContext _context;
        public CreateUserController(AppDbContext appContext)
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
        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.Where(x=>x.Email == login.Email & x.Password == login.Password).FirstOrDefault();
                if (user != null)
                {
                    // success
                }
                else {
                    ModelState.AddModelError("", "Forkert kodeord !!");
                }
            }

            return View(login);
        }


    }

          //  List<Product>? products = _dbContext.Products.Take(4).ToList();
           // return View(products);
        }
    

