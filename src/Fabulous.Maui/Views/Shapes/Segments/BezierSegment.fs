namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IBezierSegment =
    inherit IPathSegment

module BezierSegment =
    let WidgetKey = Widgets.register<BezierSegment>()

    let Point1 =
        Attributes.defineBindableWithEquality<Point> BezierSegment.Point1Property

    let Point2 =
        Attributes.defineBindableWithEquality<Point> BezierSegment.Point2Property

    let Point3 =
        Attributes.defineBindableWithEquality<Point> BezierSegment.Point3Property

[<AutoOpen>]
module BezierSegmentBuilders =

    type Fabulous.Maui.View with
        static member inline BezierSegment<'msg>(point1: Point, point2: Point, point3: Point) =
            WidgetBuilder<'msg, IBezierSegment>(
                BezierSegment.WidgetKey,
                BezierSegment.Point1.WithValue(point1),
                BezierSegment.Point2.WithValue(point2),
                BezierSegment.Point3.WithValue(point3)
            )
