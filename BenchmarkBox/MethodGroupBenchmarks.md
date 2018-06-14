``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 7 SP1 (6.1.7601.0)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
Frequency=3410087 Hz, Resolution=293.2477 ns, Timer=TSC
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2650.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2650.0


```
|      Method |      Mean |     Error |    StdDev |    Median | Scaled | ScaledSD |      Gen 0 |  Allocated |
|------------ |----------:|----------:|----------:|----------:|-------:|---------:|-----------:|-----------:|
|      Lambda |  3.293 ms | 0.0708 ms | 0.2053 ms |  3.214 ms |   1.00 |     0.00 |          - |        0 B |
| MethodGroup | 10.361 ms | 0.2637 ms | 0.7693 ms | 10.368 ms |   3.16 |     0.30 | 10156.2500 | 64000356 B |
