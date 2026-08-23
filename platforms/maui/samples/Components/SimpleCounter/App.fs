namespace SimpleCounter

open Fabulous
open Fabulous.Maui
open Microsoft.Maui.Hosting

open type Fabulous.Maui.View

module App =
    let view () =
        Component() {
            let! count = Context.State(0)

            Application(
                ContentPage(
                    (VStack() {
                        Label($"%d{count.Current}").centerTextHorizontal()
                        Button("Increment", (fun () -> count.Set(count.Current + 1)))
                        Button("Decrement", (fun () -> count.Set(count.Current - 1)))
                    })
                        .center()
                )
            )
        }

    let createMauiApp () =
        MauiApp
            .CreateBuilder()
            .UseFabulousApp(view)
            .ConfigureFonts(fun fonts ->
                fonts
                    .AddFont("OpenSans-Regular.ttf", "OpenSansRegular")
                    .AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold")
                |> ignore)
            .Build()
