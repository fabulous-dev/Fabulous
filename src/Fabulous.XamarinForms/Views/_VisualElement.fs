namespace Fabulous.XamarinForms

open System
open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IVisualElement =
    inherit INavigableElement

[<Struct>]
type TranslateToData =
    { X: float
      Y: float
      AnimationDuration: uint32
      Easing: Easing }

[<Struct>]
type ScaleToData =
    { Scale: float
      AnimationDuration: uint32
      Easing: Easing }

[<Struct>]
type FadeToData =
    { Opacity: float
      AnimationDuration: uint32
      Easing: Easing }

[<Struct>]
type RotateToData =
    { Rotation: float
      AnimationDuration: uint32
      Easing: Easing }

module VisualElementUpdaters =
    let updateVisualElementFocus oldValueOpt (newValueOpt: ValueEventData<bool, bool> voption) (node: IViewNode) =
        let target = node.Target :?> VisualElement

        let onEventName = "Focus_On"
        let onEvent = target.Focused

        let offEventName = "Focus_Off"
        let offEvent = target.Unfocused

        match newValueOpt with
        | ValueNone ->
            // The attribute is no longer applied, so we clean up the events
            match node.TryGetHandler(onEventName) with
            | ValueNone -> ()
            | ValueSome handler -> onEvent.RemoveHandler(handler)

            match node.TryGetHandler(offEventName) with
            | ValueNone -> ()
            | ValueSome handler -> offEvent.RemoveHandler(handler)

            // Only clear the property if a value was set before
            match oldValueOpt with
            | ValueNone -> ()
            | ValueSome _ -> target.Unfocus()

        | ValueSome curr ->
            // Clean up the old event handlers if any
            match node.TryGetHandler(onEventName) with
            | ValueNone -> ()
            | ValueSome handler -> onEvent.RemoveHandler(handler)

            match node.TryGetHandler(offEventName) with
            | ValueNone -> ()
            | ValueSome handler -> offEvent.RemoveHandler(handler)

            // Set the new value
            if curr.Value then
                target.Focus() |> ignore
            else
                target.Unfocus()

            // Set the new event handlers
            let onHandler =
                EventHandler<FocusEventArgs>
                    (fun sender args ->
                        if not (sender :?> VisualElement).IsFocused then
                            let r = curr.Event true
                            Dispatcher.dispatch node r)

            node.SetHandler(onEventName, ValueSome onHandler)
            onEvent.AddHandler(onHandler)

            let offHandler =
                EventHandler<FocusEventArgs>
                    (fun sender args ->
                        if (sender :?> VisualElement).IsFocused then
                            let r = curr.Event false
                            Dispatcher.dispatch node r)

            node.SetHandler(offEventName, ValueSome offHandler)
            offEvent.AddHandler(offHandler)

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

    let TabIndex =
        Attributes.defineBindableInt VisualElement.TabIndexProperty

    let Visual =
        Attributes.defineBindableWithEquality<IVisual> VisualElement.VisualProperty

    [<Obsolete("Use FocusWithEvent instead")>]
    let Focused =
        Attributes.defineEvent<FocusEventArgs>
            "VisualElement_Focused"
            (fun target -> (target :?> VisualElement).Focused)

    [<Obsolete("Use FocusWithEvent instead")>]
    let Unfocused =
        Attributes.defineEvent<FocusEventArgs>
            "VisualElement_Unfocused"
            (fun target -> (target :?> VisualElement).Unfocused)

    let TranslateTo =
        Attributes.defineSimpleScalarWithEquality<TranslateToData>
            "View_TranslateTo"
            (fun _ newValueOpt node ->
                let view = node.Target :?> View

                match newValueOpt with
                | ValueNone ->
                    view.TranslateTo(0., 0., uint 0, Easing.Linear)
                    |> ignore
                | ValueSome data ->
                    view.TranslateTo(data.X, data.Y, data.AnimationDuration, data.Easing)
                    |> ignore)

    let TranslationX =
        Attributes.defineBindableFloat VisualElement.TranslationXProperty

    let TranslationY =
        Attributes.defineBindableFloat VisualElement.TranslationYProperty

    let ScaleTo =
        Attributes.defineSimpleScalarWithEquality<ScaleToData>
            "View_ScaleTo"
            (fun _ newValueOpt node ->
                let view = node.Target :?> View

                match newValueOpt with
                | ValueNone -> view.ScaleTo(1., uint 0, Easing.Linear) |> ignore
                | ValueSome data ->
                    view.ScaleTo(data.Scale, data.AnimationDuration, data.Easing)
                    |> ignore)

    let ScaleXTo =
        Attributes.defineSimpleScalarWithEquality<ScaleToData>
            "View_ScaleXTo"
            (fun _ newValueOpt node ->
                let view = node.Target :?> View

                match newValueOpt with
                | ValueNone -> view.ScaleXTo(1., uint 0, Easing.Linear) |> ignore
                | ValueSome data ->
                    view.ScaleXTo(data.Scale, data.AnimationDuration, data.Easing)
                    |> ignore)

    let ScaleYTo =
        Attributes.defineSimpleScalarWithEquality<ScaleToData>
            "View_ScaleYTo"
            (fun _ newValueOpt node ->
                let view = node.Target :?> View

                match newValueOpt with
                | ValueNone -> view.ScaleYTo(1., uint 0, Easing.Linear) |> ignore
                | ValueSome data ->
                    view.ScaleYTo(data.Scale, data.AnimationDuration, data.Easing)
                    |> ignore)

    let FadeTo =
        Attributes.defineSimpleScalarWithEquality<FadeToData>
            "View_FadeTo"
            (fun _ newValueOpt node ->
                let view = node.Target :?> View

                match newValueOpt with
                | ValueNone -> view.FadeTo(0., uint 0, Easing.Linear) |> ignore
                | ValueSome data ->
                    view.FadeTo(data.Opacity, data.AnimationDuration, data.Easing)
                    |> ignore)

    let RotateTo =
        Attributes.defineSimpleScalarWithEquality<RotateToData>
            "View_RotateTo"
            (fun _ newValueOpt node ->
                let view = node.Target :?> View

                match newValueOpt with
                | ValueNone -> view.RotateTo(0., uint 0, Easing.Linear) |> ignore
                | ValueSome data ->
                    view.RotateTo(data.Rotation, data.AnimationDuration, data.Easing)
                    |> ignore)

    let RotateXTo =
        Attributes.defineSimpleScalarWithEquality<RotateToData>
            "View_RotateXTo"
            (fun _ newValueOpt node ->
                let view = node.Target :?> View

                match newValueOpt with
                | ValueNone ->
                    view.RotateXTo(0., uint 0, Easing.Linear)
                    |> ignore
                | ValueSome data ->
                    view.RotateXTo(data.Rotation, data.AnimationDuration, data.Easing)
                    |> ignore)

    let RotateYTo =
        Attributes.defineSimpleScalarWithEquality<RotateToData>
            "View_RotateYTo"
            (fun _ newValueOpt node ->
                let view = node.Target :?> View

                match newValueOpt with
                | ValueNone ->
                    view.RotateYTo(0., uint 0, Easing.Linear)
                    |> ignore
                | ValueSome data ->
                    view.RotateYTo(data.Rotation, data.AnimationDuration, data.Easing)
                    |> ignore)

    let FocusWithEvent =
        Attributes.defineSimpleScalar
            "VisualElement_FocusWithEvent"
            ScalarAttributeComparers.noCompare
            VisualElementUpdaters.updateVisualElementFocus

