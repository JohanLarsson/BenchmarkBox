``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17134.590 (1803/April2018Update/Redstone4)
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
Frequency=2835937 Hz, Resolution=352.6171 ns, Timer=TSC
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0


```
|   Method |     Mean |    Error |   StdDev | Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|--------- |---------:|---------:|---------:|------:|--------:|------------:|------------:|------------:|--------------------:|
| Explicit | 143.0 ns | 2.505 ns | 2.344 ns |  1.00 |    0.00 |      0.0684 |           - |           - |               144 B |
| Implicit | 312.7 ns | 6.267 ns | 6.965 ns |  2.19 |    0.06 |      0.0911 |           - |           - |               192 B |
