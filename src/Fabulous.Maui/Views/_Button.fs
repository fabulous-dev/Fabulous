namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Handlers

module Button =
    let Clicked = Attributes.defineMauiEventNoArgs "Clicked"
    let Pressed = Attributes.defineMauiEventNoArgs "Pressed"
    let Released = Attributes.defineMauiEventNoArgs "Released"
    
    module Defaults =
        // Button has a custom default padding set to NaN
        let inline createDefaultPadding() = Thickness(System.Double.NaN)
    
type FabButton(handler) =
    inherit FabView(handler)
    
    interface IButton with
        member this.Clicked() = this.InvokeEvent(Button.Clicked)
        member this.Pressed() = this.InvokeEvent(Button.Pressed)
        member this.Released() = this.InvokeEvent(Button.Released)
        member this.CornerRadius = this.GetScalar(ButtonStroke.CornerRadius, ButtonStroke.Defaults.CornerRadius)
        member this.Padding = this.GetScalar(Padding.Padding, Button.Defaults.createDefaultPadding())
        member this.StrokeColor = this.GetScalar(ButtonStroke.StrokeColor, ButtonStroke.Defaults.StrokeColor)
        member this.StrokeThickness = this.GetScalar(ButtonStroke.StrokeThickness, ButtonStroke.Defaults.StrokeThickness)

[<Extension>]
type ButtonModifiers =
    [<Extension>]
    static member inline onPressed(this: WidgetBuilder<'msg, #IButton>, onPressed: 'msg) =
        this.AddScalar(Button.Pressed.WithValue(fun () -> box onPressed))
        
    [<Extension>]
    static member inline onReleased(this: WidgetBuilder<'msg, #IButton>, onReleased: 'msg) =
        this.AddScalar(Button.Released.WithValue(fun () -> box onReleased))