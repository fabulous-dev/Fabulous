namespace ComponentNavigation

open Microsoft.Maui.Hosting
open Fabulous.Maui

type MauiProgram =
    static member CreateMauiApp() =
        let nav = NavigationController()
        let appMsgDispatcher = AppMessageDispatcher()

        MauiApp
            .CreateBuilder()
            .UseFabulousApp(Sample.view nav appMsgDispatcher)
            .ConfigureFonts(fun fonts ->
                fonts
                    .AddFont("OpenSans-Regular.ttf", "OpenSansRegular")
                    .AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold")
                |> ignore)
            .Build()
