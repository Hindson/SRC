using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RCLibrary
{
    //ToDo #2.5 Класс автомобиль +
    public class Auto : IFile
    {
        private static List<Auto> autos = new List<Auto>();
        public static List<Auto> Autos { get => autos; }

        public Guid Id { get; set; } = Guid.NewGuid();
        private string brand = string.Empty;
        private string model = string.Empty;
        private int? dailyPrice = 0;

        [DisplayName("Бренд")]
        public string? Brand
        {
            get => brand;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Предупреждение: Необходимо указать бренд автомобиля.");
                if (value.Length > 15)
                    throw new ArgumentException("Предупреждение: Бренд автомобиля слишком длинный!");
                brand = value;
            }
        }

        [DisplayName("Модель")]
        public string? Model
        {
            get => model;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Предупреждение: Необходимо указать модель автомобиля.");
                if (value.Length > 15)
                    throw new ArgumentException("Предупреждение: Модель автомобиля слишком длинный!");
                model = value;
            }
        }

        [DisplayName("Класс авто")]
        public classAuto? Aclass { get; set; }

        [DisplayName("Тип КПП")]
        public gearboxType? Atype { get; set; }

        [DisplayName("Цвет")]
        public colorAuto? Acolor { get; set; }

        [DisplayName("Цена аренды (грн/сутки)")]
        public int? DailyPrice
        {
            get => dailyPrice;
            set
            {
                if (value < 800)
                    throw new ArgumentException("Предупреждение: Аренда автомобиля должна быть больше 800 грн. ");
                if (value > 10000)
                    throw new ArgumentException("Предупреждение: Аренда автомобиля должна быть меньше 10 000 грн. ");

                dailyPrice = value;
            }
        }

        public bool Serialize()
        {
            string jsonstring = "";
            foreach (var item in Auto.Autos)
            {
                jsonstring += JsonSerializer.Serialize<Auto>(item);
                jsonstring += "\n";
            }
            File.WriteAllText("Autos.json", jsonstring);
            return true;
        }

        public bool Deserialize()
        {
            List<string> lines = new List<string>();
            string filePath = "Autos.json";

            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            lines = File.ReadAllLines(filePath).ToList();
            if (lines.Count != 0)
            {
                Auto.Autos.Clear();
                foreach (var item in lines)
                {
                    Auto? car = JsonSerializer.Deserialize<Auto>(item);
                    if (car != null)
                    {
                        autos.Add(car);
                    }
                }
            }
            return true;
        }

        public override string ToString()
        {
            return $"{brand} {model} ({Aclass}, {Atype}, {Acolor})";
        }
    }
}