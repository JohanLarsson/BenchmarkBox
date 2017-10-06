``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435868 Hz, Resolution=410.5313 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2110.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2110.0


```
 |                   Method |      Mean |     Error |    StdDev |    Median | Scaled | ScaledSD | Allocated |
 |------------------------- |----------:|----------:|----------:|----------:|-------:|---------:|----------:|
 |                 SwitchAL |  3.218 ns | 0.1117 ns | 0.1045 ns |  3.211 ns |   1.00 |     0.00 |       0 B |
 |                 SwitchWY |  2.432 ns | 0.0521 ns | 0.0488 ns |  2.444 ns |   0.76 |     0.03 |       0 B |
 | DictionaryWithComparerAL | 12.982 ns | 0.3168 ns | 0.2963 ns | 13.127 ns |   4.04 |     0.15 |       0 B |
 | DictionaryWithComparerWY | 14.132 ns | 0.6164 ns | 1.8079 ns | 13.308 ns |   4.40 |     0.58 |       0 B |
 |       DictionaryBoxingAL | 12.246 ns | 0.1772 ns | 0.1383 ns | 12.281 ns |   3.81 |     0.13 |       0 B |
 |       DictionaryBoxingWY | 13.384 ns | 0.3629 ns | 0.6544 ns | 13.162 ns |   4.16 |     0.24 |       0 B |
 |       DictionaryStringAL | 29.169 ns | 0.4246 ns | 0.3972 ns | 29.242 ns |   9.07 |     0.31 |       0 B |
 |      DictionaryStringrWY | 28.865 ns | 0.3348 ns | 0.2968 ns | 28.877 ns |   8.98 |     0.29 |       0 B |
