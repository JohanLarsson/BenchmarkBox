namespace BenchmarkBox
{
    using System;
    using System.Collections.Generic;

    internal static class EnumerableExt
    {
        internal static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }

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