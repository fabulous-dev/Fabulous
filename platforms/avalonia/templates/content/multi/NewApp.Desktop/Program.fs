namespace NewApp.Desktop

open System
open Avalonia
open Fabulous.Avalonia
open NewApp

module Program =
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [<STAThread; EntryPoint>]
    let Main (args: string array) =
        App
            .create()
            .UsePlatformDetect()
            .LogToTrace(?level = None)
            .StartWithClassicDesktopLifetime(args)
