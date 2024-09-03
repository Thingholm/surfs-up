using SurfsUpWebApp.Repositories;
using SurfsUpWebApp.Models;

namespace Tests
{
    [TestClass]
    public class TypeTests
    {
        [TestMethod]
        public void Get_AllTypes_ReturnsListOfAllTypes()
        {
            // Arrange
            // Act
            List<ProductType> types = ProductTypeRepository.GetAllTypes();

            // Assert
            Assert.AreEqual(5, types.Count);
            Assert.AreEqual("Shortboard", types[0].Name);
            Assert.AreEqual("Funboard", types[1].Name);
            Assert.AreEqual("Fish", types[2].Name);
            Assert.AreEqual("Longboard", types[3].Name);
            Assert.AreEqual("SUP", types[4].Name);
        }
    }
}