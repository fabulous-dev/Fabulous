namespace Gallery

open System
open System.Diagnostics
open Avalonia.Animation
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module ExpanderPage =
    type Model = { IsExpanded: bool }

    type Msg =
        | ExpandChanged of bool
        | Expanding of CancelRoutedEventArgs
        | Collapsing of CancelRoutedEventArgs

    let init () = { IsExpanded = true }, Cmd.none

    let update msg model =
        match msg with
        | ExpandChanged b -> { IsExpanded = b }, Cmd.none
        | Expanding _ -> model, Cmd.none
        | Collapsing _ -> model, Cmd.none

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
        Component("ExpanderPage") {
            let! model = Context.Mvu program

            VStack(spacing = 15.) {
                Expander("Title", "Mr.")

                Expander(TextBlock("Title"), "Mr.")
                    .onExpandedChanged(model.IsExpanded, ExpandChanged)

                Expander(
                    "Title",
                    VStack(8.) {
                        TextBlock("Mr.")
                        TextBlock("Mr.")
                        TextBlock("Ms.")
                        TextBlock("Mr.")
                    }
                )
                    .contentTransition(CrossFade(TimeSpan.FromSeconds(2.5)) :> IPageTransition)


                Expander(
                    TextBlock("Marital status"),
                    VStack(8.) {
                        TextBlock("Married")
                        Separator()
                        TextBlock("Single")
                        Separator()
                        TextBlock("Divorced")
                        Separator()
                        TextBlock("Widowed")
                    }
                )
                    .expandDirection(ExpandDirection.Right)
                    .onCollapsing(Collapsing)
                    .onExpanding(Expanding)
            }
        }
