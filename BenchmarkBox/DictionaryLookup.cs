namespace BenchmarkBox
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    using BenchmarkDotNet.Attributes;

    public class DictionaryLookup
    {
        private readonly Dictionary<int, int> dictionary = new Dictionary<int, int>();
        private readonly ConcurrentDictionary<int, int> concurrentDictionary = new ConcurrentDictionary<int, int>();
        public DictionaryLookup()
        {
            for (int i = 0; i < 1000; i++)
            {
                this.dictionary.Add(i, i);
                this.concurrentDictionary.TryAdd(i, i);
            }
        }

        [Benchmark(Baseline = true)]
        public int DictionaryTryGetValue()
        {
            int value;
            this.dictionary.TryGetValue(234, out value);
            return value;
        }

        [Benchmark]
        public int ConcurrentDictionaryTryGetValue()
        {
            int value;
            this.concurrentDictionary.TryGetValue(234, out value);
            return value;
        }

        [Benchmark]
        public int ConcurrentDictionaryGetOrAdd()
        {
            return this.concurrentDictionary.GetOrAdd(234, x => x);
        }

        [Benchmark]
        public int ConcurrentDictionaryGetOrAddNamedMethod()
        {
            return this.concurrentDictionary.GetOrAdd(234, CreateValue);
        }

        private static int CreateValue(int arg)
        {
            return arg;
        }
    }
}
