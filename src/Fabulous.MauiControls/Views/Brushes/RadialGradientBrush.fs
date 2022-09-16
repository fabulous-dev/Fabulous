namespace Fabulous.Maui

open System.Drawing
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IRadialGradientBrush =
    inherit IGradientBrush

module RadialGradientBrush =

    let WidgetKey = Widgets.register<RadialGradientBrush>()

    let Center =
        Attributes.defineBindableWithEquality<Point> RadialGradientBrush.CenterProperty

    let Radius =
        Attributes.defineBindableFloat RadialGradientBrush.RadiusProperty

[<AutoOpen>]
module RadialGradientBrushBuilders =
    type Fabulous.Maui.View with
        /// <summary>RadialGradientBrush paints an area with a radial gradient, which blends two or more colors across a circle.</summary>
        /// <param name="center">Center, of type Point, which represents the center point of the circle for the radial gradient. The default value of this property is (0.5,0.5).</param>
        /// <param name="radius">Radius, of type float, which represents the radius of the circle for the radial gradient. The default value of this property is 0.5.</param>
        static member inline RadialGradientBrush<'msg>(?center: Point, ?radius: float) =
            match center, radius with
            | Some c, None ->
                CollectionBuilder<'msg, IRadialGradientBrush, IGradientStop>(
                    RadialGradientBrush.WidgetKey,
                    GradientBrush.Children,
                    RadialGradientBrush.Center.WithValue(c),
                    RadialGradientBrush.Radius.WithValue(0.5)
                )
            | None, Some r ->
                CollectionBuilder<'msg, IRadialGradientBrush, IGradientStop>(
                    RadialGradientBrush.WidgetKey,
                    GradientBrush.Children,
                    RadialGradientBrush.Center.WithValue(Point(0.5, 0.5)),
                    RadialGradientBrush.Radius.WithValue(r)
                )
            | Some c, Some r ->
                CollectionBuilder<'msg, IRadialGradientBrush, IGradientStop>(
                    RadialGradientBrush.WidgetKey,
                    GradientBrush.Children,
                    RadialGradientBrush.Center.WithValue(c),
                    RadialGradientBrush.Radius.WithValue(r)
                )

            | None, None ->
                CollectionBuilder<'msg, IRadialGradientBrush, IGradientStop>(
                    RadialGradientBrush.WidgetKey,
                    GradientBrush.Children,
                    RadialGradientBrush.Center.WithValue(Point(0.5, 0.5)),
                    RadialGradientBrush.Radius.WithValue(0.5)
                )
