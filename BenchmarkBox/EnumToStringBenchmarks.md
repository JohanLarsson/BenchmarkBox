``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435876 Hz, Resolution=410.5299 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0


```
 |               Method |         Mean |      Error |      StdDev |       Median | Scaled |  Gen 0 | Allocated |
 |--------------------- |-------------:|-----------:|------------:|-------------:|-------:|-------:|----------:|
 |             ToString | 1,588.842 ns | 36.3889 ns | 103.8195 ns | 1,557.969 ns |   1.00 | 0.0572 |     120 B |
 |          EnumGetName |   271.896 ns |  5.1766 ns |   7.5877 ns |   272.067 ns |   0.17 | 0.0229 |      48 B |
 |         SwitchNameof |     3.083 ns |  0.1644 ns |   0.3432 ns |     2.932 ns |   0.00 |      - |       0 B |
