namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IFabPolyQuadraticBezierSegment =
    inherit IFabPathSegment

module PolyQuadraticBezierSegment =
    let WidgetKey = Widgets.register<PolyQuadraticBezierSegment>()

    let PointsList =
        Attributes.defineSimpleScalarWithEquality<Point array> "PolyQuadraticBezierSegment_PointsList" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(PolyQuadraticBezierSegment.PointsProperty)
            | ValueSome points ->
                let coll = PointCollection()
                points |> Array.iter coll.Add
                target.SetValue(PolyQuadraticBezierSegment.PointsProperty, coll))

    let PointsString =
        Attributes.defineSimpleScalarWithEquality<string> "PolyQuadraticBezierSegment_PointsString" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(PolyQuadraticBezierSegment.PointsProperty)
            | ValueSome string -> target.SetValue(PolyQuadraticBezierSegment.PointsProperty, PointCollectionConverter().ConvertFromInvariantString(string)))

[<AutoOpen>]
module PolyQuadraticBezierSegmentBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a PolyQuadraticBezierSegment with a list of points</summary>
        /// <param name="points">The points list</param>
        static member inline PolyQuadraticBezierSegment<'msg when 'msg: equality>(points: string) =
            WidgetBuilder<'msg, IFabPolyQuadraticBezierSegment>(PolyQuadraticBezierSegment.WidgetKey, PolyQuadraticBezierSegment.PointsString.WithValue(points))

        /// <summary>Create a PolyQuadraticBezierSegment with a list of points</summary>
        /// <param name="points">The points list</param>
        static member inline PolyQuadraticBezierSegment<'msg when 'msg: equality>(points: seq<Point>) =
            WidgetBuilder<'msg, IFabPolyQuadraticBezierSegment>(
                PolyQuadraticBezierSegment.WidgetKey,
                PolyQuadraticBezierSegment.PointsList.WithValue(Array.ofSeq points)
            )

[<Extension>]
type PolyQuadraticBezierSegmentModifiers =
    /// <summary>Link a ViewRef to access the direct PolyQuadraticBezierSegment control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPolyQuadraticBezierSegment>, value: ViewRef<PolyQuadraticBezierSegment>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
