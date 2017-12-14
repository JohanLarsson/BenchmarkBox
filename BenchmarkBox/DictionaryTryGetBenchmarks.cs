namespace BenchmarkBox
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using BenchmarkDotNet.Attributes;

    public class DictionaryTryGetBenchmarks
    {
        private static readonly Dictionary<int, int> Dictionary = new Dictionary<int, int>();
        private static readonly ConcurrentDictionary<int, int> ConcurrentDictionary = new ConcurrentDictionary<int, int>();
        private static readonly ImmutableDictionary<int, int> ImmutableDictionary;

        static DictionaryTryGetBenchmarks()
        {
            var builder = System.Collections.Immutable.ImmutableDictionary.CreateBuilder<int, int>();
            for (var i = 0; i < 1000000; i++)
            {
                Dictionary[i] = i;
                ConcurrentDictionary[i] = i;
                builder[i] = i;
            }

            ImmutableDictionary = builder.ToImmutable();
        }

        [Benchmark(Baseline = true)]
        public int DictionaryTryGet()
        {
            Dictionary.TryGetValue(1, out var result);
            return result;
        }

        [Benchmark]
        public int ConcurrentDictionaryTryGet()
        {
            ConcurrentDictionary.TryGetValue(1, out var result);
            return result;
        }

        [Benchmark]
        public int ImmutableDictionaryTryGet()
        {
            ImmutableDictionary.TryGetValue(1, out var result);
            return result;
        }
    }
}