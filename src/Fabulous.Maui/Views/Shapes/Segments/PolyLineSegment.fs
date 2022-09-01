namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IPolyLineSegment =
    inherit Fabulous.Maui.IPathSegment

module PolyLineSegment =
    let WidgetKey = Widgets.register<PolyLineSegment>()

    let PointsString =
        Attributes.defineSimpleScalarWithEquality<string>
            "PolyLineSegment_PointsString"
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(PolyLineSegment.PointsProperty)
                | ValueSome string ->
                    target.SetValue(
                        PolyLineSegment.PointsProperty,
                        PointCollectionConverter()
                            .ConvertFromInvariantString(string)
                    ))

    let PointsList =
        Attributes.defineSimpleScalarWithEquality<Point array>
            "PolyLineSegment_PointsList"
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(PolyLineSegment.PointsProperty)
                | ValueSome points ->
                    let coll = PointCollection()
                    points |> Array.iter coll.Add
                    target.SetValue(PolyLineSegment.PointsProperty, coll))

[<AutoOpen>]
module PolyLineSegmentBuilders =

    type Fabulous.Maui.View with
        static member inline PolyLineSegment<'msg>(points: string) =
            WidgetBuilder<'msg, IPolyLineSegment>(
                PolyLineSegment.WidgetKey,
                PolyLineSegment.PointsString.WithValue(points)
            )

        static member inline PolyLineSegment<'msg>(points: Point list) =
            WidgetBuilder<'msg, IPolyLineSegment>(
                PolyLineSegment.WidgetKey,
                PolyLineSegment.PointsList.WithValue(Array.ofList points)
            )
