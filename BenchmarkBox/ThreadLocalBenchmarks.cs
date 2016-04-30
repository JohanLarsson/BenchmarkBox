using System.Collections.Generic;

using BenchmarkDotNet.Attributes;

namespace BenchmarkBox
{
    using System.Threading;

    using BenchmarkDotNet.Attributes;

    public class ThreadLocalBenchmarks
    {
        private static readonly ThreadLocal<SortedSet<int>> Set =
            new ThreadLocal<SortedSet<int>>(() => new SortedSet<int>());

        public ThreadLocalBenchmarks()
        {
            // forcing creation
            var sortedSet = Set.Value;
        }

        [Benchmark(Baseline = true)]
        public int NewSet()
        {
            var set = new SortedSet<int> { 1, 1, 2 };
            return set.Count;
        }

        [Benchmark]
        public int NewSetAdds()
        {
            var set = new SortedSet<int>();
            set.Clear();
            set.Add(1);
            set.Add(1);
            set.Add(2);
            return set.Count;
        }

        [Benchmark]
        public SortedSet<int> GetValue()
        {
            return Set.Value;
        }

        [Benchmark]
        public int CachedAdds()
        {
            var set = Set.Value;
            set.Add(1);
            set.Add(1);
            set.Add(2);
            var count = set.Count;
            set.Clear();
            return count;
        }
    }
}
