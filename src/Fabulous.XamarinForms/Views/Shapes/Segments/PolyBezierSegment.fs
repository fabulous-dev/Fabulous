namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms
open Xamarin.Forms.Shapes

type IPolyBezierSegment =
    inherit IPathSegment

module PolyBezierSegment =
    let WidgetKey = Widgets.register<PolyBezierSegment> ()

    let Points =
        Attributes.defineScalarWithConverter<PointsConverter.Value, PointsConverter.Value, PointsConverter.Value>
            "PolyBezierSegment_Points"
            id
            id
            ScalarAttributeComparers.equalityCompare
            (fun newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(PolyBezierSegment.PointsProperty)
                | ValueSome pointsValue ->
                    match pointsValue with
                    | PointsConverter.String string ->
                        target.SetValue(
                            PolyBezierSegment.PointsProperty,
                            PointCollectionConverter()
                                .ConvertFromInvariantString(string)
                        )
                    | PointsConverter.PointsList points ->
                        let coll = PointCollection()
                        points |> List.iter coll.Add
                        target.SetValue(PolyBezierSegment.PointsProperty, coll))

[<AutoOpen>]
module PolyBezierSegmentBuilders =

    type Fabulous.XamarinForms.View with
        static member inline PolyBezierSegment<'msg>(point: PointsConverter.Value) =
            WidgetBuilder<'msg, IPolyBezierSegment>(
                PolyBezierSegment.WidgetKey,
                PolyBezierSegment.Points.WithValue(point)
            )
