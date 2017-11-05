namespace BenchmarkBox
{
    using System.Linq;
    using BenchmarkDotNet.Attributes;

    public class DistinctByBenchmarks
    {
        private static readonly string[] Source = Enumerable.Range(0, 1000000)
                                                            .Select(x => new string('a', x % 10))
                                                            .ToArray();

        [Benchmark]
        public int ToLookupSelectFirstCount()
        {
            return Source.ToLookup(x => x.Length).Select(x => x.First()).Count();
        }

        [Benchmark(Baseline = true)]
        public int SetAdd()
        {
            return Source.DistinctBy(x => x.Length).Count();
        }
    }
}