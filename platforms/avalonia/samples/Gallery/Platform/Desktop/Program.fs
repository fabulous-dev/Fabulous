namespace Gallery.Desktop

open System
open Avalonia
open Gallery

module Program =

    [<CompiledName "BuildAvaloniaApp">]
    let buildAvaloniaApp () = MainWindow.create().UsePlatformDetect()

    [<EntryPoint; STAThread>]
    let main argv =
        buildAvaloniaApp().StartWithClassicDesktopLifetime(argv)
