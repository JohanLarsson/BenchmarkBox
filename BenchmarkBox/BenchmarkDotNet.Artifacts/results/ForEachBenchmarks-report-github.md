``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435876 Hz, Resolution=410.5299 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0


```
 |          Method |      Mean |     Error |    StdDev | Scaled |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
 |---------------- |----------:|----------:|----------:|-------:|---------:|---------:|---------:|----------:|
 | ExtensionMethod | 10.842 ms | 0.1299 ms | 0.1085 ms |   1.00 |        - |        - |        - |     128 B |
 |   ToListForEach |  6.559 ms | 0.0482 ms | 0.0451 ms |   0.61 | 328.1250 | 328.1250 | 328.1250 | 4001550 B |
 |     ListForEach |  4.692 ms | 0.0243 ms | 0.0216 ms |   0.43 |        - |        - |        - |       0 B |
