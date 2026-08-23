namespace DrawingApp

open Avalonia
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Avalonia.Themes.Fluent
open Avalonia.Layout
open Avalonia.Markup.Xaml.Converters
open Avalonia.Media

open type Fabulous.Avalonia.View
open type Fabulous.Context

module ColorPicker =
    let view (color: StateValue<Color>) =
        Component("ColorPicker") {
            let brushes = [ Colors.Black; Colors.Red; Colors.Green; Colors.Blue; Colors.Yellow ]
            let! color = Binding(color)

            HStack(5.) {
                for item in brushes do
                    Border()
                        .width(32.0)
                        .height(32.0)
                        .cornerRadius(16.0)
                        .background(SolidColorBrush(item))
                        .borderThickness(4.0)
                        .borderBrush(
                            if item = color.Current then
                                SolidColorBrush(item)
                            else
                                SolidColorBrush(Colors.Transparent)
                        )
                        .onPointerPressed(fun _ -> color.Set(item))
            }
        }


module SizePicker =
    let view (size: StateValue<float>) =
        Component("SizePicker") {
            let sizes = [ 2.; 4.; 6.; 8.; 16.; 32. ]
            let! size = Binding(size)

            HStack(5.) {
                for item in sizes do
                    Border()
                        .width(item)
                        .height(item)
                        .cornerRadius(item / 2.0)
                        .background(
                            if item = size.Current then
                                SolidColorBrush(Colors.Black)
                            else
                                SolidColorBrush(Colors.Gray)
                        )
                        .onPointerPressed(fun _ -> size.Set item)
            }
        }

module Setting =
    let view (color, size) =
        Component("Setting") {
            Border(
                Dock(false) {
                    ColorPicker.view(color).dock(Dock.Left)
                    SizePicker.view(size).dock(Dock.Right)
                }
            )
                .dock(Dock.Bottom)
                .margin(5.0)
                .padding(5.0)
                .cornerRadius(8.0)
                .background("#bdc3c7")
        }

module DrawingCanvas =
    let view (color: StateValue<Color>) (size: StateValue<float>) =
        Component("DrawingCanvas") {
            let! color = Binding(color)
            let! size = Binding(size)
            let! isPressed = State(false)
            let! lastPoint = State(Some(Point(0., 0.)))
            let canvasRef = ViewRef<Canvas>()

            Canvas(canvasRef)
                .verticalAlignment(VerticalAlignment.Stretch)
                .horizontalAlignment(HorizontalAlignment.Stretch)
                .background(SolidColorBrush(Colors.White))
                .onPointerPressed(fun _ -> isPressed.Set true)
                .onPointerReleased(fun _ -> isPressed.Set false)
                .onPointerMoved(fun args ->
                    let canvasRef = canvasRef.Value
                    let currentPoint = args.GetPosition(canvasRef)
                    let isPressed = isPressed.Current
                    lastPoint.Set(None)

                    if isPressed then
                        match lastPoint.Current with
                        | Some point ->
                            let brush = unbox(ColorToBrushConverter.Convert(box(color.Current), typeof<IBrush>))

                            let line =
                                Shapes.Line(
                                    StartPoint = point,
                                    EndPoint = currentPoint,
                                    Stroke = brush,
                                    StrokeThickness = size.Current,
                                    StrokeLineCap = PenLineCap.Round
                                )

                            if canvasRef <> null then
                                canvasRef.Children.Add(line)

                            lastPoint.Set(Some currentPoint)
                        | None -> lastPoint.Set(Some currentPoint)
                    else
                        lastPoint.Set(Some currentPoint)

                )
        }

module App =
    let content () =
        Component("App") {
            let! color = State(Colors.Black)
            let! size = State(2.)

            (Dock() {
                Setting.view(color, size).dock(Dock.Bottom)
                (DrawingCanvas.view color size).dock(Dock.Top)
            })
                .background(SolidColorBrush(Colors.White))
        }

    let view () =
#if MOBILE
        SingleViewApplication(content())
#else
        DesktopApplication() { Window(content()) }
#endif


    let create () =
        FabulousAppBuilder.Configure(FluentTheme, view)
