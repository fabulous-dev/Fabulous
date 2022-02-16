namespace Fabulous.XamarinForms

open Fabulous.XamarinForms
open Xamarin.Forms
open System.Runtime.CompilerServices
open Fabulous

type IProgressBar =
    inherit IView

module ProgressBar =

    let WidgetKey = Widgets.register<ProgressBar> ()

    let ProgressColor =
        Attributes.defineAppThemeBindable<Color> ProgressBar.ProgressColorProperty

    let Progress =
        Attributes.defineBindable<float> ProgressBar.ProgressProperty

[<AutoOpen>]
module ProgressBarBuilders =
    type Fabulous.XamarinForms.View with
        static member inline ProgressBar<'msg>(progress: float) =
            WidgetBuilder<'msg, IProgressBar>(ProgressBar.WidgetKey, ProgressBar.Progress.WithValue(progress))

[<Extension>]
type ProgressBarModifiers =
    /// <summary>Set the color of the progress bar</summary>
    /// <param name="light">The color of the progress bar in the light theme.</param>
    /// <param name="dark">The color of the progress bar in the dark theme.</param>
    [<Extension>]
    static member inline progressColor(this: WidgetBuilder<'msg, #IProgressBar>, light: Color, ?dark: Color) =
        this.AddScalar(ProgressBar.ProgressColor.WithValue(AppTheme.create light dark))
