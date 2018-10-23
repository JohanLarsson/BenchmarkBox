``` ini

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.17134.345 (1803/April2018Update/Redstone4)
Intel Core i7-7500U CPU 2.70GHz (Max: 0.80GHz) (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
Frequency=2835940 Hz, Resolution=352.6168 ns, Timer=TSC
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3190.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3190.0


```
|                                Method |        Mean |      Error |     StdDev | Scaled | ScaledSD |  Gen 0 | Allocated |
|-------------------------------------- |------------:|-----------:|-----------:|-------:|---------:|-------:|----------:|
|                      StringGetMethods | 2,293.22 ns | 18.5912 ns | 15.5245 ns |  35.53 |     0.38 | 1.2207 |    2568 B |
| StringGetMethodCloneWithFlagsAndTypes |    64.55 ns |  0.6201 ns |  0.5801 ns |   1.00 |     0.00 |      - |       0 B |
|          StringGetMethodCloneNameOnly |    58.40 ns |  0.6856 ns |  0.6413 ns |   0.90 |     0.01 |      - |       0 B |
