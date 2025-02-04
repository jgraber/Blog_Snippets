using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using WebApp.Helper;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class WaitingBenchmark
    {
        private Waste waste = new();

        [Benchmark(Baseline = true)]
        public long Original() => waste.Waiting(500);

        [Benchmark]
        public long Improved() => waste.WaitingNew(500);
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<WaitingBenchmark>();
        }
    }
}