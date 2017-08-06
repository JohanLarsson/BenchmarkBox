``` ini

BenchmarkDotNet=v0.10.8, OS=Windows 7 SP1 (6.1.7601)
Processor=Intel Xeon CPU E5-2637 v4 3.50GHz, ProcessorCount=8
Frequency=3410097 Hz, Resolution=293.2468 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1649.1
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1649.1


```
 |        Method |        Mean |      Error |    StdDev |      Median | Scaled | ScaledSD | Allocated |
 |-------------- |------------:|-----------:|----------:|------------:|-------:|---------:|----------:|
 | RangeWhereSum | 12,256.8 ns | 245.020 ns | 506.01 ns | 12,239.0 ns |  62.42 |     8.44 |      72 B |
 |       LoopMod |  5,158.8 ns | 305.380 ns | 900.42 ns |  4,823.4 ns |  26.27 |     5.71 |       0 B |
 |    ThreeLoops |    199.7 ns |   8.937 ns |  26.35 ns |    187.4 ns |   1.00 |     0.00 |       0 B |
