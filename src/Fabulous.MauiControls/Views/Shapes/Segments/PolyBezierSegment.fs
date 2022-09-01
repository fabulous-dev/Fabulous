namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IPolyBezierSegment =
    inherit Fabulous.Maui.IPathSegment

module PolyBezierSegment =
    let WidgetKey = Widgets.register<PolyBezierSegment>()

    let PointsString =
        Attributes.defineSimpleScalarWithEquality<string>
            "PolyBezierSegment_PointsString"
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(PolyBezierSegment.PointsProperty)
                | ValueSome string ->
                    target.SetValue(
                        PolyBezierSegment.PointsProperty,
                        PointCollectionConverter()
                            .ConvertFromInvariantString(string)
                    ))

    let PointsList =
        Attributes.defineSimpleScalarWithEquality<Point array>
            "PolyBezierSegment_PointsList"
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(PolyBezierSegment.PointsProperty)
                | ValueSome points ->
                    let coll = PointCollection()
                    points |> Array.iter coll.Add
                    target.SetValue(PolyBezierSegment.PointsProperty, coll))

[<AutoOpen>]
module PolyBezierSegmentBuilders =

    type Fabulous.Maui.View with
        static member inline PolyBezierSegment<'msg>(points: string) =
            WidgetBuilder<'msg, IPolyBezierSegment>(
                PolyBezierSegment.WidgetKey,
                PolyBezierSegment.PointsString.WithValue(points)
            )

        static member inline PolyBezierSegment<'msg>(points: Point list) =
            WidgetBuilder<'msg, IPolyBezierSegment>(
                PolyBezierSegment.WidgetKey,
                PolyBezierSegment.PointsList.WithValue(Array.ofList points)
            )
