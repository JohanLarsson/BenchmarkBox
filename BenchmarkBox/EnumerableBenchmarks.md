``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435876 Hz, Resolution=410.5299 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0


```
 |  Method |      Mean |    Error |   StdDev |    Median | Scaled | ScaledSD |  Gen 0 | Allocated |
 |-------- |----------:|---------:|---------:|----------:|-------:|---------:|-------:|----------:|
 |  ToList |  98.74 ns | 1.432 ns | 1.340 ns |  98.93 ns |   1.00 |     0.00 | 0.0495 |     104 B |
 | ToArray | 112.59 ns | 2.788 ns | 6.236 ns | 110.20 ns |   1.14 |     0.06 | 0.0304 |      64 B |
