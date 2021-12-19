``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Big Sur 11.5.1 (20G80) [Darwin 20.6.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.100
  [Host]   : .NET 6.0.0 (6.0.21.52210), Arm64 RyuJIT DEBUG
  .NET 6.0 : .NET 6.0.0 (6.0.21.52210), Arm64 RyuJIT

Job=.NET 6.0  Runtime=.NET 6.0  

```
|        Method | depth |       Mean |    Error |    StdDev |
|-------------- |------ |-----------:|---------:|----------:|
| **CreateWidgets** |   **100** |   **127.1 μs** |  **0.20 μs** |   **0.16 μs** |
| **CreateWidgets** |  **1000** | **2,845.5 μs** | **56.45 μs** | **116.58 μs** |
