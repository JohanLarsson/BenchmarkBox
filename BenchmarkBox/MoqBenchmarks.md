``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 7 SP1 (6.1.7601)
Processor=Intel Xeon CPU E5-2637 v4 3.50GHzIntel Xeon CPU E5-2637 v4 3.50GHz, ProcessorCount=16
Frequency=3410097 Hz, Resolution=293.2468 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2116.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2116.0


```
 |                   Method |             Mean |          Error |          StdDev |     Scaled |  ScaledSD |   Gen 0 |  Gen 1 | Allocated |
 |------------------------- |-----------------:|---------------:|----------------:|-----------:|----------:|--------:|-------:|----------:|
 |                   NewFoo |         3.560 ns |      0.1500 ns |       0.4254 ns |       1.00 |      0.00 |  0.0038 |      - |      24 B |
 |               MockOfIFoo | 1,136,309.451 ns | 31,751.9711 ns |  93,621.4032 ns | 323,663.61 | 46,408.86 |  5.8594 | 1.9531 |   51458 B |
 | MockOfIFooWithExpression | 2,460,603.594 ns | 61,109.8930 ns | 178,260.4262 ns | 700,872.33 | 96,641.84 | 11.7188 | 3.9063 |   82529 B |
