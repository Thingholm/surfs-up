using SurfsUpWebApp.Repositories;
using EntityFramework.Models;
using CartItem = SurfsUpWebApp.Models.CartItem;

namespace CartItemTests
{
    [TestClass]


    public class UnitTest1
    {
        #region GetAll Methods

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
                ProductType =             new ProductType
                {
                    Id = 1,
                    Name = "Shortboard",
                    ImageUrl = "category-1.jpg"
                },
                Price = 565.0,
                Equipment = new List<string>() { "Leash", "finn", "padel", "pump" },
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
            Assert.AreEqual("Id: 23, Product: Id: 1, Name: The Minilog, Length: 6, Width: 21, Thickness: 2,75, Volume: 38,8, Type: Shortboard, Price: 565, Amount: 25", cartItem.ToString());
        }
        #endregion

        #region Update Method

        [TestMethod]

        public void UpdateCartItemAmount()
        {
            // Arrange
            CartItemRepository cartItemRepository = new CartItemRepository();
            Product product = new Product()
            {
                Id = 1,
                Name = "The Minilog",
                Length = 6.0,
                Width = 21.0,
                Thickness = 2.75,
                Volume = 38.8,
                ProductType =             new ProductType
                {
                    Id = 1,
                    Name = "Shortboard",
                    ImageUrl = "category-1.jpg"
                },
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
            cartItemRepository.AddCartItem(cartItem);
            int updatedAmount = 50;

            // Act
            cartItemRepository.UpdateCartItemAmount(cartItem.Id, updatedAmount);
            var updatedCartItem = cartItemRepository.GetAllCartItems().Find(x => x.Id == cartItem.Id);

            // Assert
            Assert.IsNotNull(updatedCartItem);
            Assert.AreEqual(updatedAmount, updatedCartItem.Amount);
        }
        #endregion

        #region Remove Method

        [TestMethod]

        public void DeleteCartItem()
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
                ProductType =             new ProductType
                {
                    Id = 1,
                    Name = "Shortboard",
                    ImageUrl = "category-1.jpg"
                },
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
            cartItemRepository.AddCartItem(cartItem);


            //Act
            cartItemRepository.DeleteCartItem(cartItem.Id);

            //Assert
            var result = cartItemRepository.GetAllCartItems();
            Assert.IsNull(result);

        }


        [TestMethod]
        public void DeleteCartItemWith2Items()
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
                ProductType =             new ProductType
                {
                    Id = 1,
                    Name = "Shortboard",
                    ImageUrl = "category-1.jpg"
                },
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
            CartItem cartItem2 = new CartItem()
            {
                Id = 3,
                Product = product,
                Amount = 2
            };
            cartItemRepository.AddCartItem(cartItem);
            cartItemRepository.AddCartItem(cartItem2);


            //Act
            cartItemRepository.DeleteCartItem(cartItem.Id);

            //Assert
            var allCartItems = cartItemRepository.GetAllCartItems();
            Assert.IsFalse(allCartItems.Any(ci => ci.Id == cartItem.Id));


        }
        #endregion

        #region Add Method

        [TestMethod]
        public void AddCartItem_ShouldAddItemToCart()
        {
            // Arrange
            CartItemRepository cartItemRepository = new CartItemRepository();
            Product product = new Product()
            {
                Id = 1,
                Name = "The Minilog",
                Length = 6.0,
                Width = 21.0,
                Thickness = 2.75,
                Volume = 38.8,
                ProductType =             new ProductType
                {
                    Id = 1,
                    Name = "Shortboard",
                    ImageUrl = "category-1.jpg"
                },
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

            // Act
            cartItemRepository.AddCartItem(cartItem);
            var cartItems = cartItemRepository.GetAllCartItems();

            // Assert
            Assert.IsNotNull(cartItems); // Ensure that the cartItems list is not null
            Assert.AreEqual(1, cartItems.Count); // Ensure that one item was added
            Assert.AreEqual(cartItem, cartItems[0]); // Ensure that the added item is the same as the one retrieved
        }
        #endregion

    }
}