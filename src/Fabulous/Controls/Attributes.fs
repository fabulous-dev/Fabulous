namespace Fabulous.Controls

open System.Collections.Generic
open System.Runtime.CompilerServices
open Fabulous

type [<Struct>] AttributeKey = AttributeKey of int

type [<Struct>] Attribute =
    { Key: AttributeKey
#if DEBUG
      DebugName: string
#endif
      Value: obj }

type IAttributeDefinition = interface end

type IAttributedViewNode =
    inherit IViewNode
    abstract Attributes: Attribute[]

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
        defineNoCompare<'T -> obj> name (fun () -> fun _ -> null)

    let inline define<'T when 'T: equality> name defaultValue =
        defineWithConverter<'T, 'T> name defaultValue id AttributeComparers.equalityComparer
            
[<Extension>]
type AttributeDefinitionExtensions =
    [<Extension>]
    static member inline WithValue<'inputType, 'modelType>(x: AttributeDefinition<'inputType, 'modelType>, value) =
        { Key = x.Key
#if DEBUG
          DebugName = x.Name
#endif
          Value = x.Convert(value) }
              
    [<Extension>]
    static member inline TryGetValue<'inputType, 'modelType>(x: AttributeDefinition<'inputType, 'modelType>, node: IAttributedViewNode) : 'modelType option =
        node.Attributes
        |> Array.tryFind (fun a -> a.Key = x.Key)
        |> Option.map (fun a -> unbox a.Value)

    [<Extension>]
    static member inline GetValue<'inputType, 'modelType>(x: AttributeDefinition<'inputType, 'modelType>, node: IAttributedViewNode) =
        AttributeDefinitionExtensions.TryGetValue<'inputType, 'modelType>(x, node)
        |> Option.defaultWith x.DefaultWith

    [<Extension>]
    static member inline Execute(x: AttributeDefinition<'inputType, ('arg -> 'msg)>, node: IAttributedViewNode, args: 'arg) =
        match x.TryGetValue(node) with
        | None -> ()
        | Some fn ->
            fn args
            |> box
            |> node.Context.Dispatch