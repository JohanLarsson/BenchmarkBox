``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435868 Hz, Resolution=410.5313 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2110.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2110.0


```
 |       Method |      Mean |     Error |    StdDev | Scaled | ScaledSD | Allocated |
 |------------- |----------:|----------:|----------:|-------:|---------:|----------:|
 |     SwitchAL |  3.354 ns | 0.1497 ns | 0.1400 ns |   1.00 |     0.00 |       0 B |
 |     SwitchWY |  3.186 ns | 0.1035 ns | 0.0864 ns |   0.95 |     0.05 |       0 B |
 | DictionaryAL | 12.715 ns | 0.2038 ns | 0.1806 ns |   3.80 |     0.16 |       0 B |
 | DictionaryWY | 12.021 ns | 0.2062 ns | 0.1929 ns |   3.59 |     0.15 |       0 B |
