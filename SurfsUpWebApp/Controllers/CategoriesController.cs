using Microsoft.AspNetCore.Mvc;
using SurfsUpWebApp.Repositories;
using SurfsUpWebApp.Models;
using EntityFramework.Models;
using EntityFramework.Infrastructure;

namespace SurfsUpWebApp.Controllers
{
    [Route("kategorier")]
    public class CategoriesController : Controller
    {
            private readonly AppDbContext _dbContext;
            public CategoriesController(AppDbContext dbContext)
            {
                _dbContext = dbContext;
            }
        public IActionResult Index()
        {
            List<ProductType> types = _dbContext.ProductTypes.ToList();
            if (types.Count > 0)
            {
                return View(types);
            }
            return View();
        }
    }
}
