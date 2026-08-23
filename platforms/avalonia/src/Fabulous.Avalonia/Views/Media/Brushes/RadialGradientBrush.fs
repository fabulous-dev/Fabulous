namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabRadialGradientBrush =
    inherit IFabGradientBrush

module RadialGradientBrush =
    let WidgetKey = Widgets.register<RadialGradientBrush>()

    let Center =
        Attributes.defineAvaloniaPropertyWithEquality RadialGradientBrush.CenterProperty

    let GradientOrigin =
        Attributes.defineAvaloniaPropertyWithEquality RadialGradientBrush.GradientOriginProperty

    let RadiusX =
        Attributes.defineAvaloniaPropertyWithEquality RadialGradientBrush.RadiusXProperty

    let RadiusY =
        Attributes.defineAvaloniaPropertyWithEquality RadialGradientBrush.RadiusYProperty

[<AutoOpen>]
module RadialGradientBrushBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        static member RadialGradientBrush(center: RelativePoint) =
            CollectionBuilder<'msg, IFabRadialGradientBrush, IFabGradientStop>(
                RadialGradientBrush.WidgetKey,
                ComponentGradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(center),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint.Center)
            )

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        /// <param name="unit">The relative unit of the center.</param>
        static member RadialGradientBrush(center: Point, unit: RelativeUnit) =
            CollectionBuilder<'msg, IFabRadialGradientBrush, IFabGradientStop>(
                RadialGradientBrush.WidgetKey,
                ComponentGradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(RelativePoint(center, unit)),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint.Center)
            )

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        /// <param name="origin">The origin of the gradient.</param>
        static member RadialGradientBrush(center: RelativePoint, origin: RelativePoint) =
            CollectionBuilder<'msg, IFabRadialGradientBrush, IFabGradientStop>(
                RadialGradientBrush.WidgetKey,
                ComponentGradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(center),
                RadialGradientBrush.GradientOrigin.WithValue(origin)
            )

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        /// <param name="origin">The origin of the gradient.</param>
        /// <param name="unit">The relative unit of the center and origin.</param>
        static member RadialGradientBrush(center: Point, origin: Point, unit: RelativeUnit) =
            CollectionBuilder<'msg, IFabRadialGradientBrush, IFabGradientStop>(
                RadialGradientBrush.WidgetKey,
                ComponentGradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(RelativePoint(center, unit)),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint(origin, unit))
            )

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        static member RadialGradientBrush() =
            CollectionBuilder<'msg, IFabRadialGradientBrush, IFabGradientStop>(
                RadialGradientBrush.WidgetKey,
                ComponentGradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(RelativePoint.Center),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint.Center)
            )

type RadialGradientBrushModifiers =

    /// <summary>Sets the RadiusX property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Radius value.</param>
    [<Extension>]
    static member inline radiusX(this: WidgetBuilder<'msg, #IFabRadialGradientBrush>, value: float) =
        this.AddScalar(RadialGradientBrush.RadiusX.WithValue(RelativeScalar(value, RelativeUnit.Relative)))

    /// <summary>Sets the RadiusX property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Radius value.</param>
    [<Extension>]
    static member inline radiusX(this: WidgetBuilder<'msg, #IFabRadialGradientBrush>, value: RelativeScalar) =
        this.AddScalar(RadialGradientBrush.RadiusX.WithValue(value))

    /// <summary>Sets the RadiusY property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Radius value.</param>
    [<Extension>]
    static member inline radiusY(this: WidgetBuilder<'msg, #IFabRadialGradientBrush>, value: float) =
        this.AddScalar(RadialGradientBrush.RadiusY.WithValue(RelativeScalar(value, RelativeUnit.Relative)))

    /// <summary>Sets the RadiusY property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Radius value.</param>
    [<Extension>]
    static member inline radiusY(this: WidgetBuilder<'msg, #IFabRadialGradientBrush>, value: RelativeScalar) =
        this.AddScalar(RadialGradientBrush.RadiusY.WithValue(value))

    /// <summary>Link a ViewRef to access the direct RadialGradientBrush control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabRadialGradientBrush>, value: ViewRef<RadialGradientBrush>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
