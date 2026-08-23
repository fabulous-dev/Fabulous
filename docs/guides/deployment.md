# Deployment

Always publish the generated application project, not a Fabulous library. Set the application identifier, display version, numeric version, icons, signing identity, and target minimums in the project/platform manifests before producing store artifacts. Validate launch on a physical device or clean VM; compilation alone is not runtime validation.

## .NET MAUI

The maintained [HelloWorld project](https://github.com/fabulous-dev/Fabulous/blob/main/samples/maui/HelloWorld/HelloWorld.fsproj) shows the shared resources and conditional Android, iOS, Mac Catalyst, and Windows items.

```bash
# Android APK/AAB; configure an Android signing keystore for distribution
dotnet publish MyApp.fsproj -c Release -f net8.0-android

# iOS and Mac Catalyst require macOS, Xcode, and Apple signing profiles
dotnet publish MyApp.fsproj -c Release -f net8.0-ios
dotnet publish MyApp.fsproj -c Release -f net8.0-maccatalyst

# Windows requires Windows, the MAUI workload, and a Windows TFM in the project
dotnet publish MyApp.fsproj -c Release -f net8.0-windows10.0.19041.0
```

Follow the platform signing and store steps in the [.NET MAUI publishing guide](https://learn.microsoft.com/dotnet/maui/deployment/). The repository's Windows support uses `FSharp.Maui.WinUICompat`; generated templates add it for the Windows target.

## Avalonia

Desktop Avalonia publishes with a runtime identifier:

```bash
dotnet publish MyApp.fsproj -c Release -f net8.0 -r linux-x64 --self-contained true
dotnet publish MyApp.fsproj -c Release -f net8.0 -r osx-arm64 --self-contained true
dotnet publish MyApp.fsproj -c Release -f net8.0 -r win-x64 --self-contained true
```

Package the output using the operating system's normal installer format. For Avalonia Android and iOS, start from `fabulous-avalonia-multi`; build the platform host project on a machine with the corresponding workloads and signing tools. See the maintained [multi-target sample hosts](https://github.com/fabulous-dev/Fabulous/tree/main/samples/avalonia/Mvu/CounterApp/Platform) and Avalonia's [deployment documentation](https://docs.avaloniaui.net/docs/deployment/).