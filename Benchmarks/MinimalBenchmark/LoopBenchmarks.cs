using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace MinimalBenchmark
{
    [DisassemblyDiagnoser]
    public class LoopBenchmarks
    {
        public static readonly List<int> Data = new List<int>{0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

        [Benchmark(Baseline = true)]
        public int For()
        {
            var total = 0;
            for (int i = 0; i < Data.Count; i++)
            {
                total += Data[i];
            }

            return total;
        }

        [Benchmark]
        public int Foreach()
        {
            var total = 0;
            foreach (var value in Data)
            {
                total += value;
            }
            
            return total;
        }

        [Benchmark]
        public int While()
        {
            var total = 0;
            var counter = 0;
            while (counter < Data.Count)
            {
                total += Data[counter];
                counter++;
            }

            return total;
        }

        //[Benchmark]
        //public int Linq()
        //{
        //    return Data.Sum();
        //}
    }
}
