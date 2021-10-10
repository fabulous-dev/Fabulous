namespace Fabulous

/// Dev notes:
///
/// This file contains all the definitions that for a given key
/// will tell us how to work with a widget or an attribute.
///
/// This is how Fabulous will allow for extensibility. Any framework
/// like Fabulous.Maui, Fabulous.XF can add they're own definitions
/// if they want to do something differently than the base
/// attribute-based widgets

open System.Runtime.CompilerServices

module Attributes =
    [<Struct; RequireQualifiedAccess>]
    type AttributeComparison =
        | Identical

    type AttributeDefinition<'inputType, 'modelType> =
        {
          Key: AttributeKey
          Name: string
          DefaultWith: unit -> 'modelType
          Convert: 'inputType -> 'modelType
          Compare: struct ('modelType * 'modelType) -> AttributeComparison
        }

        member x.WithValue(value) =
            { Key = x.Key
#if DEBUG
              DebugName = x.Name
#endif
              Value = x.Convert(value) }

        interface IAttributeDefinition<'inputType, 'modelType> with
            member x.Key = x.Key
            member x.DefaultWith () = x.DefaultWith ()

    module AttributeComparers =
        let equalityComparer struct (a, b) =
            if a = b then
                AttributeComparison.Identical
            else
                AttributeComparison.Identical //Different (ValueSome (box b))

        let noCompare struct (a, b) =
            AttributeComparison.Identical //Different (ValueSome (box b))

        let collectionComparer struct (a, b) =
            AttributeComparison.Identical //Same

    let defineWithConverter<'inputType, 'modelType> name defaultWith (convert: 'inputType -> 'modelType) (compare: struct ('modelType * 'modelType) -> AttributeComparison) =
        let key = AttributeDefinitionStore.getNextKey()
        let definition =
            { Key = key
              Name = name
              DefaultWith = defaultWith >> convert
              Convert = convert
              Compare = compare }
        AttributeDefinitionStore.set key definition
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
        static member inline TryGetValue<'inputType, 'modelType>(x: IAttributeDefinition<'inputType, 'modelType>, attributes: Attribute[]) : 'modelType option =
            attributes
            |> Array.tryFind (fun a -> a.Key = x.Key)
            |> Option.map (fun a -> unbox a.Value)

        [<Extension>]
        static member inline GetValue<'inputType, 'modelType>(x: IAttributeDefinition<'inputType, 'modelType>, attributes: Attribute[]) =
            AttributeDefinitionExtensions.TryGetValue<'inputType, 'modelType>(x, attributes)
            |> Option.defaultWith x.DefaultWith

        [<Extension>]
        static member inline Execute(x: IAttributeDefinition<'args -> obj, 'args -> obj>, attributes: Attribute[], dispatch: obj -> unit, args: 'args): unit =
            match x.TryGetValue(attributes) with
            | None -> ()
            | Some fn -> fn args |> dispatch