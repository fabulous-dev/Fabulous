namespace Fabulous.Avalonia

open System.Collections.Generic
open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Avalonia
open Fabulous

type IFabPolyline =
    inherit IFabShape

module Polyline =
    let WidgetKey = Widgets.register<Polyline>()

    let Points =
        Attributes.defineSimpleScalarWithEquality<Point list> "Polyline_Points" (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Polyline.PointsProperty)
            | ValueSome points ->
                let coll = List<Point>()
                points |> List.iter coll.Add
                target.SetValue(Polyline.PointsProperty, coll) |> ignore)

[<AutoOpen>]
module PolylineBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Polyline widget.</summary>
        /// <param name="points">The points of the polyline.</param>
        static member Polyline(points: Point list) =
            WidgetBuilder<'msg, IFabPolyline>(Polyline.WidgetKey, Polyline.Points.WithValue(points))

type PolylineModifiers =
    /// <summary>Link a ViewRef to access the direct Polyline control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPolyline>, value: ViewRef<Polyline>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
