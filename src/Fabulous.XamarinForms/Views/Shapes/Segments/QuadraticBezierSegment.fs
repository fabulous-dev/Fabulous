namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms
open Xamarin.Forms.Shapes

type IQuadraticBezierSegment =
    inherit IPathSegment

module QuadraticBezierSegment =
    let WidgetKey =
        Widgets.register<QuadraticBezierSegment>()

    let Point1 =
        Attributes.defineBindable<Point> QuadraticBezierSegment.Point1Property

    let Point2 =
        Attributes.defineBindable<Point> QuadraticBezierSegment.Point2Property

[<AutoOpen>]
module QuadraticBezierSegmentBuilders =

    type Fabulous.XamarinForms.View with
        static member inline QuadraticBezierSegment<'msg>(point1: Point, point2: Point) =
            WidgetBuilder<'msg, IQuadraticBezierSegment>(
                QuadraticBezierSegment.WidgetKey,
                QuadraticBezierSegment.Point1.WithValue(point1),
                QuadraticBezierSegment.Point2.WithValue(point2)
            )
