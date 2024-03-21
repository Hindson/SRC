using RCLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class ManagerTests
    {
        //ToDo #4.3 Тест класса Manager +
        private Manager manager = new Manager();

        [TestMethod]
        public void TestMethod_AddCar()
        {
            Auto car = new Auto()
            {
                Brand = "Audi",
                Model = "Q7",
                Aclass = classAuto.Средний,
                Acolor = colorAuto.Белый,
                Atype = gearboxType.Автомат,
                DailyPrice = 4000
            };
            Auto.Autos.Clear();
            bool result = manager.AddCar(car);

            Assert.IsTrue(result);
            Assert.AreEqual(car, Auto.Autos[0]);
        }

        [TestMethod]
        public void TestMethod_AddClient()
        {
            Client client = new Client
            {
                Email = "igor532@gmail.com",
                LastName = "Igorov",
                FirstName = "Igor",
                PhoneNumber = "0995427821",
                Password = "Igor2023",
                DriverLicense = "SSA-757214",
                DateDriverLicense = new DateTime(2001, 2, 3)
            };

            Client.Clients.Clear();
            bool result = manager.AddClient(client);

            Assert.IsTrue(result);
            Assert.AreEqual(client, Client.Clients[0]);
        }

        [TestMethod]
        public void TestMethod_RemoveCar()
        {
            Auto car = new Auto();
            Auto.Autos.Add(car);
            int carIndex = Auto.Autos.IndexOf(car);

            bool result = manager.RemoveCar(carIndex);

            Assert.IsTrue(result);
            Assert.IsFalse(Auto.Autos.Contains(car));
        }

        [TestMethod]
        public void TestMethod_RemoveClient()
        {
            Client client = new Client();
            Client.Clients.Add(client);
            int clientIndex = Client.Clients.IndexOf(client);

            bool result = manager.RemoveClient(clientIndex);

            Assert.IsTrue(result);
            Assert.IsFalse(Client.Clients.Contains(client));
        }

        [TestMethod]
        public void TestMethod_AddContract()
        {
            Client client = new Client
            {
                Email = "igor@gmail.com",
                LastName = "Igorov",
                FirstName = "Igor",
                PhoneNumber = "0995427821",
                Password = "Igor2023",
                DriverLicense = "SSA-757214",
                DateDriverLicense = new DateTime(2001, 2, 3)
            };

            Auto car = new Auto()
            {
                Brand = "Audi",
                Model = "Q7",
                Aclass = classAuto.Средний,
                Acolor = colorAuto.Белый,
                Atype = gearboxType.Автомат,
                DailyPrice = 4000
            };

            Manager employee = new Manager
            {
                Email = "client01@gmail.com",
                LastName = "Olegov",
                FirstName = "Oleg",
                PhoneNumber = "0995427821",
                Password = "Oleg2023"
            };

            Contract contract = new Contract
            {
                Car = car,
                Employee = employee,
                Renter = client,
                StartDate = new DateTime(2023, 5, 10),
                EndDate = new DateTime(2023, 5, 15)
            };

            bool result = manager.AddContract(contract);
            Assert.AreEqual(contract, Contract.Contracts[0]);
        }

        [TestMethod]
        public void TestMethod_RemoveContract()
        {
            Contract contract = new Contract();
            Contract.Contracts.Add(contract);
            int contractIndex = Contract.Contracts.IndexOf(contract);

            bool result = manager.RemoveContract(contractIndex);

            Assert.IsTrue(result);
            Assert.IsFalse(Contract.Contracts.Contains(contract));
        }

        [TestMethod]
        public void TestMethod_Serialize()
        {
            string filePath = "Managers.json";

            bool result = manager.Serialize();

            Assert.IsTrue(result);
            Assert.IsTrue(File.Exists(filePath));
        }
    }
}