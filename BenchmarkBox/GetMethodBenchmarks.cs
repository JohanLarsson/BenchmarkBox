namespace BenchmarkBox
{
    using System;
    using System.Reflection;
    using BenchmarkDotNet.Attributes;

    public class GetMethodBenchmarks
    {
        [Benchmark]
        public object StringGetMethods() => typeof(string).GetMethods();

        [Benchmark(Baseline = true)]
        public MethodInfo StringGetMethodCloneWithFlagsAndTypes() => typeof(string).GetMethod(nameof(string.Clone), BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly, null, Type.EmptyTypes, null);

        [Benchmark]
        public MethodInfo StringGetMethodCloneNameOnly() => typeof(string).GetMethod(nameof(string.Clone));
    }
}
