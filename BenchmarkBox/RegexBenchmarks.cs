namespace BenchmarkBox
{
    using System.Text.RegularExpressions;
    using BenchmarkDotNet.Attributes;

    public class RegexBenchmarks
    {
        private const string Pattern = "^[A-Za-z][A-Za-z0-9]{2,62}$";
        private const string Text = "Abcdefgh9";
        private static readonly Regex Compiled = new Regex(Pattern, RegexOptions.Compiled);
        private static readonly Regex CompiledSingleline = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.Singleline);
        private static readonly Regex Singleline = new Regex(Pattern, RegexOptions.Singleline);
        private static readonly Regex Vanilla = new Regex(Pattern);

        [Benchmark]
        public bool IsMatch()
        {
            return Regex.IsMatch(Text, Pattern);
        }

        [Benchmark(Baseline = true)]
        public bool CompiledIsMatch()
        {
            return Compiled.IsMatch(Text);
        }

        [Benchmark]
        public bool CompiledSinglelineIsMatch()
        {
            return CompiledSingleline.IsMatch(Text);
        }

        [Benchmark]
        public bool SinglelineIsMatch()
        {
            return Singleline.IsMatch(Text);
        }

        [Benchmark]
        public bool VanillaIsMatch()
        {
            return Vanilla.IsMatch(Text);
        }

        [Benchmark]
        public bool NewVanillaIsMatch()
        {
            return new Regex(Pattern).IsMatch(Text);
        }

        [Benchmark]
        public bool NewCompiledIsMatch()
        {
            // yes this is not how it is meant to be.
            return new Regex(Pattern, RegexOptions.Compiled).IsMatch(Text);
        }

        [Benchmark]
        public bool Manual()
        {
            if (Text.Length < 3 || Text.Length > 63)
            {
                return false;
            }

            foreach (var c in Text)
            {
                if ('A' <= c && c <= 'z')
                {
                    continue;
                }

                if ('0' <= c && c <= '9')
                {
                    continue;
                }

                return false;
            }

            return true;
        }
    }
}