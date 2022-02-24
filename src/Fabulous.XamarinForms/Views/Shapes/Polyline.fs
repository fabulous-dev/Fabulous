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

    let PointsString =
        Attributes.define<string>
            "Polyline_PointsString"
            (fun newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(Polyline.PointsProperty)
                | ValueSome string ->
                    target.SetValue(
                        Polyline.PointsProperty,
                        PointCollectionConverter()
                            .ConvertFromInvariantString(string)
                    ))

    let PointsList =
        Attributes.define<Point list>
            "Polyline_PointsList"
            (fun newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(Polyline.PointsProperty)
                | ValueSome points ->
                    let coll = PointCollection()
                    points |> List.iter coll.Add
                    target.SetValue(Polyline.PointsProperty, coll))

    let FillRule =
        Attributes.defineBindable<FillRule> Polyline.FillRuleProperty

[<AutoOpen>]
module PolylineBuilders =

    type Fabulous.XamarinForms.View with
        static member inline Polyline<'msg>(points: string) =
            WidgetBuilder<'msg, IPolyline>(Polyline.WidgetKey, Polyline.PointsString.WithValue(points))

        static member inline Polyline<'msg>(points: Point list) =
            WidgetBuilder<'msg, IPolyline>(Polyline.WidgetKey, Polyline.PointsList.WithValue(points))

[<Extension>]
type PolylineModifiers =

    [<Extension>]
    static member inline fillRule(this: WidgetBuilder<'msg, #IPolyline>, value: FillRule) =
        this.AddScalar(Polyline.FillRule.WithValue(value))
