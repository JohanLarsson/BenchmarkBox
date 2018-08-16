namespace BenchmarkBox
{
    using System;
    using System.Linq;
    using BenchmarkDotNet.Attributes;

    public class PalindromeBenchmarks
    {
        private const string Text = "abcda";

        [Benchmark(Baseline = true)]
        public bool While()
        {
            var i = 0;
            var j = Text.Length - 1;
            while (i <= j)
            {
                if (Text[i] != Text[j])
                {
                    return false;
                }

                i++;
                j--;
            }

            return true;
        }

        [Benchmark]
        public bool Linq() => string.Equals(Text, new string(Text.Reverse().ToArray()), StringComparison.InvariantCultureIgnoreCase);

        [Benchmark]
        public bool For()
        {
            int halfLen = (Text.Length - (Text.Length % 2)) / 2;
            bool matched = true;
            for (int i = 0; i < halfLen && matched; i++)
            {
                matched = Text[i] == Text[Text.Length - (i + 1)];
            }
            return matched;
        }
    }
}