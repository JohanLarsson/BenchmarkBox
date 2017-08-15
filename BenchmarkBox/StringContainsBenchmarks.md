``` ini

BenchmarkDotNet=v0.10.8, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435874 Hz, Resolution=410.5303 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2102.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2102.0


```
 |                                   Method |      Mean |     Error |    StdDev | Scaled | ScaledSD |  Gen 0 | Allocated |
 |----------------------------------------- |----------:|----------:|----------:|-------:|---------:|-------:|----------:|
 |                                 Contains |  70.70 ns | 1.3519 ns | 1.2645 ns |   1.00 |     0.00 |      - |       0 B |
 |                   ToLowerContainsToLower | 326.50 ns | 3.8655 ns | 3.4267 ns |   4.62 |     0.09 | 0.0205 |      44 B |
 | ToLowerInvariantContainsToLowerInvariant | 315.07 ns | 3.1498 ns | 2.9464 ns |   4.46 |     0.09 | 0.0205 |      44 B |
 |                           IndexOfOrdinal |  70.79 ns | 0.5184 ns | 0.4596 ns |   1.00 |     0.02 |      - |       0 B |
 |                 IndexOfOrdinalIgnoreCase | 192.91 ns | 2.1124 ns | 1.9760 ns |   2.73 |     0.05 |      - |       0 B |
