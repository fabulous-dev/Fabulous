namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms
open Xamarin.Forms.Shapes

type ILine =
    inherit IShape

module Line =

    let WidgetKey = Widgets.register<Line>()

    let Points =
        Attributes.defineSimpleScalarWithEquality<struct (Point * Point)>
            "Line_Point1"
            (fun _ newValueOpt node ->
                let line = node.Target :?> Line

                match newValueOpt with
                | ValueNone ->
                    line.X1 <- 0.
                    line.Y1 <- 0.
                    line.X2 <- 0.
                    line.Y2 <- 0.
                | ValueSome (startPoint, endPoint) ->
                    line.X1 <- startPoint.X
                    line.Y1 <- startPoint.Y
                    line.X2 <- endPoint.X
                    line.Y2 <- endPoint.Y)

[<AutoOpen>]
module LineBuilders =

    type Fabulous.XamarinForms.View with
        static member inline Line<'msg>
            (
                startPoint: Point,
                endPoint: Point,
                strokeThickness: float,
                strokeLight: Brush,
                ?strokeDark: Brush
            ) =
            WidgetBuilder<'msg, ILine>(
                Line.WidgetKey,
                Line.Points.WithValue(struct (startPoint, endPoint)),
                Shape.StrokeThickness.WithValue(strokeThickness),
                Shape.Stroke.WithValue(AppTheme.create strokeLight strokeDark)
            )


[<Extension>]
type LineModifiers =
    /// <summary>Link a ViewRef to access the direct Line control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, ILine>, value: ViewRef<Line>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
