namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Shapes

type IFabShape =
    inherit IFabView

module Shape =
    let Aspect = Attributes.defineBindableWithEquality<Stretch> Shape.AspectProperty

    let Fill = Attributes.defineBindableWithEquality<Brush> Shape.FillProperty

    let FillWidget = Attributes.defineBindableWidget Shape.FillProperty

    let Stroke = Attributes.defineBindableWithEquality<Brush> Shape.StrokeProperty

    let StrokeWidget = Attributes.defineBindableWidget Shape.StrokeProperty

    let StrokeDashArrayString =
        Attributes.defineSimpleScalarWithEquality<string> "Shape_StrokeDashArrayString" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Shape.StrokeDashArrayProperty)
            | ValueSome string -> target.SetValue(Shape.StrokeDashArrayProperty, DoubleCollectionConverter().ConvertFromInvariantString(string)))

    let StrokeDashArrayList =
        Attributes.defineSimpleScalarWithEquality<float array> "Shape_StrokeDashArrayList" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Shape.StrokeDashArrayProperty)
            | ValueSome points ->
                let coll = DoubleCollection()
                points |> Array.iter coll.Add
                target.SetValue(Shape.StrokeDashArrayProperty, coll))

    let StrokeDashOffset = Attributes.defineBindableFloat Shape.StrokeDashOffsetProperty

    let StrokeLineCap =
        Attributes.defineBindableWithEquality<PenLineCap> Shape.StrokeLineCapProperty

    let StrokeLineJoin =
        Attributes.defineBindableWithEquality<PenLineJoin> Shape.StrokeLineJoinProperty

    let StrokeMiterLimit = Attributes.defineBindableFloat Shape.StrokeMiterLimitProperty

    let StrokeThickness = Attributes.defineBindableFloat Shape.StrokeThicknessProperty

[<Extension>]
type ShapeModifiers =
    /// <summary>Set the aspect of the stroke</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The aspect value</param>
    [<Extension>]
    static member inline aspect(this: WidgetBuilder<'msg, #IFabShape>, value: Stretch) =
        this.AddScalar(Shape.Aspect.WithValue(value))

    /// <summary>Set the fill brush of the shape</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The brush value</param>
    [<Extension>]
    static member inline fill(this: WidgetBuilder<'msg, #IFabShape>, value: Brush) =
        this.AddScalar(Shape.Fill.WithValue(value))

    /// <summary>Set the fill brush of the shape</summary>
    /// <param name="this">Current widget</param>
    /// <param name="content">The brush widget</param>
    [<Extension>]
    static member inline fill(this: WidgetBuilder<'msg, #IFabShape>, content: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Shape.FillWidget.WithValue(content.Compile()))

    /// <summary>Set the stroke brush of the shape</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The brush value</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IFabShape>, value: Brush) =
        this.AddScalar(Shape.Stroke.WithValue(value))

    /// <summary>Set the stroke brush of the shape</summary>
    /// <param name="this">Current widget</param>
    /// <param name="content">The brush widget</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IFabShape>, content: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Shape.StrokeWidget.WithValue(content.Compile()))

    /// <summary>Set the stroke dash pattern of the shape</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The dash pattern value</param>
    [<Extension>]
    static member inline strokeDashArray(this: WidgetBuilder<'msg, #IFabShape>, value: string) =
        this.AddScalar(Shape.StrokeDashArrayString.WithValue(value))

    /// <summary>Set the stroke dash pattern of the shape</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The dash pattern value</param>
    [<Extension>]
    static member inline strokeDashArray(this: WidgetBuilder<'msg, #IFabShape>, value: seq<float>) =
        this.AddScalar(Shape.StrokeDashArrayList.WithValue(Array.ofSeq value))

    /// <summary>Set the offset of the stroke dash pattern</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The dash offset value</param>
    [<Extension>]
    static member inline strokeDashOffset(this: WidgetBuilder<'msg, #IFabShape>, value: float) =
        this.AddScalar(Shape.StrokeDashOffset.WithValue(value))

    /// <summary>Set the line cap of the stroke</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The line cap</param>
    [<Extension>]
    static member inline strokeLineCap(this: WidgetBuilder<'msg, #IFabShape>, value: PenLineCap) =
        this.AddScalar(Shape.StrokeLineCap.WithValue(value))

    /// <summary>Set the line join of the stroke</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The line join</param>
    [<Extension>]
    static member inline strokeLineJoin(this: WidgetBuilder<'msg, #IFabShape>, value: PenLineJoin) =
        this.AddScalar(Shape.StrokeLineJoin.WithValue(value))

    /// <summary>Set the miter line of the stroke</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The miter limit</param>
    [<Extension>]
    static member inline strokeMiterLimit(this: WidgetBuilder<'msg, #IFabShape>, value: float) =
        this.AddScalar(Shape.StrokeMiterLimit.WithValue(value))

    /// <summary>Set the stroke thickness brush of the shape</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The thickness value</param>
    [<Extension>]
    static member inline strokeThickness(this: WidgetBuilder<'msg, #IFabShape>, value: float) =
        this.AddScalar(Shape.StrokeThickness.WithValue(value))
