using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurfsUpWebApp.Models;
using RentDetails = SurfsUpWebApp.Models.RentDetails;

namespace CartItemTests
{

    [TestClass]
    public class RentDetailsTest
    {
        [TestMethod]
        public void GetTimeSpan()
        {
            RentDetails rentDetails = new RentDetails();

            //Arrange 
            rentDetails.StartDateTime = new DateTime(2024, 9, 10, 15, 0, 0);
            rentDetails.EndDateTime = new DateTime(2024, 9, 10, 20, 0, 0);

            //Act
            TimeSpan duration = rentDetails.GetDuration();

            //Assert
            Assert.AreEqual(TimeSpan.FromHours(5), duration);

            
        }
    }
}
