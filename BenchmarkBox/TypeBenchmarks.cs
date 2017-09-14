namespace BenchmarkBox
{
    using System;
    using BenchmarkDotNet.Attributes;

    public class TypeBenchmarks
    {
        private static readonly Type StaticType = typeof(int);

        [Benchmark(Baseline = true)]
        public Type Typeof()
        {
            return typeof(int);
        }

        [Benchmark]
        public Type IntGetType()
        {
            return 1.GetType();
        }

        [Benchmark]
        public Type StaticField()
        {
            return StaticType;
        }
    }
}