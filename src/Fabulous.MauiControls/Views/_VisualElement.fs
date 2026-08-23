namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type IFabVisualElement =
    inherit IFabNavigableElement

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
        let offEventName = "Focus_Off"

        match newValueOpt with
        | ValueNone ->
            // The attribute is no longer applied, so we clean up the events
            match node.TryGetHandler(onEventName) with
            | ValueNone -> ()
            | ValueSome handler -> handler.Dispose()

            match node.TryGetHandler(offEventName) with
            | ValueNone -> ()
            | ValueSome handler -> handler.Dispose()

            // Only clear the property if a value was set before
            match oldValueOpt with
            | ValueNone -> ()
            | ValueSome _ ->
                if target.IsFocused then
                    target.Unfocus()

        | ValueSome curr ->
            // Clean up the old event handlers if any
            match node.TryGetHandler(onEventName) with
            | ValueNone -> ()
            | ValueSome handler -> handler.Dispose()

            match node.TryGetHandler(offEventName) with
            | ValueNone -> ()
            | ValueSome handler -> handler.Dispose()

            // Set the new value
            if target.IsFocused <> curr.Value then
                if curr.Value then
                    target.Focus() |> ignore
                else
                    target.Unfocus()

            // Set the new event handlers
            let onHandler =
                target.Focused.Subscribe(fun _args ->
                    let (MsgValue r) = curr.Event true
                    Dispatcher.dispatch node r)

            node.SetHandler(onEventName, onHandler)

            let offHandler =
                target.Unfocused.Subscribe(fun _args ->
                    let (MsgValue r) = curr.Event false
                    Dispatcher.dispatch node r)

            node.SetHandler(offEventName, offHandler)

module VisualElement =
    let AnchorX = Attributes.defineBindableFloat VisualElement.AnchorXProperty

    let AnchorY = Attributes.defineBindableFloat VisualElement.AnchorYProperty

    let Background =
        Attributes.defineBindableWithEquality VisualElement.BackgroundProperty

    let BackgroundWidget =
        Attributes.defineBindableWidget VisualElement.BackgroundProperty

    let Clip = Attributes.defineBindableWidget VisualElement.ClipProperty

    let FlowDirection =
        Attributes.defineBindableEnum<FlowDirection> VisualElement.FlowDirectionProperty

    let FocusWithEvent =
        Attributes.defineSimpleScalar "VisualElement_FocusWithEvent" ScalarAttributeComparers.noCompare VisualElementUpdaters.updateVisualElementFocus

    let HeightRequest =
        Attributes.defineBindableFloat VisualElement.HeightRequestProperty

    let InputTransparent =
        Attributes.defineBindableBool VisualElement.InputTransparentProperty

    let IsEnabled = Attributes.defineBindableBool VisualElement.IsEnabledProperty

    let IsVisible = Attributes.defineBindableBool VisualElement.IsVisibleProperty

    let MaximumHeightRequest =
        Attributes.defineBindableFloat VisualElement.MaximumHeightRequestProperty

    let MaximumWidthRequest =
        Attributes.defineBindableFloat VisualElement.MaximumHeightRequestProperty

    let MinimumHeightRequest =
        Attributes.defineBindableFloat VisualElement.MinimumHeightRequestProperty

    let MinimumWidthRequest =
        Attributes.defineBindableFloat VisualElement.MinimumWidthRequestProperty

    let Opacity = Attributes.defineBindableFloat VisualElement.OpacityProperty

    let ScaleX = Attributes.defineBindableFloat VisualElement.ScaleXProperty

    let ScaleY = Attributes.defineBindableFloat VisualElement.ScaleYProperty

    let Shadow = Attributes.defineBindableWidget VisualElement.ShadowProperty

    let TranslationX = Attributes.defineBindableFloat VisualElement.TranslationXProperty

    let TranslationY = Attributes.defineBindableFloat VisualElement.TranslationYProperty

    let Visual =
        Attributes.defineBindableWithEquality<IVisual> VisualElement.VisualProperty

    let WidthRequest = Attributes.defineBindableFloat VisualElement.WidthRequestProperty

    let ZIndex = Attributes.defineBindableInt VisualElement.ZIndexProperty

