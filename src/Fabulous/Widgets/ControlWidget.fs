namespace Fabulous.Widgets

open System
open System.Collections.Generic
open System.Runtime.CompilerServices

type [<Struct>] AttributeKey = AttributeKey of int

type [<Struct>] Attribute =
    { Key: AttributeKey
#if DEBUG
      Name: string
#endif
      Value: obj }

type IControlWidget =
    abstract Attributes: Attribute[]

type IControlView =
    abstract Attributes: Attribute[]
    abstract SetAttributes: Attribute[] -> unit

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
        static member inline TryGetValue<'inputType, 'modelType>(x: AttributeDefinition<'inputType, 'modelType>, controlView: IControlView) : 'modelType option =
            controlView.Attributes
            |> Array.tryFind (fun a -> a.Key = x.Key)
            |> Option.map (fun a -> unbox a.Value)

        [<Extension>]
        static member inline GetValue<'inputType, 'modelType>(x: AttributeDefinition<'inputType, 'modelType>, controlView: IControlView) =
            AttributeDefinitionExtensions.TryGetValue<'inputType, 'modelType>(x, controlView)
            |> Option.defaultWith x.DefaultWith

        [<Extension>]
        static member inline Execute(x: AttributeDefinition<'inputType, ('arg -> unit)>, controlView: IControlView, args: 'arg) =
            let fn = x.GetValue(controlView)
            fn args

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