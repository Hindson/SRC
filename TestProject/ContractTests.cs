using RCLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    //ToDo #4.7 Тесты класса Contract +
    public class ContractTests
    {
        [TestMethod]
        public void Renter_Field_Validation()
        {
            Contract contract = new Contract();
            Client renter = new Client();

            contract.Renter = renter;

            Assert.AreEqual(renter, contract.Renter);
            Assert.ThrowsException<ArgumentNullException>(() => contract.Renter = null);
        }
       
        [TestMethod]
        public void Car_Field_Validation()
        {
            Contract contract = new Contract();
            Auto car = new Auto();

            contract.Car = car;

            Assert.AreEqual(car, contract.Car);
            Assert.ThrowsException<ArgumentNullException>(() => contract.Car = null);

        }

        [TestMethod]
        public void StartDate_Field_Validation()
        {
            Contract contract = new Contract();
            DateTime startDate = DateTime.Now;

            contract.StartDate = startDate;
            Assert.AreEqual(startDate, contract.StartDate);

            DateTime pastStartDate = DateTime.Now.AddYears(-1);
            Assert.ThrowsException<ArgumentException>(() => contract.StartDate = pastStartDate);
        }

        [TestMethod]
        public void EndDate_Field_Validation()
        {
            Contract contract = new Contract();
            DateTime endDate = DateTime.Now.AddDays(7);

            contract.EndDate = endDate;
            Assert.AreEqual(endDate, contract.EndDate);

            contract.StartDate = DateTime.Now;
            DateTime endDateBeforeStartDate = contract.StartDate.AddDays(-1);
            Assert.ThrowsException<ArgumentException>(() => contract.EndDate = endDateBeforeStartDate);
        }

        [TestMethod]
        public void RentalPrice_Field_Validation()
        {
            // Arrange
            Contract contract = new Contract();
            Auto car = new Auto();
            car.DailyPrice = 900;
            contract.Car = car;
            contract.StartDate = DateTime.Now;
            contract.EndDate = contract.StartDate.AddDays(5);
            int expectedPrice = 4500;

            // Act
            int? rentalPrice = contract.RentalPrice;

            // Assert
            Assert.AreEqual(expectedPrice, rentalPrice);
        }
    }
}
