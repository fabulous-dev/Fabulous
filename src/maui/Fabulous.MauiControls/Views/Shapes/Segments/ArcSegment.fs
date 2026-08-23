namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IFabArcSegment =
    inherit IFabPathSegment

module ArcSegment =
    let WidgetKey = Widgets.register<ArcSegment>()

    let IsLargeArc = Attributes.defineBindableBool ArcSegment.IsLargeArcProperty

    let Point = Attributes.defineBindableWithEquality<Point> ArcSegment.SizeProperty

    let RotationAngle = Attributes.defineBindableFloat ArcSegment.RotationAngleProperty

    let Size = Attributes.defineBindableWithEquality<Size> ArcSegment.SizeProperty

    let SweepDirection =
        Attributes.defineBindableEnum<SweepDirection> ArcSegment.SweepDirectionProperty

[<AutoOpen>]
module ArcSegmentBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a ArcSegment widget</summary>
        /// <param name="point">The point</param>
        /// <param name="size">The size</param>
        static member inline ArcSegment<'msg when 'msg: equality>(point: Point, size: Size) =
            WidgetBuilder<'msg, IFabArcSegment>(ArcSegment.WidgetKey, ArcSegment.Point.WithValue(point), ArcSegment.Size.WithValue(size))

[<Extension>]
type ArcSegmentModifiers =
    /// <summary>Set whether the arc is large</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value indicating whether the arc is large</param>
    [<Extension>]
    static member inline isLargeArc(this: WidgetBuilder<'msg, #IFabArcSegment>, value: bool) =
        this.AddScalar(ArcSegment.IsLargeArc.WithValue(value))

    /// <summary>Set the rotation angle</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The rotation angle</param>
    [<Extension>]
    static member inline rotationAngle(this: WidgetBuilder<'msg, #IFabArcSegment>, value: float) =
        this.AddScalar(ArcSegment.RotationAngle.WithValue(value))

    /// <summary>Set the sweep direction</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The sweep direction</param>
    [<Extension>]
    static member inline sweepDirection(this: WidgetBuilder<'msg, #IFabArcSegment>, value: SweepDirection) =
        this.AddScalar(ArcSegment.SweepDirection.WithValue(value))

    /// <summary>Link a ViewRef to access the direct ArcSegment control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabArcSegment>, value: ViewRef<ArcSegment>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
