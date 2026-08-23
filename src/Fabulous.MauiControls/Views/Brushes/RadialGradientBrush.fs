namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IFabRadialGradientBrush =
    inherit IFabGradientBrush

module RadialGradientBrush =
    let WidgetKey = Widgets.register<RadialGradientBrush>()

    let Center =
        Attributes.defineBindableWithEquality<Point> RadialGradientBrush.CenterProperty

    let Radius = Attributes.defineBindableFloat RadialGradientBrush.RadiusProperty

[<AutoOpen>]
module RadialGradientBrushBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a RadialGradientBrush widget that paints an area with a radial gradient, which blends two or more colors across a circle</summary>
        /// <param name="center">Center, of type Point, which represents the center point of the circle for the radial gradient</param>
        /// <param name="radius">Radius, of type float, which represents the radius of the circle for the radial gradient</param>
        static member inline RadialGradientBrush<'msg when 'msg: equality>(center: Point, radius: float) =
            CollectionBuilder<'msg, IFabRadialGradientBrush, IFabGradientStop>(
                RadialGradientBrush.WidgetKey,
                GradientBrush.Children,
                RadialGradientBrush.Center.WithValue(center),
                RadialGradientBrush.Radius.WithValue(radius)
            )

        /// <summary>Create a RadialGradientBrush widget that paints an area with a radial gradient, which blends two or more colors across a circle</summary>
        static member inline RadialGradientBrush<'msg when 'msg: equality>() =
            CollectionBuilder<'msg, IFabRadialGradientBrush, IFabGradientStop>(RadialGradientBrush.WidgetKey, GradientBrush.Children)
