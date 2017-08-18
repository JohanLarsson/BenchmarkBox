namespace BenchmarkBox
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using BenchmarkDotNet.Attributes;

    public class DictionaryVsArrayLookup
    {
        private readonly Dictionary<int, int> dictionary = new Dictionary<int, int>();
        private readonly ConcurrentDictionary<int, int> concurrentDictionary = new ConcurrentDictionary<int, int>();
        private readonly KeyValuePair<int, int>[] array = new KeyValuePair<int, int>[20];

        public DictionaryVsArrayLookup()
        {
            for (var i = 0; i < 20; i++)
            {
                this.dictionary.Add(i, i);
                this.concurrentDictionary.TryAdd(i, i);
                array[i] = new KeyValuePair<int, int>(i, i);
            }
        }

        [Benchmark(Baseline = true)]
        public int DictionaryTryGetValue()
        {
            this.dictionary.TryGetValue(10, out int value);
            return value;
        }

        [Benchmark]
        public int ConcurrentDictionaryTryGetValue()
        {
            this.concurrentDictionary.TryGetValue(10, out int value);
            return value;
        }


        [Benchmark]
        public int ArrayLoop()
        {
            foreach (var kvp in array)
            {
                if (kvp.Key == 10)
                {
                    return kvp.Value;
                }
            }

            return -1;
        }

        [Benchmark]
        public int FirstOrDefault()
        {
            return array.FirstOrDefault(x => x.Key == 10).Value;
        }
    }
}