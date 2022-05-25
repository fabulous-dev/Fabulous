namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IActivityIndicator =
    inherit IView

module ActivityIndicator =
    let WidgetKey = Widgets.register<ActivityIndicator>()

    let IsRunning =
        Attributes.defineBindableBool ActivityIndicator.IsRunningProperty

    let Color =
        Attributes.defineBindableAppTheme<Color> ActivityIndicator.ColorProperty

[<AutoOpen>]
module ActivityIndicatorBuilders =
    type Fabulous.XamarinForms.View with
        static member inline ActivityIndicator<'msg>(isRunning: bool) =
            WidgetBuilder<'msg, IActivityIndicator>(
                ActivityIndicator.WidgetKey,
                ActivityIndicator.IsRunning.WithValue(isRunning)
            )

[<Extension>]
type ActivityIndicatorModifiers =

    /// <summary>Sets the activity indicator color.</summary>
    /// <param name="light">The color of the activity indicator in the light theme.</param>
    /// <param name="dark">The color of the activity indicator in the dark theme.</param>
    [<Extension>]
    static member inline color(this: WidgetBuilder<'msg, #IActivityIndicator>, light: Color, ?dark: Color) =
        this.AddScalar(ActivityIndicator.Color.WithValue(AppTheme.create light dark))

    /// <summary>Link a ViewRef to access the direct ActivityIndicator control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IActivityIndicator>, value: ViewRef<ActivityIndicator>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
