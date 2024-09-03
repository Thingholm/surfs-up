using SurfsUpWebApp.Repositories;
using SurfsUpWebApp.Models;
using Type = SurfsUpWebApp.Models.Type;

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
            List<Type> types = TypeRepository.GetAllTypes();

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