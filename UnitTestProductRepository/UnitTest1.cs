using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SurfsUpWebApp.Models;
using SurfsUpWebApp.Repositories;
using xunit;

namespace UnitTestProductRepository
{
    [TestClass]
    public class ProductRepositoryTests
    {
        [Fact]
        public void AddProduct_ShouldAddProductToRepository()
        {
            // Arrange
            var repository = new ProductRepository();
            var product = new Product { Id = 1, Name = "Surfboard" };

            // Act
            repository.AddProduct(product);

            // Assert
            var result = repository.GetProductById(1);
            Assert.NotNull(result);
            Assert.Equal("Surfboard", result.Name);
        }
        public void Update_ShouldUpdateExistingProduct()
        {
            // Arrange
            var repository = new ProductRepository();
            var product = new Product { Id = 1, Name = "Surfboard" };
            repository.AddProduct(product);

            var updatedProduct = new Product { Id = 1, Name = "Updated Surfboard" };

            // Act
            repository.Update(updatedProduct);

            // Assert
            var result = repository.GetProductById(1);
            Assert.NotNull(result);
            Assert.Equal("Updated Surfboard", result.Name);
        }
        public void GetProductById_ShouldReturnCorrectProduct()
        {
            // Arrange
            var repository = new ProductRepository();
            var product = new Product { Id = 1, Name = "Surfboard" };
            repository.AddProduct(product);

            // Act
            var result = repository.GetProductById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Surfboard", result.Name);
        }

        [Fact]
        public void GetProductById_ShouldReturnNullWhenNotFound()
        {
            // Arrange
            var repository = new ProductRepository();

            // Act
            var result = repository.GetProductById(999);

            // Assert
            Assert.Null(result);
        }
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            // Arrange
            var repository = new ProductRepository();
            repository.AddProduct(new Product { Id = 1, Name = "Surfboard" });
            repository.AddProduct(new Product { Id = 2, Name = "Wetsuit" });

            // Act
            var result = repository.GetAllProducts();

            // Assert
            Assert.Equal(2, result.Count);
        }
        public void GetProductByType_ShouldReturnCorrectProduct()
        {
            // Arrange
            var repository = new ProductRepository();
            var product = new Product { Id = 1, Name = "Surfboard", Type = "Board" };
            repository.AddProduct(product);

            // Act
            var result = repository.GetProductByType("Board");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Board", result.Type);
        }
        public void DeleteProduct_ShouldRemoveProductFromRepository()
        {
            // Arrange
            var repository = new ProductRepository();
            var product = new Product { Id = 1, Name = "Surfboard" };
            repository.AddProduct(product);

            // Act
            repository.DeleteProduct(product);

            // Assert
            var result = repository.GetProductById(1);
            Assert.Null(result);
        }
    }
