namespace Gallery.Desktop

open System
open Avalonia
open Gallery

module Program =

    [<CompiledName "BuildAvaloniaApp">]
    let buildAvaloniaApp () =
        match Environment.GetEnvironmentVariable("FABULOUS_GALLERY_PAGE") with
        | null -> MainWindow.create().UsePlatformDetect()
        | _ -> MainView.createDesktop().UsePlatformDetect()

    [<EntryPoint; STAThread>]
    let main argv =
        buildAvaloniaApp().StartWithClassicDesktopLifetime(argv)
