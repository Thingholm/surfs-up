using Microsoft.VisualStudio.TestTools.UnitTesting;
using SurfsUpWebApp.Models;
using SurfsUpWebApp.Repositories;

namespace UnitTestProductRepository1
{
    [TestClass]
    public class ProductRepositoryTests
    {
        

        private ProductRepository repository;

        [TestInitialize]
        public void Setup()
        {
            repository = new ProductRepository();
        }

        [TestMethod]
        public void AddProduct_ShouldAddProductToRepository()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Surfboard" };

            // Act
            repository.AddProduct(product);

            // Assert
            var result = repository.GetProductById(1);
            Assert.IsNotNull(result);
            Assert.AreEqual("Surfboard", result.Name);
        }

        [TestMethod]
        public void Update_ShouldUpdateExistingProduct()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Surfboard" };
            repository.AddProduct(product);

            var updatedProduct = new Product { Id = 1, Name = "Updated Surfboard" };

            // Act
            repository.Update(updatedProduct);

            // Assert
            var result = repository.GetProductById(1);
            Assert.IsNotNull(result);
            Assert.AreEqual("Updated Surfboard", result.Name);
        }

        [TestMethod]
        public void GetProductById_ShouldReturnCorrectProduct()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Surfboard" };
            repository.AddProduct(product);

            // Act
            var result = repository.GetProductById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Surfboard", result.Name);
        }

        [TestMethod]
        public void GetProductById_ShouldReturnNullWhenNotFound()
        {
            // Act
            var result = repository.GetProductById(999);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            // Arrange
            repository.AddProduct(new Product { Id = 1, Name = "Surfboard" });
            repository.AddProduct(new Product { Id = 2, Name = "Wetsuit" });

            // Act
            var result = repository.GetAllProducts();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetProductByType_ShouldReturnCorrectProduct()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Surfboard", Type = "Board" };
            repository.AddProduct(product);

            // Act
            var result = repository.GetProductByType("Board");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Board", result.Type);
        }

        [TestMethod]
        public void DeleteProduct_ShouldRemoveProductFromRepository()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Surfboard" };
            repository.AddProduct(product);

            // Act
            repository.DeleteProduct(product);

            // Assert
            var result = repository.GetProductById(1);
            Assert.IsNull(result);
        }
    }
}
