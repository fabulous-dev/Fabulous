namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms
open Xamarin.Forms.Shapes

type IShape =
    inherit IView

module Shape =

    let Fill =
        Attributes.defineAppThemeBindable<Brush> Shape.FillProperty

    let Stroke =
        Attributes.defineAppThemeBindable<Brush> Shape.StrokeProperty

    let StrokeThickness =
        Attributes.defineBindable<float> Shape.StrokeThicknessProperty

    let StrokeDashArrayString =
        Attributes.define<string>
            "Shape_StrokeDashArrayString"
            (fun newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(Shape.StrokeDashArrayProperty)
                | ValueSome string ->
                    target.SetValue(
                        Shape.StrokeDashArrayProperty,
                        DoubleCollectionConverter()
                            .ConvertFromInvariantString(string)
                    ))

    let StrokeDashArrayList =
        Attributes.define<float list>
            "Shape_StrokeDashArrayList"
            (fun newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(Shape.StrokeDashArrayProperty)
                | ValueSome points ->
                    let coll = DoubleCollection()
                    points |> List.iter coll.Add
                    target.SetValue(Shape.StrokeDashArrayProperty, coll))

    let StrokeDashOffset =
        Attributes.defineBindable<float> Shape.StrokeDashOffsetProperty

    let StrokeLineCap =
        Attributes.defineBindable<PenLineCap> Shape.StrokeLineCapProperty

    let StrokeLineJoin =
        Attributes.defineBindable<PenLineJoin> Shape.StrokeLineJoinProperty

    let StrokeMiterLimit =
        Attributes.defineBindable<float> Shape.StrokeMiterLimitProperty

    let Aspect =
        Attributes.defineBindable<Stretch> Shape.AspectProperty


[<Extension>]
type ShapeModifiers =

    [<Extension>]
    static member inline fill(this: WidgetBuilder<'msg, #IShape>, light: Brush, ?dark: Brush) =
        this.AddScalar(Shape.Fill.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IShape>, light: Brush, ?dark: Brush) =
        this.AddScalar(Shape.Stroke.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline strokeThickness(this: WidgetBuilder<'msg, #IShape>, value: float) =
        this.AddScalar(Shape.StrokeThickness.WithValue(value))

    [<Extension>]
    static member inline strokeDashArray(this: WidgetBuilder<'msg, #IShape>, value: string) =
        this.AddScalar(Shape.StrokeDashArrayString.WithValue(value))

    [<Extension>]
    static member inline strokeDashArray(this: WidgetBuilder<'msg, #IShape>, value: float list) =
        this.AddScalar(Shape.StrokeDashArrayList.WithValue(value))

    [<Extension>]
    static member inline strokeDashOffset(this: WidgetBuilder<'msg, #IShape>, value: float) =
        this.AddScalar(Shape.StrokeDashOffset.WithValue(value))

    [<Extension>]
    static member inline strokeLineCap(this: WidgetBuilder<'msg, #IShape>, value: PenLineCap) =
        this.AddScalar(Shape.StrokeLineCap.WithValue(value))

    [<Extension>]
    static member inline strokeLineJoin(this: WidgetBuilder<'msg, #IShape>, value: PenLineJoin) =
        this.AddScalar(Shape.StrokeLineJoin.WithValue(value))

    [<Extension>]
    static member inline strokeMiterLimit(this: WidgetBuilder<'msg, #IShape>, value: float) =
        this.AddScalar(Shape.StrokeMiterLimit.WithValue(value))

    [<Extension>]
    static member inline aspect(this: WidgetBuilder<'msg, #IShape>, value: Stretch) =
        this.AddScalar(Shape.Aspect.WithValue(value))
