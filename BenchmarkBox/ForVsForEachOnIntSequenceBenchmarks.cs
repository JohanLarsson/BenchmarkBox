using System.Linq;

namespace BenchmarkBox
{
    using BenchmarkDotNet.Attributes;

    public class ForVsForEachOnIntSequenceBenchmarks
    {
        private static int value;

        [Benchmark(Baseline = true)]
        public int For()
        {
            value = 0;
            for(int i = 0; i < 1000000; ++i)
            {
                value += i;
            }
            return value;
        }

        [Benchmark]
        public int ForEach()
        {
            value = 0;
            foreach(var i in Enumerable.Range(0, 1000000))
            {
                value += i;
            }
            return value;
        }
    }
}