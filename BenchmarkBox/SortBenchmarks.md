``` ini

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.17134.407 (1803/April2018Update/Redstone4)
Intel Core i7-7500U CPU 2.70GHz (Max: 0.80GHz) (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
Frequency=2835939 Hz, Resolution=352.6169 ns, Timer=TSC
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3221.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3221.0


```
| Method |     Mean |    Error |   StdDev | Scaled | ScaledSD | Allocated |
|------- |---------:|---------:|---------:|-------:|---------:|----------:|
|  Array | 96.91 ms | 2.046 ms | 5.355 ms |   1.00 |     0.00 |       0 B |
|   List | 97.08 ms | 1.914 ms | 2.745 ms |   1.00 |     0.06 |       0 B |
