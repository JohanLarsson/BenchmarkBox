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


        [Benchmark(Baseline = true)]
        public int InvokeFunc() => Func();

        [Benchmark]
        public int MethodInfoInvoke() => (int)MethodInfo.Invoke(null, null);

        [Benchmark]
        public int Call() => Foo();

        private static int Foo() => 1;
    }
}
