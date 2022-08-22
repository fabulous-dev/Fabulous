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
    
type FabButton(handler) =
    inherit FabView(handler)
    
    interface IButton with
        member this.Clicked() = this.InvokeEvent(Button.Clicked)
        member this.Pressed() = this.InvokeEvent(Button.Pressed)
        member this.Released() = this.InvokeEvent(Button.Released)
        member this.CornerRadius = this.GetScalar(ButtonStroke.CornerRadius, -1)
        member this.Padding = this.GetScalar(Padding.Padding, Thickness(System.Double.NaN))
        member this.StrokeColor = this.GetScalar(ButtonStroke.StrokeColor, null)
        member this.StrokeThickness = this.GetScalar(ButtonStroke.StrokeThickness, -1.)

[<Extension>]
type ButtonModifiers =
    [<Extension>]
    static member inline onPressed(this: WidgetBuilder<'msg, #IButton>, onPressed: 'msg) =
        this.AddScalar(Button.Pressed.WithValue(fun () -> box onPressed))
        
    [<Extension>]
    static member inline onReleased(this: WidgetBuilder<'msg, #IButton>, onReleased: 'msg) =
        this.AddScalar(Button.Released.WithValue(fun () -> box onReleased))