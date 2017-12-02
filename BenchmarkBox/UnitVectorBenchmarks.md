``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 7 SP1 (6.1.7601)
Processor=Intel Xeon CPU E5-2637 v4 3.50GHzIntel Xeon CPU E5-2637 v4 3.50GHz, ProcessorCount=16
Frequency=3410117 Hz, Resolution=293.2451 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2117.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2117.0


```
 |                                 Method |       Mean |     Error |    StdDev | Scaled | ScaledSD | Allocated |
 |--------------------------------------- |-----------:|----------:|----------:|-------:|---------:|----------:|
 |                CreateUnitVectorReturnX |  0.0088 ns | 0.0128 ns | 0.0236 ns |      ? |        ? |       0 B |
 |         CreateCheckedUnitVectorReturnX |  2.7895 ns | 0.1140 ns | 0.3343 ns |      ? |        ? |       0 B |
 | CreateCheckedUnitVectorNullableReturnX | 14.7826 ns | 0.4761 ns | 0.3717 ns |      ? |        ? |       0 B |
 |                                Return1 |  0.1331 ns | 0.0262 ns | 0.0644 ns |      ? |        ? |       0 B |
