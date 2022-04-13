namespace CounterApp

open Fabulous.Maui
open Microsoft.Maui.Hosting

type MauiProgram =
    static member CreateMauiApp() =
        MauiApp
            .CreateBuilder()
            .UseFabulousApp(App.program)
            .ConfigureFonts(fun fonts ->
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular") |> ignore
            )
            .Build()