``` ini

BenchmarkDotNet=v0.10.8, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435883 Hz, Resolution=410.5287 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2102.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2102.0


```
 |                    Method |            Mean |          Error |         StdDev |   Scaled | ScaledSD |  Gen 0 |  Gen 1 | Allocated |
 |-------------------------- |----------------:|---------------:|---------------:|---------:|---------:|-------:|-------:|----------:|
 |                   IsMatch |       840.55 ns |     16.1406 ns |     12.6015 ns |     2.69 |     0.05 | 0.1059 |      - |     224 B |
 |           CompiledIsMatch |       312.74 ns |      3.7315 ns |      3.4905 ns |     1.00 |     0.00 |      - |      - |       0 B |
 | CompiledSinglelineIsMatch |       316.17 ns |      6.7516 ns |      7.2241 ns |     1.01 |     0.02 |      - |      - |       0 B |
 |         SinglelineIsMatch |       448.26 ns |     14.1807 ns |     15.7618 ns |     1.43 |     0.05 |      - |      - |       0 B |
 |            VanillaIsMatch |       453.54 ns |      9.0413 ns |     17.2020 ns |     1.45 |     0.06 |      - |      - |       0 B |
 |         NewVanillaIsMatch |     5,270.73 ns |    100.8205 ns |    123.8167 ns |    16.86 |     0.43 | 1.7319 |      - |    3644 B |
 |        NewCompiledIsMatch | 1,232,629.21 ns | 24,589.5632 ns | 19,197.9118 ns | 3,941.80 |    72.49 | 5.8594 | 1.9531 |   12496 B |
 |                    Manual |        13.14 ns |      0.1099 ns |      0.0974 ns |     0.04 |     0.00 |      - |      - |       0 B |
