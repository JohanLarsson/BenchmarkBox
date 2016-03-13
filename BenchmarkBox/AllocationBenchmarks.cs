using System.Collections.Concurrent;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace BenchmarkBox
{
    public class AllocationBenchmarks
    {
        [Benchmark]
        public ConcurrentDictionary<int, string> ConcurrentDictionary()
        {
            return new ConcurrentDictionary<int, string>();
        }

        [Benchmark]
        public Dictionary<int, string> Dictionary()
        {
            return new Dictionary<int, string>();
        }

        [Benchmark]
        public List<KeyValuePair<int, string>> List()
        {
            return new List<KeyValuePair<int, string>>();
        }
    }
}