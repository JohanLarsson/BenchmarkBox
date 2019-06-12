namespace BenchmarkBox
{
    using System.Collections.Generic;
    using System.Linq;
    using BenchmarkDotNet.Attributes;

    public class InterfaceBenchmarks
    {
        private static readonly int[] Array = Enumerable.Range(0, 1000).ToArray();
        private static readonly IReadOnlyList<int> IReadOnlyList = Array;

        [Benchmark(Baseline = true)]
        public int LoopArray()
        {
            var sum = 0;
            for (var i = 0; i < Array.Length; i++)
            {
                sum += Array[i];
            }

            return sum;
        }

        [Benchmark]
        public int LoopIReadOnlyList()
        {
            var sum = 0;
            for (var i = 0; i < IReadOnlyList.Count; i++)
            {
                sum += IReadOnlyList[i];
            }

            return sum;
        }
    }
}
