namespace BenchmarkBox
{
    using System.Collections.Generic;
    using System.Linq;
    using BenchmarkDotNet.Attributes;

    public class SumBenchmarks
    {
        private static readonly int[] Ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private static readonly IReadOnlyList<int> ReadOnlyInts = Ints;

        [Benchmark]
        public int Linq() => Ints.Sum();

        [Benchmark(Baseline = true)]
        public int For()
        {
            var sum = 0;
            for (var i = 0; i < Ints.Length; i++)
            {
                sum += Ints[i];
            }

            return sum;
        }

        [Benchmark]
        public int ForEach()
        {
            var sum = 0;
            foreach (var i in Ints)
            {
                sum += i;

            }
            return sum;
        }

        [Benchmark]
        public int ForIReadOnlyList()
        {
            var sum = 0;
            for (var i = 0; i < ReadOnlyInts.Count; i++)
            {
                sum += ReadOnlyInts[i];
            }

            return sum;
        }

        [Benchmark]
        public int Checked()
        {
            var sum = 0;
            checked
            {
                for (var i = 0; i < Ints.Length; i++)
                {
                    sum += Ints[i];
                }
            }

            return sum;
        }

        [Benchmark]
        public int Long()
        {
            var sum = 0L;
            for (var i = 0; i < Ints.Length; i++)
            {
                sum += Ints[i];
            }

            return (int)sum;
        }
    }
}
