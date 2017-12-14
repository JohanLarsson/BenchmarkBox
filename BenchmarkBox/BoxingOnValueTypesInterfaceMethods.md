``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10.0.16299
Processor=Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), ProcessorCount=8
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2600.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2600.0


```
 |              Method |       Mean |     Error |    StdDev |  Gen 0 | Allocated |
 |-------------------- |-----------:|----------:|----------:|-------:|----------:|
 |   GetHashCodeMethod |  6.4086 ns | 0.1332 ns | 0.1246 ns | 0.0057 |      24 B |
 | GetHashCodeComparer |  0.8956 ns | 0.0029 ns | 0.0023 ns |      - |       0 B |
 |        EqualsMethod | 10.0337 ns | 0.2561 ns | 0.2847 ns | 0.0114 |      48 B |
 |      EqualsComparer |  0.8823 ns | 0.0066 ns | 0.0061 ns |      - |       0 B |
