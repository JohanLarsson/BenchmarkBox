``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435876 Hz, Resolution=410.5299 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0


```
 |                               Method |      Mean |     Error |    StdDev |    Median | Scaled | ScaledSD | Allocated |
 |------------------------------------- |----------:|----------:|----------:|----------:|-------:|---------:|----------:|
 |                     DictionaryTryGet |  15.21 ns | 0.3452 ns | 0.6311 ns |  14.99 ns |   1.00 |     0.00 |       0 B |
 |                 DictionaryTryGetMiss |  10.67 ns | 0.1653 ns | 0.1380 ns |  10.66 ns |   0.70 |     0.03 |       0 B |
 |                DictionaryContainsGet |  26.03 ns | 0.5493 ns | 0.4870 ns |  25.83 ns |   1.71 |     0.07 |       0 B |
 |               DictionaryContainsMiss |  10.88 ns | 0.4580 ns | 1.3140 ns |  10.86 ns |   0.72 |     0.09 |       0 B |
 | ConcurrentDictionaryDictionaryTryGet |  23.88 ns | 1.7859 ns | 5.2657 ns |  23.84 ns |   1.57 |     0.35 |       0 B |
 |                 DictionaryTryGetLock |  46.83 ns | 2.5635 ns | 7.3964 ns |  43.75 ns |   3.08 |     0.50 |       0 B |
 |                   ConcurrentGetOrAdd |  32.59 ns | 2.1587 ns | 6.3650 ns |  33.60 ns |   2.15 |     0.43 |       0 B |
 |         ConditionalWeakTableGetValue | 107.18 ns | 2.2269 ns | 2.4752 ns | 107.37 ns |   7.06 |     0.32 |       0 B |
