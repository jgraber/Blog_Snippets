using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialInterfaces
{
    interface IPersistable
    {
        void Save(object o);

        void Load(int i);
    }
}
