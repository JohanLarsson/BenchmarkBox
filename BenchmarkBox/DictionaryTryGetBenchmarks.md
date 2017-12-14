``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435878 Hz, Resolution=410.5296 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0


```
 |                     Method |     Mean |     Error |    StdDev |   Median | Scaled | ScaledSD | Allocated |
 |--------------------------- |---------:|----------:|----------:|---------:|-------:|---------:|----------:|
 |           DictionaryTryGet | 13.89 ns | 0.3460 ns | 0.8019 ns | 13.61 ns |   1.00 |     0.00 |       0 B |
 | ConcurrentDictionaryTryGet | 16.62 ns | 0.3506 ns | 0.3279 ns | 16.56 ns |   1.20 |     0.07 |       0 B |
 |  ImmutableDictionaryTryGet | 74.48 ns | 0.6615 ns | 0.5165 ns | 74.50 ns |   5.38 |     0.29 |       0 B |
