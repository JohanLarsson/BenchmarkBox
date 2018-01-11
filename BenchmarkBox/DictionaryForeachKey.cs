using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace BenchmarkBox
{
    static class DeconstructorsDictionaryForeachKey
    {
        public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> kvp, out TKey key, out TValue value)
        {
            key = kvp.Key;
            value = kvp.Value;
        }
    }

    public class DictionaryForeachKey
    {
        private static readonly IDictionary<int, string> stuff = Enumerable.Range(0, 1000000).ToDictionary(x => x, x => x.ToString());
        private static string value;

        [Benchmark]
        public string KeyValuePairDeconstruction()
        {
            foreach(var (k, v) in stuff)
            {
                value = v;
            }

            return value;
        }

        [Benchmark]
        public string KeyCollection()
        {
            foreach(var k in stuff.Keys)
            {
                value = stuff[k];
            }

            return value;
        }

        [Benchmark]
        public string ValueCollection()
        {
            foreach(var v in stuff.Values)
            {
                value = v;
            }

            return value;
        }

        [Benchmark(Baseline = true)]
        public string DirectKeyValuePairAccess()
        {
            foreach(var kvp in stuff)
            {
                value = kvp.Value;
            }

            return value;
        }
    }
}
