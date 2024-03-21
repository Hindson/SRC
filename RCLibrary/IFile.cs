using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCLibrary
{
    //ToDo #1.4 Интерфейс для сериализации и десериализации объектов +
    public interface IFile
    {
        bool Serialize();
        bool Deserialize();
    }
}
