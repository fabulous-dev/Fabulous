namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabConicGradientBrush =
    inherit IFabGradientBrush

module ConicGradientBrush =
    let WidgetKey = Widgets.register<ConicGradientBrush>()

    let Center =
        Attributes.defineAvaloniaPropertyWithEquality ConicGradientBrush.CenterProperty

    let Angle =
        Attributes.defineAvaloniaPropertyWithEquality ConicGradientBrush.AngleProperty

[<AutoOpen>]
module ConicGradientBrushBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ConicGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        /// <param name="angle">The angle of the gradient.</param>
        static member ConicGradientBrush(center: RelativePoint, angle: float) =
            CollectionBuilder<'msg, IFabConicGradientBrush, IFabGradientStop>(
                ConicGradientBrush.WidgetKey,
                ComponentGradientBrush.GradientStops,
                ConicGradientBrush.Center.WithValue(center),
                ConicGradientBrush.Angle.WithValue(angle)
            )

        /// <summary>Creates a ConicGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        static member ConicGradientBrush(center: RelativePoint) =
            CollectionBuilder<'msg, IFabConicGradientBrush, IFabGradientStop>(
                ConicGradientBrush.WidgetKey,
                ComponentGradientBrush.GradientStops,
                ConicGradientBrush.Center.WithValue(center),
                ConicGradientBrush.Angle.WithValue(0.)
            )

        /// <summary>Creates a ConicGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        /// <param name="unit">The unit of the center.</param>
        /// <param name="angle">The angle of the gradient.</param>
        static member ConicGradientBrush(center: Point, unit: RelativeUnit, angle: float) =
            CollectionBuilder<'msg, IFabConicGradientBrush, IFabGradientStop>(
                ConicGradientBrush.WidgetKey,
                ComponentGradientBrush.GradientStops,
                ConicGradientBrush.Center.WithValue(RelativePoint(center, unit)),
                ConicGradientBrush.Angle.WithValue(angle)
            )

        /// <summary>Creates a ConicGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        /// <param name="unit">The unit of the center.</param>
        static member ConicGradientBrush(center: Point, unit: RelativeUnit) =
            CollectionBuilder<'msg, IFabConicGradientBrush, IFabGradientStop>(
                ConicGradientBrush.WidgetKey,
                ComponentGradientBrush.GradientStops,
                ConicGradientBrush.Center.WithValue(RelativePoint(center, unit)),
                ConicGradientBrush.Angle.WithValue(0.)
            )

        /// <summary>Creates a ConicGradientBrush widget.</summary>
        /// <param name="angle">The angle of the gradient.</param>
        static member ConicGradientBrush(angle: float) =
            CollectionBuilder<'msg, IFabConicGradientBrush, IFabGradientStop>(
                ConicGradientBrush.WidgetKey,
                ComponentGradientBrush.GradientStops,
                ConicGradientBrush.Center.WithValue(RelativePoint.Center),
                ConicGradientBrush.Angle.WithValue(angle)
            )

        /// <summary>Creates a ConicGradientBrush widget.</summary>
        static member ConicGradientBrush() =
            CollectionBuilder<'msg, IFabConicGradientBrush, IFabGradientStop>(
                ConicGradientBrush.WidgetKey,
                ComponentGradientBrush.GradientStops,
                ConicGradientBrush.Center.WithValue(RelativePoint.Center),
                ConicGradientBrush.Angle.WithValue(0.)
            )


type ConicGradientBrushModifiers =
    /// <summary>Link a ViewRef to access the direct ConicGradientBrush control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabConicGradientBrush>, value: ViewRef<ConicGradientBrush>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
