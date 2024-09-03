using SurfsUpWebApp.Models;

namespace SurfsUpWebApp.Repositories
{
    public class CartItemRepository
    { 
        private List<CartItem> cartItems = new List<CartItem>();

        public void AddCartItem(CartItem cartItem)
        {
            cartItems.Add(cartItem);
        }

        public List<CartItem> GetAllCartItems() 
        {
            if (cartItems == null || cartItems.Count < 1)
            {
                return null;
            }
            
            return cartItems;
            
        }

        public void UpdateCartItemAmount(int cartItemId, int amount) 
        {
             if(cartItemId == null || amount < 0)
                return;

            CartItem cartItemToBeUpdated = cartItems.FirstOrDefault(x => x.Id == cartItemId);
            if (cartItemToBeUpdated == null)
                return;
            
            cartItemToBeUpdated.Amount = amount;
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            cartItems.Remove(cartItem);
        }
    }
}