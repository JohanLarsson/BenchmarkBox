``` ini

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.17134.407 (1803/April2018Update/Redstone4)
Intel Core i7-7500U CPU 2.70GHz (Max: 0.80GHz) (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
Frequency=2835939 Hz, Resolution=352.6169 ns, Timer=TSC
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3221.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3221.0


```
| Method |     Mean |    Error |   StdDev | Scaled | ScaledSD | Allocated |
|------- |---------:|---------:|---------:|-------:|---------:|----------:|
|  Array | 90.71 ms | 1.460 ms | 1.365 ms |   1.00 |     0.00 |       0 B |
|   List | 87.90 ms | 2.037 ms | 1.806 ms |   0.97 |     0.02 |       0 B |
