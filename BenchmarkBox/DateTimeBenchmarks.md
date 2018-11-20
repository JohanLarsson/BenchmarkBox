``` ini

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.17134.407 (1803/April2018Update/Redstone4)
Intel Core i7-7500U CPU 2.70GHz (Max: 0.80GHz) (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
Frequency=2835939 Hz, Resolution=352.6169 ns, Timer=TSC
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3221.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3221.0


```
| Method |      Mean |     Error |   StdDev |    Median | Scaled | Allocated |
|------- |----------:|----------:|---------:|----------:|-------:|----------:|
|    Now | 221.75 ns | 4.3999 ns | 9.471 ns | 217.97 ns |   1.00 |       0 B |
| UtcNow |  14.68 ns | 0.5870 ns | 1.731 ns |  13.97 ns |   0.07 |       0 B |
