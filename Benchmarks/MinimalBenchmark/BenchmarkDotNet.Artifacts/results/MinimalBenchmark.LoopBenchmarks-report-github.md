```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26100.2033)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.302
  [Host]     : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2


```
| Method  | Mean     | Error     | StdDev    | Ratio | RatioSD | Code Size |
|-------- |---------:|----------:|----------:|------:|--------:|----------:|
| For     | 5.819 ns | 0.1475 ns | 0.3046 ns |  1.00 |    0.00 |      81 B |
| Foreach | 9.544 ns | 0.0966 ns | 0.0856 ns |  1.71 |    0.11 |      68 B |
| While   | 5.337 ns | 0.1369 ns | 0.1732 ns |  0.92 |    0.08 |      81 B |
