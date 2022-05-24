namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms
open Xamarin.Forms.Shapes

type ILineGeometry =
    inherit IGeometry

module LineGeometry =
    let WidgetKey = Widgets.register<LineGeometry>()

    let StartPoint =
        Attributes.defineBindableWithEquality<Point> LineGeometry.StartPointProperty

    let EndPoint =
        Attributes.defineBindableWithEquality<Point> LineGeometry.EndPointProperty

[<AutoOpen>]
module LineGeometryBuilders =
    type Fabulous.XamarinForms.View with
        static member inline LineGeometry<'msg>(start: Point, end': Point) =
            WidgetBuilder<'msg, ILineGeometry>(
                LineGeometry.WidgetKey,
                LineGeometry.StartPoint.WithValue(start),
                LineGeometry.EndPoint.WithValue(end')
            )
