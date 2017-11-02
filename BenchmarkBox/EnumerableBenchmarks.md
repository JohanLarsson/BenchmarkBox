``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 7 SP1 (6.1.7601)
Processor=Intel Xeon CPU E5-2637 v4 3.50GHzIntel Xeon CPU E5-2637 v4 3.50GHz, ProcessorCount=16
Frequency=3410097 Hz, Resolution=293.2468 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2116.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2116.0


```
 |  Method |     Mean |    Error |   StdDev | Scaled | ScaledSD |  Gen 0 | Allocated |
 |-------- |---------:|---------:|---------:|-------:|---------:|-------:|----------:|
 |  ToList | 81.23 ns | 1.687 ns | 4.867 ns |   1.00 |     0.00 | 0.0165 |     104 B |
 | ToArray | 85.87 ns | 1.967 ns | 5.676 ns |   1.06 |     0.09 | 0.0101 |      64 B |
