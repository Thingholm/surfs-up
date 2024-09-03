using Microsoft.AspNetCore.Mvc;
using SurfsUpWebApp.Models;
using SurfsUpWebApp.Repositories;

namespace SurfsUpWebApp.Controllers
{
    [Route("kurv")]
    public class CartController : Controller
    {
        private readonly CartItemRepository _cartItemRepository;
        public CartController(CartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }
        public IActionResult Index()
        {
            List<CartItem> cartItems = _cartItemRepository.GetAllCartItems();
            return View(cartItems);
        }
    }
}