namespace BenchmarkBox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;

    using BenchmarkDotNet.Attributes;

    public class ParseBenchmarks
    {
        private const string Text = "First: {0:N}, Second: {1}";

        [Benchmark]
        public int Optimized()
        {
            int count;
            bool? any;
            FormatString.IsValidFormat(Text, out count, out any);
            return count;
        }

        [Benchmark(Baseline = true)]
        public int Regex()
        {
            var indices = FormatString.GetFormatIndices(Text);
            return FormatString.CountUnique(indices);
        }

        internal static class FormatString
        {
            private static readonly IReadOnlyList<string> Empty = new string[0];
            private static readonly ThreadLocal<SortedSet<int>> Indices = new ThreadLocal<SortedSet<int>>(() => new SortedSet<int>());

            internal static bool IsValidFormat(string text, out int count, out bool? anyItemHasFormat)
            {
                int pos = 0;
                anyItemHasFormat = false;
                var indices = Indices.Value;
                indices.Clear();
                while (TrySkipTo(text, '{', ref pos))
                {
                    int index;
                    bool? itemHasFormat;
                    if (!TryParseItemFormat(text, ref pos, out index, out itemHasFormat))
                    {
                        count = -1;
                        anyItemHasFormat = null;
                        return false;
                    }

                    anyItemHasFormat |= itemHasFormat;
                    indices.Add(index);
                }

                if (indices.Min == 0 && indices.Max == indices.Count - 1)
                {
                    count = indices.Count;
                    return true;
                }

                count = -1;
                return false;
            }

            /// <summary>Call with "first: {0}, second {1} returns new []{"0", "1"};</summary>
            /// <param name="format">The format string</param>
            /// <returns>An unordered list of format items found in <paramref name="format"/></returns>
            internal static IReadOnlyCollection<string> GetFormatIndices(string format)
            {
                if (string.IsNullOrEmpty(format))
                {
                    return Empty;
                }

                var matches = System.Text.RegularExpressions.Regex.Matches(format, @"{(?<index>\d+)([^}]+)?}", RegexOptions.ExplicitCapture);
                var items = matches.Cast<Match>()
                                   .Select(x => x.Groups["index"].Value)
                                   .ToList();
                return items;
            }

            internal static int CountUnique(IReadOnlyCollection<string> items)
            {
                if (items.Count == 0)
                {
                    return 0;
                }

                var indexes = Indices.Value;
                indexes.Clear();

                foreach (var item in items)
                {
                    int index;
                    if (!int.TryParse(item, out index))
                    {
                        throw new InvalidOperationException($"Format item is not an int: {item}");
                    }

                    indexes.Add(index);
                }

                return indexes.Count;
            }

            /// <summary>Checks that <paramref name="items"/> are 0..1..n.</summary>
            /// <param name="items">The format items.</param>
            /// <returns>True if <paramref name="items"/> are 0..1..n.</returns>
            internal static bool AreItemsValid(IReadOnlyCollection<string> items)
            {
                if (items.Count == 0)
                {
                    return true;
                }

                var indexes = Indices.Value;
                indexes.Clear();

                foreach (var item in items)
                {
                    int index;
                    if (!int.TryParse(item, out index))
                    {
                        return false;
                    }

                    if (index < 0 || index >= items.Count)
                    {
                        return false;
                    }

                    indexes.Add(index);
                }

                return indexes.Min == 0 && indexes.Max == indexes.Count - 1;
            }

            private static bool TrySkipTo(string text, char c, ref int pos)
            {
                while (pos < text.Length && text[pos] != c)
                {
                    pos++;
                }

                return pos < text.Length && text[pos] == c;
            }

            private static bool TryParseItemFormat(string text, ref int pos, out int index, out bool? itemHasFormat)
            {
                if (text[pos] != '{')
                {
                    index = -1;
                    itemHasFormat = null;
                    return false;
                }

                pos++;
                if (!TryParseUnsignedInt(text, ref pos, out index))
                {
                    itemHasFormat = null;
                    return false;
                }

                if (!TryParseFormatSuffix(text, ref pos, out itemHasFormat) || !TrySkipTo(text, '}', ref pos))
                {
                    index = -1;
                    itemHasFormat = null;
                    return false;
                }

                pos++;
                return true;
            }

            private static bool TryParseFormatSuffix(string text, ref int pos, out bool? itemHasFormat)
            {
                if (text[pos] == '}')
                {
                    itemHasFormat = false;
                    return true;
                }

                if (text[pos] != ':')
                {
                    itemHasFormat = null;
                    return false;
                }

                if (pos < text.Length - 1 && text[pos + 1] == '}')
                {
                    itemHasFormat = null;
                    return false;
                }

                pos++;
                if (!TrySkipTo(text, '}', ref pos))
                {
                    itemHasFormat = null;
                    return false;
                }

                itemHasFormat = true;
                return true;
            }

            private static bool TryParseUnsignedInt(string text, ref int pos, out int result)
            {
                result = -1;
                while (pos < text.Length)
                {
                    var i = text[pos] - '0';
                    if (i < 0 || i > 9)
                    {
                        return result != -1;
                    }

                    if (result == -1)
                    {
                        result = i;
                    }
                    else
                    {
                        result *= 10;
                        result += i;
                    }

                    pos++;
                }

                return result != -1;
            }
        }
    }
}