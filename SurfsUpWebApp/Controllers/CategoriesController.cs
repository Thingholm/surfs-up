using Microsoft.AspNetCore.Mvc;
using SurfsUpWebApp.Repositories;
using SurfsUpWebApp.Models;

namespace SurfsUpWebApp.Controllers
{
    [Route("kategorier")]
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            List<ProductType> types = ProductTypeRepository.GetAllTypes();
            if (types.Count > 0)
            {
                return View(types);
            }
            return View();
        }
    }
}
