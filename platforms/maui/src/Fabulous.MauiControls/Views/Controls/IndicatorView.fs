namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IFabIndicatorView =
    inherit IFabTemplatedView

module IndicatorView =
    let WidgetKey = Widgets.register<IndicatorView>()

    let HideSingle = Attributes.defineBindableBool IndicatorView.HideSingleProperty

    let IndicatorColor =
        Attributes.defineBindableColor IndicatorView.IndicatorColorProperty

    let IndicatorsShape =
        Attributes.defineBindableEnum<IndicatorShape> IndicatorView.IndicatorsShapeProperty

    let IndicatorSize =
        Attributes.defineBindableFloat IndicatorView.IndicatorSizeProperty

    let ItemsSource =
        Attributes.defineBindable<WidgetItems, System.Collections.Generic.IEnumerable<Widget>>
            IndicatorView.ItemsSourceProperty
            (fun modelValue ->
                seq {
                    for x in modelValue.OriginalItems do
                        modelValue.Template x
                })
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)

    let MaximumVisible =
        Attributes.defineBindableInt IndicatorView.MaximumVisibleProperty

    let SelectedIndicatorColor =
        Attributes.defineBindableColor IndicatorView.SelectedIndicatorColorProperty

[<AutoOpen>]
module IndicatorViewBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create an IndicatorView widget with a reference</summary>
        static member inline IndicatorView<'msg when 'msg: equality>(reference: ViewRef<IndicatorView>) =
            WidgetBuilder<'msg, IFabIndicatorView>(IndicatorView.WidgetKey, ViewRefAttributes.ViewRef.WithValue(reference.Unbox))

[<Extension>]
type IndicatorViewModifiers =
    /// <summary>Set whether to hide the indicator if there is only one item</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value indicating whether to hide the indicator if there is only one item</param>
    [<Extension>]
    static member inline hideSingle(this: WidgetBuilder<'msg, #IFabIndicatorView>, value: bool) =
        this.AddScalar(IndicatorView.HideSingle.WithValue(value))

    /// <summary>Set the indicator color</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color of the indicator</param>
    [<Extension>]
    static member inline indicatorColor(this: WidgetBuilder<'msg, #IFabIndicatorView>, value: Color) =
        this.AddScalar(IndicatorView.IndicatorColor.WithValue(value))

    /// <summary>Set the indicator shape</summary>
    /// <param name="this">Current widget</param>
    /// <param name="shape">The shape of the indicator</param>
    [<Extension>]
    static member inline indicatorsShape(this: WidgetBuilder<'msg, #IFabIndicatorView>, shape: IndicatorShape) =
        this.AddScalar(IndicatorView.IndicatorsShape.WithValue(shape))

    /// <summary>Set the indicator size</summary>
    /// <param name="this">Current widget</param>
    /// <param name="size">The size of the indicator</param>
    [<Extension>]
    static member inline indicatorSize(this: WidgetBuilder<'msg, #IFabIndicatorView>, size: float) =
        this.AddScalar(IndicatorView.IndicatorSize.WithValue(size))

    /// <summary>Set the maximum number of visible indicators</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The maximum number of visible indicators</param>
    [<Extension>]
    static member inline maximumVisible(this: WidgetBuilder<'msg, #IFabIndicatorView>, value: int) =
        this.AddScalar(IndicatorView.MaximumVisible.WithValue(value))

    /// <summary>Set the selected indicator color</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color of the indicator</param>
    [<Extension>]
    static member inline selectedIndicatorColor(this: WidgetBuilder<'msg, #IFabIndicatorView>, value: Color) =
        this.AddScalar(IndicatorView.SelectedIndicatorColor.WithValue(value))
