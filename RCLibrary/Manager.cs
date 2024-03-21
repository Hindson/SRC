using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RCLibrary
{
    //ToDo #2.3 Класс для менеджера. +
    public class Manager : UserSystem, IManager
    {
        private static List<Manager> managers = new List<Manager>();
        public static List<Manager> Managers { get => managers; }

        // +
        public bool AddCar(Auto car)
        {
            Auto.Autos.Add(car);
            car.Serialize();
            return true;
        }

        // +
        public bool AddClient(Client newClient)
        {
            newClient.TypeClass = "Клиент";
            bool res = Register(newClient);
            if (res)
            {
                Client.Clients.Add(newClient);
                newClient.Serialize();
                return true;
            }
            return false;
        }

        // +
        public bool RemoveCar(int value)
        {
            Auto.Autos.RemoveAt(value);
            return true;
        }
        
        // +
        public bool RemoveClient(int value)
        {
            Client.Clients.RemoveAt(value);
            return true;
        }

        public bool AddContract(Contract newContract)
        {
            Contract.Contracts.Add(newContract);
            newContract.Serialize();
            return true;
        }

        public bool RemoveContract(int value)
        {
            Contract.Contracts.RemoveAt(value);
            return true;
        }

        public override bool Serialize()
        {
            string jsonstring = "";
            foreach (var item in Manager.Managers)
            {
                jsonstring += JsonSerializer.Serialize<Manager>(item);
                jsonstring += "\n";
            }
            File.WriteAllText("Managers.json", jsonstring);
            return true;
        }

        public override bool Deserialize()
        {
            List<string> lines = new List<string>();
            string filePath = "Managers.json";

            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            lines = File.ReadAllLines(filePath).ToList();
            if (lines.Count != 0)
            {
                Manager.Managers.Clear();
                foreach (var item in lines)
                {
                    Manager? account = JsonSerializer.Deserialize<Manager>(item);
                    if (account != null)
                    {
                        managers.Add(account);
                    }
                }
            }
            return true;
        }
    }
}
