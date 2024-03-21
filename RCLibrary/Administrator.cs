using System.Text.Json;

namespace RCLibrary
{
    // ToDo #2.4 Класс для администратора. +
    public class Administrator : Manager, IAdministrator
    {
        private static List<Administrator> administrators = new List<Administrator>();
        public static List<Administrator> Administrators { get => administrators; }

        // Добавление менеджера +
        public bool AddManager(Manager newManager)
        {
            newManager.TypeClass = "Менеджер";
            bool res = Register(newManager);
            if (res)
            {
                Manager.Managers.Add(newManager);
                newManager.Serialize();
                return true;
            }
            return false;
        }

        // Удаление менеджера +
        public bool RemoveManager(int value)
        {
            Manager.Managers.RemoveAt(value);
            return true;
        }

        // Добавление администратора +
        public bool AddAdmin(Administrator newAdmin)
        {
            newAdmin.TypeClass = "Администратор";
            bool res = Register(newAdmin);
            if (res)
            {
                administrators.Add(newAdmin);
                newAdmin.Serialize();
                return true;
            }
            return false;
        }

        // Удаление администратора +
        public bool RemoveAdmin(int value)
        {
            administrators.RemoveAt(value);
            return true;
        }

        public override bool Serialize()
        {
            string jsonstring = "";
            foreach (var item in Administrator.Administrators)
            {
                jsonstring += JsonSerializer.Serialize<Administrator>(item);
                jsonstring += "\n";
            }
            File.WriteAllText("Admins.json", jsonstring);
            return true;
        }

        public override bool Deserialize()
        {
            List<string> lines = new List<string>();
            string filePath = "Admins.json";

            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            lines = File.ReadAllLines(filePath).ToList();
            if (lines.Count != 0)
            {
                Administrator.administrators.Clear();
                foreach (var item in lines)
                {
                    Administrator? account = JsonSerializer.Deserialize<Administrator>(item);
                    if (account != null)
                    {
                        administrators.Add(account);
                    }
                }
            }
            return true;
        }
    }
}