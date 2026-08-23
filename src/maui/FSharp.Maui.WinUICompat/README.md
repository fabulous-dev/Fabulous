# FSharp.Maui.WinUICompat

Precompiled `Microsoft.UI.Xaml.Application` and startup support for F# MAUI Windows applications.

The WinUI XAML build normally generates a C# application entry point and XAML metadata provider. An F# MAUI project cannot use that generated startup path directly. This package supplies the precompiled application metadata and startup helper; the F# host supplies an explicit `Main` function that identifies its application type. Omitting that entry point can produce an application that builds but exits during Windows startup.

## How to use

1. Add the `FSharp.Maui.WinUICompat` NuGet package to your F# MAUI project under the Windows `ItemGroup`:

```xml
<ItemGroup Condition="$(TargetPlatformIdentifier) == 'windows'">
  (...)
  <PackageReference Include="FSharp.Maui.WinUICompat" Version="1.1.0" />
</ItemGroup>
```

The Fabulous MAUI template already adds this reference and uses its current package version.

2. In `Platforms\Windows\App.fs`, inherit from `FSharp.Maui.WinUICompat.App`:

```diff
type App() =
-    inherit MauiWinUIApplication()
+    inherit FSharp.Maui.WinUICompat.App()
```

3. Add `Platforms\Windows\Main.fs` after `App.fs` in project compile order:

```fsharp
namespace MyApp.WinUI

open System

module Program =
  [<EntryPoint; STAThread>]
  let main args =
    FSharp.Maui.WinUICompat.Program.Main(args, typeof<MyApp.WinUI.App>)
    0
```

Both packaged and unpackaged Windows applications are supported. The default MAUI launch profile uses `MsixPackage`; configure the package identity, signing certificate, and manifest for deployment. For local or CI launch tests without MSIX registration, build with `-p:WindowsPackageType=None -p:RuntimeIdentifier=win10-x64`. The package initializes the Windows App SDK runtime for that unpackaged path.

See `samples/maui/WinUICompat/HelloWorld.Maui` for a plain MAUI host and `samples/maui/WinUICompat/HelloWorld.Fabulous` for a Fabulous host.