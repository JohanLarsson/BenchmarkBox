namespace BenchmarkBox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BenchmarkDotNet.Attributes;

    public class DistinctByBenchmarks
    {
        private static readonly string[] Source = Enumerable.Range(0, 1000000)
                                                            .Select(x => new string('a', x % 10))
                                                            .ToArray();

        [Benchmark]
        public int ToLookupSelectFirstCount()
        {
            return Source.ToLookup(x => x.Length).Select(x => x.First()).Count();
        }

        [Benchmark(Baseline = true)]
        public int SetAdd()
        {
            return Source.DistinctBy(x => x.Length).Count();
        }
    }

    static class EnumerableExt
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            return source.DistinctByCore(selector);
        }

        private static IEnumerable<TSource> DistinctByCore<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            var set = new HashSet<TKey>();
            foreach (var item in source)
            {
                if (set.Add(selector(item)))
                {
                    yield return item;
                }
            }
        }
    }
}