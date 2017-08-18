``` ini

BenchmarkDotNet=v0.10.8, OS=Windows 7 SP1 (6.1.7601)
Processor=Intel Xeon CPU E5-2637 v4 3.50GHz, ProcessorCount=8
Frequency=3410136 Hz, Resolution=293.2434 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2053.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2053.0


```
 |                          Method |       Mean |     Error |     StdDev | Scaled | ScaledSD |  Gen 0 | Allocated |
 |-------------------------------- |-----------:|----------:|-----------:|-------:|---------:|-------:|----------:|
 |           DictionaryTryGetValue |  12.518 ns | 0.2877 ns |  0.7629 ns |   1.00 |     0.00 |      - |       0 B |
 | ConcurrentDictionaryTryGetValue |  16.779 ns | 0.3995 ns |  1.1653 ns |   1.35 |     0.12 |      - |       0 B |
 |                       ArrayLoop |   9.624 ns | 0.2246 ns |  0.6033 ns |   0.77 |     0.07 |      - |       0 B |
 |                  FirstOrDefault | 169.473 ns | 3.5815 ns | 10.4475 ns |  13.59 |     1.17 | 0.0036 |      20 B |
