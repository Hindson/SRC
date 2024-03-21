using RCLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    //ToDo #4.4 Тесты класса Administrator +
    public class AdminTests
    {
        private Administrator admin = new Administrator();

        [TestMethod]
        public void TestMethod_AddManager()
        {
            Manager manager = new Manager
            {
                Email = "igor11@gmail.com",
                LastName = "Igorov",
                FirstName = "Igor",
                PhoneNumber = "0995427821",
                Password = "Igor2023"
            };

            Manager.Managers.Clear();
            bool result = admin.AddManager(manager);

            Assert.IsTrue(result);
            Assert.AreEqual(manager, Manager.Managers[0]);
        }

        [TestMethod]
        public void TestMethod_RemoveManager()
        {
            Manager manager = new Manager();
            Manager.Managers.Add(manager);
            int managerIndex = Manager.Managers.IndexOf(manager);

            bool result = admin.RemoveManager(managerIndex);

            Assert.IsTrue(result);
            Assert.IsFalse(Manager.Managers.Contains(manager));
        }

        [TestMethod]
        public void TestMethod_AddAdmin()
        {
            Administrator administrator = new Administrator
            {
                Email = "igor@gmail.com",
                LastName = "Igorov",
                FirstName = "Igor",
                PhoneNumber = "0995427821",
                Password = "Igor2023"
            };

            Administrator.Administrators.Clear();
            bool result = admin.AddAdmin(administrator);

            Assert.IsTrue(result);
            Assert.AreEqual(administrator, Administrator.Administrators[0]);
        }

        [TestMethod]
        public void TestMethod_RemoveAdmin()
        {
            Administrator administrator = new Administrator();
            Administrator.Administrators.Add(administrator);
            int adminIndex = Administrator.Administrators.IndexOf(administrator);

            bool result = admin.RemoveAdmin(adminIndex);

            Assert.IsTrue(result);
            Assert.IsFalse(Administrator.Administrators.Contains(administrator));
        }
    }
}
