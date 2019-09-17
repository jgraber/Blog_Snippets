using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialInterfaces
{
    public partial class MemoryStore : IPersistable
    {
        public void Load(int i)
        {
            Console.WriteLine($"Load was called for {i}");
        }
    }
}
