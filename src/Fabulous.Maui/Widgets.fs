namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous

/// Dev notes:
///
/// Making the DSL allocation-free would be great
/// But how to keep type safety without interfaces?
///
/// E.g Application can only have Window children
/// Window, StackLayout, Grid, etc. can only have View children
///
/// Those interfaces also allow for targeted extension members to avoid cluttering IntelliSense
/// with inappropriate attribute setters


type IWidget =
    abstract Attributes: Attribute[]
    abstract Compile: unit -> Widget

type IWidget<'msg> = inherit IWidget
type IApplicationWidget<'msg> = inherit IWidget<'msg>
type IWindowWidget<'msg> = inherit IWidget<'msg>
type IViewWidget<'msg> = inherit IWidget<'msg>

[<Extension>]
type IWidgetExtensions () =
    [<Extension>]
    static member inline AddAttribute(this: ^T when ^T :> IWidget, attr: Attribute) =
        let attribs = this.Attributes
        let attribs2 = Array.zeroCreate (attribs.Length + 1)
        Array.blit attribs 0 attribs2 0 attribs.Length
        attribs2.[attribs.Length] <- attr
        let result = (^T : (new : Attribute[] -> ^T) attribs2)
        result

type StatefulApplication<'arg, 'model, 'msg, 'view when 'view :> IApplicationWidget<'msg>> =
    { State: StateKey option
      Init: 'arg -> 'model
      Update: 'msg -> 'model -> 'model
      View: 'model -> 'view }
    interface IStatefulComponent<'arg, 'model, 'msg> with
        member x.Init(arg) = x.Init arg
        member x.Update(msg, model) = x.Update msg model
        member x.View(model) = x.View(model).Compile()
        
type StatefulWindow<'arg, 'model, 'msg, 'view when 'view :> IWindowWidget<'msg>> =
    { State: StateKey option
      Init: 'arg -> 'model
      Update: 'msg -> 'model -> 'model
      View: 'model -> 'view }
    interface IStatefulComponent<'arg, 'model, 'msg> with
        member x.Init(arg) = x.Init arg
        member x.Update(msg, model) = x.Update msg model
        member x.View(model) = x.View(model).Compile()

type StatefulView<'arg, 'model, 'msg, 'view when 'view :> IViewWidget<'msg>> =
    { State: StateKey option
      Init: 'arg -> 'model
      Update: 'msg -> 'model -> 'model
      View: 'model -> 'view }
    interface IStatefulComponent<'arg, 'model, 'msg> with
        member x.Init(arg) = x.Init arg
        member x.Update(msg, model) = x.Update msg model
        member x.View(model) = x.View(model).Compile()
    
module StatefulWidget =
    let mkSimpleView init update view : StatefulView<_,_,_,_> =
        { State = None
          Init = init
          Update = update
          View = view }
        
    let mkSimpleApp init update view : StatefulApplication<_,_,_,_> =
        { State = None
          Init = init
          Update = update
          View = view }
          
type StatelessApplication<'view when 'view :> IApplicationWidget<unit>> =
    { View: unit -> 'view }
    interface IStatelessComponent with
        member x.View() = x.View().Compile()
                  
type StatelessWindow<'view when 'view :> IWindowWidget<unit>> =
    { View: unit -> 'view }
    interface IStatelessComponent with
        member x.View() = x.View().Compile()

type StatelessView<'view when 'view :> IViewWidget<unit>> =
    { View: unit -> 'view }
    interface IStatelessComponent with
        member x.View() = x.View().Compile()
        
module StatelessWidget =
    let mkSimpleView view : StatelessView<_> =
        { View = view }