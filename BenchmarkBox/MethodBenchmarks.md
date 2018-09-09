``` ini

BenchmarkDotNet=v0.11.0, OS=Windows 10.0.17134.254 (1803/April2018Update/Redstone4)
Intel Core i7-7500U CPU 2.70GHz (Max: 0.80GHz) (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
Frequency=2835943 Hz, Resolution=352.6164 ns, Timer=TSC
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3163.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3163.0


```
|           Method |        Mean |     Error |    StdDev | Scaled | ScaledSD |  Gen 0 | Allocated |
|----------------- |------------:|----------:|----------:|-------:|---------:|-------:|----------:|
|       InvokeFunc |   1.5627 ns | 0.0460 ns | 0.0430 ns |   1.00 |     0.00 |      - |       0 B |
| MethodInfoInvoke | 127.1398 ns | 2.5701 ns | 3.1563 ns |  81.42 |     2.93 | 0.0112 |      24 B |
|             Call |   0.0251 ns | 0.0256 ns | 0.0240 ns |   0.02 |     0.01 |      - |       0 B |
