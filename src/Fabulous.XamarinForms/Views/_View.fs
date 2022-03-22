namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type IView =
    inherit IVisualElement

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

module XFView =
    let HorizontalOptions =
        Attributes.defineBindable<LayoutOptions> View.HorizontalOptionsProperty

    let VerticalOptions =
        Attributes.defineBindable<LayoutOptions> View.VerticalOptionsProperty

    let Margin =
        Attributes.defineBindable<Thickness> View.MarginProperty

    let GestureRecognizers =
        Attributes.defineWidgetCollection<IGestureRecognizer>
            "View_GestureRecognizers"
            ViewNode.get
            (fun target -> (target :?> View).GestureRecognizers)

    let TranslateTo =
        Attributes.define<TranslateToData>
            "View_TranslateTo"
            (fun newValueOpt node ->
                let view = node.Target :?> View

                match newValueOpt with
                | ValueNone ->
                    view.TranslateTo(0., 0., uint 0, Easing.Linear)
                    |> ignore
                | ValueSome data ->
                    view.TranslateTo(data.X, data.Y, data.AnimationDuration, data.Easing)
                    |> ignore)

    let ScaleTo =
        Attributes.define<ScaleToData>
            "View_ScaleTo"
            (fun newValueOpt node ->
                let view = node.Target :?> View

                match newValueOpt with
                | ValueNone -> view.ScaleTo(1., uint 0, Easing.Linear) |> ignore
                | ValueSome data ->
                    view.ScaleTo(data.Scale, data.AnimationDuration, data.Easing)
                    |> ignore)

    let ScaleXTo =
        Attributes.define<ScaleToData>
            "View_ScaleXTo"
            (fun newValueOpt node ->
                let view = node.Target :?> View

                match newValueOpt with
                | ValueNone -> view.ScaleXTo(1., uint 0, Easing.Linear) |> ignore
                | ValueSome data ->
                    view.ScaleXTo(data.Scale, data.AnimationDuration, data.Easing)
                    |> ignore)

    let ScaleYTo =
        Attributes.define<ScaleToData>
            "View_ScaleYTo"
            (fun newValueOpt node ->
                let view = node.Target :?> View

                match newValueOpt with
                | ValueNone -> view.ScaleYTo(1., uint 0, Easing.Linear) |> ignore
                | ValueSome data ->
                    view.ScaleYTo(data.Scale, data.AnimationDuration, data.Easing)
                    |> ignore)

    let FadeTo =
        Attributes.define<FadeToData>
            "View_FadeTo"
            (fun newValueOpt node ->
                let view = node.Target :?> View

                match newValueOpt with
                | ValueNone -> view.FadeTo(0., uint 0, Easing.Linear) |> ignore
                | ValueSome data ->
                    view.FadeTo(data.Opacity, data.AnimationDuration, data.Easing)
                    |> ignore)

    let RotateTo =
        Attributes.define<RotateToData>
            "View_RotateTo"
            (fun newValueOpt node ->
                let view = node.Target :?> View

                match newValueOpt with
                | ValueNone -> view.RotateTo(0., uint 0, Easing.Linear) |> ignore
                | ValueSome data ->
                    view.RotateTo(data.Rotation, data.AnimationDuration, data.Easing)
                    |> ignore)

    let RotateXTo =
        Attributes.define<RotateToData>
            "View_RotateXTo"
            (fun newValueOpt node ->
                let view = node.Target :?> View

                match newValueOpt with
                | ValueNone ->
                    view.RotateXTo(0., uint 0, Easing.Linear)
                    |> ignore
                | ValueSome data ->
                    view.RotateXTo(data.Rotation, data.AnimationDuration, data.Easing)
                    |> ignore)

    let RotateYTo =
        Attributes.define<RotateToData>
            "View_RotateYTo"
            (fun newValueOpt node ->
                let view = node.Target :?> View

                match newValueOpt with
                | ValueNone ->
                    view.RotateYTo(0., uint 0, Easing.Linear)
                    |> ignore
                | ValueSome data ->
                    view.RotateYTo(data.Rotation, data.AnimationDuration, data.Easing)
                    |> ignore)

