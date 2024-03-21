using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RCLibrary
{
    //ToDo #2.2 Класс для всех пользователей системы. +
    public class UserSystem : User
    {
        private static List<UserSystem> users = new List<UserSystem>();
        public static List<UserSystem> Users { get => users; }

        public static UserSystem activeUser = new UserSystem();

        public bool Register(UserSystem user)
        {
            // Проверка, что пользователь с таким же email еще не зарегистрирован
            if (users.Any(u => u.Email == user.Email))
                return false;

            // Добавление нового пользователя в список
            users.Add(user);
            return true;
        }

        public bool Authenticate(string email, string password)
        {
            // Поиск пользователя по email и паролю
            UserSystem? user = users.FirstOrDefault(u => u.Email == email && u.Password == password);

            // Если пользователь найден, то вход выполнен успешно
            if (user != null)
            {
                activeUser = user;
                return true;
            }

            return false;
        }

        public override bool Serialize()
        {
            string jsonstring = "";
            foreach (var item in Client.Clients)
            {
                jsonstring += JsonSerializer.Serialize<UserSystem>(item);
                jsonstring += "\n";
            }

            foreach (var item in Manager.Managers)
            {
                jsonstring += JsonSerializer.Serialize<UserSystem>(item);
                jsonstring += "\n";
            }

            foreach (var item in Administrator.Administrators)
            {
                jsonstring += JsonSerializer.Serialize<UserSystem>(item);
                jsonstring += "\n";
            }

            File.WriteAllText("Users.json", jsonstring);
            return true;
        }

        public override bool Deserialize()
        {
            List<string> lines = new List<string>();
            string filePath = "Users.json";

            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            lines = File.ReadAllLines(filePath).ToList();

            if (lines.Count != 0)
            {
                UserSystem.users.Clear();
                foreach (var item in lines)
                {
                    UserSystem? account = JsonSerializer.Deserialize<UserSystem>(item);
                    if (account != null)
                        users.Add(account);
                }
            }
            return true;
        }
    }
}
