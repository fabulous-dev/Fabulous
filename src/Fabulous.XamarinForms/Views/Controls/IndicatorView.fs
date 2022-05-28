namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IIndicatorView =
    inherit ITemplatedView

module IndicatorView =
    let WidgetKey = Widgets.register<IndicatorView>()

    let ItemsSource<'T> =
        Attributes.defineBindable<WidgetItems<'T>, System.Collections.Generic.IEnumerable<Widget>>
            IndicatorView.ItemsSourceProperty
            (fun modelValue ->
                seq {
                    for x in modelValue.OriginalItems do
                        modelValue.Template x
                })
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)

    let HideSingle =
        Attributes.defineBindableBool IndicatorView.HideSingleProperty

    let IndicatorColor =
        Attributes.defineBindableAppThemeColor IndicatorView.IndicatorColorProperty

    let IndicatorSize =
        Attributes.defineBindableFloat IndicatorView.IndicatorSizeProperty

    let IndicatorsShape =
        Attributes.defineBindableEnum<IndicatorShape> IndicatorView.IndicatorsShapeProperty

    let MaximumVisible =
        Attributes.defineBindableInt IndicatorView.MaximumVisibleProperty

    let SelectedIndicatorColor =
        Attributes.defineBindableAppThemeColor IndicatorView.SelectedIndicatorColorProperty

[<AutoOpen>]
module IndicatorViewBuilders =
    type Fabulous.XamarinForms.View with
        static member inline IndicatorView<'msg>(reference: ViewRef<IndicatorView>) =
            WidgetBuilder<'msg, IIndicatorView>(
                IndicatorView.WidgetKey,
                ViewRefAttributes.ViewRef.WithValue(reference.Unbox)
            )

[<Extension>]
type IndicatorViewModifiers =
    /// <summary>Sets the selected indicator color.</summary>
    /// <param name="light">The color of the indicator in the light theme.</param>
    /// <param name="dark">The color of the indicator in the dark theme.</param>
    [<Extension>]
    static member inline selectedIndicatorColor
        (
            this: WidgetBuilder<'msg, #IIndicatorView>,
            light: Color,
            ?dark: Color
        ) =
        this.AddScalar(IndicatorView.SelectedIndicatorColor.WithValue(AppTheme.create<Color> light dark))

    /// <summary>Sets the indicator size.</summary>
    /// <param name="size">The size of the indicator.</param>
    [<Extension>]
    static member inline indicatorSize(this: WidgetBuilder<'msg, #IIndicatorView>, size: float) =
        this.AddScalar(IndicatorView.IndicatorSize.WithValue(size))

    /// <summary>Sets the indicator shape.</summary>
    /// <param name="shape">The shape of the indicator.</param>
    [<Extension>]
    static member inline indicatorsShape(this: WidgetBuilder<'msg, #IIndicatorView>, shape: IndicatorShape) =
        this.AddScalar(IndicatorView.IndicatorsShape.WithValue(shape))

    [<Extension>]
    static member inline hideSingle(this: WidgetBuilder<'msg, #IIndicatorView>, hide: bool) =
        this.AddScalar(IndicatorView.HideSingle.WithValue(hide))

    /// <summary>Sets the indicator color.</summary>
    /// <param name="light">The color of the indicator in the light theme.</param>
    /// <param name="dark">The color of the indicator in the dark theme.</param>
    [<Extension>]
    static member inline indicatorColor(this: WidgetBuilder<'msg, #IIndicatorView>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(IndicatorView.IndicatorColor.WithValue(AppTheme.create<Color> light dark))

    /// <summary>Sets the maximum number of visible indicators.</summary>
    /// <param name="maximum">The maximum number of visible indicators.</param>
    [<Extension>]
    static member inline maximumVisible(this: WidgetBuilder<'msg, IIndicatorView>, count: int) =
        this.AddScalar(IndicatorView.MaximumVisible.WithValue(count))
