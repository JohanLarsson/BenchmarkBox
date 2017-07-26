``` ini

BenchmarkDotNet=v0.10.8, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435883 Hz, Resolution=410.5287 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2101.1
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2101.1


```
 |     Method |           Mean |         Error |        StdDev | Scaled | ScaledSD |  Gen 0 |  Gen 1 | Allocated |
 |----------- |---------------:|--------------:|--------------:|-------:|---------:|-------:|-------:|----------:|
 |    Vanilla |      0.0212 ns |     0.0209 ns |     0.0196 ns |      ? |        ? |      - |      - |       0 B |
 | Expression | 88,377.0220 ns | 1,757.5250 ns | 1,880.5319 ns |      ? |        ? | 1.7090 | 0.8545 |    3797 B |
