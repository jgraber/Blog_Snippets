using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace MinimalBenchmark
{
    [MemoryDiagnoser]
    public class VariableImpact
    {
        [Benchmark(Baseline = true)]
        public int Direct()
        {
            return GetNumbers().Length;
        }

        [Benchmark]
        public int ViaVariable()
        {
            var numbers = GetNumbers();
            return numbers.Length;
        }

        private int[] GetNumbers()
        {
            return [1, 2, 3, 4, 5, 6, 7, 8, 9];
        }
    }
}
