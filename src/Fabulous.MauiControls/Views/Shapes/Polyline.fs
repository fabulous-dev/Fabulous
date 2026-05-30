namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IFabPolyline =
    inherit IFabShape

module Polyline =
    let WidgetKey = Widgets.register<Polyline>()

    let FillRule = Attributes.defineBindableEnum<FillRule> Polyline.FillRuleProperty

    let PointsString =
        Attributes.defineSimpleScalarWithEquality<string> "Polyline_PointsString" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Polyline.PointsProperty)
            | ValueSome string -> target.SetValue(Polyline.PointsProperty, PointCollectionConverter().ConvertFromInvariantString(string)))

    let PointsList =
        Attributes.defineSimpleScalarWithEquality<Point array> "Polyline_PointsList" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Polyline.PointsProperty)
            | ValueSome points ->
                let coll = PointCollection()

                for point in points do
                    coll.Add(point)

                target.SetValue(Polyline.PointsProperty, coll))

[<AutoOpen>]
module PolylineBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a Polyline widget with a list of points, a stroke thickness, a stroke brush</summary>
        /// <param name="points">The points list</param>
        static member inline Polyline<'msg when 'msg: equality>(points: string) =
            WidgetBuilder<'msg, IFabPolyline>(Polyline.WidgetKey, Polyline.PointsString.WithValue(points))

        /// <summary>Create a Polyline widget with a list of points, a stroke thickness, a stroke brush</summary>
        /// <param name="points">The points list</param>
        static member inline Polyline(points: seq<Point>) =
            WidgetBuilder<'msg, IFabPolyline>(Polyline.WidgetKey, Polyline.PointsList.WithValue(Array.ofSeq points))

[<Extension>]
type PolylineModifiers =
    /// <summary>Set the fill rule of the polyline</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The fill rule</param>
    [<Extension>]
    static member inline fillRule(this: WidgetBuilder<'msg, #IFabPolyline>, value: FillRule) =
        this.AddScalar(Polyline.FillRule.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Polyline control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPolyline>, value: ViewRef<Polyline>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
