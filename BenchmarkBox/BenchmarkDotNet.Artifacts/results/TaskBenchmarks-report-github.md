``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435876 Hz, Resolution=410.5299 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0


```
 |                     Method |     Mean |    Error |    StdDev | Scaled |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
 |--------------------------- |---------:|---------:|----------:|-------:|-------:|-------:|-------:|----------:|
 | TaskRunConfigureAwaitFalse | 308.9 ns | 1.066 ns | 0.9449 ns |   1.00 | 0.0191 | 0.0053 | 0.0005 |      88 B |
 |  TaskRunConfigureAwaitTrue | 308.2 ns | 1.263 ns | 1.1195 ns |   1.00 | 0.0191 | 0.0053 | 0.0005 |      88 B |
