namespace BenchmarkBox
{
    using System.Collections.Concurrent;
    using System.Text;
    using BenchmarkDotNet.Attributes;

    public class StringBenchmarks
    {
        private static readonly string Name = "a";
        private static readonly int Year =2017;
        private static readonly ConcurrentQueue<StringBuilder> Pool = new ConcurrentQueue<StringBuilder>();

        [Benchmark(Baseline = true)]
        public string Concat()
        {
            return "Title: " + Name + " Premiered in: " + Year;
        }

        [Benchmark]
        public string Interpolate()
        {
            return $"Title: {Name} Premiered in: {Year}";
        }

        [Benchmark]
        public string StringBuilder()
        {
            return new StringBuilder().Append("Title: ").Append(Name).Append(" Premiered in: ").Append(Year).ToString();
        }

        [Benchmark]
        public string PooledStringBuilder()
        {
            if (!Pool.TryDequeue(out var builder))
            {
                builder = new StringBuilder();
            }

            var text = builder.Append("Title: ").Append(Name).Append(" Premiered in: ").Append(Year).ToString();
            builder.Clear();
            Pool.Enqueue(builder);
            return text;
        }
    }
}