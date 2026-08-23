namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabPolyBezierSegment =
    inherit IFabPathSegment

module PolyBezierSegment =
    let WidgetKey = Widgets.register<PolyBezierSegment>()

    let Points =
        Attributes.defineAvaloniaPropertyWithEquality PolyBezierSegment.PointsProperty

[<AutoOpen>]
module PolyBezierSegmentBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates a PolyLineSegment widget.</summary>
        /// <param name="points">The points of the polyline.</param>
        static member PolyBezierSegment(points: Point list) =
            WidgetBuilder<'msg, IFabPolyBezierSegment>(PolyBezierSegment.WidgetKey, PolyBezierSegment.Points.WithValue(Points(points)))

type PolyBezierSegmentModifiers =

    /// <summary>Link a ViewRef to access the direct PolyBezierSegment control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPolyBezierSegment>, value: ViewRef<PolyBezierSegment>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
