``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10.0.16299
Processor=Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), ProcessorCount=8
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2600.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2600.0


```
 |                   Method |     Mean |     Error |    StdDev |  Gen 0 | Allocated |
 |------------------------- |---------:|----------:|----------:|-------:|----------:|
 | AsyncHashMultipleStreams | 6.592 us | 0.0496 us | 0.0440 us | 4.3564 |  17.87 KB |
 |   SyncHashMultpleStreams | 6.648 us | 0.1316 us | 0.1567 us | 4.2572 |  17.48 KB |
