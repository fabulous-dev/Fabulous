namespace Fabulous.XamarinForms

open System
open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms
open Xamarin.Forms.Shapes

type IRoundRectangleGeometry =
    inherit IGeometryGroup

module RoundRectangleGeometry =

    let WidgetKey =
        Widgets.register<RoundRectangleGeometry>()

    let CornerRadius =
        Attributes.defineBindableWithEquality<Xamarin.Forms.CornerRadius> RoundRectangleGeometry.CornerRadiusProperty

    let Rect =
        Attributes.defineBindableWithEquality<Rect> RoundRectangleGeometry.RectProperty

    let FillRule =
        Attributes.defineBindableEnum<FillRule> RoundRectangleGeometry.FillRuleProperty

[<AutoOpen>]
module RoundRectangleGeometryBuilders =
    type Fabulous.XamarinForms.View with
        [<Obsolete("Use RoundRectangleGeometry(cornerRadius: CornerRadius, rect: Rect) instead")>]
        static member inline RoundRectangleGeometry<'msg>(cornerRadius: float, rect: Rect) =
            WidgetBuilder<'msg, IRoundRectangleGeometry>(
                RoundRectangleGeometry.WidgetKey,
                RoundRectangleGeometry.CornerRadius.WithValue(CornerRadius(cornerRadius)),
                RoundRectangleGeometry.Rect.WithValue(rect)
            )

        static member inline RoundRectangleGeometry<'msg>(cornerRadius: CornerRadius, rect: Rect) =
            WidgetBuilder<'msg, IRoundRectangleGeometry>(
                RoundRectangleGeometry.WidgetKey,
                RoundRectangleGeometry.CornerRadius.WithValue(cornerRadius),
                RoundRectangleGeometry.Rect.WithValue(rect)
            )

[<Extension>]
type RoundRectangleGeometryModifiers =

    [<Extension>]
    static member inline fillRule(this: WidgetBuilder<'msg, #IRoundRectangleGeometry>, value: FillRule) =
        this.AddScalar(RoundRectangleGeometry.FillRule.WithValue(value))
