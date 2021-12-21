``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i5-9600KF CPU 3.70GHz (Coffee Lake), 1 CPU, 6 logical and 6 physical cores
.NET SDK=6.0.101
  [Host]   : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT DEBUG
  .NET 6.0 : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT

Job=.NET 6.0  Runtime=.NET 6.0  

```
|        Method | depth |         Mean |       Error |      StdDev |      Gen 0 |     Gen 1 |    Gen 2 | Allocated |
|-------------- |------ |-------------:|------------:|------------:|-----------:|----------:|---------:|----------:|
| **CreateWidgets** |    **10** |     **323.7 μs** |     **1.85 μs** |     **1.54 μs** |   **106.4453** |   **38.5742** |        **-** |    **551 KB** |
| **CreateWidgets** |    **20** | **101,939.1 μs** | **1,878.27 μs** | **1,756.94 μs** | **11600.0000** | **2800.0000** | **800.0000** | **68,072 KB** |
