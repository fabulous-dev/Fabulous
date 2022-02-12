namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type IIndicatorView =
    inherit ITemplatedView

module IndicatorView =
    let WidgetKey =
        Widgets.register<FabulousIndicatorView> ()

    let ItemsSource<'T> =
        Attributes.defineBindableWithComparer<WidgetItems<'T>, WidgetItems<'T>, System.Collections.Generic.IEnumerable<Widget>>
            IndicatorView.ItemsSourceProperty
            id
            (fun modelValue ->
                seq {
                    for x in modelValue.OriginalItems do
                        modelValue.Template x
                })
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)

    let Count =
        Attributes.defineBindable<int> IndicatorView.CountProperty

    let HideSingle =
        Attributes.defineBindable<bool> IndicatorView.HideSingleProperty

    let IndicatorColor =
        Attributes.defineAppThemeBindable<Color> IndicatorView.IndicatorColorProperty

    let IndicatorSize =
        Attributes.defineBindable<float> IndicatorView.IndicatorSizeProperty

    let IndicatorsShape =
        Attributes.defineBindable<IndicatorShape> IndicatorView.IndicatorsShapeProperty

    let MaximumVisible =
        Attributes.defineBindable<int> IndicatorView.MaximumVisibleProperty

    let Position =
        Attributes.defineBindable<int> IndicatorView.PositionProperty

    let SelectedIndicatorColor =
        Attributes.defineAppThemeBindable<Color> IndicatorView.SelectedIndicatorColorProperty

    let PositionChanged =
        Attributes.defineEvent<Fabulous.XamarinForms.PositionChangedEventArgs>
            "FabulousIndicatorView_PositionChanged"
            (fun target -> (target :?> FabulousIndicatorView).PositionChanged)

[<AutoOpen>]
module IndicatorViewBuilders =
    type Fabulous.XamarinForms.View with
        static member inline IndicatorView<'msg>(count: int, position: int, positionChanged: int -> 'msg)
            =
            WidgetBuilder<'msg, IIndicatorView>(
                IndicatorView.WidgetKey,
                IndicatorView.Count.WithValue(count),
                IndicatorView.Position.WithValue(position),
                IndicatorView.PositionChanged.WithValue(fun args -> positionChanged args.CurrentPosition |> box)
            )

[<Extension>]
type IndicatorViewModifiers =
    [<Extension>]
    static member inline selectedIndicatorColor
        (
            this: WidgetBuilder<'msg, #IIndicatorView>,
            light: Color,
            ?dark: Color
        ) =
        let appTheme = AppTheme.create<Color> light dark
        this.AddScalar(IndicatorView.SelectedIndicatorColor.WithValue(appTheme))

    [<Extension>]
    static member inline indicatorSize(this: WidgetBuilder<'msg, #IIndicatorView>, size: float) =
        this.AddScalar(IndicatorView.IndicatorSize.WithValue(size))

    [<Extension>]
    static member inline indicatorsShape(this: WidgetBuilder<'msg, #IIndicatorView>, shape: IndicatorShape) =
        this.AddScalar(IndicatorView.IndicatorsShape.WithValue(shape))

    [<Extension>]
    static member inline hideSingle(this: WidgetBuilder<'msg, #IIndicatorView>, hide: bool) =
        this.AddScalar(IndicatorView.HideSingle.WithValue(hide))

    [<Extension>]
    static member inline indicatorColor(this: WidgetBuilder<'msg, #IIndicatorView>, light: Color, ?dark: Color) =
        let appTheme = AppTheme.create<Color> light dark
        this.AddScalar(IndicatorView.IndicatorColor.WithValue(appTheme))

    [<Extension>]
    static member inline maximumVisible(this: WidgetBuilder<'msg, #IIndicatorView>, count: int) =
        this.AddScalar(IndicatorView.MaximumVisible.WithValue(count))

    [<Extension>]
    static member inline position(this: WidgetBuilder<'msg, #IIndicatorView>, value: int) =
        this.AddScalar(IndicatorView.Position.WithValue(value))
