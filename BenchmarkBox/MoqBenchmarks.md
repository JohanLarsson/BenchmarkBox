``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435876 Hz, Resolution=410.5299 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0


```
 |                       Method |        Mean |      Error |     StdDev | Scaled | ScaledSD |   Gen 0 |   Gen 1 | Allocated |
 |----------------------------- |------------:|-----------:|-----------:|-------:|---------:|--------:|--------:|----------:|
 |             SubstituteForFoo |    10.32 us |  0.2227 us |  0.4073 us |   1.00 |     0.00 |  3.1738 |       - |    6.5 KB |
 | SubstituteForFooValueReturns |    23.03 us |  0.3219 us |  0.3011 us |   2.23 |     0.09 |  5.3406 |       - |  10.94 KB |
 |                   MockOfIFoo | 1,099.42 us | 14.7704 us | 12.3339 us | 106.67 |     4.13 | 23.4375 |  7.8125 |  48.64 KB |
 |     MockOfIFooWithExpression | 2,477.31 us | 24.0851 us | 22.5292 us | 240.37 |     9.18 | 35.1563 | 11.7188 |  79.07 KB |
