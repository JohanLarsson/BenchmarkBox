``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3667U CPU 2.00GHz (Ivy Bridge), ProcessorCount=4
Frequency=2435878 Hz, Resolution=410.5296 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0


```
 |                  Method |         Mean |       Error |      StdDev |   Scaled | ScaledSD |  Gen 0 | Allocated |
 |------------------------ |-------------:|------------:|------------:|---------:|---------:|-------:|----------:|
 |                  Direct |     1.952 ns |   0.0488 ns |   0.0456 ns |     1.00 |     0.00 |      - |       0 B |
 |            PropertyInfo |   361.807 ns |   6.8914 ns |   5.7547 ns |   185.47 |     5.10 | 0.0300 |      64 B |
 |      CachedPropertyInfo |   256.117 ns |   3.4446 ns |   3.2221 ns |   131.29 |     3.40 | 0.0300 |      64 B |
 |                 Dynamic |    21.063 ns |   0.0903 ns |   0.0705 ns |    10.80 |     0.25 |      - |       0 B |
 |                  Action |    10.785 ns |   0.1969 ns |   0.1841 ns |     5.53 |     0.16 | 0.0305 |      64 B |
 |           DynamicInvoke | 6,167.136 ns | 136.8144 ns | 235.9982 ns | 3,161.43 |   139.58 | 0.1297 |     288 B |
 |          CachedDelegate |    12.608 ns |   0.2789 ns |   0.2608 ns |     6.46 |     0.20 |      - |       0 B |
 | CreateAndInvokeDelegate | 3,415.144 ns |  11.2954 ns |   9.4322 ns | 1,750.69 |    40.29 | 0.0267 |      64 B |
 |            CachedSetter |    23.217 ns |   0.4996 ns |   0.9977 ns |    11.90 |     0.57 |      - |       0 B |
 |   CreateAndInvokeSetter | 7,178.681 ns | 100.5899 ns |  89.1703 ns | 3,679.97 |    94.97 | 0.2289 |     480 B |
