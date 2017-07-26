``` ini

BenchmarkDotNet=v0.10.8, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435883 Hz, Resolution=410.5287 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2101.1
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2101.1


```
 |            Method |          Mean |         Error |        StdDev |        Median |   Scaled | ScaledSD |  Gen 0 |  Gen 1 | Allocated |
 |------------------ |--------------:|--------------:|--------------:|--------------:|---------:|---------:|-------:|-------:|----------:|
 |              Func |      13.17 ns |     0.1944 ns |     0.1818 ns |      13.15 ns |     1.00 |     0.00 |      - |      - |       0 B |
 |         ParseFunc |   3,334.73 ns |    29.7927 ns |    27.8681 ns |   3,333.98 ns |   253.27 |     3.95 | 0.2174 |      - |     460 B |
 |        Expression |   3,835.93 ns |    77.0253 ns |   209.5529 ns |   3,750.92 ns |   291.34 |    16.29 | 0.2899 |      - |     612 B |
 | CompileExpression | 111,178.82 ns | 2,381.5905 ns | 2,227.7410 ns | 110,630.18 ns | 8,443.99 |   198.51 | 1.4648 | 0.7324 |    3082 B |
 |   ParseExpression |   4,027.44 ns |   103.1617 ns |   299.2907 ns |   3,909.43 ns |   305.88 |    22.98 | 0.2899 |      - |     612 B |
