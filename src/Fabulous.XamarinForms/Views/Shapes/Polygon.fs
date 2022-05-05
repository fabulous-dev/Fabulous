namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms
open Xamarin.Forms.Shapes

type IPolygon =
    inherit IShape

module Polygon =

    let WidgetKey = Widgets.register<Polygon>()

    let PointsString =
        Attributes.define<string>
            "Polygon_PointsString"
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(Polygon.PointsProperty)
                | ValueSome string ->
                    target.SetValue(
                        Polygon.PointsProperty,
                        PointCollectionConverter()
                            .ConvertFromInvariantString(string)
                    ))

    let PointsList =
        Attributes.define<Point list>
            "Polygon_PointsList"
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(Polygon.PointsProperty)
                | ValueSome points ->
                    let coll = PointCollection()
                    points |> List.iter coll.Add
                    target.SetValue(Polygon.PointsProperty, coll))

    let FillRule =
        Attributes.defineBindable<FillRule> Polygon.FillRuleProperty

[<AutoOpen>]
module PolygonBuilders =

    type Fabulous.XamarinForms.View with
        static member inline Polygon<'msg>
            (
                points: string,
                strokeThickness: float,
                strokeLight: Brush,
                ?strokeDark: Brush
            ) =
            WidgetBuilder<'msg, IPolygon>(
                Polygon.WidgetKey,
                Polygon.PointsString.WithValue(points),
                Shape.StrokeThickness.WithValue(strokeThickness),
                Shape.Stroke.WithValue(AppTheme.create strokeLight strokeDark)
            )

        static member inline Polygon<'msg>
            (
                points: Point list,
                strokeThickness: float,
                strokeLight: Brush,
                ?strokeDark: Brush
            ) =
            WidgetBuilder<'msg, IPolygon>(
                Polygon.WidgetKey,
                Polygon.PointsList.WithValue(points),
                Shape.StrokeThickness.WithValue(strokeThickness),
                Shape.Stroke.WithValue(AppTheme.create strokeLight strokeDark)
            )

[<Extension>]
type PolygonModifiers =

    [<Extension>]
    static member inline fillRule(this: WidgetBuilder<'msg, #IPolygon>, value: FillRule) =
        this.AddScalar(Polygon.FillRule.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Polygon control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IPolygon>, value: ViewRef<Polygon>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
