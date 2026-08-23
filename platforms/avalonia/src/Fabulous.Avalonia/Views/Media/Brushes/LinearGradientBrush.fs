namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabLinearGradientBrush =
    inherit IFabGradientBrush

module LinearGradientBrush =
    let WidgetKey = Widgets.register<LinearGradientBrush>()

    let StartPoint =
        Attributes.defineAvaloniaPropertyWithEquality LinearGradientBrush.StartPointProperty

    let EndPoint =
        Attributes.defineAvaloniaPropertyWithEquality LinearGradientBrush.EndPointProperty

[<AutoOpen>]
module LinearGradientBrushBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a LinearGradientBrush widget.</summary>
        /// <param name="startPoint">The start point of the gradient.</param>
        /// <param name="endPoint">The end point of the gradient.</param>
        static member LinearGradientBrush(startPoint: RelativePoint, endPoint: RelativePoint) =
            CollectionBuilder<'msg, IFabLinearGradientBrush, IFabGradientStop>(
                LinearGradientBrush.WidgetKey,
                ComponentGradientBrush.GradientStops,
                LinearGradientBrush.StartPoint.WithValue(startPoint),
                LinearGradientBrush.EndPoint.WithValue(endPoint)
            )

        /// <summary>Creates a LinearGradientBrush widget.</summary>
        /// <param name="startPoint">The start point of the gradient.</param>
        /// <param name="endPoint">The end point of the gradient.</param>
        static member LinearGradientBrush'(startPoint: RelativePoint, endPoint: RelativePoint) =
            WidgetBuilder<'msg, IFabLinearGradientBrush>(
                LinearGradientBrush.WidgetKey,
                LinearGradientBrush.StartPoint.WithValue(startPoint),
                LinearGradientBrush.EndPoint.WithValue(endPoint)
            )

        /// <summary>Creates a LinearGradientBrush widget.</summary>
        /// <param name="startPoint">The start point of the gradient.</param>
        /// <param name="endPoint">The end point of the gradient.</param>
        /// <param name="unit">The relative unit of the start and end points.</param>
        static member LinearGradientBrush(startPoint: Point, endPoint: Point, unit: RelativeUnit) =
            CollectionBuilder<'msg, IFabLinearGradientBrush, IFabGradientStop>(
                LinearGradientBrush.WidgetKey,
                ComponentGradientBrush.GradientStops,
                LinearGradientBrush.StartPoint.WithValue(RelativePoint(startPoint, unit)),
                LinearGradientBrush.EndPoint.WithValue(RelativePoint(endPoint, unit))
            )

        /// <summary>Creates a LinearGradientBrush widget.</summary>
        /// <param name="startPoint">The start point of the gradient.</param>
        /// <param name="endPoint">The end point of the gradient.</param>
        static member LinearGradientBrush(startPoint: Point, endPoint: Point) =
            let startPoint = RelativePoint(startPoint, RelativeUnit.Relative)
            let endPoint = RelativePoint(endPoint, RelativeUnit.Relative)
            View.LinearGradientBrush(startPoint, endPoint)

        /// <summary>Creates a LinearGradientBrush widget.</summary>
        /// <param name="startPoint">The start point of the gradient.</param>
        /// <param name="endPoint">The end point of the gradient.</param>
        /// <param name="startUnit">The relative unit of the start point.</param>
        /// <param name="endUnit">The relative unit of the end point.</param>
        static member LinearGradientBrush(startPoint: Point, endPoint: Point, startUnit: RelativeUnit, endUnit: RelativeUnit) =
            CollectionBuilder<'msg, IFabLinearGradientBrush, IFabGradientStop>(
                LinearGradientBrush.WidgetKey,
                ComponentGradientBrush.GradientStops,
                LinearGradientBrush.StartPoint.WithValue(RelativePoint(startPoint, startUnit)),
                LinearGradientBrush.EndPoint.WithValue(RelativePoint(endPoint, endUnit))
            )

        /// <summary>Creates a LinearGradientBrush widget.</summary>
        static member LinearGradientBrush() =
            CollectionBuilder<'msg, IFabLinearGradientBrush, IFabGradientStop>(
                LinearGradientBrush.WidgetKey,
                ComponentGradientBrush.GradientStops,
                LinearGradientBrush.StartPoint.WithValue(RelativePoint.TopLeft),
                LinearGradientBrush.EndPoint.WithValue(RelativePoint.BottomRight)
            )

        /// <summary>Creates a LinearGradientBrush widget.</summary>
        static member LinearGradientBrush'() =
            WidgetBuilder<'msg, IFabLinearGradientBrush>(
                LinearGradientBrush.WidgetKey,
                LinearGradientBrush.StartPoint.WithValue(RelativePoint.TopLeft),
                LinearGradientBrush.EndPoint.WithValue(RelativePoint.BottomRight)
            )

type LinearGradientBrushModifiers =
    /// <summary>Link a ViewRef to access the direct LinearGradientBrush control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabLinearGradientBrush>, value: ViewRef<LinearGradientBrush>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
