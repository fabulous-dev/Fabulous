namespace Fabulous.Maui

open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Controls
open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Graphics

type IFabProgressBar =
    inherit IFabView

[<Struct>]
type ProgressToData =
    { Progress: float
      AnimationDuration: uint32
      Easing: Easing }

module ProgressBar =
    let WidgetKey = Widgets.register<ProgressBar>()

    let Progress = Attributes.defineBindableFloat ProgressBar.ProgressProperty

    let ProgressColor = Attributes.defineBindableColor ProgressBar.ProgressColorProperty

module ProgressBarAnimations =
    let ProgressTo =
        Attributes.defineSimpleScalarWithEquality<ProgressToData> "ProgressBar_ProgressTo" (fun _ newValueOpt node ->
            let view = node.Target :?> ProgressBar

            match newValueOpt with
            | ValueNone -> view.ProgressTo(0., uint32 0, Easing.Linear) |> ignore
            | ValueSome data -> view.ProgressTo(data.Progress, data.AnimationDuration, data.Easing) |> ignore)

[<AutoOpen>]
module ProgressBarBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a ProgressBar widget with a current progress value</summary>
        /// <param name="progress">The progress value</param>
        static member inline ProgressBar<'msg when 'msg: equality>(progress: float) =
            WidgetBuilder<'msg, IFabProgressBar>(ProgressBar.WidgetKey, ProgressBar.Progress.WithValue(progress))

        /// <summary>Create a ProgressBar widget with a progress value that will animate when changed</summary>
        /// <param name="progress">The progress value</param>
        /// <param name="duration">The duration of the animation</param>
        /// <param name="easing">The easing of the animation</param>
        static member inline ProgressBar<'msg when 'msg: equality>(progress: float, duration: int, easing: Easing) =
            WidgetBuilder<'msg, IFabProgressBar>(
                ProgressBar.WidgetKey,
                ProgressBarAnimations.ProgressTo.WithValue(
                    { Progress = progress
                      AnimationDuration = uint32 duration
                      Easing = easing }
                )
            )

[<Extension>]
type ProgressBarModifiers =
    /// <summary>Set the color of the progress bar</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color of the progress bar</param>
    [<Extension>]
    static member inline progressColor(this: WidgetBuilder<'msg, #IFabProgressBar>, value: Color) =
        this.AddScalar(ProgressBar.ProgressColor.WithValue(value))

    /// <summary>Link a ViewRef to access the direct ProgressBar control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabProgressBar>, value: ViewRef<ProgressBar>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