[<Extension>]
type ViewModifiers =
    [<Extension>]
    static member inline horizontalOptions(this: WidgetBuilder<'msg, #IView>, value: LayoutOptions) =
        this.AddScalar(XFView.HorizontalOptions.WithValue(value))

    [<Extension>]
    static member inline verticalOptions(this: WidgetBuilder<'msg, #IView>, value: LayoutOptions) =
        this.AddScalar(XFView.VerticalOptions.WithValue(value))

    [<Extension>]
    static member inline center(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.Center
            | Some true -> LayoutOptions.CenterAndExpand

        this
            .AddScalar(XFView.HorizontalOptions.WithValue(options))
            .AddScalar(XFView.VerticalOptions.WithValue(options))


    [<Extension>]
    static member inline centerHorizontal(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.Center
            | Some true -> LayoutOptions.CenterAndExpand

        this.AddScalar(XFView.HorizontalOptions.WithValue(options))

    [<Extension>]
    static member inline centerVertical(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.Center
            | Some true -> LayoutOptions.CenterAndExpand

        this.AddScalar(XFView.VerticalOptions.WithValue(options))

    [<Extension>]
    static member inline alignStartHorizontal(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.Start
            | Some true -> LayoutOptions.StartAndExpand

        this.AddScalar(XFView.HorizontalOptions.WithValue(options))

    [<Extension>]
    static member inline alignStartVertical(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.Start
            | Some true -> LayoutOptions.StartAndExpand

        this.AddScalar(XFView.VerticalOptions.WithValue(options))

    [<Extension>]
    static member inline alignEndHorizontal(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.End
            | Some true -> LayoutOptions.EndAndExpand

        this.AddScalar(XFView.HorizontalOptions.WithValue(options))

    [<Extension>]
    static member inline alignEndVertical(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.End
            | Some true -> LayoutOptions.EndAndExpand

        this.AddScalar(XFView.VerticalOptions.WithValue(options))

    [<Extension>]
    static member inline fillHorizontal(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.Fill
            | Some true -> LayoutOptions.FillAndExpand

        this.AddScalar(XFView.HorizontalOptions.WithValue(options))

    [<Extension>]
    static member inline fillVertical(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.Fill
            | Some true -> LayoutOptions.FillAndExpand

        this.AddScalar(XFView.VerticalOptions.WithValue(options))

    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IView>, value: Thickness) =
        this.AddScalar(XFView.Margin.WithValue(value))

    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IView>, value: float) =
        ViewModifiers.margin (this, Thickness(value))

    [<Extension>]
    static member inline margin
        (
            this: WidgetBuilder<'msg, #IView>,
            left: float,
            top: float,
            right: float,
            bottom: float
        ) =
        ViewModifiers.margin (this, Thickness(left, top, right, bottom))

    [<Extension>]
    static member inline gestureRecognizers<'msg, 'marker when 'marker :> IView>(this: WidgetBuilder<'msg, 'marker>) =
        WidgetHelpers.buildAttributeCollection<'msg, 'marker, Fabulous.XamarinForms.IGestureRecognizer>
            XFView.GestureRecognizers
            this

    /// <summary>Animates an elements TranslationX and TranslationY properties from their current values to the new values. This ensures that the input layout is in the same position as the visual layout.</summary>
    /// <param name="x">The x component of the final translation vector.</param>
    /// <param name="y">The y component of the final translation vector.</param>
    /// <param name="duration">The duration of the animation in milliseconds.</param>
    /// <param name="easing">The easing of the animation.</param>
    [<Extension>]
    static member inline translateTo
        (
            this: WidgetBuilder<'msg, #IView>,
            x: float,
            y: float,
            duration: int,
            easing: Easing
        ) =
        this.AddScalar(
            XFView.TranslateTo.WithValue(
                { X = x
                  Y = y
                  AnimationDuration = uint duration
                  Easing = easing }
            )
        )

    /// <summary>Animates elements Scale property from their current values to the new values. This ensures that the input layout is in the same position as the visual layout.</summary>
    /// <param name="scale">The value of the final scale vector.</param>
    /// <param name="duration">The time, in milliseconds, over which to animate the transition. The default is 250.</param>
    /// <param name="easing">The easing of the animation.</param>
    [<Extension>]
    static member inline scaleTo(this: WidgetBuilder<'msg, #IView>, scale: float, duration: int, easing: Easing) =
        this.AddScalar(
            XFView.ScaleTo.WithValue(
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
    static member inline scaleXTo(this: WidgetBuilder<'msg, #IView>, scale: float, duration: int, easing: Easing) =
        this.AddScalar(
            XFView.ScaleXTo.WithValue(
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
    static member inline scaleYTo(this: WidgetBuilder<'msg, #IView>, scale: float, duration: int, easing: Easing) =
        this.AddScalar(
            XFView.ScaleYTo.WithValue(
                { Scale = scale
                  AnimationDuration = uint duration
                  Easing = easing }
            )
        )

    /// <summary>Animates elements Opacity property from their current values to the new values. This ensures that the input layout is in the same position as the visual layout.</summary>
    /// <param name="opacity">The value of the final opacity value.</param>
    /// <param name="duration">The time, in milliseconds, over which to animate the transition. The default is 250.</param>
    /// <param name="easing">The easing of the animation.</param>
    [<Extension>]
    static member inline fadeTo(this: WidgetBuilder<'msg, #IView>, opacity: float, duration: int, easing: Easing) =
        this.AddScalar(
            XFView.FadeTo.WithValue(
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
    static member inline rotateTo(this: WidgetBuilder<'msg, #IView>, rotation: float, duration: int, easing: Easing) =
        this.AddScalar(
            XFView.RotateTo.WithValue(
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
    static member inline rotateXTo(this: WidgetBuilder<'msg, #IView>, rotation: float, duration: int, easing: Easing) =
        this.AddScalar(
            XFView.RotateXTo.WithValue(
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
    static member inline rotateYTo(this: WidgetBuilder<'msg, #IView>, rotation: float, duration: int, easing: Easing) =
        this.AddScalar(
            XFView.RotateYTo.WithValue(
                { Rotation = rotation
                  AnimationDuration = uint duration
                  Easing = easing }
            )
        )
