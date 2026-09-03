# Deployment

Always publish the generated application project, not a Fabulous library. Set the application identifier, display version, numeric version, icons, signing identity, and target minimums in the project/platform manifests before producing store artifacts. Validate launch on a physical device or clean VM; compilation alone is not runtime validation.

## .NET MAUI

The maintained [HelloWorld project](https://github.com/fabulous-dev/Fabulous/blob/main/samples/maui/HelloWorld/HelloWorld.fsproj) shows the shared resources and conditional Android, iOS, Mac Catalyst, and Windows items.

```bash
# Android APK/AAB; configure an Android signing keystore for distribution
dotnet publish MyApp.fsproj -c Release -f net10.0-android

# iOS and Mac Catalyst require macOS, Xcode, and Apple signing profiles
dotnet publish MyApp.fsproj -c Release -f net10.0-ios
dotnet publish MyApp.fsproj -c Release -f net10.0-maccatalyst

# Windows requires Windows, the MAUI workload, and a Windows TFM in the project
# A packaged Windows app host cannot be built as ProcessorArchitecture-neutral (AnyCPU),
# so a RuntimeIdentifier is required for `dotnet publish` (the templates set win-x64 by default)
dotnet publish MyApp.fsproj -c Release -f net10.0-windows10.0.19041.0
```

Follow the platform signing and store steps in the [.NET MAUI publishing guide](https://learn.microsoft.com/dotnet/maui/deployment/). The repository's Windows support uses `FSharp.Maui.WinUICompat`; generated templates add it for the Windows target and default `RuntimeIdentifier`/`Platform` to `win-x64`/`x64` when publishing so the packaged app host isn't ProcessorArchitecture-neutral. If you see `error: Packaged .NET applications with an app host exe cannot be ProcessorArchitecture neutral`, pass an explicit RID, e.g. `dotnet publish MyApp.fsproj -c Release -f net10.0-windows10.0.19041.0 -r win-x64`, or check that the project's `RuntimeIdentifier`/`Platform` properties aren't overridden to empty/AnyCPU.

## Avalonia

Desktop Avalonia publishes with a runtime identifier:

```bash
dotnet publish MyApp.fsproj -c Release -f net10.0 -r linux-x64 --self-contained true
dotnet publish MyApp.fsproj -c Release -f net10.0 -r osx-arm64 --self-contained true
dotnet publish MyApp.fsproj -c Release -f net10.0 -r win-x64 --self-contained true
```

Package the output using the operating system's normal installer format. For Avalonia Android and iOS, start from `fabulous-avalonia-multi`; build the platform host project on a machine with the corresponding workloads and signing tools. See the maintained [multi-target sample hosts](https://github.com/fabulous-dev/Fabulous/tree/main/samples/avalonia/Mvu/CounterApp/Platform) and Avalonia's [deployment documentation](https://docs.avaloniaui.net/docs/deployment/).