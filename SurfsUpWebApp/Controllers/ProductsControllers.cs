using Microsoft.AspNetCore.Mvc;
using SurfsUpWebApp.Models;
using SurfsUpWebApp.Repositories;

namespace SurfsUpWebApp.Controllers
{
    public class ProductsController : Controller
    {
        [Route("produkter")]
        public IActionResult Index(string? types, string? sortBy)
        {
            if (types == null)
            {
                List<Product>? products = ProductRepository.GetAllProducts();
                return View(products);
            }
            else
            {
                string[] typeList = types.Contains(",") ? types.Split(",") : [types];
                List<Product>? products = ProductRepository.GetProductsByTypes(typeList);

                if (sortBy != null && products != null){
                    switch (sortBy)
                    {
                        case "popularity":
                            products = products.OrderBy(p => p.Id).ToList();
                            break;
                        case "price-asc":
                            products = products.OrderBy(p => p.Price).ToList();
                            break;
                        case "price-desc":
                            products = products.OrderByDescending(p => p.Price).ToList();
                            break;
                        default:
                            break;
                    }
                }

                return View(products);
            }
        }


        [Route("produkter/{id}")]
        public IActionResult Product(int id){
            Product? product = ProductRepository.GetProductById(id);
            if (product != null){
                return View(product);
            }
            return View("Index");
        }
    }
}
