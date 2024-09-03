using SurfsUpWebApp.Models;

namespace SurfsUpWebApp.Repositories
{
    public static class CartItemRepository
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
             if(cartItem == null || amount < 0)
                return;

            CartItem cartItemToBeUpdated = cartItems.FirstOrDefault(x => x.id == cartItemId);
            if (cartItemToBeUpdated == null)
                return;
            
            cartItemToBeUpdated.amount = amount;
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            cartItem.Remove(cartItem);
        }
    }
}