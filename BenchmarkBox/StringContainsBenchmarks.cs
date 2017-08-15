namespace BenchmarkBox
{
    using System;
    using System.Text.RegularExpressions;
    using BenchmarkDotNet.Attributes;

    public class StringContainsBenchmarks
    {
        private static readonly string A = "aBcd";
        private static readonly string B = "Bc";

        [Benchmark(Baseline = true)]
        public bool Contains()
        {
            return A.Contains(B);
        }

        [Benchmark]
        public bool ToLowerContainsToLower()
        {
            return A.ToLower().Contains(B.ToLower());
        }

        [Benchmark]
        public bool ToLowerInvariantContainsToLowerInvariant()
        {
            return A.ToLowerInvariant().Contains(B.ToLowerInvariant());
        }

        [Benchmark]
        public bool IndexOfOrdinal()
        {
            return A.IndexOf(B, StringComparison.Ordinal) != -1;
        }

        [Benchmark]
        public bool IndexOfOrdinalIgnoreCase()
        {
            return A.IndexOf(B, StringComparison.OrdinalIgnoreCase) != -1;
        }

        [Benchmark]
        public bool IsMatch()
        {
            return System.Text.RegularExpressions.Regex.IsMatch(A, B);
        }

        [Benchmark]
        public bool IsMatchIgnoreCase()
        {
            return System.Text.RegularExpressions.Regex.IsMatch(A, B, RegexOptions.IgnoreCase);
        }
    }
}