namespace Fabulous.XamarinForms

open Fabulous.XamarinForms
open Xamarin.Forms
open System.Runtime.CompilerServices
open Fabulous

type IProgressBar =
    inherit IView

[<Struct>]
type ProgressToData =
    { Progress: float
      AnimationDuration: uint32
      Easing: Easing }

module ProgressBar =

    let WidgetKey = Widgets.register<ProgressBar>()

    let ProgressColor =
        Attributes.defineAppThemeBindable<Color> ProgressBar.ProgressColorProperty

    let Progress =
        Attributes.defineBindable<float> ProgressBar.ProgressProperty

    let ProgressTo =
        Attributes.define<ProgressToData>
            "ProgressBar_ProgressTo"
            (fun _ newValueOpt node ->
                let view = node.Target :?> ProgressBar

                match newValueOpt with
                | ValueNone ->
                    view.ProgressTo(0., uint32 0, Easing.Linear)
                    |> ignore
                | ValueSome data ->
                    view.ProgressTo(data.Progress, data.AnimationDuration, data.Easing)
                    |> ignore)

[<AutoOpen>]
module ProgressBarBuilders =
    type Fabulous.XamarinForms.View with
        static member inline ProgressBar<'msg>(progress: float) =
            WidgetBuilder<'msg, IProgressBar>(ProgressBar.WidgetKey, ProgressBar.Progress.WithValue(progress))

        static member inline ProgressBar<'msg>(progress: float, duration: int, easing: Easing) =
            WidgetBuilder<'msg, IProgressBar>(
                ProgressBar.WidgetKey,
                ProgressBar.ProgressTo.WithValue(
                    { Progress = progress
                      AnimationDuration = uint32 duration
                      Easing = easing }
                )
            )

[<Extension>]
type ProgressBarModifiers =
    /// <summary>Set the color of the progress bar</summary>
    /// <param name="light">The color of the progress bar in the light theme.</param>
    /// <param name="dark">The color of the progress bar in the dark theme.</param>
    [<Extension>]
    static member inline progressColor(this: WidgetBuilder<'msg, #IProgressBar>, light: Color, ?dark: Color) =
        this.AddScalar(ProgressBar.ProgressColor.WithValue(AppTheme.create light dark))

    /// <summary>Link a ViewRef to access the direct ProgressBar control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IProgressBar>, value: ViewRef<ProgressBar>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
