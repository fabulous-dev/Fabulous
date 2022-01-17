namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

type ISwitch =
    inherit IView

module Switch =
    let WidgetKey = Widgets.register<Switch> ()

    let IsToggled =
        Attributes.defineBindable<bool> Switch.IsToggledProperty

    let Toggled =
        Attributes.defineEvent<ToggledEventArgs> "Switch_Toggled" (fun target -> (target :?> Switch).Toggled)

[<AutoOpen>]
module SwitchBuilders =
    type Fabulous.XamarinForms.View with
        static member inline Switch<'msg>(isToggled: bool, onToggled: bool -> 'msg) =
            WidgetBuilder<'msg, ISwitch>(
                Switch.WidgetKey,
                Switch.IsToggled.WithValue(isToggled),
                Switch.Toggled.WithValue(fun args -> onToggled args.Value |> box)
            )
