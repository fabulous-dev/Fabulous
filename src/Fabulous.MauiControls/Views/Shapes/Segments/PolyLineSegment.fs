namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IFabPolyLineSegment =
    inherit IFabPathSegment

module PolyLineSegment =
    let WidgetKey = Widgets.register<PolyLineSegment>()

    let PointsList =
        Attributes.defineSimpleScalarWithEquality<Point array> "PolyLineSegment_PointsList" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(PolyLineSegment.PointsProperty)
            | ValueSome points ->
                let coll = PointCollection()
                points |> Array.iter coll.Add
                target.SetValue(PolyLineSegment.PointsProperty, coll))

    let PointsString =
        Attributes.defineSimpleScalarWithEquality<string> "PolyLineSegment_PointsString" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(PolyLineSegment.PointsProperty)
            | ValueSome string -> target.SetValue(PolyLineSegment.PointsProperty, PointCollectionConverter().ConvertFromInvariantString(string)))

[<AutoOpen>]
module PolyLineSegmentBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a PolyLineSegment with a list of points</summary>
        /// <param name="points">The points list</param>
        static member inline PolyLineSegment<'msg when 'msg: equality>(points: string) =
            WidgetBuilder<'msg, IFabPolyLineSegment>(PolyLineSegment.WidgetKey, PolyLineSegment.PointsString.WithValue(points))

        /// <summary>Create a PolyLineSegment with a list of points</summary>
        /// <param name="points">The points list</param>
        static member inline PolyLineSegment<'msg when 'msg: equality>(points: seq<Point>) =
            WidgetBuilder<'msg, IFabPolyLineSegment>(PolyLineSegment.WidgetKey, PolyLineSegment.PointsList.WithValue(Array.ofSeq points))

[<Extension>]
type PolyLineSegmentModifiers =
    /// <summary>Link a ViewRef to access the direct PolyLineSegment control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPolyLineSegment>, value: ViewRef<PolyLineSegment>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
