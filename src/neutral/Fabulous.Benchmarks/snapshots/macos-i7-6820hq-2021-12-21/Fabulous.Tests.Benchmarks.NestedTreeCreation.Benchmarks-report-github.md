``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.1 (21C52) [Darwin 21.2.0]
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]   : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT DEBUG
  .NET 6.0 : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT

Job=.NET 6.0  Runtime=.NET 6.0  

```
|        Method | depth |         Mean |       Error |      StdDev |      Gen 0 |     Gen 1 |    Gen 2 | Allocated |
|-------------- |------ |-------------:|------------:|------------:|-----------:|----------:|---------:|----------:|
| **CreateWidgets** |    **10** |     **439.6 μs** |     **3.39 μs** |     **3.00 μs** |   **120.6055** |   **45.4102** |        **-** |    **551 KB** |
| **CreateWidgets** |    **20** | **159,309.5 μs** | **3,076.23 μs** | **3,159.06 μs** | **14000.0000** | **3000.0000** | **750.0000** | **68,072 KB** |
