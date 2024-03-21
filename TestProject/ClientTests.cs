using RCLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    //ToDo #4.6 Тесты класса Client +
    public class ClientTests
    {
        [TestMethod]
        public void DriverLicense_Field_Validation()
        {
            var client = new Client();

            // Test #1
            var expected = "SSS-857321";
            client.DriverLicense = expected;
            Assert.AreEqual(expected, client.DriverLicense);

            // Test #2
            Assert.ThrowsException<ArgumentException>(() => client.DriverLicense = null);

            // Test #3
            Assert.ThrowsException<ArgumentException>(() => client.DriverLicense = "");

            // Test #4
            Assert.ThrowsException<ArgumentException>(() => client.DriverLicense = "Иван5");

            // Test #5
            Assert.ThrowsException<ArgumentException>(() => client.DriverLicense = "742-DASADQ");

            // Test #6
            Assert.ThrowsException<ArgumentException>(() => client.DriverLicense = "ASF-DSGDGSDGDSG");
        }

        [TestMethod]
        public void DateDriverLicense_Field_Validation()
        {
            var client = new Client();

            // Test #1
            Assert.ThrowsException<ArgumentException>(() => client.DateDriverLicense = new DateTime(2023, 05, 10));
        
            // Test #2
            DateTime validDate = DateTime.Now.AddYears(-20);
            client.DateDriverLicense = validDate;
            Assert.AreEqual(validDate.Date, client.DateDriverLicense);

            // Test #3
            DateTime underageDate = DateTime.Now.AddYears(-16);
            Assert.ThrowsException<ArgumentException>(() => client.DateDriverLicense = underageDate);            
        }

        [TestMethod]
        public void TestMethod_RentCar()
        {
            Auto auto = new Auto();
            Client client = new Client();
            Assert.ThrowsException<NotImplementedException>(() => client.RentCar(auto));
        }

        [TestMethod]
        public void TestMethod_ReturnCar()
        {
            Auto auto = new Auto();
            Client client = new Client();
            Assert.ThrowsException<NotImplementedException>(() => client.ReturnCar(auto));
        }

        [TestMethod]
        public void TestMethod_Serialize()
        {
            string filePath = "Clients.json";
            Client client = new Client();
            bool action = client.Serialize();

            // Сериализаия прошла успешно
            Assert.IsTrue(action);
            Assert.IsTrue(File.Exists(filePath));
        }
    }
}
