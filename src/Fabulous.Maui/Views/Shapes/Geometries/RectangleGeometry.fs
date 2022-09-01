namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IRectangleGeometry =
    inherit IGeometry

module RectangleGeometry =
    let WidgetKey = Widgets.register<RectangleGeometry>()

    let Rect =
        Attributes.defineBindableWithEquality<Rect> RectangleGeometry.RectProperty

[<AutoOpen>]
module RectangleGeometryBuilders =
    type Fabulous.Maui.View with
        static member inline RectangleGeometry<'msg>(rect: Rect) =
            WidgetBuilder<'msg, IRectangleGeometry>(RectangleGeometry.WidgetKey, RectangleGeometry.Rect.WithValue(rect))
