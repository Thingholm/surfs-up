using Microsoft.AspNetCore.Mvc;
using SurfsUpWebApp.Models;
using SurfsUpWebApp.Repositories;

namespace SurfsUpWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly CartItemRepository _cartItemRepository;
        public CartController(CartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }
        [Route("kurv")]
        public IActionResult Index()
        {
            List<CartItem> cartItems = _cartItemRepository.GetAllCartItems();
            return View(cartItems);
        }
        
        [HttpPost]
        public IActionResult DeleteItem(int id)
        {
            _cartItemRepository.DeleteCartItem(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult IncreaseAmount(int id)
        {
            CartItem? cartItemToBeUpdated = _cartItemRepository.GetCartItemById(id);
            if (cartItemToBeUpdated != null)
            {
                cartItemToBeUpdated.Amount++;
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DecreaseAmount(int id)
        {
            CartItem? cartItemToBeUpdated = _cartItemRepository.GetCartItemById(id);
            if (cartItemToBeUpdated != null)
            {
                cartItemToBeUpdated.Amount--;
            }
            return RedirectToAction("Index");
        }
        [HttpPost("kurv/checkout")]
        public IActionResult GoToCheckout(DateTime date){
            if (ModelState.IsValid)
            {
                return Redirect("/kurv/checkout");
            }
            return RedirectToAction("Index");
        }
    }
}