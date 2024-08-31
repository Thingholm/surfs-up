using Microsoft.AspNetCore.Mvc;
using SurfsUpWebApp.Models;
using SurfsUpWebApp.Repositories;

namespace SurfsUpWebApp.Controllers
{
    [Route("produkter")]
    public class ProdukterController : Controller
    {
        public IActionResult Index(string? type)
        {
            if (type == null)
            {
                List<Product> products = ProductRepository.GetAllProducts();
                return View(products);
            }
            else
            {
                List<Product> products = ProductRepository.GetProductsByType(type);
                return View(products);
            }
        }
    }
}
