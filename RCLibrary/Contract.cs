using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RCLibrary
{
    public class Contract : IFile
    {
        private static List<Contract> contracts = new List<Contract>();
        public static List<Contract> Contracts { get => contracts; }

        private static int id = 0;
        private Auto? car = new Auto();
        private Client? renter = new Client();
        private Manager? employee = new Manager();
        private DateTime startDate;
        private DateTime endDate;
        private int? rentalPrice = 0;

        [DisplayName("Номер договора")]
        public int Id { get => ++id; }

        [DisplayName("Арендатор")]
        public Client? Renter
        {
            get { return renter; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Предупреждение: Для аренды должен быть выбран арендодатель!\"");

                renter = value;
            }
        }

        [DisplayName("Автомобиль")]
        public Auto? Car
        {
            get { return car; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Предупреждение: Для аренды должен быть выбран автомобиль!\"");

                car = value;
            }
        }

        [DisplayName("Работник")]
        public Manager? Employee
        {
            get { return employee; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Предупреждение: Для аренды должен быть выбран работник!\"");

                employee = value;
            }
        }

        [DisplayName("Дата начала аренды")]
        public DateTime StartDate
        {
            get => startDate;
            set
            {
                if (value.Year < DateTime.Today.Year)
                    throw new ArgumentException($"Дата начала аренды должна быть в {DateTime.Today.Year} году или позднее.");

                startDate = value;
            }
        }

        [DisplayName("Дата окончания аренды")]
        public DateTime EndDate
        {
            get => endDate;
            set
            {
                if (value.Year < DateTime.Today.Year)
                    throw new ArgumentException($"Дата окончания аренды должна быть в {DateTime.Today.Year} году или позднее.");
                if (value < startDate)
                    throw new ArgumentException("Дата окончания аренды должна быть позднее даты начала аренды!");

                endDate = value;
            }
        }

        [DisplayName("Цена аренды (грн)")]
        public int? RentalPrice
        {
            get {
                rentalPrice = ((int)(endDate - startDate).TotalDays) * car?.DailyPrice;
                return rentalPrice;
            }
        }

        public bool Serialize()
        {
            string jsonstring = "";
            foreach (var item in Contract.Contracts)
            {
                jsonstring += JsonSerializer.Serialize<Contract>(item);
                jsonstring += "\n";
            }
            File.WriteAllText("Contracts.json", jsonstring);
            return true;
        }

        public bool Deserialize()
        {
            List<string> lines = new List<string>();
            string filePath = "Contracts.json";

            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            lines = File.ReadAllLines(filePath).ToList();
            if (lines.Count != 0)
            {
                Contract.contracts.Clear();
                foreach (var item in lines)
                {
                    Contract? account = JsonSerializer.Deserialize<Contract>(item);
                    if (account != null)
                    {
                        contracts.Add(account);
                    }
                }
            }
            return true;
        }
    }
}