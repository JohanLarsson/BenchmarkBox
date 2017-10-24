namespace BenchmarkBox
{
    using System.Collections.Generic;
    using System.Linq;
    using BenchmarkDotNet.Attributes;

    public class EnumerableBenchmarks
    {
        private static readonly IEnumerable<int> Source = Enumerable.Range(0, 10).ToArray();

        [Benchmark(Baseline = true)]
        public object ToList()
        {
            return Source.ToList();
        }

        [Benchmark]
        public object ToArray()
        {
            return Source.ToArray();
        }
    }
}
