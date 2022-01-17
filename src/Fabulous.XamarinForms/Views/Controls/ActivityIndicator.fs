namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

type IActivityIndicator =
    inherit IView

module ActivityIndicator =
    let WidgetKey =
        Widgets.register<ActivityIndicator> ()
        
    let IsRunning =
        Attributes.defineBindable<bool> ActivityIndicator.IsRunningProperty
        
[<AutoOpen>]
module ActivityIndicatorBuilders =
    type Fabulous.XamarinForms.View with
        static member inline ActivityIndicator<'msg>(isRunning: bool) =
            WidgetBuilder<'msg, IActivityIndicator>(
                ActivityIndicator.WidgetKey,
                ActivityIndicator.IsRunning.WithValue(isRunning)
            )