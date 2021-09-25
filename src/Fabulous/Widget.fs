namespace Fabulous

open System
open System.Collections.Generic
open System.Runtime.CompilerServices

type [<Struct>] RunnerKey = RunnerKey of int
type [<Struct>] AttributeKey = AttributeKey of int
    
type Attribute =
    { Key: AttributeKey
#if DEBUG
      Name: string
#endif
      Value: obj }
    
module Attributes =
    type IAttributeDefinition = interface end

    type AttributeDefinition<'inputType, 'modelType> =
        { Key: AttributeKey
          Name: string
          DefaultWith: unit -> 'modelType
          Convert: 'inputType -> 'modelType }
        interface IAttributeDefinition
    
    let private _attributes = Dictionary<AttributeKey, IAttributeDefinition>()
    
    let createDefinitionWithConverter<'inputType, 'modelType> name defaultWith (convert: 'inputType -> 'modelType) =
        let key = AttributeKey (_attributes.Count + 1)
        let definition =
            { Key = key
              Name = name
              DefaultWith = defaultWith >> convert
              Convert = convert }
        _attributes.Add(key, definition)
        definition
    
    let createDefinition<'T> name defaultValue =
        createDefinitionWithConverter<'T, 'T> name defaultValue id
             
    [<Extension>]
    type AttributeDefinitionExtensions =
        [<Extension>]
        static member inline WithValue<'inputType, 'modelType>(x: AttributeDefinition<'inputType, 'modelType>, value) =
            { Key = x.Key
    #if DEBUG
              Name = x.Name
    #endif
              Value = x.Convert(value) }
              
        [<Extension>]
        static member inline TryGetValue<'inputType, 'modelType>(x: AttributeDefinition<'inputType, 'modelType>, attrs: Attribute array) : 'modelType option =
            attrs
            |> Array.tryFind (fun a -> a.Key = x.Key)
            |> Option.map (fun a -> unbox a.Value)

        [<Extension>]
        static member inline GetValue<'inputType, 'modelType>(x: AttributeDefinition<'inputType, 'modelType>, attrs: Attribute array) =
            AttributeDefinitionExtensions.TryGetValue<'inputType, 'modelType>(x, attrs)
            |> Option.defaultWith x.DefaultWith

        [<Extension>]
        static member inline Execute(x: AttributeDefinition<'inputType, ('arg -> unit)> , attrs: Attribute array, args: 'arg) =
            let fn = x.GetValue(attrs)
            fn args
        
            


/// Base logical element
type IWidget =
    abstract CreateView: unit -> obj
    
module ControlWidget =
    type IControlWidget =
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
        
    
    let inline addAttribute (fn: Attribute[] -> #IControlWidget) (attribs: Attribute[]) (attr: Attribute) =
        let attribs2 = Array.zeroCreate (attribs.Length + 1)
        Array.blit attribs 0 attribs2 0 attribs.Length
        attribs2.[attribs.Length] <- attr
        (fn attribs2) :> IControlWidget
        
    [<Extension>]
    type IControlWidgetExtensions () =
        [<Extension>]
        static member inline AddAttribute<'T when 'T :> IControlWidget>(this: 'T, attr: Attribute) =
            this.Add(attr) :?> 'T
        
    

/// Logical element without state able to generate a logical tree composed of child widgets
type IStatelessWidget<'view when 'view :> IWidget> =
    abstract View: Attribute[] -> 'view 

/// Logical element with MVU state able to generate a logical tree composed of child widgets
type IStatefulWidget<'arg, 'model, 'msg, 'view when 'view :> IWidget> =
    abstract State: RunnerKey option
    abstract Init: 'arg -> 'model
    abstract Update: 'msg * 'model -> 'model
    abstract View: 'model * Attribute[] -> 'view

