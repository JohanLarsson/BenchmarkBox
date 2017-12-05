``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 7 SP1 (6.1.7601)
Processor=Intel Xeon CPU E5-2637 v4 3.50GHzIntel Xeon CPU E5-2637 v4 3.50GHz, ProcessorCount=16
Frequency=3410117 Hz, Resolution=293.2451 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2117.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2117.0


```
 |                                 Method |       Mean |     Error |    StdDev |     Median | Scaled | ScaledSD | Allocated |
 |--------------------------------------- |-----------:|----------:|----------:|-----------:|-------:|---------:|----------:|
 |                CreateUnitVectorReturnX |  1.6905 ns | 0.0834 ns | 0.0960 ns |  1.6328 ns |   1.00 |     0.00 |       0 B |
 |         CreateCheckedUnitVectorReturnX |  9.1679 ns | 0.2173 ns | 0.2134 ns |  9.1276 ns |   5.44 |     0.31 |       0 B |
 | CreateCheckedUnitVectorNullableReturnX | 14.2711 ns | 0.3215 ns | 0.7387 ns | 14.2982 ns |   8.47 |     0.62 |       0 B |
 |                                Return1 |  0.0372 ns | 0.0227 ns | 0.0494 ns |  0.0000 ns |   0.02 |     0.03 |       0 B |
