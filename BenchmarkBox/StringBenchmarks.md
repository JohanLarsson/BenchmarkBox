``` ini

BenchmarkDotNet=v0.10.8, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435883 Hz, Resolution=410.5287 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2101.1
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2101.1


```
 |              Method |      Mean |     Error |    StdDev | Scaled | ScaledSD |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
 |-------------------- |----------:|----------:|----------:|-------:|---------:|-------:|-------:|-------:|----------:|
 |              Concat |  20.42 ns | 0.3408 ns | 0.3188 ns |   1.00 |     0.00 | 0.0095 |      - |      - |      20 B |
 |         Interpolate | 111.36 ns | 2.4255 ns | 5.4251 ns |   5.46 |     0.28 | 0.0094 |      - |      - |      20 B |
 |       StringBuilder |  44.33 ns | 0.5800 ns | 0.5425 ns |   2.17 |     0.04 | 0.0438 |      - |      - |      92 B |
 | PooledStringBuilder |  76.51 ns | 2.0575 ns | 1.9246 ns |   3.75 |     0.11 | 0.0061 | 0.0029 | 0.0001 |      27 B |
