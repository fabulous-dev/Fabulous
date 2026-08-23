``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i5-9600KF CPU 3.70GHz (Coffee Lake), 1 CPU, 6 logical and 6 physical cores
.NET SDK=6.0.101
  [Host]   : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT DEBUG
  .NET 6.0 : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT

Job=.NET 6.0  Runtime=.NET 6.0  

```
|          Method | depth |       Mean |    Error |   StdDev |       Gen 0 |       Gen 1 |      Gen 2 | Allocated |
|---------------- |------ |-----------:|---------:|---------:|------------:|------------:|-----------:|----------:|
| **ProcessMessages** |    **10** |   **173.7 ms** |  **2.13 ms** |  **1.89 ms** |  **40000.0000** |   **5000.0000** |  **2000.0000** |    **222 MB** |
| **ProcessMessages** |    **15** | **4,920.9 ms** | **63.42 ms** | **59.32 ms** | **510000.0000** | **196000.0000** | **96000.0000** |  **2,470 MB** |
