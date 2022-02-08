namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type IVisualElement =
    inherit IElement

module VisualElement =
    let IsEnabled =
        Attributes.defineBindable<bool> VisualElement.IsEnabledProperty

    let Opacity =
        Attributes.defineBindable<float> VisualElement.OpacityProperty

    let BackgroundColor =
        Attributes.defineAppThemeBindable<Color> VisualElement.BackgroundColorProperty

    let Height =
        Attributes.defineBindable<float> VisualElement.HeightRequestProperty

    let Width =
        Attributes.defineBindable<float> VisualElement.WidthRequestProperty

    let IsVisible =
        Attributes.defineBindable<bool> VisualElement.IsVisibleProperty

[<Extension>]
type VisualElementModifiers =
    [<Extension>]
    static member inline isEnabled(this: WidgetBuilder<'msg, #IVisualElement>, value: bool) =
        this.AddScalar(VisualElement.IsEnabled.WithValue(value))

    [<Extension>]
    static member inline opacity(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.Opacity.WithValue(value))

    [<Extension>]
    static member inline backgroundColor(this: WidgetBuilder<'msg, #IVisualElement>, light: Color, ?dark: Color) =
        this.AddScalar(VisualElement.BackgroundColor.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline isVisible(this: WidgetBuilder<'msg, #IVisualElement>, value: bool) =
        this.AddScalar(VisualElement.IsVisible.WithValue(value))

    [<Extension>]
    static member inline height(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.Height.WithValue(value))

    [<Extension>]
    static member inline width(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.Width.WithValue(value))
