namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IEllipseGeometry =
    inherit Fabulous.Maui.IGeometry

module EllipseGeometry =
    let WidgetKey = Widgets.register<EllipseGeometry>()

    let Center =
        Attributes.defineBindableWithEquality<Point> EllipseGeometry.CenterProperty

    let RadiusX =
        Attributes.defineBindableFloat EllipseGeometry.RadiusXProperty

    let RadiusY =
        Attributes.defineBindableFloat EllipseGeometry.RadiusYProperty

[<AutoOpen>]
module EllipseGeometryBuilders =

    type Fabulous.Maui.View with
        static member inline EllipseGeometry<'msg>(center: Point, radiusX: float, radiusY: float) =
            WidgetBuilder<'msg, IEllipseGeometry>(
                EllipseGeometry.WidgetKey,
                EllipseGeometry.Center.WithValue(center),
                EllipseGeometry.RadiusX.WithValue(radiusX),
                EllipseGeometry.RadiusY.WithValue(radiusY)
            )
