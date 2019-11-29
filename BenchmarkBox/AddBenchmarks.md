``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.8.4018.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.8.4018.0


```
|             Method |       Mean |     Error |    StdDev |
|------------------- |-----------:|----------:|----------:|
|               Func |  1.2212 ns | 0.0119 ns | 0.0105 ns |
|               Emit |  1.8791 ns | 0.0210 ns | 0.0186 ns |
| ExpressionCompiled |  0.8046 ns | 0.0117 ns | 0.0098 ns |
|            Dynamic | 18.9726 ns | 0.2041 ns | 0.1909 ns |
