namespace Fabulous.Maui

open System.Drawing
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type ILinearGradientBrush =
    inherit IGradientBrush

module LinearGradientBrush =

    let WidgetKey = Widgets.register<LinearGradientBrush>()

    let StartPoint =
        Attributes.defineBindableWithEquality<Point> LinearGradientBrush.StartPointProperty

    let EndPoint =
        Attributes.defineBindableWithEquality<Point> LinearGradientBrush.EndPointProperty

[<AutoOpen>]
module LinearGradientBrushBuilders =
    type Fabulous.Maui.View with
        /// <summary>LinearGradientBrush paints an area with a linear gradient, which blends two or more colors along a line known as the gradient axis. </summary>
        /// <param name="endPoint">EndPoint, of type Point, which represents the ending two-dimensional coordinates of the linear gradient. The default value of this property is (1,1).</param>
        /// <param name="startPoint">StartPoint, of type Point, which represents the starting two-dimensional coordinates of the linear gradient. The default value of this property is (0,0).</param>
        static member inline LinearGradientBrush<'msg>(?startPoint: Point, ?endPoint: Point) =
            match startPoint, endPoint with
            | Some s, None ->
                CollectionBuilder<'msg, ILinearGradientBrush, IGradientStop>(
                    LinearGradientBrush.WidgetKey,
                    GradientBrush.Children,
                    LinearGradientBrush.StartPoint.WithValue(s),
                    LinearGradientBrush.EndPoint.WithValue(Point(1., 1.))
                )
            | None, Some e ->
                CollectionBuilder<'msg, ILinearGradientBrush, IGradientStop>(
                    LinearGradientBrush.WidgetKey,
                    GradientBrush.Children,
                    LinearGradientBrush.StartPoint.WithValue(Point(0., 0.)),
                    LinearGradientBrush.EndPoint.WithValue(e)
                )
            | Some s, Some e ->
                CollectionBuilder<'msg, ILinearGradientBrush, IGradientStop>(
                    LinearGradientBrush.WidgetKey,
                    GradientBrush.Children,
                    LinearGradientBrush.StartPoint.WithValue(s),
                    LinearGradientBrush.EndPoint.WithValue(e)
                )

            | None, None ->
                CollectionBuilder<'msg, ILinearGradientBrush, IGradientStop>(
                    LinearGradientBrush.WidgetKey,
                    GradientBrush.Children,
                    LinearGradientBrush.StartPoint.WithValue(Point(0., 0.)),
                    LinearGradientBrush.EndPoint.WithValue(Point(1., 1.))
                )
