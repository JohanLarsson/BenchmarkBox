``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.17134
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
Frequency=3410071 Hz, Resolution=293.2490 ns, Timer=TSC
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3110.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3110.0


```
| Method |       Mean |     Error |    StdDev | Scaled | ScaledSD |  Gen 0 | Allocated |
|------- |-----------:|----------:|----------:|-------:|---------:|-------:|----------:|
|  While |   1.971 ns | 0.0704 ns | 0.0658 ns |   1.00 |     0.00 |      - |       0 B |
|   Linq | 329.823 ns | 6.4940 ns | 6.6689 ns | 167.50 |     6.39 | 0.0505 |     320 B |
|    For |   3.496 ns | 0.1043 ns | 0.1798 ns |   1.78 |     0.11 |      - |       0 B |
