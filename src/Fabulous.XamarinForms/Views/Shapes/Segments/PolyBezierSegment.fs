namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms
open Xamarin.Forms.Shapes

type IPolyBezierSegment =
    inherit IPathSegment

module PolyBezierSegment =
    let WidgetKey = Widgets.register<PolyBezierSegment>()

    let PointsString =
        Attributes.define<string>
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
        Attributes.define<Point list>
            "PolyBezierSegment_PointsList"
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(PolyBezierSegment.PointsProperty)
                | ValueSome points ->
                    let coll = PointCollection()
                    points |> List.iter coll.Add
                    target.SetValue(PolyBezierSegment.PointsProperty, coll))

[<AutoOpen>]
module PolyBezierSegmentBuilders =

    type Fabulous.XamarinForms.View with
        static member inline PolyBezierSegment<'msg>(points: string) =
            WidgetBuilder<'msg, IPolyBezierSegment>(
                PolyBezierSegment.WidgetKey,
                PolyBezierSegment.PointsString.WithValue(points)
            )

        static member inline PolyBezierSegment<'msg>(points: Point list) =
            WidgetBuilder<'msg, IPolyBezierSegment>(
                PolyBezierSegment.WidgetKey,
                PolyBezierSegment.PointsList.WithValue(points)
            )
