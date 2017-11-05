``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435876 Hz, Resolution=410.5299 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0


```
 |          Method |     Mean |     Error |    StdDev | Scaled | ScaledSD |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
 |---------------- |---------:|----------:|----------:|-------:|---------:|---------:|---------:|---------:|----------:|
 | ExtensionMethod | 4.770 ms | 0.0910 ms | 0.0851 ms |   1.00 |     0.00 |        - |        - |        - |       0 B |
 |   ToListForEach | 6.482 ms | 0.0425 ms | 0.0377 ms |   1.36 |     0.02 | 329.1667 | 329.1667 | 329.1667 | 4001547 B |
 |     ListForEach | 4.649 ms | 0.0353 ms | 0.0330 ms |   0.97 |     0.02 |        - |        - |        - |       0 B |
