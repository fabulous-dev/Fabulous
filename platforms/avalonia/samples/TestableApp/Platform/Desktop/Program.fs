namespace TestableApp.Desktop

open System
open Avalonia

open Fabulous.Avalonia
open TestableApp

module Program =

    [<CompiledName "BuildAvaloniaApp">]
    let buildAvaloniaApp () =
        AppBuilder
            .Configure<FabApplication>()
            .UsePlatformDetect()
            .LogToTrace(areas = Array.empty)

    [<EntryPoint; STAThread>]
    let main argv =
        buildAvaloniaApp().StartWithClassicDesktopLifetime(argv)
