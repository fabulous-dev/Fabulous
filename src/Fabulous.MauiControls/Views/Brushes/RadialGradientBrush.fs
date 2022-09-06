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
        /// <summary>RadialGradientBrush paints an area with a linear gradient, which blends two or more colors along a line known as the gradient axis. </summary>
        /// <param name="endPoint">EndPoint, of type Point, which represents the ending two-dimensional coordinates of the linear gradient. The default value of this property is (1,1).</param>
        /// <param name="startPoint">StartPoint, of type Point, which represents the starting two-dimensional coordinates of the linear gradient. The default value of this property is (0,0).</param>
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
