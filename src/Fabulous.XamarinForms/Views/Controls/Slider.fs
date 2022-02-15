namespace Fabulous.XamarinForms

open System
open System.IO
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type ISlider =
    inherit IView

module Slider =
    let WidgetKey = Widgets.register<Slider> ()

    let MinimumMaximum =
        Attributes.define<struct (float * float)> "Slider_MinimumMaximum" ViewUpdaters.updateSliderMinMax

    let MaximumTrackColor =
        Attributes.defineAppThemeBindable<Color> Slider.MaximumTrackColorProperty

    let MinimumTrackColor =
        Attributes.defineAppThemeBindable<Color> Slider.MinimumTrackColorProperty

    let ThumbColor =
        Attributes.defineAppThemeBindable<Color> Slider.ThumbColorProperty

    let ThumbImageSource =
        Attributes.defineAppThemeBindable<ImageSource> Slider.ThumbImageSourceProperty

    let Value =
        Attributes.defineBindable<float> Slider.ValueProperty

    let ValueChanged =
        Attributes.defineEvent<ValueChangedEventArgs>
            "Slider_ValueChanged"
            (fun target -> (target :?> Slider).ValueChanged)

    let DragCompleted =
        Attributes.defineEventNoArg "Slider_DragCompleted" (fun target -> (target :?> Slider).DragCompleted)

    let DragStarted =
        Attributes.defineEventNoArg "Slider_DragStarted" (fun target -> (target :?> Slider).DragStarted)

[<AutoOpen>]
module SliderBuilders =
    type Fabulous.XamarinForms.View with
        static member inline Slider<'msg>(min: float, max: float, value: float, onValueChanged: float -> 'msg) =
            WidgetBuilder<'msg, ISlider>(
                Slider.WidgetKey,
                Slider.Value.WithValue(value),
                Slider.ValueChanged.WithValue(fun args -> onValueChanged args.NewValue |> box),
                Slider.MinimumMaximum.WithValue(struct (min, max))
            )

[<Extension>]
type SliderModifiers =

    /// <summary>Set the color of the maximumTrackColor.</summary>
    /// <param name="light">The color of the text in the light theme.</param>
    /// <param name="dark">The color of the text in the dark theme.</param>
    [<Extension>]
    static member inline maximumTrackColor(this: WidgetBuilder<'msg, #ISlider>, light: Color, ?dark: Color) =
        this.AddScalar(Slider.MaximumTrackColor.WithValue(AppTheme.create light dark))

    /// <summary>Set the color of the minimumTrackColor.</summary>
    /// <param name="light">The color of the minimumTrackColor in the light theme.</param>
    /// <param name="dark">The color of the minimumTrackColor in the dark theme.</param>
    [<Extension>]
    static member inline minimumTrackColor(this: WidgetBuilder<'msg, #ISlider>, light: Color, ?dark: Color) =
        this.AddScalar(Slider.MinimumTrackColor.WithValue(AppTheme.create light dark))

    /// <summary>Set the color of the thumbColor.</summary>
    /// <param name="light">The color of the thumbColor in the light theme.</param>
    /// <param name="dark">The color of the thumbColor in the dark theme.</param>
    [<Extension>]
    static member inline thumbColor(this: WidgetBuilder<'msg, #ISlider>, light: Color, ?dark: Color) =
        this.AddScalar(Slider.ThumbColor.WithValue(AppTheme.create light dark))

    /// <summary>Set the source of the thumbImage.</summary>
    /// <param name="light">The source of the thumbImage in the light theme.</param>
    /// <param name="dark">The source of the thumbImage in the dark theme.</param>
    [<Extension>]
    static member inline thumbImageSource(this: WidgetBuilder<'msg, #ISlider>, light: ImageSource, ?dark: ImageSource) =
        this.AddScalar(Slider.ThumbImageSource.WithValue(AppTheme.create light dark))

    /// <summary>Set the source of the thumbImage.</summary>
    /// <param name="light">The source of the thumbImage in the light theme.</param>
    /// <param name="dark">The source of the thumbImage in the dark theme.</param>
    [<Extension>]
    static member inline thumbImageSource(this: WidgetBuilder<'msg, #ISlider>, light: string, ?dark: string) =
        let light = ImageSource.FromFile(light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromFile(v))

        SliderModifiers.thumbImageSource (this, light, ?dark = dark)

    /// <summary>Set the source of the thumbImage.</summary>
    /// <param name="light">The source of the thumbImage in the light theme.</param>
    /// <param name="dark">The source of the thumbImage in the dark theme.</param>
    [<Extension>]
    static member inline thumbImageSource(this: WidgetBuilder<'msg, #ISlider>, light: Uri, ?dark: Uri) =
        let light = ImageSource.FromUri(light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromUri(v))

        SliderModifiers.thumbImageSource (this, light, ?dark = dark)

    /// <summary>Set the source of the thumbImage.</summary>
    /// <param name="light">The source of the thumbImage in the light theme.</param>
    /// <param name="dark">The source of the thumbImage in the dark theme.</param>
    [<Extension>]
    static member inline thumbImageSource(this: WidgetBuilder<'msg, #ISlider>, light: Stream, ?dark: Stream) =
        let light = ImageSource.FromStream(fun () -> light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromStream(fun () -> v))

        SliderModifiers.thumbImageSource (this, light, ?dark = dark)

    [<Extension>]
    static member inline onDragCompleted(this: WidgetBuilder<'msg, #ISlider>, onDragCompleted: 'msg) =
        this.AddScalar(Slider.DragCompleted.WithValue(onDragCompleted))

    [<Extension>]
    static member inline onDragStarted(this: WidgetBuilder<'msg, #ISlider>, onDragStarted: 'msg) =
        this.AddScalar(Slider.DragStarted.WithValue(onDragStarted))
