namespace BenchmarkBox
{
    using System.Collections.Concurrent;
    using System.ComponentModel;

    using BenchmarkDotNet.Attributes;

public class PropertyChangedEventArgsBenchmarks
{
    private static readonly PropertyChangedEventArgs Cached = new PropertyChangedEventArgs("Foo");
    private static readonly ConcurrentDictionary<string, PropertyChangedEventArgs> Cache = new ConcurrentDictionary<string, PropertyChangedEventArgs>();

    [Benchmark(Baseline = true)]
    public PropertyChangedEventArgs NewPropertyChangedEventArgs()
    {
        return new PropertyChangedEventArgs("Foo");
    }

    [Benchmark]
    public PropertyChangedEventArgs ReturnCached()
    {
        return Cached;
    }

    [Benchmark]
    public PropertyChangedEventArgs ReturnCachedInDictionary()
    {
        return Cache.GetOrAdd("Foo", x => new PropertyChangedEventArgs(x));
    }

        [Benchmark]
        public object Meh()
        {
            return new ConcurrentDictionary<string, PropertyChangedEventArgs>();
        }
    }
}