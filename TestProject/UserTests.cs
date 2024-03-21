using RCLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class UserTests
    {
        //ToDo #4.1 Тесты абстрактного класса User +
        [TestMethod]
        public void Email_Field_Validation()
        {
            var manager = new Manager();

            // Test #1
            Assert.ThrowsException<ArgumentException>(() => manager.Email = "");

            // Test #2
            var expected = "tkachevoleg@gmail.com";
            manager.Email = expected;
            Assert.AreEqual(expected, manager.Email);

            // Test #3
            Assert.ThrowsException<ArgumentException>(() => manager.Email = "tkachevoleggmail.com");

            // Test #4
            Assert.ThrowsException<ArgumentException>(() => manager.Email = "tkachevoleg@gmailcom");

            // Test #5
            Assert.ThrowsException<ArgumentException>(() => manager.Email = "tkachevoleggmailcom");
        }

        [TestMethod]
        public void LastName_Field_Validation()
        {
            var manager = new Manager();

            // Test #1
            var expected = "Иванов";
            manager.LastName = expected;
            Assert.AreEqual(expected, manager.LastName);

            // Test #2
            Assert.ThrowsException<ArgumentException>(() => manager.LastName = null);

            // Test #3
            Assert.ThrowsException<ArgumentException>(() => manager.LastName = "");

            // Test #4
            Assert.ThrowsException<ArgumentException>(() => manager.LastName = "Иванов512");
        }

        [TestMethod]
        public void FirstName_Field_Validation()
        {
            var manager = new Manager();

            // Test #1
            var expected = "Иван";
            manager.FirstName = expected;
            Assert.AreEqual(expected, manager.FirstName);
            
            // Test #2
            Assert.ThrowsException<ArgumentException>(() => manager.FirstName = null);

            // Test #3
            Assert.ThrowsException<ArgumentException>(() => manager.FirstName = "");
            
            // Test #4
            Assert.ThrowsException<ArgumentException>(() => manager.FirstName = "Иван5");
        }

        [TestMethod]
        public void MiddleName_Field_Validation()
        {
            var manager = new Manager();

            // Test #1
            manager.MiddleName = "";
            Assert.AreEqual("-", manager.MiddleName);

            // Test #2
            var expected = "Иванович";
            manager.MiddleName = expected;
            Assert.AreEqual(expected, manager.MiddleName);

            // Test #3
            Assert.ThrowsException<ArgumentException>(() => manager.MiddleName = "Иван5ович");
        }

        [TestMethod]
        public void PhoneNumber_Field_Validation()
        {
            var manager = new Manager();
            
            // Test #1
            var expected = "1234567890";
            manager.PhoneNumber = expected;
            Assert.AreEqual(expected, manager.PhoneNumber);

            // Test #2
            Assert.ThrowsException<ArgumentException>(() => manager.PhoneNumber = null);

            // Test #3
            Assert.ThrowsException<ArgumentException>(() => manager.PhoneNumber = "");

            // Test #4
            Assert.ThrowsException<ArgumentException>(() => manager.PhoneNumber = "123456789");

            // Test #5
            Assert.ThrowsException<ArgumentException>(() => manager.PhoneNumber = "12345678901");
        }

        [TestMethod]
        public void Password_Field_Validation()
        {
            Manager manager = new Manager();

            // Test #1
            Assert.ThrowsException<ArgumentException>(() => manager.Password = "");
            
            // Test #2
            Assert.ThrowsException<ArgumentException>(() => manager.Password = "Sasgq");
            
            // Test #3
            Assert.AreEqual(manager.Password = "Tkach2001", "Tkach2001");
        }
    }
}