using EntityFramework.Infrastructure;
using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using SurfsUpWebApp.Models;
using SurfsUpWebApp.Repositories;

namespace SurfsUpWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;
        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Product>? products = _dbContext.Products.Take(4).ToList();
            return View(products);
        }
    }
}
