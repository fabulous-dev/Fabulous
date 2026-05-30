namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Shapes

type IFabBorder =
    inherit IFabView

module Border =
    let WidgetKey = Widgets.register<Border>()

    let Content = Attributes.defineBindableWidget Border.ContentProperty

    let Padding =
        Attributes.defineBindableWithEquality<Thickness> Border.PaddingProperty

    let Stroke = Attributes.defineBindableWithEquality Border.StrokeProperty

    let StrokeWidget = Attributes.defineBindableWidget Border.StrokeProperty

    let StrokeDashArrayString =
        Attributes.defineSimpleScalarWithEquality<string> "Border_StrokeDashArrayString" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Border.StrokeDashArrayProperty)
            | ValueSome string -> target.SetValue(Shape.StrokeDashArrayProperty, DoubleCollectionConverter().ConvertFromInvariantString(string)))

    let StrokeDashArray =
        Attributes.defineSimpleScalarWithEquality<float array> "Border_StrokeDashArrayList" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Border.StrokeDashArrayProperty)
            | ValueSome points ->
                let coll = DoubleCollection()
                points |> Array.iter coll.Add
                target.SetValue(Border.StrokeDashArrayProperty, coll))

    let StrokeDashOffset =
        Attributes.defineBindableFloat Border.StrokeDashOffsetProperty

    let StrokeLineCap =
        Attributes.defineBindableWithEquality<PenLineCap> Border.StrokeLineCapProperty

    let StrokeLineJoin =
        Attributes.defineBindableWithEquality<PenLineJoin> Border.StrokeLineJoinProperty

    let StrokeMiterLimit =
        Attributes.defineBindableFloat Border.StrokeMiterLimitProperty

    let StrokeShape =
        Attributes.defineSimpleScalarWithEquality<Shape> "Border_StrokeShape" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Border.StrokeShapeProperty)
            | ValueSome value -> target.SetValue(Border.StrokeShapeProperty, value))

    let StrokeShapeString =
        Attributes.defineSimpleScalarWithEquality<string> "Border_StrokeShapeString" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Border.StrokeShapeProperty)
            | ValueSome value -> target.SetValue(Border.StrokeShapeProperty, StrokeShapeTypeConverter().ConvertFromInvariantString(value)))

    let StrokeShapeWidget = Attributes.defineBindableWidget Border.StrokeShapeProperty

    let StrokeThickness = Attributes.defineBindableFloat Border.StrokeThicknessProperty

[<AutoOpen>]
module BorderBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a Border widget with a content widget</summary>
        /// <param name="content">The content widget</param>
        static member inline Border(content: WidgetBuilder<'msg, #IFabView>) =
            WidgetBuilder<'msg, IFabBorder>(
                Border.WidgetKey,
                AttributesBundle(StackList.empty(), [| Border.Content.WithValue(content.Compile()) |], [||], [||])
            )

[<Extension>]
type BorderModifiers =
    /// <summary>Set the padding inside the border</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The padding inside the border</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabBorder>, value: Thickness) =
        this.AddScalar(Border.Padding.WithValue(value))

    /// <summary>Set the stroke brush of the border</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The brush value</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IFabBorder>, value: Brush) =
        this.AddScalar(Border.Stroke.WithValue(value))

    /// <summary>Set the stroke brush of the border</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The brush widget</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IFabBorder>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Border.StrokeWidget.WithValue(value.Compile()))

    /// <summary>Set the stroke dash pattern of the border</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The dash pattern value</param>
    [<Extension>]
    static member inline strokeDashArray(this: WidgetBuilder<'msg, #IFabShape>, value: seq<float>) =
        this.AddScalar(Border.StrokeDashArray.WithValue(Array.ofSeq value))

    /// <summary>Set the stroke dash pattern of the border</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The dash pattern value</param>
    [<Extension>]
    static member inline strokeDashArray(this: WidgetBuilder<'msg, #IFabBorder>, value: string) =
        this.AddScalar(Border.StrokeDashArrayString.WithValue(value))

    /// <summary>Set the stroke dash offset of the border</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The dash offset value</param>
    [<Extension>]
    static member inline strokeDashOffset(this: WidgetBuilder<'msg, #IFabBorder>, value: float) =
        this.AddScalar(Border.StrokeDashOffset.WithValue(value))

    /// <summary>Set the stroke line cap of the border</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The line cap value</param>
    [<Extension>]
    static member inline strokeLineCap(this: WidgetBuilder<'msg, #IFabBorder>, value: PenLineCap) =
        this.AddScalar(Border.StrokeLineCap.WithValue(value))

    /// <summary>Set the stroke line join of the border</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The line join value</param>
    [<Extension>]
    static member inline strokeLineJoin(this: WidgetBuilder<'msg, #IFabBorder>, value: PenLineJoin) =
        this.AddScalar(Border.StrokeLineJoin.WithValue(value))

    /// <summary>Set the stroke miter limit of the border</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The miter limit value</param>
    [<Extension>]
    static member inline strokeMiterLimit(this: WidgetBuilder<'msg, #IFabBorder>, value: float) =
        this.AddScalar(Border.StrokeMiterLimit.WithValue(value))

    /// <summary>Set the stroke shape of the border</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The shape value</param>
    [<Extension>]
    static member inline strokeShape(this: WidgetBuilder<'msg, #IFabBorder>, value: Shape) =
        this.AddScalar(Border.StrokeShape.WithValue(value))

    /// <summary>Set the stroke shape of the border</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The shape value</param>
    [<Extension>]
    static member inline strokeShape(this: WidgetBuilder<'msg, #IFabBorder>, value: string) =
        this.AddScalar(Border.StrokeShapeString.WithValue(value))

    /// <summary>Set the shape of the border</summary>
    /// <param name="this">Current widget</param>
    /// <param name="content">The shape widget</param>
    [<Extension>]
    static member inline strokeShape(this: WidgetBuilder<'msg, #IFabBorder>, content: WidgetBuilder<'msg, #IFabShape>) =
        this.AddWidget(Border.StrokeShapeWidget.WithValue(content.Compile()))

    /// <summary>Set the stroke thickness of the border</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The thickness value</param>
    [<Extension>]
    static member inline strokeThickness(this: WidgetBuilder<'msg, #IFabBorder>, value: float) =
        this.AddScalar(Border.StrokeThickness.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Border control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabBorder>, value: ViewRef<Border>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type BorderExtraModifiers =
    /// <summary>Set the padding inside the border</summary>
    /// <param name="this">Current widget</param>
    /// <param name="uniformSize">The uniform padding inside the border</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabBorder>, uniformSize: float) = this.padding(Thickness(uniformSize))

    /// <summary>Set the padding inside the border</summary>
    /// <param name="this">Current widget</param>
    /// <param name="left">The left component of the padding inside the border</param>
    /// <param name="top">The left component of the padding inside the border</param>
    /// <param name="right">The left component of the padding inside the border</param>
    /// <param name="bottom">The left component of the padding inside the border</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabBorder>, left: float, top: float, right: float, bottom: float) =
        this.padding(Thickness(left, top, right, bottom))
