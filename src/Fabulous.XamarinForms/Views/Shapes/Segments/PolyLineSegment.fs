namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms
open Xamarin.Forms.Shapes

type IPolyLineSegment =
    inherit IPathSegment

module PolyLineSegment =
    let WidgetKey = Widgets.register<PolyLineSegment> ()

    let PointsString =
        Attributes.define<string>
            "PolyLineSegment_PointsString"
            (fun newValueOpt node ->
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
        Attributes.define<Point list>
            "PolyLineSegment_PointsList"
            (fun newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(PolyLineSegment.PointsProperty)
                | ValueSome points ->
                    let coll = PointCollection()
                    points |> List.iter coll.Add
                    target.SetValue(PolyLineSegment.PointsProperty, coll))

[<AutoOpen>]
module PolyLineSegmentBuilders =

    type Fabulous.XamarinForms.View with
        static member inline PolyLineSegment<'msg>(points: string) =
            WidgetBuilder<'msg, IPolyLineSegment>(
                PolyLineSegment.WidgetKey,
                PolyLineSegment.PointsString.WithValue(points)
            )

        static member inline PolyLineSegment<'msg>(points: Point list) =
            WidgetBuilder<'msg, IPolyLineSegment>(
                PolyLineSegment.WidgetKey,
                PolyLineSegment.PointsList.WithValue(points)
            )
