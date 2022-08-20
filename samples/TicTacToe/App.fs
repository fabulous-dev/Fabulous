namespace TicTacToe

open Fabulous
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics
open Microsoft.Maui.Accessibility
open Microsoft.Maui.Primitives

open type Fabulous.Maui.View

module App =
    type Model = { Count: int }

    type Msg = | Clicked

    type CmdMsg = SemanticAnnounce of string

    let semanticAnnounce text =
        Cmd.ofSub(fun _ -> SemanticScreenReader.Announce(text))

    let mapCmd cmdMsg =
        match cmdMsg with
        | SemanticAnnounce text -> semanticAnnounce text

    let init () = { Count = 0 }, []

    let update msg model =
        match msg with
        | Clicked -> { model with Count = model.Count + 1 }, []

    let view model =
        Application() {
            Window(
                (VStack(spacing = 25.) {
                    Label("Hello, World!")
                        .font(Microsoft.Maui.Font.Default.WithSize(32.))
                        .centerHorizontal()
                 })
                    .padding(Thickness(30., 0., 30., 0.))
                    .centerVertical()
            )
        }

    let program =
        Program.statefulWithCmdMsg init update view mapCmd
