``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10.0.16299
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435873 Hz, Resolution=410.5304 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0


```
 |           Method |      Mean |     Error |    StdDev | Scaled | ScaledSD |  Gen 0 | Allocated |
 |----------------- |----------:|----------:|----------:|-------:|---------:|-------:|----------:|
 |             Linq | 79.886 ns | 1.6034 ns | 1.7821 ns |   9.43 |     0.23 | 0.0151 |      32 B |
 |              For |  8.470 ns | 0.0996 ns | 0.0883 ns |   1.00 |     0.00 |      - |       0 B |
 |          ForEach |  8.495 ns | 0.0489 ns | 0.0457 ns |   1.00 |     0.01 |      - |       0 B |
 | ForIReadOnlyList | 61.842 ns | 0.5361 ns | 0.5015 ns |   7.30 |     0.09 |      - |       0 B |
 |          Checked |  9.647 ns | 0.0605 ns | 0.0505 ns |   1.14 |     0.01 |      - |       0 B |
 |             Long |  8.433 ns | 0.0945 ns | 0.0884 ns |   1.00 |     0.01 |      - |       0 B |
