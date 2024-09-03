using Microsoft.AspNetCore.Mvc;
using SurfsUpWebApp.Models;
using SurfsUpWebApp.Repositories;
using SurfsUpWebApp.Utils;

namespace SurfsUpWebApp.Controllers
{
    public class ProductsController : Controller
    {
        [Route("produkter")]
        public IActionResult Index(string? types, string? sortBy)
        {
            List<ProductType> productTypes = ProductTypeRepository.GetAllTypes();
            List<Product>? products;
            if (types == null)
            {
                products = ProductRepository.GetAllProducts();
            }
            else
            {
                string[] typeList = types.Contains(",") ? types.Split(",") : [types];
                products = ProductRepository.GetProductsByTypes(typeList);
            }

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
            (List<Product> Products, List<ProductType> ProductTypes) tuple = (products, productTypes);
            return View(tuple);
        }


        [Route("produkter/{id}/{name?}")]
        public IActionResult Product(int id, string? name){
            Product? product = ProductRepository.GetProductById(id);
            if (product != null)
            {
                if (name == null)
                {
                    string formattedString = StringFormatter.GenerateUrlSlug(product.Name);
                    return RedirectToAction("Product", new { id = id, name = formattedString });
                }
                return View(product);
            }
            return View("Index");
        }
    }
}