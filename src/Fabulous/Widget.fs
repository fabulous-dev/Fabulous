namespace Fabulous

open System
open System.Collections.Generic

type [<Struct>] RunnerKey = RunnerKey of int
type [<Struct>] AttributeKey = AttributeKey of int
    
type Attribute =
    { Key: AttributeKey
      Value: obj }

/// Base logical element
type IWidget = interface end
    
module ControlWidget =
    type IControlWidget =
        inherit IWidget
        abstract Add: Attribute -> IControlWidget
        
    type Handler =
        { TargetType: Type
          Create: Attribute[] -> obj }
    
    let private _handlers = Dictionary<Type, Handler>()
    
    let registerWithCustomCtor<'Builder, 'T> (create: Attribute[] -> 'T) =
        if not (_handlers.ContainsKey(typeof<'Builder>)) then
            _handlers.[typeof<'Builder>] <-
                { TargetType = typeof<'T>
                  Create = create >> box }
                
    let register<'Builder, 'T when 'T : (new : unit -> 'T)> () =
        registerWithCustomCtor<'Builder, 'T> (fun _ -> new 'T())
        
    

/// Logical element without state able to generate a logical tree composed of child widgets
type StatelessWidget =
    { View: Attribute[] -> IWidget
      ExtendedAttributes: Attribute[] voption }

/// Logical element with MVU state able to generate a logical tree composed of child widgets
type StatefulWidget<'arg, 'model, 'msg, 'view when 'view :> IWidget> =
    { State: RunnerKey option
      Init: 'arg -> 'model
      Update: 'msg * 'model -> 'model
      View: 'model * Attribute[] -> 'view }

