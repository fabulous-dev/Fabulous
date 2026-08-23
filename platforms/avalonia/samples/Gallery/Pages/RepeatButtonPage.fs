namespace Gallery

open System.Diagnostics
open Avalonia.Interactivity
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module RepeatButtonPage =
    type Model = { Nothing: bool }

    type Msg = Clicked of RoutedEventArgs

    let init () = { Nothing = true }, Cmd.none

    let update msg model =
        match msg with
        | Clicked _ -> model, Cmd.none

    let program =
        Program.statefulWithCmd init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component("RepeatButtonPage") {
            let! model = Context.Mvu program

            VStack(spacing = 15.) {
                RepeatButton("Click me, or press and hold!", Clicked)
                    .delay(400)
                    .interval(200)

                RepeatButton(
                    Clicked,
                    HStack(16.) {
                        Image("avares://Gallery/Assets/Icons/fabulous-icon.png")
                            .width(20.)
                            .height(20.)

                        TextBlock("Example with custom content")
                    }
                )
                    .delay(400)
                    .interval(200)
            }
        }
