``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10.0.16299
Processor=Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), ProcessorCount=8
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2600.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2600.0


```
 |                     Method |      Mean |     Error |    StdDev | Scaled | Allocated |
 |--------------------------- |----------:|----------:|----------:|-------:|----------:|
 | KeyValuePairDeconstruction | 11.349 ms | 0.0888 ms | 0.0831 ms |   1.01 |     128 B |
 |              KeyCollection | 16.168 ms | 0.1277 ms | 0.1195 ms |   1.43 |     256 B |
 |            ValueCollection |  9.088 ms | 0.0541 ms | 0.0479 ms |   0.81 |     128 B |
 |   DirectKeyValuePairAccess | 11.268 ms | 0.0862 ms | 0.0807 ms |   1.00 |     128 B |
