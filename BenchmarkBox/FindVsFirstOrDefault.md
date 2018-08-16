``` ini

BenchmarkDotNet=v0.11.0, OS=Windows 10.0.17134.81 (1803/April2018Update/Redstone4)
Intel Xeon CPU E5-2637 v4 3.50GHz (Max: 3.49GHz), 2 CPU, 16 logical and 8 physical cores
Frequency=3410073 Hz, Resolution=293.2489 ns, Timer=TSC
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3110.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3110.0


```
|         Method |     Mean |     Error |    StdDev | Scaled | ScaledSD | Allocated |
|--------------- |---------:|----------:|----------:|-------:|---------:|----------:|
|           Find | 25.38 us | 0.4881 us | 0.5994 us |   1.00 |     0.00 |       0 B |
| FirstOrDefault | 82.67 us | 0.0924 us | 0.0819 us |   3.26 |     0.07 |      41 B |
