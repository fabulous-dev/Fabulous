namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.Shapes

type IPolygon =
    inherit IShape

module Polygon =

    let WidgetKey = Widgets.register<Polygon> ()

    let Points =
        Attributes.defineScalarWithConverter<PointsConverter.Value, PointsConverter.Value, PointsConverter.Value>
            "Polygon_Points"
            id
            id
            ScalarAttributeComparers.equalityCompare
            (fun newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(Polygon.PointsProperty)
                | ValueSome pointsValue ->
                    match pointsValue with
                    | PointsConverter.String string ->
                        target.SetValue(
                            Polygon.PointsProperty,
                            PointCollectionConverter()
                                .ConvertFromInvariantString(string)
                        )
                    | PointsConverter.PointsList points ->
                        let coll = PointCollection()
                        points |> List.iter coll.Add
                        target.SetValue(Polygon.PointsProperty, coll))

    let FillRule =
        Attributes.defineBindable<FillRule> Polygon.FillRuleProperty

[<AutoOpen>]
module PolygonBuilders =

    type Fabulous.XamarinForms.View with
        static member inline Polygon<'msg>(points: PointsConverter.Value) =
            WidgetBuilder<'msg, IPolygon>(Polygon.WidgetKey, Polygon.Points.WithValue(points))

[<Extension>]
type PolygonModifiers =

    [<Extension>]
    static member inline fillRule(this: WidgetBuilder<'msg, #IPolygon>, value: FillRule) =
        this.AddScalar(Polygon.FillRule.WithValue(value))
