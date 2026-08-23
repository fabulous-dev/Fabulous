namespace Gallery

open System
open System.Diagnostics
open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia.Markup.Xaml.Styling
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module MainView =
    type Model = { Details: DetailPage option }

    type Msg =
        | SelectControl of RoutedEventArgs
        | GoBack

    let init () = { Details = None }, Cmd.none

    let update msg model =
        match msg with
        | SelectControl args ->
            args.Handled <- true
            let control = args.Source :?> TextBlock

            let detailPage =
                match control.Text with
                | CurrentPage page -> Some page
                | _ -> None

            { Details = detailPage }, Cmd.none
        | GoBack -> { Details = None }, Cmd.none

    let controlNames =
        [ "Acrylic"
          "AdornerLayer"
          "AutoCompleteBox"
          "Buttons"
          "ButtonSpinner"
          "Border"
          "Calendar"
          "CalendarDatePicker"
          "Canvas"
          "CheckBox"
          "Carousel"
          "ComboBox"
          "ColorPicker"
          "Composition"
          "ContextMenu"
          "ContextFlyout"
          "Clipboard"
          "DataGrid"
          "DockPanel"
          "Dialogs"
          "DragAndDrop"
          "DropDownButton"
          "Effects"
          "Expander"
          "Flyout"
          "Gestures"
          "Geometries"
          "Grid"
          "GridSplitter"
          "Image"
          "ItemsRepeater"
          "Label"
          "LayoutTransformControl"
          "ListBox"
          "MenuFlyout"
          "MaskedTextBox"
          "Menu"
          "NumericUpDown"
          "Notifications"
          "OpenGL"
          "ProgressBar"
          "Panel"
          "PathIcon"
          "Pointers"
          "Popup"
          "Transitions"
          "RepeatButton"
          "RadioButton"
          "RefreshContainer"
          "SelectableTextBlock"
          "SplitButton"
          "Slider"
          "Shapes"
          "ScrollBar"
          "SplitView"
          "StackPanel"
          "Styles"
          "ScrollViewer"
          "ToggleSplitButton"
          "TextBlock"
          "TextBox"
          "TickBar"
          "ToggleSwitch"
          "ToggleButton"
          "ToolTip"
          "TabControl"
          "TreeView"
          "TreeDataGrid"
          "TransitioningContent"
          "TabStrip"
          "ThemeAware"
          "UniformGrid"
          "ViewBox"
          "Implicit Animations"
          "Draw Line Animation"
          "Compositor Animations"
          "Animations"
          "Spring Animations"
          "Transitions"
          "Render Transform"
          "Brushes"
          "Clipping"
          "Drawing"
          "Line Bounds"
          "Transform3D"
          "Writable Bitmap"
          "Render Target Bitmap"
          "Path Measurement"
          "Custom Animator"
          "SkCanvas" ]

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
        Component("MainView") {
            let! model = Context.Mvu program

            SingleViewApplication(
                ScrollViewer(
                    match model.Details with
                    | Some(CurrentWidget page) ->
                        AnyView(
                            VStack(16.) {
                                Button("Go back", GoBack)
                                page
                            }
                        )
                    | _ ->
                        AnyView(
                            Grid() {
                                UniformGrid(cols = 2, rows = 37) {
                                    for i in 0 .. controlNames.Length - 1 do
                                        CardItem(controlNames[i])
                                            .onTapped(SelectControl)
                                            .gridRow(i / 2)
                                }
                            }
                        )
                )
            )
        }

    let create () =
        let theme () =
            StyleInclude(baseUri = null, Source = Uri("avares://Gallery/App.xaml"))

        FabulousAppBuilder.Configure(theme, view)
