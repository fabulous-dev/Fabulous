namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IVisualElement =
    inherit INavigableElement

module VisualElement =
    let AnchorX =
        Attributes.defineSmallBindable<float> VisualElement.AnchorXProperty SmallScalars.Float.decode

    let AnchorY =
        Attributes.defineSmallBindable<float> VisualElement.AnchorYProperty SmallScalars.Float.decode

    let BackgroundColor =
        Attributes.defineAppThemeBindable<Color> VisualElement.BackgroundColorProperty

    let Background =
        Attributes.defineAppThemeBindable<Brush> VisualElement.BackgroundProperty

    let Clip =
        Attributes.defineBindableWidget VisualElement.ClipProperty

    let FlowDirection =
        Attributes.defineSmallBindable<FlowDirection> VisualElement.FlowDirectionProperty SmallScalars.FlowDirection.decode

    let HeightRequest =
        Attributes.defineSmallBindable<float> VisualElement.HeightRequestProperty SmallScalars.Float.decode

    let WidthRequest =
        Attributes.defineSmallBindable<float> VisualElement.WidthRequestProperty SmallScalars.Float.decode

    let InputTransparent =
        Attributes.defineSmallBindable<bool> VisualElement.InputTransparentProperty SmallScalars.Bool.decode

    let IsEnabled =
        Attributes.defineSmallBindable<bool> VisualElement.IsEnabledProperty SmallScalars.Bool.decode

    let IsTabStop =
        Attributes.defineSmallBindable<bool> VisualElement.IsTabStopProperty SmallScalars.Bool.decode

    let IsVisible =
        Attributes.defineSmallBindable<bool> VisualElement.IsVisibleProperty SmallScalars.Bool.decode

    let MinimumHeightRequest =
        Attributes.defineSmallBindable<float> VisualElement.MinimumHeightRequestProperty SmallScalars.Float.decode

    let MinimumWidthRequest =
        Attributes.defineSmallBindable<float> VisualElement.MinimumWidthRequestProperty SmallScalars.Float.decode

    let Opacity =
        Attributes.defineSmallBindable<float> VisualElement.OpacityProperty SmallScalars.Float.decode

    let Rotation =
        Attributes.defineSmallBindable<float> VisualElement.RotationProperty SmallScalars.Float.decode

    let RotationX =
        Attributes.defineSmallBindable<float> VisualElement.RotationXProperty SmallScalars.Float.decode

    let RotationY =
        Attributes.defineSmallBindable<float> VisualElement.RotationYProperty SmallScalars.Float.decode

    let Scale =
        Attributes.defineSmallBindable<float> VisualElement.ScaleProperty SmallScalars.Float.decode

    let ScaleX =
        Attributes.defineSmallBindable<float> VisualElement.ScaleXProperty SmallScalars.Float.decode

    let ScaleY =
        Attributes.defineSmallBindable<float> VisualElement.ScaleYProperty SmallScalars.Float.decode

    let TabIndex =
        Attributes.defineSmallBindable<int> VisualElement.TabIndexProperty SmallScalars.Int.decode

    let TranslationX =
        Attributes.defineSmallBindable<float> VisualElement.TranslationXProperty SmallScalars.Float.decode

    let TranslationY =
        Attributes.defineSmallBindable<float> VisualElement.TranslationYProperty SmallScalars.Float.decode

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
