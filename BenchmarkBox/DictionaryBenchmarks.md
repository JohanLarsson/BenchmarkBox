``` ini

BenchmarkDotNet=v0.10.8, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435874 Hz, Resolution=410.5303 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2101.1
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2101.1


```
 |                               Method |     Mean |     Error |    StdDev | Scaled | ScaledSD | Allocated |
 |------------------------------------- |---------:|----------:|----------:|-------:|---------:|----------:|
 |                     DictionaryTryGet | 14.78 ns | 0.3288 ns | 0.3518 ns |   1.00 |     0.00 |       0 B |
 |                 DictionaryTryGetMiss | 12.14 ns | 0.1924 ns | 0.1706 ns |   0.82 |     0.02 |       0 B |
 |                DictionaryContainsGet | 28.38 ns | 0.5638 ns | 0.4998 ns |   1.92 |     0.05 |       0 B |
 |               DictionaryContainsMiss | 14.21 ns | 0.1922 ns | 0.1605 ns |   0.96 |     0.02 |       0 B |
 | ConcurrentDictionaryDictionaryTryGet | 20.32 ns | 0.4140 ns | 0.3873 ns |   1.38 |     0.04 |       0 B |
 |                 DictionaryTryGetLock | 40.07 ns | 0.7044 ns | 0.6245 ns |   2.71 |     0.07 |       0 B |
 |                   ConcurrentGetOrAdd | 25.12 ns | 0.3248 ns | 0.3038 ns |   1.70 |     0.04 |       0 B |
