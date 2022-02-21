namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms
open Xamarin.Forms.Shapes

type IPolyQuadraticBezierSegment =
    inherit IPathSegment

module PolyQuadraticBezierSegment =
    let WidgetKey = Widgets.register<PolyQuadraticBezierSegment> ()

    let Points =
        Attributes.defineScalarWithConverter<PointsConverter.Value, PointsConverter.Value, PointsConverter.Value>
            "PolyLineSegment_Points"
            id
            id
            ScalarAttributeComparers.equalityCompare
            (fun newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(PolyQuadraticBezierSegment.PointsProperty)
                | ValueSome pointsValue ->
                    match pointsValue with
                    | PointsConverter.String string ->
                        target.SetValue(
                            PolyQuadraticBezierSegment.PointsProperty,
                            PointCollectionConverter()
                                .ConvertFromInvariantString(string)
                        )
                    | PointsConverter.PointsList points ->
                        let coll = PointCollection()
                        points |> List.iter coll.Add
                        target.SetValue(PolyQuadraticBezierSegment.PointsProperty, coll))

[<AutoOpen>]
module PolyQuadraticBezierSegmentBuilders =

    type Fabulous.XamarinForms.View with
        static member inline PolyQuadraticBezierSegment<'msg>(point: PointsConverter.Value) =
            WidgetBuilder<'msg, IPolyQuadraticBezierSegment>(
                PolyQuadraticBezierSegment.WidgetKey,
                PolyQuadraticBezierSegment.Points.WithValue(point)
            )
