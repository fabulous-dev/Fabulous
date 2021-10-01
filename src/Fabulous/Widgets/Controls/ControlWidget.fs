namespace Fabulous.Widgets.Controls

open System
open System.Collections.Generic
open System.Runtime.CompilerServices
open Fabulous.Widgets.Controls

type IControlWidget =
    abstract Attributes: Attribute[]

module ControlWidget =
    type Handler =
        { TargetType: Type
          Create: Attribute[] -> obj }
    
    let private _handlers = Dictionary<Type, Handler>()
    
    let registerWithCustomCtor<'Builder, 'T> (create: Attribute[] -> 'T) =
        if not (_handlers.ContainsKey(typeof<'Builder>)) then
            _handlers.[typeof<'Builder>] <-
                { TargetType = typeof<'T>
                  Create = create >> box }
                
    let inline register<'Builder, 'T when 'T : (new : unit -> 'T)> () =
        registerWithCustomCtor<'Builder, 'T> (fun _ -> new 'T())

    let inline createView<'T when 'T :> IControlView and 'T : (new: unit -> 'T)> (attrs: Attribute[]) =
        let view = new 'T()
        view.SetAttributes(attrs)
        box view

        
[<Extension>]
type IControlWidgetExtensions () =
    [<Extension>]
    static member inline AddAttribute(this: ^T when ^T :> IControlWidget, attr: Attribute) =
        let attribs = this.Attributes
        let attribs2 = Array.zeroCreate (attribs.Length + 1)
        Array.blit attribs 0 attribs2 0 attribs.Length
        attribs2.[attribs.Length] <- attr
        let result = (^T : (new : Attribute[] -> ^T) attribs2)
        result