``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 7 SP1 (6.1.7601.0)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
Frequency=3410097 Hz, Resolution=293.2468 ns, Timer=TSC
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2558.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2558.0


```
|           Method |      Mean |     Error |    StdDev |    Median | Scaled | ScaledSD |  Gen 0 | Allocated |
|----------------- |----------:|----------:|----------:|----------:|-------:|---------:|-------:|----------:|
|             Linq | 66.977 ns | 1.6317 ns | 1.6757 ns | 66.110 ns |  17.76 |     0.49 | 0.0050 |      32 B |
|              For |  3.772 ns | 0.0677 ns | 0.0528 ns |  3.764 ns |   1.00 |     0.00 |      - |       0 B |
|          ForEach |  3.887 ns | 0.1153 ns | 0.2356 ns |  3.844 ns |   1.03 |     0.06 |      - |       0 B |
| ForIReadOnlyList | 56.023 ns | 1.1339 ns | 1.7315 ns | 56.293 ns |  14.85 |     0.49 |      - |       0 B |
|          Checked |  5.715 ns | 0.1886 ns | 0.2936 ns |  5.567 ns |   1.52 |     0.08 |      - |       0 B |
|             Long |  5.271 ns | 0.1409 ns | 0.1176 ns |  5.283 ns |   1.40 |     0.04 |      - |       0 B |
