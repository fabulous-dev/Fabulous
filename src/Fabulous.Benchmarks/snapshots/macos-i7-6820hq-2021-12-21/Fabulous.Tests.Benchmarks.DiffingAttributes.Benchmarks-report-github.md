``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.1 (21C52) [Darwin 21.2.0]
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]   : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT DEBUG
  .NET 6.0 : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT

Job=.NET 6.0  Runtime=.NET 6.0  

```
|          Method | depth |       Mean |    Error |   StdDev |       Gen 0 |       Gen 1 |      Gen 2 | Allocated |
|---------------- |------ |-----------:|---------:|---------:|------------:|------------:|-----------:|----------:|
| **ProcessMessages** |    **10** |   **257.5 ms** |  **3.79 ms** |  **3.36 ms** |  **46000.0000** |  **14000.0000** |  **2000.0000** |    **222 MB** |
| **ProcessMessages** |    **15** | **7,457.8 ms** | **33.21 ms** | **31.06 ms** | **605000.0000** | **196000.0000** | **96000.0000** |  **2,470 MB** |