[<Extension>]
type VisualElementModifiers =
    /// <summary>Sets the anchor of the element on the X axis.</summary>
    [<Extension>]
    static member inline anchorX(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.AnchorX.WithValue(value))

    /// <summary>Sets the anchor of the element on the Y axis.</summary>
    [<Extension>]
    static member inline anchorY(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.AnchorY.WithValue(value))

    /// <summary>Sets the background color depending if light or dark mode.</summary>
    [<Extension; Obsolete("Use background instead.")>]
    static member inline backgroundColor(this: WidgetBuilder<'msg, #IVisualElement>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(VisualElement.BackgroundColor.WithValue(AppTheme.create light dark))

    /// <summary>Sets the background color depending if light or dark mode.</summary>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IVisualElement>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(VisualElement.BackgroundColor.WithValue(AppTheme.create light dark))

    /// <summary>Sets the background brush depending if light or dark mode.</summary>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IVisualElement>, light: Brush, ?dark: Brush) =
        this.AddScalar(VisualElement.Background.WithValue(AppTheme.create light dark))

    /// <summary>Clips the shape of the element based on a geometry.</summary>
    [<Extension>]
    static member inline clip<'msg, 'marker, 'contentMarker when 'marker :> IVisualElement and 'contentMarker :> IGeometry>
        (
            this: WidgetBuilder<'msg, 'marker>,
            content: WidgetBuilder<'msg, 'contentMarker>
        ) =
        this.AddWidget(VisualElement.Clip.WithValue(content.Compile()))

    /// <summary>Sets the flow direction of the element.</summary>
    [<Extension>]
    static member inline flowDirection(this: WidgetBuilder<'msg, #IVisualElement>, value: FlowDirection) =
        this.AddScalar(VisualElement.FlowDirection.WithValue(value))

    /// <summary>Sets the focus state of the element and listen for any changes.</summary>
    /// <param name="isFocused">The focus state</param>
    /// <param name="onFocusChange">The message to dispatch when the focus state changes</param>
    [<Extension>]
    static member inline focus
        (
            this: WidgetBuilder<'msg, #IVisualElement>,
            isFocused: bool,
            onFocusChanged: bool -> 'msg
        ) =
        this.AddScalar(
            VisualElement.FocusWithEvent.WithValue(
                ValueEventData.create isFocused (fun args -> onFocusChanged args |> box)
            )
        )

    /// <summary>Sets the height of the element.</summary>
    [<Extension>]
    static member inline height(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.HeightRequest.WithValue(value))

    /// <summary>Sets a value indicating whether this element should interact with the user.</summary>
    [<Extension>]
    static member inline inputTransparent(this: WidgetBuilder<'msg, #IVisualElement>, value: bool) =
        this.AddScalar(VisualElement.InputTransparent.WithValue(value))

    /// <summary>Sets a value indicating whether this element is enabled.</summary>
    [<Extension>]
    static member inline isEnabled(this: WidgetBuilder<'msg, #IVisualElement>, value: bool) =
        this.AddScalar(VisualElement.IsEnabled.WithValue(value))

    /// <summary>Sets a value that indicates whether a control is included in tab navigation.</summary>
    [<Extension>]
    static member inline isTabStop(this: WidgetBuilder<'msg, #IVisualElement>, value: bool) =
        this.AddScalar(VisualElement.IsTabStop.WithValue(value))

    /// <summary>Sets a value indicating whether this element is visible.</summary>
    [<Extension>]
    static member inline isVisible(this: WidgetBuilder<'msg, #IVisualElement>, value: bool) =
        this.AddScalar(VisualElement.IsVisible.WithValue(value))

    /// <summary>Sets the minimum height of the element.</summary>
    [<Extension>]
    static member inline minimumHeight(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.MinimumHeightRequest.WithValue(value))

    /// <summary>Sets the minimum width of the element.</summary>
    [<Extension>]
    static member inline minimumWidth(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.MinimumWidthRequest.WithValue(value))

    /// <summary>Sets the opacity of the element.</summary>
    [<Extension>]
    static member inline opacity(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.Opacity.WithValue(value))

    /// <summary>Sets the tab index of the element.</summary>
    [<Extension>]
    static member inline tabIndex(this: WidgetBuilder<'msg, #IVisualElement>, value: int) =
        this.AddScalar(VisualElement.TabIndex.WithValue(value))

    /// <summary>Translates the position of the element on the X axis.</summary>
    [<Extension>]
    static member inline translationX(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.TranslationX.WithValue(value))

    /// <summary>Translates the position of the element on the Y axis.</summary>
    [<Extension>]
    static member inline translationY(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.TranslationY.WithValue(value))

    /// <summary>Sets the visual of an element. With the VisualMarker class providing the following IVisual properties: Default, MatchParent, Material.</summary>
    [<Extension>]
    static member inline visual(this: WidgetBuilder<'msg, #IVisualElement>, value: IVisual) =
        this.AddScalar(VisualElement.Visual.WithValue(value))

    /// <summary>Sets the width of the element.</summary>
    [<Extension>]
    static member inline width(this: WidgetBuilder<'msg, #IVisualElement>, value: float) =
        this.AddScalar(VisualElement.WidthRequest.WithValue(value))

    [<Extension; Obsolete("Use focus instead")>]
    static member inline onFocused(this: WidgetBuilder<'msg, #IVisualElement>, onFocused: bool -> 'msg) =
        this.AddScalar(VisualElement.Focused.WithValue(fun args -> onFocused args.IsFocused |> box))

    [<Extension; Obsolete("Use focus instead")>]
    static member inline onUnfocused(this: WidgetBuilder<'msg, #IVisualElement>, onUnfocused: bool -> 'msg) =
        this.AddScalar(VisualElement.Unfocused.WithValue(fun args -> onUnfocused args.IsFocused |> box))

[<Extension>]
type VisualElementExtraModifiers =
    /// <summary>Sets the size of an element by applying the width and height of the element.</summary>
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
type VisualElementAnimationModifiers =
    /// <summary>Animates elements Opacity property from their current values to the new values. This ensures that the input layout is in the same position as the visual layout.</summary>
    /// <param name="opacity">The value of the final opacity value.</param>
    /// <param name="duration">The time, in milliseconds, over which to animate the transition. The default is 250.</param>
    /// <param name="easing">The easing of the animation.</param>
    [<Extension>]
    static member inline fadeTo
        (
            this: WidgetBuilder<'msg, #IVisualElement>,
            opacity: float,
            duration: int,
            easing: Easing
        ) =
        this.AddScalar(
            VisualElement.FadeTo.WithValue(
                { Opacity = opacity
                  AnimationDuration = uint duration
                  Easing = easing }
            )
        )

    /// <summary>Animates an elements Rotation property from its current value to the new value. This ensures that the input layout is in the same position as the visual layout.</summary>
    /// <param name="rotation">The value of the final rotation value.</param>
    /// <param name="duration">The time, in milliseconds, over which to animate the transition. The default is 250.</param>
    /// <param name="easing">The easing of the animation.</param>
    [<Extension>]
    static member inline rotateTo
        (
            this: WidgetBuilder<'msg, #IVisualElement>,
            rotation: float,
            duration: int,
            easing: Easing
        ) =
        this.AddScalar(
            VisualElement.RotateTo.WithValue(
                { Rotation = rotation
                  AnimationDuration = uint duration
                  Easing = easing }
            )
        )

    /// <summary>Animates an elements RotationX property from its current value to the new value. This ensures that the input layout is in the same position as the visual layout.</summary>
    /// <param name="rotation">The value of the final rotationX value.</param>
    /// <param name="duration">The time, in milliseconds, over which to animate the transition. The default is 250.</param>
    /// <param name="easing">The easing of the animation.</param>
    [<Extension>]
    static member inline rotateXTo
        (
            this: WidgetBuilder<'msg, #IVisualElement>,
            rotation: float,
            duration: int,
            easing: Easing
        ) =
        this.AddScalar(
            VisualElement.RotateXTo.WithValue(
                { Rotation = rotation
                  AnimationDuration = uint duration
                  Easing = easing }
            )
        )

    /// <summary>Animates an elements RotationY property from its current value to the new value. This ensures that the input layout is in the same position as the visual layout.</summary>
    /// <param name="rotation">The value of the final rotationY value.</param>
    /// <param name="duration">The time, in milliseconds, over which to animate the transition. The default is 250.</param>
    /// <param name="easing">The easing of the animation.</param>
    [<Extension>]
    static member inline rotateYTo
        (
            this: WidgetBuilder<'msg, #IVisualElement>,
            rotation: float,
            duration: int,
            easing: Easing
        ) =
        this.AddScalar(
            VisualElement.RotateYTo.WithValue(
                { Rotation = rotation
                  AnimationDuration = uint duration
                  Easing = easing }
            )
        )

    /// <summary>Animates elements Scale property from their current values to the new values. This ensures that the input layout is in the same position as the visual layout.</summary>
    /// <param name="scale">The value of the final scale vector.</param>
    /// <param name="duration">The time, in milliseconds, over which to animate the transition. The default is 250.</param>
    /// <param name="easing">The easing of the animation.</param>
    [<Extension>]
    static member inline scaleTo
        (
            this: WidgetBuilder<'msg, #IVisualElement>,
            scale: float,
            duration: int,
            easing: Easing
        ) =
        this.AddScalar(
            VisualElement.ScaleTo.WithValue(
                { Scale = scale
                  AnimationDuration = uint duration
                  Easing = easing }
            )
        )

    /// <summary>Animates elements ScaleX property from their current value to the new value. This ensures that the input layout is in the same position as the visual layout.</summary>
    /// <param name="scale">The value of the final scale vector.</param>
    /// <param name="duration">The time, in milliseconds, over which to animate the transition. The default is 250.</param>
    /// <param name="easing">The easing of the animation.</param>
    [<Extension>]
    static member inline scaleXTo
        (
            this: WidgetBuilder<'msg, #IVisualElement>,
            scale: float,
            duration: int,
            easing: Easing
        ) =
        this.AddScalar(
            VisualElement.ScaleXTo.WithValue(
                { Scale = scale
                  AnimationDuration = uint duration
                  Easing = easing }
            )
        )

    /// <summary>Animates elements ScaleY property from their current value to the new value. This ensures that the input layout is in the same position as the visual layout.</summary>
    /// <param name="scale">The value of the final scale vector.</param>
    /// <param name="duration">The time, in milliseconds, over which to animate the transition. The default is 250.</param>
    /// <param name="easing">The easing of the animation.</param>
    [<Extension>]
    static member inline scaleYTo
        (
            this: WidgetBuilder<'msg, #IVisualElement>,
            scale: float,
            duration: int,
            easing: Easing
        ) =
        this.AddScalar(
            VisualElement.ScaleYTo.WithValue(
                { Scale = scale
                  AnimationDuration = uint duration
                  Easing = easing }
            )
        )

    /// <summary>Animates an elements TranslationX and TranslationY properties from their current values to the new values. This ensures that the input layout is in the same position as the visual layout.</summary>
    /// <param name="x">The x component of the final translation vector.</param>
    /// <param name="y">The y component of the final translation vector.</param>
    /// <param name="duration">The duration of the animation in milliseconds.</param>
    /// <param name="easing">The easing of the animation.</param>
    [<Extension>]
    static member inline translateTo
        (
            this: WidgetBuilder<'msg, #IVisualElement>,
            x: float,
            y: float,
            duration: int,
            easing: Easing
        ) =
        this.AddScalar(
            VisualElement.TranslateTo.WithValue(
                { X = x
                  Y = y
                  AnimationDuration = uint duration
                  Easing = easing }
            )
        )
