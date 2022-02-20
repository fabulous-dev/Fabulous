namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.Shapes

type IPolyline =
    inherit IShape

module Polyline =

    let WidgetKey = Widgets.register<Polyline> ()

    let Points =
        Attributes.defineScalarWithConverter<Points.Value, Points.Value, Points.Value>
            "Polyline_Points"
            id
            id
            ScalarAttributeComparers.equalityCompare
            (fun newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(Polyline.PointsProperty)
                | ValueSome pointsValue ->
                    match pointsValue with
                    | Points.String string ->
                        target.SetValue(
                            Polyline.PointsProperty,
                            PointCollectionConverter()
                                .ConvertFromInvariantString(string)
                        )
                    | Points.PointsList points ->
                        let coll = PointCollection()
                        points |> List.iter coll.Add
                        target.SetValue(Polyline.PointsProperty, coll))

    let FillRule =
        Attributes.defineBindable<FillRule> Polyline.FillRuleProperty

[<AutoOpen>]
module PolylineBuilders =

    type Fabulous.XamarinForms.View with
        static member inline Polyline<'msg>(points: Points.Value) =
            WidgetBuilder<'msg, IPolyline>(Polyline.WidgetKey, Polyline.Points.WithValue(points))

[<Extension>]
type PolylineModifiers =

    [<Extension>]
    static member inline fillRule(this: WidgetBuilder<'msg, #IPolyline>, value: FillRule) =
        this.AddScalar(Polyline.FillRule.WithValue(value))
