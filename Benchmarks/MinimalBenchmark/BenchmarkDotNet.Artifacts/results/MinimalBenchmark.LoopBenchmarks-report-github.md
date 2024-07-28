```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3672/23H2/2023Update/SunValley3)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.300
  [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2


```
| Method  | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Code Size |
|-------- |----------:|----------:|----------:|----------:|------:|--------:|----------:|
| For     |  5.936 ns | 0.1555 ns | 0.1728 ns |  5.868 ns |  1.00 |    0.00 |      81 B |
| Foreach | 11.631 ns | 0.3274 ns | 0.9073 ns | 11.232 ns |  2.09 |    0.21 |      68 B |
| While   |  5.769 ns | 0.1419 ns | 0.1394 ns |  5.732 ns |  0.97 |    0.04 |      81 B |
