namespace BenchmarkBox
{
    using BenchmarkDotNet.Attributes;

    public class StringInterpolationBenchmarks
    {
        private const int A = 1;
        private const int B = 1;

        [Benchmark(Baseline = true)]
        public string Explicit()
        {
            return $"Title: {A.ToString()} Premiered in: {B.ToString()}";
        }

        [Benchmark]
        public string Implicit()
        {
            return $"Title: {A} Premiered in: {B}";
        }
    }
}