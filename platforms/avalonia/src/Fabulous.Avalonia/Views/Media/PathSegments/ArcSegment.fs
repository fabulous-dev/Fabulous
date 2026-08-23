namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabArcSegment =
    inherit IFabPathSegment

module ArcSegment =
    let WidgetKey = Widgets.register<ArcSegment>()

    let IsLargeArc =
        Attributes.defineAvaloniaPropertyWithEquality ArcSegment.IsLargeArcProperty

    let Point = Attributes.defineAvaloniaPropertyWithEquality ArcSegment.PointProperty

    let RotationAngle =
        Attributes.defineAvaloniaPropertyWithEquality ArcSegment.RotationAngleProperty

    let Size = Attributes.defineAvaloniaPropertyWithEquality ArcSegment.SizeProperty

    let SweepDirection =
        Attributes.defineAvaloniaPropertyWithEquality ArcSegment.SweepDirectionProperty

[<AutoOpen>]
module ArcSegmentBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates a ArcSegment widget.</summary>
        /// <param name="point">The point at which the arc ends.</param>
        /// <param name="size">The size of the arc.</param>
        static member ArcSegment(point: Point, size: Size) =
            WidgetBuilder<'msg, IFabArcSegment>(ArcSegment.WidgetKey, ArcSegment.Point.WithValue(point), ArcSegment.Size.WithValue(size))

type ArcSegmentModifiers =

    /// <summary>Sets the RotationAngle property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The RotationAngle value.</param>
    [<Extension>]
    static member inline rotationAngle(this: WidgetBuilder<'msg, #IFabArcSegment>, value: float) =
        this.AddScalar(ArcSegment.RotationAngle.WithValue(value))

    /// <summary>Sets the SweepDirection property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SweepDirection value.</param>
    [<Extension>]
    static member inline sweepDirection(this: WidgetBuilder<'msg, #IFabArcSegment>, value: SweepDirection) =
        this.AddScalar(ArcSegment.SweepDirection.WithValue(value))

    /// <summary>Sets the IsLargeArc property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsLargeArc value.</param>
    [<Extension>]
    static member inline isLargeArc(this: WidgetBuilder<'msg, #IFabArcSegment>, value: bool) =
        this.AddScalar(ArcSegment.IsLargeArc.WithValue(value))

    /// <summary>Link a ViewRef to access the direct ArcSegment control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabArcSegment>, value: ViewRef<ArcSegment>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
