namespace Fabulous.Widgets.Controls

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

type IAttributeDefinition = interface end

type IControlView =
    abstract Attributes: Attribute[]
    abstract SetAttributes: Attribute[] -> unit

type [<Struct>] AttributeComparison =
    | Same
    | Different of data: obj voption

type AttributeDefinition<'inputType, 'modelType> =
    {
        Key: AttributeKey
        Name: string
        DefaultWith: unit -> 'modelType
        Convert: 'inputType -> 'modelType
        Compare: struct ('modelType * 'modelType) -> AttributeComparison
    }
    interface IAttributeDefinition

module AttributeComparers =
    let equalityComparer struct (a, b) =
        if a = b then
            Same
        else
            Different (ValueSome (box b))

    let noCompare struct (a, b) =
        Different (ValueSome (box b))

    let collectionComparer struct (a, b) =
        Same

module Attributes =
    let private _attributes = Dictionary<AttributeKey, IAttributeDefinition>()
    
    let defineWithConverter<'inputType, 'modelType> name defaultWith (convert: 'inputType -> 'modelType) (compare: struct ('modelType * 'modelType) -> AttributeComparison) =
        let key = AttributeKey (_attributes.Count + 1)
        let definition =
            { Key = key
              Name = name
              DefaultWith = defaultWith >> convert
              Convert = convert
              Compare = compare }
        _attributes.Add(key, definition)
        definition
        
    let inline defineCollection<'elementType> name =
        defineWithConverter<'elementType seq, 'elementType array> name (fun () -> Seq.empty) Seq.toArray AttributeComparers.collectionComparer
    
    let inline defineWithComparer<'T> name defaultValue compare =
        defineWithConverter<'T, 'T> name defaultValue id compare

    let inline defineNoCompare<'T> name defaultValue =
        defineWithConverter<'T, 'T> name defaultValue id AttributeComparers.noCompare

    let inline defineEvent<'T> name =
        defineNoCompare<'T -> unit> name (fun _ -> ignore)

    let inline define<'T when 'T: equality> name defaultValue =
        defineWithConverter<'T, 'T> name defaultValue id AttributeComparers.equalityComparer
            
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