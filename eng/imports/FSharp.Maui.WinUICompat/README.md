# FSharp.Maui.WinUICompat

Precompiled `Microsoft.UI.Xaml.Application` compatible with the F# MAUI template.

## How to use

1. Add the `FSharp.Maui.WinUICompat` NuGet package to your F# MAUI project under the `Windows` ItemGroup

```xml
<ItemGroup Condition="$(TargetPlatformIdentifier) == 'windows'">
  (...)
  <PackageReference Include="FSharp.Maui.WinUICompat" Version="1.0.0" />
</ItemGroup>
```

2. In the file `Platforms\Windows\App.fs`, change the inherited class to `FSharp.Maui.WinUICompat.App`

```diff
type App() =
-    inherit MauiWinUIApplication()
+    inherit FSharp.Maui.WinUICompat.App()
```

3. Create the file `Platforms\Windows\Main.fs`, add the following code

```fs
module Program =
    [<EntryPoint>]
    [<STAThread>]
    let main args =
        do FSharp.Maui.WinUICompat.Program.Main(args, typeof<YourApp.WinUI.App>)
        0
```

Where `YourApp.WinUI.App` is the `App` class defined in step 2
