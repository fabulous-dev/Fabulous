namespace Fabulous.Maui

open Fabulous
open Fabulous.Attributes

module MauiAttributes =
    type IMauiAttributeDefinition =
        inherit IAttributeDefinition
        abstract member MauiPropertyName: string

    type MauiAttributeDefinition<'inputType, 'modelType> =
        {
            Key: AttributeKey
            Name: string
            MauiPropertyName: string
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

        interface IMauiAttributeDefinition with
            member x.MauiPropertyName = x.MauiPropertyName

        interface IAttributeDefinition<'inputType, 'modelType> with
            member x.Key = x.Key
            member x.DefaultWith () = x.DefaultWith ()

    let defineWithConverter<'inputType, 'modelType> name mauiPropertyName defaultWith (convert: 'inputType -> 'modelType) (compare: struct ('modelType * 'modelType) -> AttributeComparison) =
        let key = AttributeDefinitionStore.getNextKey()
        let definition =
            { Key = key
              Name = name
              MauiPropertyName = mauiPropertyName
              DefaultWith = defaultWith >> convert
              Convert = convert
              Compare = compare }
        AttributeDefinitionStore.set key definition
        definition
    
    let inline defineCollection<'elementType> name mauiPropertyName =
        defineWithConverter<'elementType seq, 'elementType array> name mauiPropertyName (fun () -> Seq.empty) Seq.toArray AttributeComparers.collectionComparer

    let inline defineWithComparer<'T> name mauiPropertyName defaultValue compare =
        defineWithConverter<'T, 'T> name mauiPropertyName defaultValue id compare

    let inline defineNoCompare<'T> name mauiPropertyName defaultValue =
        defineWithConverter<'T, 'T> name mauiPropertyName defaultValue id AttributeComparers.noCompare

    let inline defineEvent<'args> name =
        Fabulous.Attributes.defineWithConverter<'args -> obj, 'args -> obj> name (fun () -> fun _ -> null) id AttributeComparers.noCompare

    let inline define<'T when 'T: equality> name mauiPropertyName defaultValue =
        defineWithConverter<'T, 'T> name mauiPropertyName defaultValue id AttributeComparers.equalityComparer