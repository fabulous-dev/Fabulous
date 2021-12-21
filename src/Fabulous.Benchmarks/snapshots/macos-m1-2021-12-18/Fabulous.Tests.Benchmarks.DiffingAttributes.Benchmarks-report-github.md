``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Big Sur 11.5.1 (20G80) [Darwin 20.6.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.100
  [Host]   : .NET 6.0.0 (6.0.21.52210), Arm64 RyuJIT DEBUG
  .NET 6.0 : .NET 6.0.0 (6.0.21.52210), Arm64 RyuJIT

Job=.NET 6.0  Runtime=.NET 6.0  

```
|          Method | depth |        Mean |     Error |    StdDev |
|---------------- |------ |------------:|----------:|----------:|
| **ProcessMessages** |   **100** |    **61.72 ms** |  **0.560 ms** |  **0.468 ms** |
| **ProcessMessages** |  **1000** | **1,438.17 ms** | **23.754 ms** | **21.057 ms** |
