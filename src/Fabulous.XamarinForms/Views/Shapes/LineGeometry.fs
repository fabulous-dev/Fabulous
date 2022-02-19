namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms
open Xamarin.Forms.Shapes

type ILineGeometry =
    inherit IGeometry

module LineGeometry =
    let WidgetKey = Widgets.register<LineGeometry> ()

    let StartPoint =
        Attributes.defineBindable<Point> LineGeometry.StartPointProperty

    let EndPoint =
        Attributes.defineBindable<Point> LineGeometry.EndPointProperty

[<AutoOpen>]
module LineGeometryBuilders =

    type Fabulous.XamarinForms.View with
        static member inline LineGeometry<'msg>(startPoint: Point, endPoint: Point) =
            WidgetBuilder<'msg, IEllipseGeometry>(
                LineGeometry.WidgetKey,
                LineGeometry.StartPoint.WithValue(startPoint),
                LineGeometry.EndPoint.WithValue(endPoint)
            )
