``` ini

BenchmarkDotNet=v0.10.8, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435874 Hz, Resolution=410.5303 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2102.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2102.0


```
 |                                   Method |      Mean |     Error |    StdDev |    Median | Scaled | ScaledSD |  Gen 0 | Allocated |
 |----------------------------------------- |----------:|----------:|----------:|----------:|-------:|---------:|-------:|----------:|
 |                                 Contains |  72.55 ns |  1.499 ns |  1.540 ns |  71.80 ns |   1.00 |     0.00 |      - |       0 B |
 |                   ToLowerContainsToLower | 397.60 ns |  7.992 ns | 19.902 ns | 391.54 ns |   5.48 |     0.29 | 0.0205 |      44 B |
 | ToLowerInvariantContainsToLowerInvariant | 335.17 ns |  7.369 ns | 16.021 ns | 330.35 ns |   4.62 |     0.24 | 0.0205 |      44 B |
 |                           IndexOfOrdinal |  76.66 ns |  2.537 ns |  7.319 ns |  72.93 ns |   1.06 |     0.10 |      - |       0 B |
 |                 IndexOfOrdinalIgnoreCase | 145.33 ns |  2.493 ns |  2.082 ns | 145.13 ns |   2.00 |     0.05 |      - |       0 B |
 |                                  IsMatch | 597.79 ns | 11.714 ns | 18.238 ns | 601.80 ns |   8.24 |     0.30 | 0.0830 |     176 B |
 |                        IsMatchIgnoreCase | 664.44 ns | 13.944 ns | 33.677 ns | 657.29 ns |   9.16 |     0.50 | 0.0830 |     176 B |
