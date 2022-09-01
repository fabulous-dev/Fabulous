namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type ILineGeometry =
    inherit Fabulous.Maui.IGeometry

module LineGeometry =
    let WidgetKey = Widgets.register<LineGeometry>()

    let StartPoint =
        Attributes.defineBindableWithEquality<Point> LineGeometry.StartPointProperty

    let EndPoint =
        Attributes.defineBindableWithEquality<Point> LineGeometry.EndPointProperty

[<AutoOpen>]
module LineGeometryBuilders =
    type Fabulous.Maui.View with
        static member inline LineGeometry<'msg>(start: Point, end': Point) =
            WidgetBuilder<'msg, ILineGeometry>(
                LineGeometry.WidgetKey,
                LineGeometry.StartPoint.WithValue(start),
                LineGeometry.EndPoint.WithValue(end')
            )
