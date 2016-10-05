namespace BenchmarkBox
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using BenchmarkDotNet.Attributes;

    public class DictionaryBenchmarks
    {
        private static readonly Dictionary<int, int> dictionary = new Dictionary<int, int>();
        private static readonly ConcurrentDictionary<int, int> concurrent = new ConcurrentDictionary<int, int>();
        private readonly object gate = new object();

        static DictionaryBenchmarks()
        {
            for (int i = 0; i < 1000000; i++)
            {
                dictionary[i] = i;
                concurrent[i] = i;
            }
        }

        [Benchmark(Baseline = true)]
        public int DictionaryTryGet()
        {
            int result;
            dictionary.TryGetValue(1, out result);
            return result;
        }

        [Benchmark]
        public int DictionaryTryGetLock()
        {
            lock (this.gate)
            {
                int result;
                dictionary.TryGetValue(1, out result);
                return result;
            }
        }

        [Benchmark]
        public int ConcurrentGetOrAdd()
        {
            return concurrent.GetOrAdd(1, x => x);
        }
    }
}
