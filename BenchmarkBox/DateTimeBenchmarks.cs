namespace BenchmarkBox
{
    using System;
    using BenchmarkDotNet.Attributes;

    public class DateTimeBenchmarks
    {
        [Benchmark(Baseline = true)]
        public DateTime Now() => DateTime.Now;

        [Benchmark]
        public DateTime UtcNow() => DateTime.UtcNow;
    }
}