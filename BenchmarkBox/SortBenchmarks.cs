namespace BenchmarkBox
{
    using System.Collections.Generic;
    using System.Linq;
    using BenchmarkDotNet.Attributes;

    public class SortBenchmarks
    {
        private static readonly int[] array = Enumerable.Range(0, 1_000_000).Reverse().ToArray();
        private static readonly List<int> list = array.ToList();

        [Benchmark(Baseline = true)]
        public void Array()
        {
            System.Array.Sort(array);
            System.Array.Sort(array, ReverseComparer.Default);
        }

        [Benchmark]
        public void List()
        {
            list.Sort();
            list.Sort(ReverseComparer.Default);
        }

        private class ReverseComparer : IComparer<int>
        {
            internal static readonly IComparer<int> Default = new ReverseComparer();

            public int Compare(int x, int y) => y.CompareTo(x);
        }
    }
}