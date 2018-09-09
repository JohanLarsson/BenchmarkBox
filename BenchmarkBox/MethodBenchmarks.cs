using System;
using System.Drawing.Text;
using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace BenchmarkBox
{
    public class MethodBenchmarks
    {
        private static readonly MethodInfo MethodInfo = typeof(MethodBenchmarks).GetMethod(nameof(Foo), BindingFlags.Static | BindingFlags.NonPublic);

        private static readonly Func<int> Func = (Func<int>)Delegate.CreateDelegate(
            typeof(Func<int>),
            MethodInfo);


        [Benchmark]
        public int InvokeFunc() => Func();

        [Benchmark(Baseline = true)]
        public int MethodInfoInvoke() => (int)MethodInfo.Invoke(null, null);

        [Benchmark]
        public int Call() => Foo();

        [Benchmark]
        public Func<int> CreateDelegate() => (Func<int>) Delegate.CreateDelegate(
            typeof(Func<int>),
            MethodInfo);

        private static int Foo() => 1;
    }
}
