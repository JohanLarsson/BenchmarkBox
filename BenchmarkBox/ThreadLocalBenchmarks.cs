using System.Collections.Generic;

namespace BenchmarkBox
{
    using System.Threading;

    using BenchmarkDotNet.Attributes;

    public class ThreadLocalBenchmarks
    {
        private static readonly ThreadLocal<SortedSet<int>> Set = new ThreadLocal<SortedSet<int>>(()=> new SortedSet<int>());

        public ThreadLocalBenchmarks()
        {
            // forcing creation
            var sortedSet = Set.Value;
        }

        [Benchmark(Baseline = true)]
        public int NewSet()
        {
            var sortedSet = new SortedSet<int>();
            sortedSet.Add(1);
            sortedSet.Add(1);
            sortedSet.Add(2);
            return sortedSet.Count;
        }

        [Benchmark()]
        public int Cached()
        {
            var sortedSet = Set.Value;
            sortedSet.Add(1);
            sortedSet.Add(1);
            sortedSet.Add(2);
            var count = sortedSet.Count;
            sortedSet.Clear();
            return count;
        }
    }
}
