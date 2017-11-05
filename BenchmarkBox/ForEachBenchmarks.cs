namespace BenchmarkBox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BenchmarkDotNet.Attributes;

    public class ForEachBenchmarks
    {
        private static readonly int[] Ints = Enumerable.Range(0, 1000000).ToArray();
        private static int value;

        [Benchmark(Baseline = true)]
        public int ExtensionMethod()
        {
            Ints.ForEach(x => value = x);
            return value;
        }

        [Benchmark]
        public int ToListForEach()
        {
            Ints.ToList().ForEach(x => value = x);
            return value;
        }
    }
}