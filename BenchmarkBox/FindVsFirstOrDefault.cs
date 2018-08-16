namespace BenchmarkBox
{
    using System.Linq;
    using System.Collections.Generic;
    using BenchmarkDotNet.Attributes;

    public class FindVsFirstOrDefault
    {
        private const int N = 9_999;
        private static readonly List<int> Ints = Enumerable.Range(0, 10_000).ToList();

        [Benchmark(Baseline = true)]
        public int Find()
        {
            return Ints.Find(x => x == N);
        }

        [Benchmark]
        public int FirstOrDefault()
        {
            return Ints.FirstOrDefault(x => x == N);
        }
    }
}