namespace BenchmarkBox
{
    using System;
    using BenchmarkDotNet.Attributes;

public class EnumToStringBenchmarks
{
    [Benchmark(Baseline = true)]
    public new string ToString()
    {
        return StringComparison.OrdinalIgnoreCase.ToString();
    }

    [Benchmark]
    public string EnumGetName()
    {
        return Enum.GetName(typeof(StringComparison), StringComparison.OrdinalIgnoreCase);
    }

    [Benchmark]
    public string SwitchNameof()
    {
        return StringValue(StringComparison.OrdinalIgnoreCase);
    }

    private static string StringValue(StringComparison self)
    {
        switch (self)
        {
            case StringComparison.CurrentCulture:
                return nameof(StringComparison.CurrentCulture);
            case StringComparison.CurrentCultureIgnoreCase:
                return nameof(StringComparison.CurrentCultureIgnoreCase);
            case StringComparison.InvariantCulture:
                return nameof(StringComparison.InvariantCulture);
            case StringComparison.InvariantCultureIgnoreCase:
                return nameof(StringComparison.InvariantCultureIgnoreCase);
            case StringComparison.Ordinal:
                return nameof(StringComparison.Ordinal);
            case StringComparison.OrdinalIgnoreCase:
                return nameof(StringComparison.OrdinalIgnoreCase);
            default:
                throw new ArgumentOutOfRangeException(nameof(self), self, null);
        }
    }
}
}