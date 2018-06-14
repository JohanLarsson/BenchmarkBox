namespace BenchmarkBox
{
    using System;
    using BenchmarkDotNet.Attributes;

public class MethodGroupBenchmarks
{
    private const int N = 1_000_000;

    [Benchmark(Baseline = true)]
    public void Lambda()
    {
        for (var i = 0; i < N; i++)
        {
            Meh(i, x => Id(x));
        }
    }

    [Benchmark]
    public void MethodGroup()
    {
        for (var i = 0; i < N; i++)
        {
            Meh(i, Id);
        }
    }

    private static void Meh(int x, Func<int, int> f) => f(x);

    private static int Id(int x) => x;
}
}
