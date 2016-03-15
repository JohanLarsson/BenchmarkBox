using BenchmarkDotNet.Attributes;

namespace BenchmarkBox
{
    public class EqualsBenchmarks
    {
        [Benchmark(Baseline = true)]
        public bool IsCastEquals()
        {
            return IsCastEquals(true);
        }

        [Benchmark]
        public bool ObjectEquals()
        {
            return ObjectEquals(true);
        }

        private static bool IsCastEquals(object value)
        {
            if (value is bool)
            {
                return (bool) value;
            }

            return false;
        }

        private static bool ObjectEquals(object value)
        {
            if (value is bool)
            {
                return Equals(value, true);
            }

            return false;
        }
    }
}
