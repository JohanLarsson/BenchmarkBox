``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10.0.16299
Processor=Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), ProcessorCount=8
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2600.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2600.0


```
 |  Method |     Mean |     Error |    StdDev | Scaled | ScaledSD | Allocated |
 |-------- |---------:|----------:|----------:|-------:|---------:|----------:|
 |     For | 1.195 ms | 0.0013 ms | 0.0011 ms |   1.00 |     0.00 |       0 B |
 | ForEach | 3.624 ms | 0.0333 ms | 0.0311 ms |   3.03 |     0.03 |      64 B |
