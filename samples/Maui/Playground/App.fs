namespace Playground

open Fabulous
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Accessibility
open Microsoft.Maui.Primitives

open type Fabulous.Maui.View

module App =
    type FieldFocused =
        | Entry1
        | Entry2
        | Entry3

    type Model = { Focus: FieldFocused option }

    type Msg =
        | TextChanged of string
        | FocusChanged of FieldFocused * bool
        | SetFocus of FieldFocused option

    let init () = { Focus = None }

    let update msg model =
        match msg with
        | TextChanged _ -> model
        | FocusChanged (field, isFocused) ->
            if isFocused then
                { model with Focus = Some field }
            else
                { model with Focus = None }

        | SetFocus field -> { model with Focus = field }

    let focusChanged field args = FocusChanged(field, args)

    let view model =
        Application(
            ContentPage(
                "Title",
                (VStack() {
                    // let text =
                    //     match model.Focus with
                    //     | None -> "None"
                    //     | Some f -> f.ToString()
                    //
                    // Label($"Field currently selected: {text}")
                    //
                    // Entry("Entry1", TextChanged)
                    //     .focus(model.Focus = Some Entry1, focusChanged Entry1)
                    //
                    // Entry("Entry2", TextChanged)
                    //     .focus(model.Focus = Some Entry2, focusChanged Entry2)
                    //
                    // Entry("Entry3", TextChanged)
                    //     .focus(model.Focus = Some Entry3, focusChanged Entry3)
                    //     
                    (Grid(coldefs = [Star], rowdefs = [Star]) {
                        Label("View 1")
                            .zindex(4)
                            .backgroundColor(Colors.Green.ToFabColor())
                            .margin(10., 0., 0.,0.)
                            
                        Label("View 2")
                            .zindex(3)
                            .backgroundColor(Colors.Navy.ToFabColor())
                            .margin(30., 30., 0.,0.)
                            
                        Label("View 3")
                            .zindex(2)
                            .backgroundColor(Colors.Yellow.ToFabColor())
                            .margin(60., 60., 0.,0.)
                            
                        Label("View 4")
                            .zindex(1)
                            .backgroundColor(Colors.SkyBlue.ToFabColor())
                            .margin(90., 90., 0.,0.)
                    }).centerVertical()

                    // Button("Set focus on Entry1", SetFocus(Some Entry1))
                    // Button("Set focus on Entry2", SetFocus(Some Entry2))
                    // Button("Set focus on Entry3", SetFocus(Some Entry3))
                    // Button("Unfocus", SetFocus None)
                 })
                    .padding(20.)
            )
        )

    let program = Program.stateful init update view
