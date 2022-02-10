namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.Shapes

type IVisualElement =
    inherit INavigableElement

module VisualElement =
    let AnchorX =
        Attributes.defineBindable<float> VisualElement.AnchorXProperty

    let AnchorY =
        Attributes.defineBindable<float> VisualElement.AnchorYProperty

    let BackgroundColor =
        Attributes.defineAppThemeBindable<Color> VisualElement.BackgroundColorProperty

    let Background =
        Attributes.defineAppThemeBindable<Brush> VisualElement.BackgroundProperty

    let Clip =
        Attributes.defineBindable<Geometry> VisualElement.ClipProperty

    let FlowDirection =
        Attributes.defineBindable<FlowDirection> VisualElement.FlowDirectionProperty

    let HeightRequest =
        Attributes.defineBindable<float> VisualElement.HeightRequestProperty

    let WidthRequest =
        Attributes.defineBindable<float> VisualElement.WidthRequestProperty

    let InputTransparent =
        Attributes.defineBindable<bool> VisualElement.InputTransparentProperty

    let IsEnabled =
        Attributes.defineBindable<bool> VisualElement.IsEnabledProperty

    let IsTabStop =
        Attributes.defineBindable<bool> VisualElement.IsTabStopProperty

    let IsVisible =
        Attributes.defineBindable<bool> VisualElement.IsVisibleProperty

    let MinimumHeightRequest =
        Attributes.defineBindable<float> VisualElement.MinimumHeightRequestProperty

    let MinimumWidthRequest =
        Attributes.defineBindable<float> VisualElement.MinimumWidthRequestProperty

    let Opacity =
        Attributes.defineBindable<float> VisualElement.OpacityProperty

    let Rotation =
        Attributes.defineBindable<float> VisualElement.RotationProperty

    let RotationX =
        Attributes.defineBindable<float> VisualElement.RotationXProperty

    let RotationY =
        Attributes.defineBindable<float> VisualElement.RotationYProperty

    let Scale =
        Attributes.defineBindable<float> VisualElement.ScaleProperty

    let ScaleX =
        Attributes.defineBindable<float> VisualElement.ScaleXProperty

    let ScaleY =
        Attributes.defineBindable<float> VisualElement.ScaleYProperty

    let TabIndex =
        Attributes.defineBindable<int> VisualElement.TabIndexProperty

    let TranslationX =
        Attributes.defineBindable<float> VisualElement.TranslationXProperty

    let TranslationY =
        Attributes.defineBindable<float> VisualElement.TranslationYProperty

    let Visual =
        Attributes.defineBindable<IVisual> VisualElement.VisualProperty


    let Focused =
        Attributes.defineEvent<FocusEventArgs>
            "VisualElement_Focused"
            (fun target -> (target :?> VisualElement).Focused)

    let Unfocused =
        Attributes.defineEvent<FocusEventArgs>
            "VisualElement_Unfocused"
            (fun target -> (target :?> VisualElement).Unfocused)

[<Extension>]
type VisualElementModifiers =

    [<Extension>]
    static member inline anchorX(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.AnchorX.WithValue(value))

    [<Extension>]
    static member inline anchorY(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.AnchorY.WithValue(value))

    [<Extension>]
    static member inline backgroundColor(this: WidgetBuilder<'msg, #IVisualElement>, light: Color, ?dark: Color) =
        this.AddScalar(VisualElement.BackgroundColor.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IVisualElement>, light: Brush, ?dark: Brush) =
        this.AddScalar(VisualElement.Background.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline clip(this: WidgetBuilder<'msg, #IVisualElement>, value: Geometry) =
        this.AddScalar(VisualElement.Clip.WithValue(value))

    [<Extension>]
    static member inline flowDirection(this: WidgetBuilder<'msg, #IVisualElement>, value: FlowDirection) =
        this.AddScalar(VisualElement.FlowDirection.WithValue(value))

    [<Extension>]
    static member inline size(this: WidgetBuilder<'msg, #IVisualElement>, ?width: float, ?height: float) =
        match width, height with
        | None, None -> this
        | Some w, None -> this.AddScalar(VisualElement.WidthRequest.WithValue(w))
        | None, Some h -> this.AddScalar(VisualElement.HeightRequest.WithValue(h))
        | Some w, Some h ->
            this
                .AddScalar(VisualElement.WidthRequest.WithValue(w))
                .AddScalar(VisualElement.HeightRequest.WithValue(h))

    [<Extension>]
    static member inline height(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.HeightRequest.WithValue(value))

    [<Extension>]
    static member inline width(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.WidthRequest.WithValue(value))

    [<Extension>]
    static member inline inputTransparent(this: WidgetBuilder<'msg, #IVisualElement>, value: bool) =
        this.AddScalar(VisualElement.InputTransparent.WithValue(value))

    [<Extension>]
    static member inline isEnabled(this: WidgetBuilder<'msg, #IVisualElement>, value: bool) =
        this.AddScalar(VisualElement.IsEnabled.WithValue(value))

    [<Extension>]
    static member inline isTabStop(this: WidgetBuilder<'msg, #IVisualElement>, value: bool) =
        this.AddScalar(VisualElement.IsTabStop.WithValue(value))

    [<Extension>]
    static member inline isVisible(this: WidgetBuilder<'msg, #IVisualElement>, value: bool) =
        this.AddScalar(VisualElement.IsVisible.WithValue(value))

    [<Extension>]
    static member inline minimumHeight(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.MinimumHeightRequest.WithValue(value))

    [<Extension>]
    static member inline minimumWidth(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.MinimumWidthRequest.WithValue(value))

    [<Extension>]
    static member inline opacity(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.Opacity.WithValue(value))

    [<Extension>]
    static member inline rotation(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.Rotation.WithValue(value))

    [<Extension>]
    static member inline rotationX(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.RotationX.WithValue(value))

    [<Extension>]
    static member inline rotationY(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.RotationY.WithValue(value))

    [<Extension>]
    static member inline scale(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.Scale.WithValue(value))

    [<Extension>]
    static member inline scaleX(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.ScaleX.WithValue(value))

    [<Extension>]
    static member inline scaleY(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.ScaleY.WithValue(value))

    [<Extension>]
    static member inline tabIndex(this: WidgetBuilder<'msg, #IVisualElement>, value: int) =
        this.AddScalar(VisualElement.TabIndex.WithValue(value))

    [<Extension>]
    static member inline translationX(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.TranslationX.WithValue(value))

    [<Extension>]
    static member inline translationY(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.TranslationY.WithValue(value))

    [<Extension>]
    static member inline visual(this: WidgetBuilder<'msg, #IVisualElement>, value: IVisual) =
        this.AddScalar(VisualElement.Visual.WithValue(value))

    [<Extension>]
    static member inline onFocused(this: WidgetBuilder<'msg, #IVisualElement>, onFocused: bool -> 'msg) =
        this.AddScalar(VisualElement.Focused.WithValue(fun args -> onFocused args.IsFocused |> box))

    [<Extension>]
    static member inline onUnfocused(this: WidgetBuilder<'msg, #IVisualElement>, onUnfocused: bool -> 'msg) =
        this.AddScalar(VisualElement.Unfocused.WithValue(fun args -> onUnfocused args.IsFocused |> box))