module VisualElementAnimations =
    let FadeTo =
        Attributes.defineSimpleScalarWithEquality<FadeToData> "VisualElement_FadeTo" (fun _ newValueOpt node ->
            let view = node.Target :?> View

            match newValueOpt with
            | ValueNone -> view.FadeTo(0., uint 0, Easing.Linear) |> ignore
            | ValueSome data -> view.FadeTo(data.Opacity, data.AnimationDuration, data.Easing) |> ignore)

    let RotateTo =
        Attributes.defineSimpleScalarWithEquality<RotateToData> "VisualElement_RotateTo" (fun _ newValueOpt node ->
            let view = node.Target :?> View

            match newValueOpt with
            | ValueNone -> view.RotateTo(0., uint 0, Easing.Linear) |> ignore
            | ValueSome data -> view.RotateTo(data.Rotation, data.AnimationDuration, data.Easing) |> ignore)

    let RotateXTo =
        Attributes.defineSimpleScalarWithEquality<RotateToData> "VisualElement_RotateXTo" (fun _ newValueOpt node ->
            let view = node.Target :?> View

            match newValueOpt with
            | ValueNone -> view.RotateXTo(0., uint 0, Easing.Linear) |> ignore
            | ValueSome data -> view.RotateXTo(data.Rotation, data.AnimationDuration, data.Easing) |> ignore)

    let RotateYTo =
        Attributes.defineSimpleScalarWithEquality<RotateToData> "VisualElement_RotateYTo" (fun _ newValueOpt node ->
            let view = node.Target :?> View

            match newValueOpt with
            | ValueNone -> view.RotateYTo(0., uint 0, Easing.Linear) |> ignore
            | ValueSome data -> view.RotateYTo(data.Rotation, data.AnimationDuration, data.Easing) |> ignore)

    let ScaleTo =
        Attributes.defineSimpleScalarWithEquality<ScaleToData> "VisualElement_ScaleTo" (fun _ newValueOpt node ->
            let view = node.Target :?> View

            match newValueOpt with
            | ValueNone -> view.ScaleTo(1., uint 0, Easing.Linear) |> ignore
            | ValueSome data -> view.ScaleTo(data.Scale, data.AnimationDuration, data.Easing) |> ignore)

    let ScaleXTo =
        Attributes.defineSimpleScalarWithEquality<ScaleToData> "VisualElement_ScaleXTo" (fun _ newValueOpt node ->
            let view = node.Target :?> View

            match newValueOpt with
            | ValueNone -> view.ScaleXTo(1., uint 0, Easing.Linear) |> ignore
            | ValueSome data -> view.ScaleXTo(data.Scale, data.AnimationDuration, data.Easing) |> ignore)

    let ScaleYTo =
        Attributes.defineSimpleScalarWithEquality<ScaleToData> "VisualElement_ScaleYTo" (fun _ newValueOpt node ->
            let view = node.Target :?> View

            match newValueOpt with
            | ValueNone -> view.ScaleYTo(1., uint 0, Easing.Linear) |> ignore
            | ValueSome data -> view.ScaleYTo(data.Scale, data.AnimationDuration, data.Easing) |> ignore)

    let TranslateTo =
        Attributes.defineSimpleScalarWithEquality<TranslateToData> "VisualElement_TranslateTo" (fun _ newValueOpt node ->
            let view = node.Target :?> View

            match newValueOpt with
            | ValueNone -> view.TranslateTo(0., 0., uint 0, Easing.Linear) |> ignore
            | ValueSome data -> view.TranslateTo(data.X, data.Y, data.AnimationDuration, data.Easing) |> ignore)

