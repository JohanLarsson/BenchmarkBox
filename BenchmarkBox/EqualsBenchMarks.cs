using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace BenchmarkBox
{
public class EqualsBenchmarks
{
    [Benchmark(Baseline = true)]
    public bool Equals()
    {
        return 1.Equals(2);
    }

    [Benchmark]
    public bool OperatorEquals()
    {
        return 1 == 2;
    }

    [Benchmark]
    public bool ObjectEquals()
    {
        return Equals(1, 2);
    }

    [Benchmark]
    public bool EqualityComparerDefaultEquals()
    {
        return EqualityComparer<int>.Default.Equals(1, 2);
    }
}
}
