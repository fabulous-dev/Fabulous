namespace Gallery

open System
open System.Collections.Generic
open System.Diagnostics
open System.Linq
open Avalonia
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Media
open Avalonia.Media.Imaging
open Avalonia.Platform
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module CursorPage =
    type StandardCursorModel(type': StandardCursorType) =
        member val Type = type' with get, set
        member val Cursor = new Cursor(type') with get, set

    type Model =
        { CustomCursor: Cursor
          StandardCursors: IList<StandardCursorModel> }

    type Msg =
        | Nothing
        | SelectionChanged of SelectionChangedEventArgs

    let init () =
        let standardCursors =
            Enum
                .GetValues(typeof<StandardCursorType>)
                .Cast<StandardCursorType>()
                .Select(fun x -> StandardCursorModel(x))
                .ToList()

        let loader = AssetLoader.Open(Uri("avares://Gallery/Assets/Icons/avalonia-32.png"))
        let bitmap = new Bitmap(loader)

        { CustomCursor = new Cursor(bitmap, PixelPoint(16, 16))
          StandardCursors = standardCursors },
        Cmd.none

    let update msg model =
        match msg with
        | Nothing -> model, Cmd.none
        | SelectionChanged args ->
            let control = args.Source :?> ListBox
            let scm = control.SelectedItem :?> StandardCursorModel
            { model with CustomCursor = scm.Cursor }, Cmd.none

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
        Component("CursorPage") {
            let! model = Context.Mvu program

            Grid(coldefs = [ Star; Star ], rowdefs = [ Auto; Star ]) {
                (VStack(4) {
                    TextBlock(text = "Defines a cursor (mouse pointer)")
                        .classes("h2")
                })
                    .gridColumnSpan(2)

                ListBox(model.StandardCursors, (fun x -> TextBlock($"{x.Type}")))
                    .onSelectionChanged(SelectionChanged)
                    .margin(0, 8, 8, 8)
                    .gridRow(1)

                (VStack() {
                    Button("Custom Cursor", Nothing)
                        .cursor(model.CustomCursor)
                        .margin(8, 8, 0, 8)
                        .padding(16)
                })
                    .gridColumn(1)
                    .gridRow(1)
                    .margin(8, 8, 0, 8)
            }
        }
