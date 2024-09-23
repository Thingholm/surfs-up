using EntityFramework.Infrastructure;
using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurfsUpWebApp.Models;
using SurfsUpWebApp.Repositories;
using SurfsUpWebApp.Utils;

namespace SurfsUpWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly CartItemRepository _cartItemRepository;
        private readonly AppDbContext _dbContext;
        public ProductsController(CartItemRepository cartItemRepository, AppDbContext dbContext)
        {
            _cartItemRepository = cartItemRepository;
            _dbContext = dbContext;
        }

        [Route("produkter")]
        public IActionResult Index(string? types, string? sortBy)
        {
            List<ProductType> productTypes = _dbContext.ProductTypes.ToList();
            List<Product>? products;
            if (types == null)
            {
                products = _dbContext.Products.ToList();
            }
            else
            {
                List<int> typeList = types.Contains(",") ? types.Split(",").Select(x => int.Parse(x)).ToList() : new List<int>() { 1 };
                products = _dbContext.Products.Where(p => typeList.Any(pt => pt == p.ProductTypeId)).ToList();
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
            (List<Product>? Products, List<ProductType>? ProductTypes) tuple = (products, productTypes);
            return View(tuple);
        }


        [Route("produkter/{id}/{name?}")]
        public IActionResult Product(int id, string? name)
        {
            Product? product = _dbContext.Products.Include(p => p.ProductType).FirstOrDefault(p => p.Id == id);
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

        [HttpPost]
        public IActionResult AddToCart(int ProductId, int Amount)
        {
            Product? product = _dbContext.Products.FirstOrDefault(p => p.Id == ProductId);
            if (product != null)
            {
                CartItem cartItem = new CartItem
                {
                    Id = product.Id,
                    Product = product,
                    Amount = Amount
                };

                _cartItemRepository.AddCartItem(cartItem);
            }

            return RedirectToAction("Product", new { id = ProductId, name = StringFormatter.GenerateUrlSlug(_dbContext.Products.FirstOrDefault(p => p.Id == ProductId).Name) });
        }
    }
}