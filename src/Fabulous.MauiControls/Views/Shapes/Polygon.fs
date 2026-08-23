namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IFabPolygon =
    inherit IFabShape

module Polygon =
    let WidgetKey = Widgets.register<Polygon>()

    let FillRule = Attributes.defineBindableEnum<FillRule> Polygon.FillRuleProperty

    let PointsString =
        Attributes.defineSimpleScalarWithEquality<string> "Polygon_PointsString" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Polygon.PointsProperty)
            | ValueSome string -> target.SetValue(Polygon.PointsProperty, PointCollectionConverter().ConvertFromInvariantString(string)))

    let PointsList =
        Attributes.defineSimpleScalarWithEquality<Point array> "Polygon_PointsList" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Polygon.PointsProperty)
            | ValueSome points ->
                let coll = PointCollection()
                points |> Array.iter coll.Add
                target.SetValue(Polygon.PointsProperty, coll))

[<AutoOpen>]
module PolygonBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a Polygon widget with a list of points</summary>
        /// <param name="points">The points list</param>
        static member inline Polygon<'msg when 'msg: equality>(points: string) =
            WidgetBuilder<'msg, IFabPolygon>(Polygon.WidgetKey, Polygon.PointsString.WithValue(points))

        /// <summary>Create a Polygon widget with a list of points</summary>
        /// <param name="points">The points list</param>
        static member inline Polygon(points: seq<Point>) =
            WidgetBuilder<'msg, IFabPolygon>(Polygon.WidgetKey, Polygon.PointsList.WithValue(Array.ofSeq points))

[<Extension>]
type PolygonModifiers =
    /// <summary>Set the fill rule of the polygon</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The fill rule</param>
    [<Extension>]
    static member inline fillRule(this: WidgetBuilder<'msg, #IFabPolygon>, value: FillRule) =
        this.AddScalar(Polygon.FillRule.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Polygon control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPolygon>, value: ViewRef<Polygon>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
