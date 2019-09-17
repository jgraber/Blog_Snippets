using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialInterfaces
{
    partial interface IPersistable
    {
        void Load(int i);
    }
}
