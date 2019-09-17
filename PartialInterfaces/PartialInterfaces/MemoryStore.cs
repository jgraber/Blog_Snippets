﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialInterfaces
{
    public partial class MemoryStore : IPersistable
    {
        public void Save(object o)
        {
            Console.WriteLine($"Save was called for {o}");
        }
    }
}
