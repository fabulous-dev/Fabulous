namespace Playground

open Fabulous
open Fabulous.Maui

open type Fabulous.Maui.View

module App =
    type FieldFocused =
        | Entry1
        | Entry2
        | Entry3

    type Model =
        { Focus: FieldFocused option
          WindowOpened: bool }

    type Msg =
        | TextChanged of string
        | FocusChanged of FieldFocused * bool
        | SetFocus of FieldFocused option
        | OpenWindow
        | CloseWindow

    let init () = { Focus = None; WindowOpened = false }

    let update msg model =
        match msg with
        | TextChanged _ -> model
        | FocusChanged(field, isFocused) ->
            if isFocused then
                { model with Focus = Some field }
            else
                { model with Focus = None }

        | SetFocus field -> { model with Focus = field }
        | OpenWindow -> { model with WindowOpened = true }
        | CloseWindow -> { model with WindowOpened = false }

    let focusChanged field args = FocusChanged(field, args)

    let view model =
        Application() {
            Window(
                ContentPage(
                    (VStack(spacing = 20.) {
                        let text =
                            match model.Focus with
                            | None -> "None"
                            | Some f -> f.ToString()

                        Label($"Field currently selected: {text}")

                        Entry("Entry1", TextChanged)
                            .focus(model.Focus = Some Entry1, focusChanged Entry1)

                        Entry("Entry2", TextChanged)
                            .focus(model.Focus = Some Entry2, focusChanged Entry2)

                        Entry("Entry3", TextChanged)
                            .focus(model.Focus = Some Entry3, focusChanged Entry3)

                        Button("Set focus on Entry1", SetFocus(Some Entry1))
                        Button("Set focus on Entry2", SetFocus(Some Entry2))
                        Button("Set focus on Entry3", SetFocus(Some Entry3))
                        Button("Unfocus", SetFocus None)
                        Button("Open window", OpenWindow)
                    })
                        .margin(20.)
                )
            )

            if model.WindowOpened then
                Window(
                    ContentPage(
                        (VStack(spacing = 20.) {
                            Label("Window opened")
                            Button("Close window", CloseWindow)
                        })
                            .margin(20.)
                    )
                )
        }

    let program = Program.stateful init update |> Program.withView view
