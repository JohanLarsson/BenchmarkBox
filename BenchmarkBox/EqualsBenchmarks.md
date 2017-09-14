``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435884 Hz, Resolution=410.5286 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2102.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2102.0


```
 |                        Method |       Mean |     Error |    StdDev | Scaled | ScaledSD |
 |------------------------------ |-----------:|----------:|----------:|-------:|---------:|
 |                        Equals |  0.0633 ns | 0.0360 ns | 0.0812 ns |      ? |        ? |
 |                OperatorEquals |  0.0083 ns | 0.0164 ns | 0.0231 ns |      ? |        ? |
 |                  ObjectEquals | 13.0236 ns | 0.3230 ns | 0.9421 ns |      ? |        ? |
 | EqualityComparerDefaultEquals | 10.5712 ns | 0.2564 ns | 0.5121 ns |      ? |        ? |
 |               ReferenceEquals |  0.0090 ns | 0.0135 ns | 0.0133 ns |      ? |        ? |
