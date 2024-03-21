using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCLibrary
{
    public class Client : UserSystem, IClient
    {
        private static List<Client> clients = new List<Client>();
        public static List<Client> Clients { get => clients; }

        private string driverLicense = string.Empty;
        private DateTime dateDriverLicense;

        private static Regex FormatDriverLicense = new Regex(@"^[A-Za-z]{3}-\d{6}$");

        [DisplayName("Права")]
        public string? DriverLicense
        {
            get { return driverLicense; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Предупреждение: Права не должны быть пустым");

                if (!FormatDriverLicense.IsMatch(value))
                    throw new ArgumentException("Предупреждение: Неверный формат поля права. (Например: \"BXX-161565\")");
                driverLicense = value.Substring(0, 3).ToUpper() + value.Substring(3);
            }
        }
        [DisplayName("Дата получения прав")]
        public DateTime DateDriverLicense
        {
            get { return dateDriverLicense.Date; }
            set
            {
                if (DateTime.Now.Year - value.Year < 18)
                    throw new ArgumentException("Предупреждение: Водитель должен быть старше 18 лет для получения прав");
                dateDriverLicense = value;
            }
        }

        public bool Register(Client newClient)
        {
            newClient.TypeClass = "Клиент";
            // Проверка, что пользователь с таким же email еще не зарегистрирован
            if (Users.Any(u => u.Email == newClient.Email))
                return false;

            // Добавление нового пользователя в список
            UserSystem.Users.Add(newClient);
            clients.Add(newClient);
            return true;
        }

        public bool RentCar(Auto auto)
        {
            throw new NotImplementedException();
        }

        public bool ReturnCar(Auto auto)
        {
            throw new NotImplementedException();
        }

        public override bool Serialize()
        {
            string jsonstring = "";
            foreach (var item in Client.Clients)
            {
                jsonstring += JsonSerializer.Serialize<Client>(item);
                jsonstring += "\n";
            }
            File.WriteAllText("Clients.json", jsonstring);
            return true;
        }

        public override bool Deserialize()
        {
            List<string> lines = new List<string>();
            string filePath = "Clients.json";

            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            lines = File.ReadAllLines(filePath).ToList();
            if (lines.Count != 0)
            {
                Client.Clients.Clear();
                foreach (var item in lines)
                {
                    Client? account = JsonSerializer.Deserialize<Client>(item);
                    if (account != null)
                    {
                        clients.Add(account);
                    }
                }
            }
            return true;
        }

        public override string ToString()
        {
            return base.ToString() + " (" + driverLicense + ")";
        }
    }
}