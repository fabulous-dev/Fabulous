namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IVisualElement =
    inherit INavigableElement

module VisualElement =
    let AnchorX =
        Attributes.defineBindableFloat VisualElement.AnchorXProperty

    let AnchorY =
        Attributes.defineBindableFloat VisualElement.AnchorYProperty

    let BackgroundColor =
        Attributes.defineBindableAppThemeColor VisualElement.BackgroundColorProperty

    let Background =
        Attributes.defineBindableAppTheme<Brush> VisualElement.BackgroundProperty

    let Clip =
        Attributes.defineBindableWidget VisualElement.ClipProperty

    let FlowDirection =
        Attributes.defineBindableEnum<FlowDirection> VisualElement.FlowDirectionProperty

    let HeightRequest =
        Attributes.defineBindableFloat VisualElement.HeightRequestProperty

    let WidthRequest =
        Attributes.defineBindableFloat VisualElement.WidthRequestProperty

    let InputTransparent =
        Attributes.defineBindableBool VisualElement.InputTransparentProperty

    let IsEnabled =
        Attributes.defineBindableBool VisualElement.IsEnabledProperty

    let IsTabStop =
        Attributes.defineBindableBool VisualElement.IsTabStopProperty

    let IsVisible =
        Attributes.defineBindableBool VisualElement.IsVisibleProperty

    let MinimumHeightRequest =
        Attributes.defineBindableFloat VisualElement.MinimumHeightRequestProperty

    let MinimumWidthRequest =
        Attributes.defineBindableFloat VisualElement.MinimumWidthRequestProperty

    let Opacity =
        Attributes.defineBindableFloat VisualElement.OpacityProperty

    let Rotation =
        Attributes.defineBindableFloat VisualElement.RotationProperty

    let RotationX =
        Attributes.defineBindableFloat VisualElement.RotationXProperty

    let RotationY =
        Attributes.defineBindableFloat VisualElement.RotationYProperty

    let Scale =
        Attributes.defineBindableFloat VisualElement.ScaleProperty

    let ScaleX =
        Attributes.defineBindableFloat VisualElement.ScaleXProperty

    let ScaleY =
        Attributes.defineBindableFloat VisualElement.ScaleYProperty

    let TabIndex =
        Attributes.defineBindableInt VisualElement.TabIndexProperty

    let TranslationX =
        Attributes.defineBindableFloat VisualElement.TranslationXProperty

    let TranslationY =
        Attributes.defineBindableFloat VisualElement.TranslationYProperty

    let Visual =
        Attributes.defineBindableWithEquality<IVisual> VisualElement.VisualProperty

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
    static member inline backgroundColor(this: WidgetBuilder<'msg, #IVisualElement>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(VisualElement.BackgroundColor.WithValue( ColorPair.create light dark))

    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IVisualElement>, light: Brush, ?dark: Brush) =
        this.AddScalar(VisualElement.Background.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline clip<'msg, 'marker, 'contentMarker when 'marker :> IVisualElement and 'contentMarker :> IGeometry>
        (
            this: WidgetBuilder<'msg, 'marker>,
            content: WidgetBuilder<'msg, 'contentMarker>
        ) =
        this.AddWidget(VisualElement.Clip.WithValue(content.Compile()))

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
