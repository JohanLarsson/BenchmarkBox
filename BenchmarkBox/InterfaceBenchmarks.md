``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17134.765 (1803/April2018Update/Redstone4)
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
Frequency=2835939 Hz, Resolution=352.6169 ns, Timer=TSC
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0


```
|            Method |       Mean |     Error |    StdDev | Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|------------------ |-----------:|----------:|----------:|------:|--------:|------------:|------------:|------------:|--------------------:|
|         LoopArray |   589.0 ns |  13.65 ns |  18.69 ns |  1.00 |    0.00 |           - |           - |           - |                   - |
| LoopIReadOnlyList | 5,313.3 ns | 105.75 ns | 108.60 ns |  8.94 |    0.33 |           - |           - |           - |                   - |
