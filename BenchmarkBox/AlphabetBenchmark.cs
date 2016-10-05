namespace BenchmarkBox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BenchmarkDotNet.Attributes;

    public class AlphabetBenchmark
    {
        private static readonly string Text = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz";

        [Benchmark(Baseline = true)]
        public bool Linq()
        {
            var length = Text.Length;
            return Text.Where(Char.IsLetter)
                .Select(c => (int)Char.ToLower(c))
                .Distinct().Sum() == 2847;
        }

        [Benchmark]
        public bool NewSetCount()
        {
            var set = new HashSet<int>(Text.Where(Char.IsLetter).Select(c => (int)Char.ToLower(c)));
            return set.Count == 26;
        }

        [Benchmark]
        public bool SortedSet()
        {
            var set = new SortedSet<char>(Text.Select(Char.ToLower));
            return set.Min == 'a' && set.Max == 'z' && set.Count == 26;
        }

        [Benchmark]
        public bool Array()
        {
            var ints = new int[26];
            foreach (var c in Text)
            {
                if (!Char.IsLetter(c))
                {
                    continue;
                }
                var i = Char.ToLower(c) % 'a';
                ints[i] = i;
            }

            var sum = 0;
            foreach (var i in ints)
            {
                sum += i;
            }

            return sum == 2847;
        }
    }
}
