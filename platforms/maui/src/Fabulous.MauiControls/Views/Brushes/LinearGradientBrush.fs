namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IFabLinearGradientBrush =
    inherit IFabGradientBrush

module LinearGradientBrush =
    let WidgetKey = Widgets.register<LinearGradientBrush>()

    let StartPoint =
        Attributes.defineBindableWithEquality<Point> LinearGradientBrush.StartPointProperty

    let EndPoint =
        Attributes.defineBindableWithEquality<Point> LinearGradientBrush.EndPointProperty

[<AutoOpen>]
module LinearGradientBrushBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a LinearGradientBrush widgets that paints an area with a linear gradient, which blends two or more colors along a line known as the gradient axis</summary>
        static member inline LinearGradientBrush<'msg when 'msg: equality>() =
            CollectionBuilder<'msg, IFabLinearGradientBrush, IFabGradientStop>(LinearGradientBrush.WidgetKey, GradientBrush.Children)

        /// <summary>Create a LinearGradientBrush widgets that paints an area with a linear gradient, which blends two or more colors along a line known as the gradient axis</summary>
        /// <param name="endPoint">EndPoint, of type Point, which represents the ending two-dimensional coordinates of the linear gradient</param>
        /// <param name="startPoint">StartPoint, of type Point, which represents the starting two-dimensional coordinates of the linear gradient</param>
        static member inline LinearGradientBrush<'msg when 'msg: equality>(startPoint: Point, endPoint: Point) =
            CollectionBuilder<'msg, IFabLinearGradientBrush, IFabGradientStop>(
                LinearGradientBrush.WidgetKey,
                GradientBrush.Children,
                LinearGradientBrush.StartPoint.WithValue(startPoint),
                LinearGradientBrush.EndPoint.WithValue(endPoint)
            )
