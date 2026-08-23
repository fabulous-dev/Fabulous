namespace DrawingApp

open System.Diagnostics
open Avalonia
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Markup.Xaml.Converters
open Avalonia.Media
open Avalonia.Themes.Fluent
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ColorPicker =

    type Model = { Color: Color }

    type Msg = PointerPressed of Color

    let init () = { Color = Colors.Black }

    let update msg model =
        match msg with
        | PointerPressed color -> { Color = color }

    let view (model: Model) =
        let brushes = [ Colors.Black; Colors.Red; Colors.Green; Colors.Blue; Colors.Yellow ]

        HStack(5.) {
            for item in brushes do
                Border()
                    .width(32.0)
                    .height(32.0)
                    .cornerRadius(16.0)
                    .background(SolidColorBrush(item))
                    .borderThickness(4.0)
                    .borderBrush(
                        if item = model.Color then
                            SolidColorBrush(item)
                        else
                            SolidColorBrush(Colors.Transparent)
                    )
                    .onPointerPressed(fun _ -> PointerPressed item)
        }

module SizePicker =
    type Model = { Size: float }

    type Msg = PointerPressed of float

    let init () = { Size = 2. }

    let update msg model =
        match msg with
        | PointerPressed size -> { Size = size }

    let view (model: Model) =
        let sizes = [ 2.; 4.; 6.; 8.; 16.; 32. ]

        HStack(5.) {
            for item in sizes do
                Border()
                    .width(item)
                    .height(item)
                    .cornerRadius(item / 2.0)
                    .background(
                        if item = model.Size then
                            SolidColorBrush(Colors.Black)
                        else
                            SolidColorBrush(Colors.Gray)
                    )
                    .onPointerPressed(fun _ -> PointerPressed item)
        }

module Setting =
    type Model =
        { ColorPicker: ColorPicker.Model
          SizePicker: SizePicker.Model }

    type Msg =
        | ColorPickerMsg of ColorPicker.Msg
        | SizePickerMsg of SizePicker.Msg

    let initModel =
        { ColorPicker = ColorPicker.init()
          SizePicker = SizePicker.init() }

    let init () = initModel

    let update msg model =
        match msg with
        | ColorPickerMsg msg ->
            let colorPicker = ColorPicker.update msg model.ColorPicker
            { model with ColorPicker = colorPicker }

        | SizePickerMsg msg ->
            let sizePicker = SizePicker.update msg model.SizePicker
            { model with SizePicker = sizePicker }

    let view (model: Model) =
        Border(
            Dock(false) {
                View.map ColorPickerMsg (ColorPicker.view(model.ColorPicker).dock(Dock.Left))
                View.map SizePickerMsg (SizePicker.view(model.SizePicker).dock(Dock.Right))
            }
        )
            .dock(Dock.Bottom)
            .margin(5.0)
            .padding(5.0)
            .cornerRadius(8.0)
            .background("#bdc3c7")


module DrawingCanvas =
    type Model =
        { IsPressed: bool
          LastPoint: Point option
          Color: Color
          Size: float }

    type Msg =
        | PointerPressed of Input.PointerPressedEventArgs
        | PointerReleased of Input.PointerReleasedEventArgs
        | PointerMoved of Input.PointerEventArgs

    let init () =
        { IsPressed = false
          LastPoint = None
          Color = Colors.Black
          Size = 2. }

    let canvasRef = ViewRef<Canvas>()

    let update msg model =
        match msg with
        | PointerPressed _ -> { model with IsPressed = true }
        | PointerReleased _ -> { model with IsPressed = false }
        | PointerMoved args ->
            let point = args.GetPosition(canvasRef.Value)

            if model.IsPressed then
                match model.LastPoint with
                | Some lastPoint ->
                    let brush = unbox(ColorToBrushConverter.Convert(box(model.Color), typeof<IBrush>))

                    let line =
                        Shapes.Line(StartPoint = lastPoint, EndPoint = point, Stroke = brush, StrokeThickness = model.Size, StrokeLineCap = PenLineCap.Round)

                    if canvasRef.Value <> null then
                        canvasRef.Value.Children.Add(line)

                    { model with LastPoint = Some point }
                | None -> { model with LastPoint = Some point }
            else
                { model with LastPoint = Some point }

    let view () =
        Canvas(canvasRef)
            .verticalAlignment(VerticalAlignment.Stretch)
            .horizontalAlignment(HorizontalAlignment.Stretch)
            .background(SolidColorBrush(Colors.White))
            .onPointerPressed(PointerPressed)
            .onPointerReleased(PointerReleased)
            .onPointerMoved(PointerMoved)

module App =
    type Model =
        { Setting: Setting.Model
          DrawingCanvas: DrawingCanvas.Model }

    type Msg =
        | SettingMsg of Setting.Msg
        | DrawingCanvasMsg of DrawingCanvas.Msg

    let init () =
        { Setting = Setting.initModel
          DrawingCanvas = DrawingCanvas.init() },
        Cmd.none

    let update msg model =
        match msg with
        | SettingMsg msg ->
            let setting = Setting.update msg model.Setting
            { model with Setting = setting }, Cmd.none

        | DrawingCanvasMsg msg ->
            let drawingCanvas =
                { model.DrawingCanvas with
                    Color = model.Setting.ColorPicker.Color
                    Size = model.Setting.SizePicker.Size }

            let drawingCanvas = DrawingCanvas.update msg drawingCanvas

            { model with
                DrawingCanvas = drawingCanvas },
            Cmd.none

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

    let content () =
        Component("App") {
            let! model = Context.Mvu program

            (Dock() {
                View.map SettingMsg (Setting.view(model.Setting).dock(Dock.Bottom))
                View.map DrawingCanvasMsg (DrawingCanvas.view().dock(Dock.Top))
            })
                .background(SolidColorBrush(Colors.White))
        }

    let view () =
#if MOBILE
        SingleViewApplication(content())
#else
        DesktopApplication() {
            Window(content())
#if DEBUG
                .attachDevTools()
#endif
        }
#endif

    let create () =

        FabulousAppBuilder.Configure(FluentTheme, view)
