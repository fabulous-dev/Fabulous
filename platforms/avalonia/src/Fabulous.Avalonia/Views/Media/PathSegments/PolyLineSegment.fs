namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabPolyLineSegment =
    inherit IFabPathSegment

module PolyLineSegment =
    let WidgetKey = Widgets.register<PolyLineSegment>()

    let Points =
        Attributes.defineAvaloniaPropertyWithEquality PolyLineSegment.PointsProperty

[<AutoOpen>]
module PolyLineSegmentBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates a PolyLineSegment widget.</summary>
        /// <param name="points">The points of the polyline.</param>
        static member PolyLineSegment(points: Point list) =
            WidgetBuilder<'msg, IFabPolyLineSegment>(PolyLineSegment.WidgetKey, PolyLineSegment.Points.WithValue(points |> Array.ofList))

type PolyLineSegmentModifiers =

    /// <summary>Link a ViewRef to access the direct PolyLineSegment control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPolyLineSegment>, value: ViewRef<PolyLineSegment>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
