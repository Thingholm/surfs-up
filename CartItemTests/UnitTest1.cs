using SurfsUpWebApp.Repositories;
using SurfsUpWebApp.Models;
using CartItem = SurfsUpWebApp.Models.CartItem;

namespace CartItemTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllCartItems()
        {
            //Arrange
            CartItemRepository cartItemRepository = new CartItemRepository();
            Product product = new Product()
            {                
                Id = 1,
                Name = "The Minilog",
                Length = 6.0,
                Width = 21.0,
                Thickness = 2.75,
                Volume = 38.8,
                Type = "Shortboard",
                Price = 565.0,
                Equipment = new List<string>(),
                ImageUrl = "s326152794241300969_p345_i3_w5000.webp"
            };
            CartItem cartItem = new CartItem()
            {
                Id = 23,
                Product = product,
                Amount = 25
            };

            //Act
            cartItemRepository.GetAllCartItems();
            //Assert

            Assert.Equals(23, product, 25);
        }
    }
}