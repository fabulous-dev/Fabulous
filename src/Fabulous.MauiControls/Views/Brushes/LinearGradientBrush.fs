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
        
    let StartPointString =
        Attributes.defineSimpleScalarWithEquality<string>
            "LinearGradientBrush_StartPointString"
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(LinearGradientBrush.StartPointProperty)
                | ValueSome value ->
                    target.SetValue(
                        LinearGradientBrush.StartPointProperty,
                        PointConverter()
                            .ConvertFromInvariantString(value)
                    ))

    let EndPoint =
        Attributes.defineBindableWithEquality<Point> LinearGradientBrush.EndPointProperty
        
    let EndPointString =
        Attributes.defineSimpleScalarWithEquality<string>
            "LinearGradientBrush_EndPointString"
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(LinearGradientBrush.EndPointProperty)
                | ValueSome value ->
                    target.SetValue(
                        LinearGradientBrush.EndPointProperty,
                        PointConverter()
                            .ConvertFromInvariantString(value)
                    ))


[<AutoOpen>]
module LinearGradientBrushBuilders =
    type Fabulous.Maui.View with
        /// <summary>LinearGradientBrush paints an area with a linear gradient, which blends two or more colors along a line known as the gradient axis. </summary>
        /// <param name="endPoint">EndPoint, of type Point, which represents the ending two-dimensional coordinates of the linear gradient. The default value of this property is (1,1).</param>
        /// <param name="startPoint">StartPoint, of type Point, which represents the starting two-dimensional coordinates of the linear gradient. The default value of this property is (0,0).</param>
        static member inline LinearGradientBrush<'msg>(endPoint: Point, ?startPoint: Point) =
            match startPoint with
            | None ->
                CollectionBuilder<'msg, ILinearGradientBrush, IGradientStop>(
                    LinearGradientBrush.WidgetKey,
                    GradientBrush.Children,
                    LinearGradientBrush.StartPoint.WithValue(Point(0., 0.)),
                    LinearGradientBrush.EndPoint.WithValue(endPoint)
                )
            | Some v ->
                CollectionBuilder<'msg, ILinearGradientBrush, IGradientStop>(
                    LinearGradientBrush.WidgetKey,
                    GradientBrush.Children,
                    LinearGradientBrush.StartPoint.WithValue(v),
                    LinearGradientBrush.EndPoint.WithValue(endPoint)
                )
                
        /// <summary>LinearGradientBrush paints an area with a linear gradient, which blends two or more colors along a line known as the gradient axis. </summary>
        /// <param name="endPoint">EndPoint, of type string, which represents the ending two-dimensional coordinates of the linear gradient. The default value of this property is (1,1).</param>
        /// <param name="startPoint">StartPoint, of type string, which represents the starting two-dimensional coordinates of the linear gradient. The default value of this property is (0,0).</param>
        static member inline LinearGradientBrush<'msg>(endPoint: string, ?startPoint: string) =
            match startPoint with
            | None ->
                CollectionBuilder<'msg, ILinearGradientBrush, IGradientStop>(
                    LinearGradientBrush.WidgetKey,
                    GradientBrush.Children,
                    LinearGradientBrush.StartPointString.WithValue("0, 0"),
                    LinearGradientBrush.EndPointString.WithValue(endPoint)
                )
            | Some v ->
                CollectionBuilder<'msg, ILinearGradientBrush, IGradientStop>(
                    LinearGradientBrush.WidgetKey,
                    GradientBrush.Children,
                    LinearGradientBrush.StartPointString.WithValue(v),
                    LinearGradientBrush.EndPointString.WithValue(endPoint)
                )
