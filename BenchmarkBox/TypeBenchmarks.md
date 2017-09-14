``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435884 Hz, Resolution=410.5286 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2102.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2102.0


```
 |       Method |      Mean |     Error |    StdDev | Scaled | ScaledSD |
 |------------- |----------:|----------:|----------:|-------:|---------:|
 |       Typeof | 1.9889 ns | 0.0975 ns | 0.0912 ns |   1.00 |     0.00 |
 |   IntGetType | 8.1186 ns | 0.2632 ns | 0.4879 ns |   4.09 |     0.30 |
 | StaticField  | 0.1406 ns | 0.1003 ns | 0.1703 ns |   0.07 |     0.08 |
