``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435883 Hz, Resolution=410.5287 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2110.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2110.0


```
 |                   Method |     Mean |     Error |    StdDev | Scaled | ScaledSD |    Gen 0 |    Gen 1 |    Gen 2 |   Allocated |
 |------------------------- |---------:|----------:|----------:|-------:|---------:|---------:|---------:|---------:|------------:|
 | ToLookupSelectFirstCount | 45.80 ms | 0.9091 ms | 0.9727 ms |   1.81 |     0.04 | 876.8750 | 811.2500 | 626.8750 | 20489.84 KB |
 |                   SetAdd | 25.34 ms | 0.2800 ms | 0.2619 ms |   1.00 |     0.00 |        - |        - |        - |        1 KB |
