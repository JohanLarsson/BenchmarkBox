namespace BenchmarkBox
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Runtime.CompilerServices;
    using BenchmarkDotNet.Attributes;

    public class DictionaryBenchmarks
    {
        private static readonly Dictionary<int, int> Dictionary = new Dictionary<int, int>();
        private static readonly ConcurrentDictionary<int, int> Concurrent = new ConcurrentDictionary<int, int>();
        private static readonly ImmutableDictionary<int, int> ImmutableDictionary;
        private static readonly ConditionalWeakTable<string, string> ConditionalWeakTable = new ConditionalWeakTable<string, string>();
        private readonly object gate = new object();

        static DictionaryBenchmarks()
        {
            var builder = System.Collections.Immutable.ImmutableDictionary.CreateBuilder<int, int>();
            for (var i = 0; i < 1000000; i++)
            {
                Dictionary[i] = i;
                Concurrent[i] = i;
                builder[i] = i;
                ConditionalWeakTable.Add(i.ToString(), i.ToString());
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
        public int DictionaryTryGetMiss()
        {
            Dictionary.TryGetValue(-1, out var result);
            return result;
        }

        [Benchmark]
        public int DictionaryContainsGet()
        {
            if (Dictionary.ContainsKey(1))
            {
                return Dictionary[1];
            }

            return 0;
        }

        [Benchmark]
        public bool DictionaryContainsMiss()
        {
            return Dictionary.ContainsKey(-1);
        }

        [Benchmark]
        public int ConcurrentDictionaryTryGet()
        {
            Concurrent.TryGetValue(1, out var result);
            return result;
        }

        [Benchmark]
        public int ImmutableDictionaryTryGet()
        {
            ImmutableDictionary.TryGetValue(1, out var result);
            return result;
        }

        [Benchmark]
        public int DictionaryTryGetLock()
        {
            lock (this.gate)
            {
                Dictionary.TryGetValue(1, out var result);
                return result;
            }
        }

        [Benchmark]
        public int ConcurrentGetOrAdd()
        {
            return Concurrent.GetOrAdd(1, x => x);
        }

        [Benchmark]
        public string ConditionalWeakTableGetValue()
        {
            return ConditionalWeakTable.GetValue("1", x => x);
        }
    }
}
