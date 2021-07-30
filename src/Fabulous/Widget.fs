namespace Fabulous

open System
open System.Collections.Generic

type [<Struct>] RunnerKey = RunnerKey of int
type [<Struct>] AttributeKey = AttributeKey of int
    
type Attribute =
    { Key: AttributeKey
      Value: obj }
    
module Attributes =
    type IAttributeDefinition = interface end
    type AttributeDefinition<'inputType, 'modelType> =
        { Key: AttributeKey
          Convert: 'inputType -> 'modelType }
        interface IAttributeDefinition
        member x.WithValue(value) =
           { Key = x.Key
             Value = x.Convert(value) } 
    
    let private _keys = Dictionary<string, AttributeKey>()
    let private _attributes = Dictionary<AttributeKey, IAttributeDefinition>()
    
    let createDefinitionWithConverter<'inputType, 'modelType> name (convert: 'inputType -> 'modelType) =
        if not (_keys.ContainsKey(name)) then
            let key = AttributeKey (_keys.Count + 1)
            let definition =
                { Key = key
                  Convert = convert }
            _keys.Add(name, key)
            _attributes.Add(key, definition)
            definition
        else
            let key = _keys.[name]
            _attributes.[key] :?> AttributeDefinition<'inputType, 'modelType>
    
    let createDefinition<'T> name =
        createDefinitionWithConverter<'T, 'T> name id
        
            

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
type IStatelessWidget<'view when 'view :> IWidget> =
    abstract View: Attribute[] -> 'view 

/// Logical element with MVU state able to generate a logical tree composed of child widgets
type IStatefulWidget<'arg, 'model, 'msg, 'view when 'view :> IWidget> =
    abstract State: RunnerKey option
    abstract Init: 'arg -> 'model
    abstract Update: 'msg * 'model -> 'model
    abstract View: 'model * Attribute[] -> 'view

