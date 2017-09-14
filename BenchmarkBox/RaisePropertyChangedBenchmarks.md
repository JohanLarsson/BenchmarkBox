``` ini

BenchmarkDotNet=v0.10.8, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435874 Hz, Resolution=410.5303 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2102.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2102.0


```
 |                  Method |         Mean |      Error |     StdDev | Scaled | ScaledSD |  Gen 0 | Allocated |
 |------------------------ |-------------:|-----------:|-----------:|-------:|---------:|-------:|----------:|
 |       SetWithExpression | 1,096.143 ns | 21.1045 ns | 21.6728 ns | 287.35 |     7.31 | 0.0954 |     204 B |
 | SetWithCallerMemberName |     3.816 ns |  0.0708 ns |  0.0662 ns |   1.00 |     0.00 |      - |       0 B |
