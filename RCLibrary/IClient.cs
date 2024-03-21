using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCLibrary
{
    //ToDo #1.1 Интерфейс для клиента. +
    public interface IClient
    {
        bool RentCar(Auto auto);
        bool ReturnCar(Auto auto);
    }
}