[<Extension>]
type VisualElementModifiers =
    /// <summary>Set the X component of the center point for any transform, relative to the bounds of the element</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The X component of the center point for any transform</param>
    [<Extension>]
    static member inline anchorX(this: WidgetBuilder<'msg, #IFabVisualElement>, value: float) =
        this.AddScalar(VisualElement.AnchorX.WithValue(value))

    /// <summary>Set the Y component of the center point for any transform, relative to the bounds of the element</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The Y component of the center point for any transform</param>
    [<Extension>]
    static member inline anchorY(this: WidgetBuilder<'msg, #IFabVisualElement>, value: float) =
        this.AddScalar(VisualElement.AnchorY.WithValue(value))

    /// <summary>Set the brush which will fill the background of the widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The brush to use</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabVisualElement>, value: Brush) =
        this.AddScalar(VisualElement.Background.WithValue(value))

    /// <summary>Set the brush widget which will fill the background of the widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="content">The brush widget to use</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabVisualElement>, content: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(VisualElement.BackgroundWidget.WithValue(content.Compile()))

    /// <summary>Set the geometry widget which will clip the widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="content">The geometry widget to use</param>
    [<Extension>]
    static member inline clip(this: WidgetBuilder<'msg, #IFabVisualElement>, content: WidgetBuilder<'msg, #IFabGeometry>) =
        this.AddWidget(VisualElement.Clip.WithValue(content.Compile()))

    /// <summary>Set the current focus state of the widget, and listen to focus state changes</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The focus state to apply</param>
    /// <param name="onFocusChanged">Message to dispatch when the widget's focus state changes</param>
    [<Extension>]
    static member inline focus(this: WidgetBuilder<'msg, #IFabVisualElement>, value: bool, onFocusChanged: bool -> 'msg) =
        this.AddScalar(VisualElement.FocusWithEvent.WithValue(ValueEventData.create value onFocusChanged))

    /// <summary>Set the layout flow direction</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The layout flow direction</param>
    [<Extension>]
    static member inline flowDirection(this: WidgetBuilder<'msg, #IFabVisualElement>, value: FlowDirection) =
        this.AddScalar(VisualElement.FlowDirection.WithValue(value))

    /// <summary>Set the desired height override of this widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The height this widget desires to be</param>
    [<Extension>]
    static member inline height(this: WidgetBuilder<'msg, #IFabVisualElement>, value: float) =
        this.AddScalar(VisualElement.HeightRequest.WithValue(value))

    /// <summary>Set a value indicating whether this widget should be involved in the user interaction cycle</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">false if the widget and its children should receive input; true if neither the widget nor its children should receive input and should, instead, pass inputs to the widgets that are visually behind the current widget</param>
    [<Extension>]
    static member inline inputTransparent(this: WidgetBuilder<'msg, #IFabVisualElement>, value: bool) =
        this.AddScalar(VisualElement.InputTransparent.WithValue(value))

    /// <summary>Set a value indicating whether this widget is enabled in the user interface</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">true if the widget is enabled; otherwise, false</param>
    [<Extension>]
    static member inline isEnabled(this: WidgetBuilder<'msg, #IFabVisualElement>, value: bool) =
        this.AddScalar(VisualElement.IsEnabled.WithValue(value))

    /// <summary>Set a value that determines whether this elements should be part of the visual tree or not</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">true if the element should be rendered; otherwise, false</param>
    [<Extension>]
    static member inline isVisible(this: WidgetBuilder<'msg, #IFabVisualElement>, value: bool) =
        this.AddScalar(VisualElement.IsVisible.WithValue(value))

    /// <summary>Set a value which overrides the maximum height the widget will request during layout</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The maximum height the widget requires</param>
    [<Extension>]
    static member inline maximumHeight(this: WidgetBuilder<'msg, #IFabVisualElement>, value: float) =
        this.AddScalar(VisualElement.MaximumHeightRequest.WithValue(value))

    /// <summary>Set a value which overrides the maximum width the widget will request during layout</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The maximum width the widget requires</param>
    [<Extension>]
    static member inline maximumWidth(this: WidgetBuilder<'msg, #IFabVisualElement>, value: float) =
        this.AddScalar(VisualElement.MaximumWidthRequest.WithValue(value))

    /// <summary>Set a value which overrides the minimum height the widget will request during layout</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The minimum height the widget requires</param>
    [<Extension>]
    static member inline minimumHeight(this: WidgetBuilder<'msg, #IFabVisualElement>, value: float) =
        this.AddScalar(VisualElement.MinimumHeightRequest.WithValue(value))

    /// <summary>Set a value which overrides the minimum width the widget will request during layout</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The minimum height the width requires</param>
    [<Extension>]
    static member inline minimumWidth(this: WidgetBuilder<'msg, #IFabVisualElement>, value: float) =
        this.AddScalar(VisualElement.MinimumWidthRequest.WithValue(value))

    /// <summary>Set the opacity value applied to the widget when it is rendered</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The opacity value. Values will be clamped between 0 and 1</param>
    [<Extension>]
    static member inline opacity(this: WidgetBuilder<'msg, #IFabVisualElement>, value: float) =
        this.AddScalar(VisualElement.Opacity.WithValue(value))

    /// <summary>Set a scale value to apply to the X direction</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The scale value to apply to the X direction</param>
    [<Extension>]
    static member inline scaleX(this: WidgetBuilder<'msg, #IFabVisualElement>, value: float) =
        this.AddScalar(VisualElement.ScaleX.WithValue(value))

    /// <summary>Set a scale value to apply to the Y direction</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The scale value to apply to the Y direction</param>
    [<Extension>]
    static member inline scaleY(this: WidgetBuilder<'msg, #IFabVisualElement>, value: float) =
        this.AddScalar(VisualElement.ScaleY.WithValue(value))

    /// <summary>Set a shadow widget to enable a shadow to be added to the widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="content">The shadow widget</param>
    [<Extension>]
    static member inline shadow(this: WidgetBuilder<'msg, #IFabVisualElement>, content: WidgetBuilder<'msg, #IFabShadow>) =
        this.AddWidget(VisualElement.Shadow.WithValue(content.Compile()))

    /// <summary>Set the X translation delta of the widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The amount to translate the widget</param>
    [<Extension>]
    static member inline translationX(this: WidgetBuilder<'msg, #IFabVisualElement>, value: float) =
        this.AddScalar(VisualElement.TranslationX.WithValue(value))

    /// <summary>Set the Y translation delta of the widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The amount to translate the widget</param>
    [<Extension>]
    static member inline translationY(this: WidgetBuilder<'msg, #IFabVisualElement>, value: float) =
        this.AddScalar(VisualElement.TranslationY.WithValue(value))

    /// <summary>Set the visual of this widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The visual value</param>
    [<Extension>]
    static member inline visual(this: WidgetBuilder<'msg, #IFabVisualElement>, value: IVisual) =
        this.AddScalar(VisualElement.Visual.WithValue(value))

    /// <summary>Set the desired width override of this widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The width this widget desires to be</param>
    [<Extension>]
    static member inline width(this: WidgetBuilder<'msg, #IFabVisualElement>, value: float) =
        this.AddScalar(VisualElement.WidthRequest.WithValue(value))

    /// <summary>Set the z-index of the widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The z-index of the widget</param>
    [<Extension>]
    static member inline zIndex(this: WidgetBuilder<'msg, #IFabVisualElement>, value: int) =
        this.AddScalar(VisualElement.ZIndex.WithValue(value))

[<Extension>]
type VisualElementAnimationModifiers =
    /// <summary>Animate the Opacity value from their current values to the new values</summary>
    /// <param name="this">Current widget</param>
    /// <param name="opacity">The value of the final opacity value</param>
    /// <param name="duration">The time, in milliseconds, over which to animate the transition</param>
    /// <param name="easing">The easing of the animation</param>
    [<Extension>]
    static member inline fadeTo(this: WidgetBuilder<'msg, #IFabVisualElement>, opacity: float, duration: int, easing: Easing) =
        this.AddScalar(
            VisualElementAnimations.FadeTo.WithValue(
                { Opacity = opacity
                  AnimationDuration = uint duration
                  Easing = easing }
            )
        )

    /// <summary>Animate the Rotation value from its current value to the new value</summary>
    /// <param name="this">Current widget</param>
    /// <param name="rotation">The value of the final rotation value</param>
    /// <param name="duration">The time, in milliseconds, over which to animate the transition</param>
    /// <param name="easing">The easing of the animation</param>
    [<Extension>]
    static member inline rotateTo(this: WidgetBuilder<'msg, #IFabVisualElement>, rotation: float, duration: int, easing: Easing) =
        this.AddScalar(
            VisualElementAnimations.RotateTo.WithValue(
                { Rotation = rotation
                  AnimationDuration = uint duration
                  Easing = easing }
            )
        )

    /// <summary>Animate the RotationX value from its current value to the new value</summary>
    /// <param name="this">Current widget</param>
    /// <param name="rotation">The value of the final rotationX value</param>
    /// <param name="duration">The time, in milliseconds, over which to animate the transition</param>
    /// <param name="easing">The easing of the animation</param>
    [<Extension>]
    static member inline rotateXTo(this: WidgetBuilder<'msg, #IFabVisualElement>, rotation: float, duration: int, easing: Easing) =
        this.AddScalar(
            VisualElementAnimations.RotateXTo.WithValue(
                { Rotation = rotation
                  AnimationDuration = uint duration
                  Easing = easing }
            )
        )

    /// <summary>Animate the RotationY value from its current value to the new value</summary>
    /// <param name="this">Current widget</param>
    /// <param name="rotation">The value of the final rotationY value</param>
    /// <param name="duration">The time, in milliseconds, over which to animate the transition</param>
    /// <param name="easing">The easing of the animation</param>
    [<Extension>]
    static member inline rotateYTo(this: WidgetBuilder<'msg, #IFabVisualElement>, rotation: float, duration: int, easing: Easing) =
        this.AddScalar(
            VisualElementAnimations.RotateYTo.WithValue(
                { Rotation = rotation
                  AnimationDuration = uint duration
                  Easing = easing }
            )
        )

    /// <summary>Animate the Scale value from their current values to the new values</summary>
    /// <param name="this">Current widget</param>
    /// <param name="scale">The value of the final scale vector</param>
    /// <param name="duration">The time, in milliseconds, over which to animate the transition</param>
    /// <param name="easing">The easing of the animation</param>
    [<Extension>]
    static member inline scaleTo(this: WidgetBuilder<'msg, #IFabVisualElement>, scale: float, duration: int, easing: Easing) =
        this.AddScalar(
            VisualElementAnimations.ScaleTo.WithValue(
                { Scale = scale
                  AnimationDuration = uint duration
                  Easing = easing }
            )
        )

    /// <summary>Animate the ScaleX value from their current value to the new value</summary>
    /// <param name="this">Current widget</param>
    /// <param name="scale">The value of the final scale vector</param>
    /// <param name="duration">The time, in milliseconds, over which to animate the transition</param>
    /// <param name="easing">The easing of the animation</param>
    [<Extension>]
    static member inline scaleXTo(this: WidgetBuilder<'msg, #IFabVisualElement>, scale: float, duration: int, easing: Easing) =
        this.AddScalar(
            VisualElementAnimations.ScaleXTo.WithValue(
                { Scale = scale
                  AnimationDuration = uint duration
                  Easing = easing }
            )
        )

    /// <summary>Animate the ScaleY value from their current value to the new value</summary>
    /// <param name="this">Current widget</param>
    /// <param name="scale">The value of the final scale vector</param>
    /// <param name="duration">The time, in milliseconds, over which to animate the transition</param>
    /// <param name="easing">The easing of the animation</param>
    [<Extension>]
    static member inline scaleYTo(this: WidgetBuilder<'msg, #IFabVisualElement>, scale: float, duration: int, easing: Easing) =
        this.AddScalar(
            VisualElementAnimations.ScaleYTo.WithValue(
                { Scale = scale
                  AnimationDuration = uint duration
                  Easing = easing }
            )
        )

    /// <summary>Animate the TranslationX and TranslationY values from their current values to the new values</summary>
    /// <param name="this">Current widget</param>
    /// <param name="x">The x component of the final translation vector</param>
    /// <param name="y">The y component of the final translation vector</param>
    /// <param name="duration">The duration of the animation in milliseconds</param>
    /// <param name="easing">The easing of the animation</param>
    [<Extension>]
    static member inline translateTo(this: WidgetBuilder<'msg, #IFabVisualElement>, x: float, y: float, duration: int, easing: Easing) =
        this.AddScalar(
            VisualElementAnimations.TranslateTo.WithValue(
                { X = x
                  Y = y
                  AnimationDuration = uint duration
                  Easing = easing }
            )
        )

[<Extension>]
type VisualElementExtraModifiers =
    /// <summary> Set the height and width of the widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="height">The desired height</param>
    /// <param name="width">The desired width</param>
    [<Extension>]
    static member inline size(this: WidgetBuilder<'msg, #IFabVisualElement>, height: float, width: float) = this.height(height).width(width)

    /// <summary> Set the height and width of the widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="uniformSize">The desired height and width</param>
    [<Extension>]
    static member inline size(this: WidgetBuilder<'msg, #IFabVisualElement>, uniformSize: float) = this.size(uniformSize, uniformSize)
