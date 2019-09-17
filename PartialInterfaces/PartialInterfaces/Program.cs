using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            IPersistable persistable = new MemoryStore();

            persistable.Save("demo");
            persistable.Load(42);
        }
    }
}
