``` ini

BenchmarkDotNet=v0.10.8, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435883 Hz, Resolution=410.5287 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2101.1
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2101.1


```
 |                               Method |     Mean |     Error |    StdDev | Scaled | ScaledSD | Allocated |
 |------------------------------------- |---------:|----------:|----------:|-------:|---------:|----------:|
 |                     DictionaryTryGet | 14.44 ns | 0.1659 ns | 0.1295 ns |   1.00 |     0.00 |       0 B |
 | ConcurrentDictionaryDictionaryTryGet | 20.50 ns | 0.4761 ns | 0.9832 ns |   1.42 |     0.07 |       0 B |
