``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10.0.16299
Processor=Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), ProcessorCount=8
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2600.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2600.0


```
 |         Method |     Mean |     Error |    StdDev | Scaled | ScaledSD | Allocated |
 |--------------- |---------:|----------:|----------:|-------:|---------:|----------:|
 |      Interface | 6.051 ms | 0.1168 ms | 0.0975 ms |   1.32 |     0.03 |       0 B |
 |       Concrete | 4.807 ms | 0.0907 ms | 0.0849 ms |   1.05 |     0.03 |       0 B |
 | SealedConcrete | 4.578 ms | 0.0891 ms | 0.0875 ms |   1.00 |     0.00 |       0 B |
