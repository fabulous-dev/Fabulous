namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IFabPolyBezierSegment =
    inherit IFabPathSegment

module PolyBezierSegment =
    let WidgetKey = Widgets.register<PolyBezierSegment>()

    let PointsList =
        Attributes.defineSimpleScalarWithEquality<Point array> "PolyBezierSegment_PointsList" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(PolyBezierSegment.PointsProperty)
            | ValueSome points ->
                let coll = PointCollection()
                points |> Array.iter coll.Add
                target.SetValue(PolyBezierSegment.PointsProperty, coll))

    let PointsString =
        Attributes.defineSimpleScalarWithEquality<string> "PolyBezierSegment_PointsString" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(PolyBezierSegment.PointsProperty)
            | ValueSome string -> target.SetValue(PolyBezierSegment.PointsProperty, PointCollectionConverter().ConvertFromInvariantString(string)))

[<AutoOpen>]
module PolyBezierSegmentBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a PolyBezierSegment with a list of points</summary>
        /// <param name="points">The points list</param>
        static member inline PolyBezierSegment<'msg when 'msg: equality>(points: string) =
            WidgetBuilder<'msg, IFabPolyBezierSegment>(PolyBezierSegment.WidgetKey, PolyBezierSegment.PointsString.WithValue(points))

        /// <summary>Create a PolyBezierSegment with a list of points</summary>
        /// <param name="points">The points list</param>
        static member inline PolyBezierSegment<'msg when 'msg: equality>(points: seq<Point>) =
            WidgetBuilder<'msg, IFabPolyBezierSegment>(PolyBezierSegment.WidgetKey, PolyBezierSegment.PointsList.WithValue(Array.ofSeq points))

[<Extension>]
type PolyBezierSegmentModifiers =
    /// <summary>Link a ViewRef to access the direct PolyBezierSegment control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPolyBezierSegment>, value: ViewRef<PolyBezierSegment>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
