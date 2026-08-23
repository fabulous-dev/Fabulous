namespace TestableApp

open Fabulous.Avalonia
open Avalonia
open Avalonia.Headless

type TestAppBuilder() =
    static member BuildAvaloniaApp() =
        AppBuilder
            .Configure<FabApplication>()
            .UseSkia()
            .UseHeadless(AvaloniaHeadlessPlatformOptions(UseHeadlessDrawing = false))

[<assembly: AvaloniaTestApplication(typeof<TestAppBuilder>)>]
do ()
