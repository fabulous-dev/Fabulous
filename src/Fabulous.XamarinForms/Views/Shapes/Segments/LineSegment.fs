namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms
open Xamarin.Forms.Shapes

type ILineSegment =
    inherit IPathSegment

module LineSegment =
    let WidgetKey = Widgets.register<LineSegment>()

    let Point =
        Attributes.defineBindable<Point> LineSegment.PointProperty

[<AutoOpen>]
module LineSegmentBuilders =

    type Fabulous.XamarinForms.View with
        static member inline LineSegment<'msg>(point: Point) =
            WidgetBuilder<'msg, ILineSegment>(LineSegment.WidgetKey, LineSegment.Point.WithValue(point))
