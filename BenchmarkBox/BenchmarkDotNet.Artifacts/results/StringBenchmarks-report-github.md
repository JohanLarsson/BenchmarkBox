``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 7 SP1 (6.1.7601)
Processor=Intel Xeon CPU E5-2637 v4 3.50GHzIntel Xeon CPU E5-2637 v4 3.50GHz, ProcessorCount=16
Frequency=3410097 Hz, Resolution=293.2468 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2116.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2116.0


```
 |              Method |     Mean |    Error |    StdDev | Scaled | ScaledSD |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
 |-------------------- |---------:|---------:|----------:|-------:|---------:|-------:|-------:|-------:|----------:|
 |              Concat | 165.7 ns | 3.377 ns |  9.414 ns |   1.00 |     0.00 | 0.0405 |      - |      - |     256 B |
 |         Interpolate | 279.4 ns | 5.957 ns | 17.378 ns |   1.69 |     0.14 | 0.0224 |      - |      - |     144 B |
 |       StringBuilder | 179.3 ns | 3.619 ns |  8.458 ns |   1.09 |     0.08 | 0.0520 |      - |      - |     328 B |
 | PooledStringBuilder | 169.8 ns | 3.464 ns |  7.307 ns |   1.03 |     0.07 | 0.0210 | 0.0095 | 0.0002 |     133 B |
