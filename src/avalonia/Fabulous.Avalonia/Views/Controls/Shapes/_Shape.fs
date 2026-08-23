namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Avalonia
open Avalonia.Collections
open Avalonia.Media
open Fabulous

type IFabShape =
    inherit IFabControl

module Shape =

    let FillWidget = Attributes.defineAvaloniaPropertyWidget Shape.FillProperty

    let Fill = Attributes.defineAvaloniaPropertyWithEquality Shape.FillProperty

    let Stretch = Attributes.defineAvaloniaPropertyWithEquality Shape.StretchProperty

    let StrokeWidget = Attributes.defineAvaloniaPropertyWidget Shape.StrokeProperty

    let Stroke = Attributes.defineAvaloniaPropertyWithEquality Shape.StrokeProperty

    let StrokeDashArray =
        Attributes.defineSimpleScalarWithEquality<float list> "Shape_StrokeDashArray" (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Shape.StrokeDashArrayProperty)
            | ValueSome points ->
                let coll = AvaloniaList<float>()
                points |> List.iter coll.Add
                target.SetValue(Shape.StrokeDashArrayProperty, coll) |> ignore)

    let StrokeDashOffset =
        Attributes.defineAvaloniaPropertyWithEquality Shape.StrokeDashOffsetProperty

    let StrokeThickness =
        Attributes.defineAvaloniaPropertyWithEquality Shape.StrokeThicknessProperty

    let StrokeLineCap =
        Attributes.defineAvaloniaPropertyWithEquality Shape.StrokeLineCapProperty

    let StrokeJoin =
        Attributes.defineAvaloniaPropertyWithEquality Shape.StrokeJoinProperty

type ShapeModifiers =
    /// <summary>Sets the Fill property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Fill value.</param>
    [<Extension>]
    static member inline fill(this: WidgetBuilder<'msg, #IFabShape>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Shape.FillWidget.WithValue(value.Compile()))

    /// <summary>Sets the Fill property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Fill value.</param>
    [<Extension>]
    static member inline fill(this: WidgetBuilder<'msg, #IFabShape>, value: IBrush) =
        this.AddScalar(Shape.Fill.WithValue(value))

    /// <summary>Sets the Fill property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Fill value.</param>
    [<Extension>]
    static member inline fill(this: WidgetBuilder<'msg, #IFabShape>, value: Color) =
        ShapeModifiers.fill(this, View.SolidColorBrush(value))

    /// <summary>Sets the Fill property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Fill value.</param>
    [<Extension>]
    static member inline fill(this: WidgetBuilder<'msg, #IFabShape>, value: string) =
        ShapeModifiers.fill(this, View.SolidColorBrush(value))

    /// <summary>Sets the Stretch property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Stretch value.</param>
    [<Extension>]
    static member inline stretch(this: WidgetBuilder<'msg, #IFabShape>, value: Stretch) =
        this.AddScalar(Shape.Stretch.WithValue(value))

    /// <summary>Sets the Stroke property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Stroke value.</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IFabShape>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Shape.StrokeWidget.WithValue(value.Compile()))

    /// <summary>Sets the Stroke property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Stroke value.</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IFabShape>, value: IBrush) =
        this.AddScalar(Shape.Stroke.WithValue(value))

    /// <summary>Sets the Stroke property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Stroke value.</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IFabShape>, value: Color) =
        ShapeModifiers.stroke(this, View.SolidColorBrush(value))

    /// <summary>Sets the Stroke property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Stroke value.</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IFabShape>, value: string) =
        ShapeModifiers.stroke(this, View.SolidColorBrush(value))

    /// <summary>Sets the StrokeDashArray property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The StrokeDashArray value.</param>
    [<Extension>]
    static member inline strokeDashArray(this: WidgetBuilder<'msg, #IFabShape>, value: float list) =
        this.AddScalar(Shape.StrokeDashArray.WithValue(value))

    /// <summary>Sets the StrokeDashOffset property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The StrokeDashOffset value.</param>
    [<Extension>]
    static member inline strokeDashOffset(this: WidgetBuilder<'msg, #IFabShape>, value: float) =
        this.AddScalar(Shape.StrokeDashOffset.WithValue(value))

    /// <summary>Sets the StrokeThickness property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The StrokeThickness value.</param>
    [<Extension>]
    static member inline strokeThickness(this: WidgetBuilder<'msg, #IFabShape>, value: float) =
        this.AddScalar(Shape.StrokeThickness.WithValue(value))

    /// <summary>Sets the StrokeLineCap property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The StrokeLineCap value.</param>
    [<Extension>]
    static member inline strokeLineCap(this: WidgetBuilder<'msg, #IFabShape>, value: PenLineCap) =
        this.AddScalar(Shape.StrokeLineCap.WithValue(value))

    /// <summary>Sets the StrokeJoin property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The StrokeJoin value.</param>
    [<Extension>]
    static member inline strokeJoin(this: WidgetBuilder<'msg, #IFabShape>, value: PenLineJoin) =
        this.AddScalar(Shape.StrokeJoin.WithValue(value))
