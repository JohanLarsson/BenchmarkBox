``` ini

BenchmarkDotNet=v0.11.0, OS=Windows 10.0.17134.254 (1803/April2018Update/Redstone4)
Intel Core i7-7500U CPU 2.70GHz (Max: 0.80GHz) (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
Frequency=2835943 Hz, Resolution=352.6164 ns, Timer=TSC
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3163.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3163.0


```
|           Method |          Mean |      Error |     StdDev |        Median | Scaled | ScaledSD |  Gen 0 | Allocated |
|----------------- |--------------:|-----------:|-----------:|--------------:|-------:|---------:|-------:|----------:|
|       InvokeFunc |     2.1685 ns |  0.2533 ns |  0.7308 ns |     1.9227 ns |  0.015 |     0.01 |      - |       0 B |
| MethodInfoInvoke |   150.0299 ns |  5.0556 ns | 14.4239 ns |   144.2799 ns |  1.000 |     0.00 | 0.0110 |      24 B |
|             Call |     0.0246 ns |  0.0214 ns |  0.0610 ns |     0.0000 ns |  0.000 |     0.00 |      - |       0 B |
|   CreateDelegate | 1,933.6295 ns | 38.7080 ns | 36.2075 ns | 1,931.5445 ns | 12.998 |     1.18 | 0.0267 |      64 B |
