namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms
open Xamarin.Forms.Shapes

type IPolyLineSegment =
    inherit IPathSegment

module PolyLineSegment =
    let WidgetKey = Widgets.register<PolyLineSegment> ()

    let Points =
        Attributes.defineScalarWithConverter<PointsConverter.Value, PointsConverter.Value, PointsConverter.Value>
            "PolyLineSegment_Points"
            id
            id
            ScalarAttributeComparers.equalityCompare
            (fun newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(PolyLineSegment.PointsProperty)
                | ValueSome pointsValue ->
                    match pointsValue with
                    | PointsConverter.String string ->
                        target.SetValue(
                            PolyLineSegment.PointsProperty,
                            PointCollectionConverter()
                                .ConvertFromInvariantString(string)
                        )
                    | PointsConverter.PointsList points ->
                        let coll = PointCollection()
                        points |> List.iter coll.Add
                        target.SetValue(PolyLineSegment.PointsProperty, coll))

[<AutoOpen>]
module PolyLineSegmentBuilders =

    type Fabulous.XamarinForms.View with
        static member inline PolyLineSegment<'msg>(point: PointsConverter.Value) =
            WidgetBuilder<'msg, IPolyLineSegment>(PolyLineSegment.WidgetKey, PolyLineSegment.Points.WithValue(point))
