using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCLibrary
{
    //ToDo #1.2 Интерфейс для менеджера. +
    public interface IManager
    {
        bool AddCar(Auto car);
        bool RemoveCar(int value);
        bool AddClient(Client client);
        bool RemoveClient(int value);

        bool AddContract(Contract newContract);
        bool RemoveContract(int value);
    }
}
