namespace BenchmarkBox
{
    using System.Collections.Concurrent;
    using System.Text;
    using BenchmarkDotNet.Attributes;

    public class StringBenchmarks
    {
        private static readonly string A = "a";
        private static readonly string B = "b";
        private static readonly ConcurrentQueue<StringBuilder> Pool = new ConcurrentQueue<StringBuilder>();

        [Benchmark(Baseline = true)]
        public string Concat()
        {
            return A + B;
        }

        [Benchmark]
        public string Interpolate()
        {
            return $"{A}{B}";
        }

        [Benchmark]
        public string StringBuilder()
        {
            return new StringBuilder().Append("a").Append("b").ToString();
        }

        [Benchmark]
        public string PooledStringBuilder()
        {
            System.Text.StringBuilder builder;
            if (!Pool.TryDequeue(out builder))
            {
                builder = new StringBuilder();
            }

            var text = builder.Append("a").Append("b").ToString();
            builder.Clear();
            Pool.Enqueue(builder);
            return text;
        }
    }
}