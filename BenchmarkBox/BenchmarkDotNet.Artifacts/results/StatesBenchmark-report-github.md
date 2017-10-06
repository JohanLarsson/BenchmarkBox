``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435868 Hz, Resolution=410.5313 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2110.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2110.0


```
 |                   Method |      Mean |     Error |    StdDev | Scaled | ScaledSD | Allocated |
 |------------------------- |----------:|----------:|----------:|-------:|---------:|----------:|
 |                 SwitchAL |  3.300 ns | 0.0820 ns | 0.0727 ns |   1.00 |     0.00 |       0 B |
 |                 SwitchWY |  2.187 ns | 0.0812 ns | 0.0678 ns |   0.66 |     0.02 |       0 B |
 | DictionaryWithComparerAL | 12.679 ns | 0.3486 ns | 0.3874 ns |   3.84 |     0.14 |       0 B |
 | DictionaryWithComparerWY | 12.818 ns | 0.2721 ns | 0.2412 ns |   3.89 |     0.11 |       0 B |
 |       DictionaryBoxingAL | 12.446 ns | 0.3492 ns | 0.5118 ns |   3.77 |     0.17 |       0 B |
 |       DictionaryBoxingWY | 12.260 ns | 0.3414 ns | 0.3932 ns |   3.72 |     0.14 |       0 B |
