namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IPolyQuadraticBezierSegment =
    inherit IPathSegment

module PolyQuadraticBezierSegment =
    let WidgetKey =
        Widgets.register<PolyQuadraticBezierSegment>()

    let PointsString =
        Attributes.defineSimpleScalarWithEquality<string>
            "PolyQuadraticBezierSegment_PointsString"
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(PolyQuadraticBezierSegment.PointsProperty)
                | ValueSome string ->
                    target.SetValue(
                        PolyQuadraticBezierSegment.PointsProperty,
                        PointCollectionConverter()
                            .ConvertFromInvariantString(string)
                    ))

    let PointsList =
        Attributes.defineSimpleScalarWithEquality<Point array>
            "PolyQuadraticBezierSegment_PointsList"
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(PolyQuadraticBezierSegment.PointsProperty)
                | ValueSome points ->
                    let coll = PointCollection()
                    points |> Array.iter coll.Add
                    target.SetValue(PolyQuadraticBezierSegment.PointsProperty, coll))

[<AutoOpen>]
module PolyQuadraticBezierSegmentBuilders =

    type Fabulous.Maui.View with
        static member inline PolyQuadraticBezierSegment<'msg>(points: string) =
            WidgetBuilder<'msg, IPolyQuadraticBezierSegment>(
                PolyQuadraticBezierSegment.WidgetKey,
                PolyQuadraticBezierSegment.PointsString.WithValue(points)
            )

        static member inline PolyQuadraticBezierSegment<'msg>(points: Point list) =
            WidgetBuilder<'msg, IPolyQuadraticBezierSegment>(
                PolyQuadraticBezierSegment.WidgetKey,
                PolyQuadraticBezierSegment.PointsList.WithValue(Array.ofList points)
            )
