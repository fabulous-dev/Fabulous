namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type ILineSegment =
    inherit Fabulous.Maui.IPathSegment

module LineSegment =
    let WidgetKey = Widgets.register<LineSegment>()

    let Point =
        Attributes.defineBindableWithEquality<Point> LineSegment.PointProperty

[<AutoOpen>]
module LineSegmentBuilders =

    type Fabulous.Maui.View with
        static member inline LineSegment<'msg>(point: Point) =
            WidgetBuilder<'msg, ILineSegment>(LineSegment.WidgetKey, LineSegment.Point.WithValue(point))
