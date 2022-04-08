namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.Shapes

type IPolyline =
    inherit IShape

module Polyline =

    let WidgetKey = Widgets.register<Polyline>()

    let PointsString =
        Attributes.define<string>
            "Polyline_PointsString"
            (fun _ newValueOpt node ->
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
            (fun _ newValueOpt node ->
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
        static member inline Polyline<'msg>
            (
                points: string,
                strokeThickness: float,
                strokeLight: Brush,
                ?strokeDark: Brush
            ) =
            WidgetBuilder<'msg, IPolyline>(
                Polyline.WidgetKey,
                Polyline.PointsString.WithValue(points),
                Shape.StrokeThickness.WithValue(strokeThickness),
                Shape.Stroke.WithValue(AppTheme.create strokeLight strokeDark)
            )

        static member inline Polyline<'msg>
            (
                points: Point list,
                strokeThickness: float,
                strokeLight: Brush,
                ?strokeDark: Brush
            ) =
            WidgetBuilder<'msg, IPolyline>(
                Polyline.WidgetKey,
                Polyline.PointsList.WithValue(points),
                Shape.StrokeThickness.WithValue(strokeThickness),
                Shape.Stroke.WithValue(AppTheme.create strokeLight strokeDark)
            )

[<Extension>]
type PolylineModifiers =

    [<Extension>]
    static member inline fillRule(this: WidgetBuilder<'msg, #IPolyline>, value: FillRule) =
        this.AddScalar(Polyline.FillRule.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Polyline control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IPolyline>, value: ViewRef<Polyline>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
