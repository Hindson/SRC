using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCLibrary
{
    //ToDo #1.3 Интерфейс для администратора. +
    public interface IAdministrator : IManager
    {
        bool AddManager(Manager manager);
        bool RemoveManager(int value);

        bool AddAdmin(Administrator administrator);
        bool RemoveAdmin(int value);
    }
}
