namespace CounterApp

open Microsoft.Maui.Hosting
open Microsoft.Maui.Controls.Hosting

type MauiProgram =
    static member CreateMauiApp() =
        MauiApp
            .CreateBuilder()
            .UseMauiApp<App>()
            .ConfigureFonts(fun fonts ->
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular") |> ignore
            )
            .Build()