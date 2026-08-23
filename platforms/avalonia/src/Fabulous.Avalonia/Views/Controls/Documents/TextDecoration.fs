namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Collections
open Avalonia.Media
open Fabulous

type IFabTextDecoration =
    inherit IFabElement

module TextDecoration =
    let WidgetKey = Widgets.register<TextDecoration>()

    let Location =
        Attributes.defineAvaloniaPropertyWithEquality TextDecoration.LocationProperty

    let StrokeWidget =
        Attributes.defineAvaloniaPropertyWidget TextDecoration.StrokeProperty

    let Stroke =
        Attributes.defineAvaloniaPropertyWithEquality TextDecoration.StrokeProperty

    let StrokeThicknessUnit =
        Attributes.defineAvaloniaPropertyWithEquality TextDecoration.StrokeThicknessUnitProperty

    let StrokeDashArray =
        Attributes.defineSimpleScalarWithEquality<float list> "TextDecoration_StrokeDashArray" (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(TextDecoration.StrokeDashArrayProperty)
            | ValueSome points ->
                let coll = AvaloniaList<float>()
                points |> List.iter coll.Add
                target.SetValue(TextDecoration.StrokeDashArrayProperty, coll) |> ignore)

    let StrokeDashOffset =
        Attributes.defineAvaloniaPropertyWithEquality TextDecoration.StrokeDashOffsetProperty

    let StrokeThickness =
        Attributes.defineAvaloniaPropertyWithEquality TextDecoration.StrokeThicknessProperty

    let StrokeLineCap =
        Attributes.defineAvaloniaPropertyWithEquality TextDecoration.StrokeLineCapProperty

    let StrokeOffset =
        Attributes.defineAvaloniaPropertyWithEquality TextDecoration.StrokeOffsetProperty

    let StrokeOffsetUnit =
        Attributes.defineAvaloniaPropertyWithEquality TextDecoration.StrokeOffsetUnitProperty

[<AutoOpen>]
module TextDecorationBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TextDecoration widget.</summary>
        /// <param name="location">The location of the TextDecoration.</param>
        static member inline TextDecoration(location: TextDecorationLocation) =
            WidgetBuilder<'msg, IFabTextDecoration>(TextDecoration.WidgetKey, TextDecoration.Location.WithValue(location))

type TextDecorationModifiers =
    /// <summary>Sets the Stroke property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The StrokeWidget value.</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IFabTextDecoration>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TextDecoration.StrokeWidget.WithValue(value.Compile()))

    /// <summary>Sets the Stroke property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Stroke value.</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IFabTextDecoration>, value: IBrush) =
        this.AddScalar(TextDecoration.Stroke.WithValue(value))

    /// <summary>Sets the Stroke property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Stroke value.</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IFabTextDecoration>, value: Color) =
        TextDecorationModifiers.stroke(this, View.SolidColorBrush(value))

    /// <summary>Sets the Stroke property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Stroke value.</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IFabTextDecoration>, value: string) =
        TextDecorationModifiers.stroke(this, View.SolidColorBrush(value))

    /// <summary>Sets the StrokeThicknessUnit property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The StrokeThicknessUnit value.</param>
    [<Extension>]
    static member inline strokeThicknessUnit(this: WidgetBuilder<'msg, #IFabTextDecoration>, value: TextDecorationUnit) =
        this.AddScalar(TextDecoration.StrokeThicknessUnit.WithValue(value))

    /// <summary>Sets the StrokeDashArray property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The StrokeDashArray value.</param>
    [<Extension>]
    static member inline strokeDashArray(this: WidgetBuilder<'msg, #IFabTextDecoration>, value: float list) =
        this.AddScalar(TextDecoration.StrokeDashArray.WithValue(value))

    /// <summary>Sets the StrokeDashOffset property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The StrokeDashOffset value.</param>
    [<Extension>]
    static member inline strokeDashOffset(this: WidgetBuilder<'msg, #IFabTextDecoration>, value: float) =
        this.AddScalar(TextDecoration.StrokeDashOffset.WithValue(value))

    /// <summary>Sets the StrokeThickness property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The StrokeThickness value.</param>
    [<Extension>]
    static member inline strokeThickness(this: WidgetBuilder<'msg, #IFabTextDecoration>, value: float) =
        this.AddScalar(TextDecoration.StrokeThickness.WithValue(value))

    /// <summary>Sets the StrokeLineCap property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The StrokeLineCap value.</param>
    [<Extension>]
    static member inline strokeLineCap(this: WidgetBuilder<'msg, #IFabTextDecoration>, value: PenLineCap) =
        this.AddScalar(TextDecoration.StrokeLineCap.WithValue(value))

    /// <summary>Sets the StrokeOffset property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The StrokeOffset value.</param>
    [<Extension>]
    static member inline strokeOffset(this: WidgetBuilder<'msg, #IFabTextDecoration>, value: float) =
        this.AddScalar(TextDecoration.StrokeOffset.WithValue(value))

    /// <summary>Sets the StrokeOffsetUnit property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The StrokeOffsetUnit value.</param>
    [<Extension>]
    static member inline strokeOffsetUnit(this: WidgetBuilder<'msg, #IFabTextDecoration>, value: TextDecorationUnit) =
        this.AddScalar(TextDecoration.StrokeOffsetUnit.WithValue(value))

    /// <summary>Link a ViewRef to access the direct TextDecoration control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTextDecoration>, value: ViewRef<TextDecoration>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
