``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435876 Hz, Resolution=410.5299 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0


```
 |          Method |     Mean |     Error |    StdDev | Scaled |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
 |---------------- |---------:|----------:|----------:|-------:|---------:|---------:|---------:|----------:|
 | ExtensionMethod | 8.822 ms | 0.1597 ms | 0.1494 ms |   1.00 |        - |        - |        - |     128 B |
 |   ToListForEach | 6.611 ms | 0.0475 ms | 0.0343 ms |   0.75 | 328.1250 | 328.1250 | 328.1250 | 4001545 B |