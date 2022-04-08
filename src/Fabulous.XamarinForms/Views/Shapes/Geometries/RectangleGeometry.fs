namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms
open Xamarin.Forms.Shapes

type IRectangleGeometry =
    inherit IGeometry

module RectangleGeometry =
    let WidgetKey = Widgets.register<RectangleGeometry>()

    let Rect =
        Attributes.defineBindable<Rect> RectangleGeometry.RectProperty

[<AutoOpen>]
module RectangleGeometryBuilders =
    type Fabulous.XamarinForms.View with
        static member inline RectangleGeometry<'msg>(rect: Rect) =
            WidgetBuilder<'msg, IRectangleGeometry>(RectangleGeometry.WidgetKey, RectangleGeometry.Rect.WithValue(rect))
