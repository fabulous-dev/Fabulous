namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms
open Xamarin.Forms.Shapes

type IRoundRectangleGeometry =
    inherit IGeometry

module RoundRectangleGeometry =

    let WidgetKey =
        Widgets.register<RoundRectangleGeometry> ()

    let CornerRadius =
        Attributes.defineBindable<float> RoundRectangleGeometry.CornerRadiusProperty

    let Rect =
        Attributes.defineBindable<Rect> RoundRectangleGeometry.RectProperty

[<AutoOpen>]
module RoundRectangleGeometryBuilders =
    type Fabulous.XamarinForms.View with
        static member inline RoundRectangleGeometry<'msg>(cornerRadius: float, rect: Rect) =
            WidgetBuilder<'msg, IRoundRectangleGeometry>(
                RoundRectangleGeometry.WidgetKey,
                RoundRectangleGeometry.CornerRadius.WithValue(cornerRadius),
                RoundRectangleGeometry.Rect.WithValue(rect)
            )
