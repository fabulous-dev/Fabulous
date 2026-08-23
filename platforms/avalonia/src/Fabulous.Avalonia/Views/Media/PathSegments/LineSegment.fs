namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabLineSegment =
    inherit IFabPathSegment

module LineSegment =
    let WidgetKey = Widgets.register<LineSegment>()

    let Point = Attributes.defineAvaloniaPropertyWithEquality LineSegment.PointProperty

[<AutoOpen>]
module LineSegmentBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates a LineSegment widget.</summary>
        /// <param name="point">The point to draw the line to.</param>
        static member LineSegment(point: Point) =
            WidgetBuilder<'msg, IFabLineSegment>(LineSegment.WidgetKey, LineSegment.Point.WithValue(point))


type LineSegmentModifiers =

    /// <summary>Link a ViewRef to access the direct LineSegment control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabLineSegment>, value: ViewRef<LineSegment>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
