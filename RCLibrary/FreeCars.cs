using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCLibrary
{
    //ToDo #2.6 Класс свободных автомобилей +
    public class FreeCars : Auto
    {
        private static List<Auto> availableCars = new List<Auto>();
        public static List<Auto> AvailableCar {  get { return availableCars; } }

        public List<Auto> AvailableCars(DateTime startDate, DateTime endDate)
        {
            availableCars.Clear();
            foreach (Auto? car in Auto.Autos)
            {
                // Проверяем, что у автомобиля нет договоров на указанную дату
                if (!Contract.Contracts.Exists(c => c.Car.Id == car.Id && startDate <= c.EndDate && endDate >= c.StartDate))
                {
                    availableCars.Add(car);
                }
            }
            return availableCars;
        }
    }
}
