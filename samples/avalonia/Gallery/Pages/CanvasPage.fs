namespace Gallery

open System
open System.Diagnostics
open Avalonia
open Avalonia.Media
open Avalonia.Threading
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module CanvasPage =
    type Model = { Time: DateTime }

    type Msg = Update of DateTime

    let timer () =
        Cmd.ofEffect(fun dispatch ->
            DispatcherTimer.Run(
                Func<bool>(fun _ ->
                    dispatch(Update(DateTime.Now))
                    true),
                TimeSpan.FromMilliseconds 1000.0
            )
            |> ignore)

    let init () = { Time = DateTime.Now }, timer()

    type PointerType =
        | Hour
        | Minute
        | Second

    let calcPointerPosition (pointer: PointerType, time: DateTime) : Point =
        let percent =
            match pointer with
            | Hour -> (float time.Hour) / 12.0
            | Minute -> (float time.Minute) / 60.0
            | Second -> (float time.Second) / 60.0

        let length =
            match pointer with
            | Hour -> 50.0
            | Minute -> 60.0
            | Second -> 70.0

        let angle = 2.0 * Math.PI * percent
        let handX = (100.0 + length * cos(angle - Math.PI / 2.0))
        let handY = (100.0 + length * sin(angle - Math.PI / 2.0))
        Point(handX, handY)

    let update msg model =
        match msg with
        | Update res -> { Time = res }, Cmd.none

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
        Component("CanvasPage") {
            let! model = Context.Mvu program

            VStack(spacing = 15.) {
                TextBlock("A panel which lays out its children by explicit coordinates")

                (Canvas() {
                    Rectangle(10., 10.)
                        .size(63., 41.)
                        .fill(SolidColorBrush(Colors.Blue))
                        .canvasLeft(40.)
                        .canvasTop(31.)
                        .opacityMask(
                            LinearGradientBrush(RelativePoint.Center, RelativePoint.BottomRight) {
                                GradientStop(Colors.Black, 0.)
                                GradientStop(Colors.Transparent, 1.0)
                            }
                        )

                    Rectangle(10., 5.)
                        .size(40., 20.)
                        .fill(SolidColorBrush(Color.ToHsv(byte 240., byte 83., byte 73., byte 90.).ToRgb()))
                        .stroke(SolidColorBrush(Color.ToHsl(byte 5., byte 85., byte 85.).ToRgb()))
                        .strokeThickness(2.)
                        .canvasLeft(150.)
                        .canvasTop(10.)

                    Ellipse()
                        .size(58., 58.)
                        .fill(SolidColorBrush(Colors.Green))
                        .canvasLeft(88.)
                        .canvasTop(100.)

                    Path("M 0,0 c 0,0 50,0 50,-50 c 0,0 50,0 50,50 h -50 v 50 l -50,-50 Z")
                        .fill(SolidColorBrush(Colors.Orange))
                        .canvasLeft(30.)
                        .canvasTop(250.)


                    Path(
                        PathGeometry(FillRule.NonZero) {
                            PathFigure(Point(0., 0.)) {
                                QuadraticBezierSegment(Point(50., 0.), Point(50., -50.))
                                QuadraticBezierSegment(Point(100., -50.), Point(100., 0.))
                                LineSegment(Point(50., 0.))
                                LineSegment(Point(50., 50.))

                            }
                        }
                    )
                        .fill(SolidColorBrush(Colors.OrangeRed))
                        .canvasLeft(180.)
                        .canvasTop(250.)


                    Line(Point(120., 185.), Point(30., 115.))
                        .stroke(SolidColorBrush(Colors.Red))
                        .strokeThickness(2.)

                    Polygon(
                        [ Point(75., 0.)
                          Point(120., 120.)
                          Point(0., 45.)
                          Point(150., 45.)
                          Point(30., 120.) ]
                    )
                        .stroke(SolidColorBrush(Colors.DarkBlue))
                        .strokeThickness(1.)
                        .fill(SolidColorBrush(Colors.Violet))
                        .canvasLeft(150.)
                        .canvasTop(31.)

                    Polyline(
                        [ Point(0., 0.)
                          Point(65., 0.)
                          Point(78., -26.)
                          Point(91., 39.)
                          Point(104., -39.)
                          Point(117., 13.)
                          Point(130., 0.)
                          Point(195., 0.) ]
                    )
                        .stroke(SolidColorBrush(Colors.Brown))
                        .canvasLeft(30.)
                        .canvasTop(350.)
                })
                    .background(SolidColorBrush(Colors.Yellow))
                    .size(300., 400.)

                Border()
                    .height(920.)
                    .width(920.)
                    .padding(8.)
                    .background(Brushes.Magenta)
                    .opacityMask(
                        VisualBrush(
                            Border(
                                Grid(coldefs = [ Star; Star; Star ], rowdefs = [ Star; Star; Star ]) {
                                    Border().background(SolidColorBrush(Colors.Aqua))

                                    Border().gridRow(1).background(SolidColorBrush(Colors.Aqua))

                                    Border().gridRow(2).background(SolidColorBrush(Colors.Aqua))

                                    Border()
                                        .gridColumn(1)
                                        .background(SolidColorBrush(Colors.Aqua))
                                }
                            )
                                .height(200.)
                                .width(200.)
                                .padding(20.)

                        )
                            .stretch(Stretch.Fill)
                            .tileMode(TileMode.None)
                    )


                (Canvas() {
                    Ellipse()
                        .canvasTop(10.)
                        .canvasLeft(10.)
                        .width(180.)
                        .height(180.)
                        .fill(SolidColorBrush(Color.Parse("#ecf0f1")))

                    Line(Point(100., 100.), calcPointerPosition(Second, model.Time))
                        .strokeThickness(2.)
                        .stroke(SolidColorBrush(Color.Parse("#e74c3c")))

                    Line(Point(100., 100.), calcPointerPosition(Minute, model.Time))
                        .strokeThickness(4.)
                        .stroke(SolidColorBrush(Color.Parse("#7f8c8d")))

                    Line(Point(100., 100.), calcPointerPosition(Hour, model.Time))
                        .strokeThickness(6.)
                        .stroke(SolidColorBrush(Colors.Black))

                    Ellipse()
                        .canvasTop(95.)
                        .canvasLeft(95.)
                        .width(10.)
                        .height(10.)
                        .fill(SolidColorBrush(Color.Parse("#95a5a6")))
                })
                    .background(SolidColorBrush(Color.Parse("#2c3e50")))
                    .size(200., 200.)
            }
        }
