namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Handlers

module Switch =
    let IsOn = Attributes.defineMauiScalarWithEquality<bool> "IsOn"
    let ThumbColor = Attributes.defineMauiScalarWithEquality<Color> "ThumbColor"
    let TrackColor = Attributes.defineMauiScalarWithEquality<Color> "TrackColor"
    
    let Toggled = Attributes.defineMauiEvent<bool> "Toggled"
    
    module Defaults =
        let [<Literal>] IsOn = false
        let [<Literal>] ThumbColor: Color = null
        let [<Literal>] TrackColor: Color = null
    
type FabSwitch(handler: IViewHandler) =
    inherit FabView(handler)
    
    static let _widgetKey = Widgets.register<FabSwitch>()
    static member WidgetKey = _widgetKey

    new() = FabSwitch(SwitchHandler())
    
    interface ISwitch with
        member this.IsOn
            with get () = this.GetScalar(Switch.IsOn, Switch.Defaults.IsOn)
            and set v = this.InvokeEvent(Switch.Toggled, v)
        member this.ThumbColor = this.GetScalar(Switch.ThumbColor, Switch.Defaults.ThumbColor)
        member this.TrackColor = this.GetScalar(Switch.TrackColor, Switch.Defaults.TrackColor)


[<AutoOpen>]
module SwitchBuilders =
    type Fabulous.Maui.View with
        static member inline Switch<'msg>(isOn: bool, onToggled: bool -> 'msg) =
            WidgetBuilder<'msg, ISwitch>(
                FabSwitch.WidgetKey,
                Switch.IsOn.WithValue(isOn),
                Switch.Toggled.WithValue(fun v -> onToggled v |> box)
            )