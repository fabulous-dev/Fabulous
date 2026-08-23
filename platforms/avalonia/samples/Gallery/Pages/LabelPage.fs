namespace Gallery

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Layout
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module LabelPage =
    type Model =
        { FirstName: string
          LastName: string
          IsBanned: bool }

    type Msg =
        | FirstNameChanged of string
        | LastNameChanged of string
        | BannedChanged of bool
        | DoSave
        | DoCancel

    let init () =
        { FirstName = ""
          LastName = ""
          IsBanned = false },
        Cmd.none

    let update msg model =
        match msg with
        | FirstNameChanged s -> { model with FirstName = s }, Cmd.none
        | LastNameChanged s -> { model with LastName = s }, Cmd.none
        | BannedChanged b -> { model with IsBanned = b }, Cmd.none
        | DoSave -> model, Cmd.none
        | DoCancel ->
            { FirstName = "John"
              LastName = "Doe"
              IsBanned = true },
            Cmd.none

    let labelStyle (this: WidgetBuilder<'msg, IFabLabel>) =
        this
            .verticalAlignment(VerticalAlignment.Center)
            .margin(6., 3., 0., 3.)

    let textBoxStyle (this: WidgetBuilder<'msg, IFabTextBox>) =
        this
            .verticalAlignment(VerticalAlignment.Center)
            .margin(0., 3., 6., 3.)

    let checkBoxStyle (this: WidgetBuilder<'msg, IFabCheckBox>) =
        this
            .verticalAlignment(VerticalAlignment.Center)
            .margin(0., 3., 6., 3.)

    let firstNameEdit = ViewRef<TextBox>()

    let lastNameEdit = ViewRef<TextBox>()

    let bannedCheck = ViewRef<CheckBox>()

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
        Component("LabelPage") {
            let! model = Context.Mvu program

            ScrollViewer(
                (Grid(rowdefs = [ Auto; Auto; Auto; Auto; Auto; Star ], coldefs = [ Auto; Pixel(6.); Star ]) {
                    Label("_FirstName")
                        .target(firstNameEdit)
                        .gridRow(0)
                        .gridColumn(0)
                        .style(labelStyle)

                    TextBox(model.FirstName, FirstNameChanged)
                        .gridRow(0)
                        .gridColumn(2)
                        .name("firstNameEdit")
                        .style(textBoxStyle)
                        .reference(firstNameEdit)

                    Label("_LastName")
                        .target(lastNameEdit)
                        .gridRow(1)
                        .gridColumn(0)
                        .style(labelStyle)

                    TextBox(model.LastName, LastNameChanged)
                        .gridRow(1)
                        .gridColumn(2)
                        .name("lastNameEdit")
                        .style(textBoxStyle)
                        .reference(lastNameEdit)

                    Label("_Banned")
                        .target(bannedCheck)
                        .gridRow(2)
                        .gridColumn(0)
                        .style(labelStyle)

                    CheckBox(model.IsBanned, BannedChanged)
                        .gridRow(2)
                        .gridColumn(2)
                        .name("bannedCheck")
                        .style(checkBoxStyle)
                        .reference(bannedCheck)

                    GridSplitter()
                        .gridRowSpan(3)
                        .gridColumn(1)
                        .verticalAlignment(VerticalAlignment.Stretch)
                        .horizontalAlignment(HorizontalAlignment.Stretch)

                    (HStack() {
                        Button("Cancel", DoCancel).isCancel(true)

                        Button("Save", DoSave).isDefault(true)
                    })
                        .gridRow(4)
                        .gridColumn(0)
                        .gridColumnSpan(3)
                        .horizontalAlignment(HorizontalAlignment.Right)
                })
                    .width(246.)
            )
                .verticalScrollBarVisibility(ScrollBarVisibility.Auto)
                .horizontalScrollBarVisibility(ScrollBarVisibility.Hidden)
        }
