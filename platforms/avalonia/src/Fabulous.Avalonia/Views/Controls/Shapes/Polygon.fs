namespace Fabulous.Avalonia

open System.Collections.Generic
open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Avalonia
open Fabulous

type IFabPolygon =
    inherit IFabShape

module Polygon =
    let WidgetKey = Widgets.register<Polygon>()

    let Points =
        Attributes.defineSimpleScalarWithEquality<Point list> "Polygon_Points" (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Polygon.PointsProperty)
            | ValueSome points ->
                let coll = List<Point>()
                points |> List.iter coll.Add
                target.SetValue(Polygon.PointsProperty, coll) |> ignore)

[<AutoOpen>]
module PolygonBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Polygon widget.</summary>
        /// <param name="points">The points of the polygon.</param>
        static member Polygon(points: Point list) =
            WidgetBuilder<'msg, IFabPolygon>(Polygon.WidgetKey, Polygon.Points.WithValue(points))

type PolygonModifiers =
    /// <summary>Link a ViewRef to access the direct Polygon control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPolygon>, value: ViewRef<Polygon>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
