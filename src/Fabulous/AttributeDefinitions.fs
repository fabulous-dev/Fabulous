namespace Fabulous

open System.Collections.Generic
open Fabulous

type ScalarAttributeData =
    { Key: AttributeKey
      UpdateNode: obj voption -> obj voption -> IViewNode -> unit
      CompareBoxed: obj -> obj -> ScalarAttributeComparison }

type NumericAttributeData =
    { Key: AttributeKey
      UpdateNode: uint64 voption -> uint64 voption -> IViewNode -> unit }

type WidgetAttributeData =
    { Key: AttributeKey
      ApplyDiff: WidgetDiff -> IViewNode -> unit
      UpdateNode: Widget voption -> Widget voption -> IViewNode -> unit }

type WidgetCollectionAttributeData =
    { Key: AttributeKey
      ApplyDiff: ArraySlice<Widget> -> WidgetCollectionItemChanges -> IViewNode -> unit
      UpdateNode: ArraySlice<Widget> voption -> ArraySlice<Widget> voption -> IViewNode -> unit }

[<RequireQualifiedAccess>]
type AttributeDefinition =
    | Numeric of NumericAttributeData
    | Scalar of ScalarAttributeData
    | Widget of WidgetAttributeData
    | WidgetCollection of WidgetCollectionAttributeData

/// Attribute definition for scalar properties
type ScalarAttributeDefinition<'inputType, 'modelType, 'valueType> =
    { Key: AttributeKey
      Name: string
      Convert: 'inputType -> 'modelType
      ConvertValue: 'modelType -> 'valueType
      Compare: 'modelType -> 'modelType -> ScalarAttributeComparison
      UpdateNode: 'valueType voption -> 'valueType voption -> IViewNode -> unit }

    member x.WithValue(value) : ScalarAttribute =
        { Key = x.Key
#if DEBUG
          DebugName = x.Name
#endif
          NumericValue = 0UL
          Value = x.Convert(value) }

    member x.ToAttributeDefinition() : AttributeDefinition =
        AttributeDefinition.Scalar
            { Key = x.Key
              CompareBoxed = (fun a b -> x.Compare(unbox<'modelType> a) (unbox<'modelType> b))
              UpdateNode =
                  (fun oldValueOpt newValueOpt node ->
                      let oldValueOpt =
                          match oldValueOpt with
                          | ValueNone -> ValueNone
                          | ValueSome v -> ValueSome(x.ConvertValue(unbox<'modelType> v))

                      let newValueOpt =
                          match newValueOpt with
                          | ValueNone -> ValueNone
                          | ValueSome v -> ValueSome(x.ConvertValue(unbox<'modelType> v))

                      x.UpdateNode oldValueOpt newValueOpt node) }

/// Attribute definition for scalar properties
type SmallScalarAttributeDefinition<'inputType, 'valueType> =
    { Key: AttributeKey
      Name: string
      Convert: 'inputType -> uint64
      ConvertValue: uint64 -> 'valueType
      UpdateNode: 'valueType voption -> 'valueType voption -> IViewNode -> unit }

    member x.WithValue(value: 'inputType) : ScalarAttribute =
        { Key = x.Key
#if DEBUG
          DebugName = x.Name
#endif
          NumericValue = x.Convert(value)
          Value = null }

    member x.ToAttributeDefinition() : AttributeDefinition =
        AttributeDefinition.Numeric
            { Key = x.Key
              UpdateNode =
                  (fun oldValueOpt newValueOpt node ->
                      let oldValueOpt =
                          match oldValueOpt with
                          | ValueNone -> ValueNone
                          | ValueSome v -> ValueSome(x.ConvertValue(v))

                      let newValueOpt =
                          match newValueOpt with
                          | ValueNone -> ValueNone
                          | ValueSome v -> ValueSome(x.ConvertValue(v))

                      x.UpdateNode oldValueOpt newValueOpt node) }


/// Attribute definition for widget properties
type WidgetAttributeDefinition =
    { Key: AttributeKey
      Name: string
      ApplyDiff: WidgetDiff -> IViewNode -> unit
      UpdateNode: Widget voption -> Widget voption -> IViewNode -> unit }

    member x.WithValue(value: Widget) : WidgetAttribute =
        { Key = x.Key
#if DEBUG
          DebugName = x.Name
#endif
          Value = value }

    member x.ToAttributeDefinition() : AttributeDefinition =
        AttributeDefinition.Widget
            { Key = x.Key
              ApplyDiff = x.ApplyDiff
              UpdateNode = x.UpdateNode }

/// Attribute definition for collection properties
type WidgetCollectionAttributeDefinition =
    { Key: AttributeKey
      Name: string
      ApplyDiff: ArraySlice<Widget> -> WidgetCollectionItemChanges -> IViewNode -> unit
      UpdateNode: ArraySlice<Widget> voption -> ArraySlice<Widget> voption -> IViewNode -> unit }

    member x.WithValue(value: ArraySlice<Widget>) : WidgetCollectionAttribute =
        { Key = x.Key
#if DEBUG
          DebugName = x.Name
#endif
          Value = value }

    member x.ToAttributeDefinition() : AttributeDefinition =
        AttributeDefinition.WidgetCollection
            { Key = x.Key
              ApplyDiff = x.ApplyDiff
              UpdateNode = x.UpdateNode }

module AttributeDefinitionStore =
    let private _attributes =
        ResizeArray<AttributeDefinition>()

    let mutable private _nextKey: uint32 = 0u

    let get (key:AttributeKey) = _attributes.[AttributeKey.getKeyValue key]
    let set (key:AttributeKey) value = _attributes.[AttributeKey.getKeyValue key] <- value

    let getNextKey () : AttributeKey =
        _attributes.Add(Unchecked.defaultof<AttributeDefinition>)
        let key = _nextKey
        _nextKey <- _nextKey + 1u
        (key ||| AttributeKey.Code.Boxed) * 1u<attributeKey>
        
    let getInlineNextKey () : AttributeKey =
        _attributes.Add(Unchecked.defaultof<AttributeDefinition>)
        let key = _nextKey
        _nextKey <- _nextKey + 1u
        (key ||| AttributeKey.Code.Inline) * 1u<attributeKey>

module AttributeHelpers =
    let tryFindScalarAttribute
        (definition: ScalarAttributeDefinition<'inputType, 'modelType, 'valueType>)
        (widget: Widget)
        =
        match widget.ScalarAttributes with
        | ValueNone -> ValueNone
        | ValueSome attrs ->
            match attrs
                  |> Array.tryFind (fun attr -> attr.Key = definition.Key) with
            | None -> ValueNone
            | Some attr -> ValueSome(unbox<'modelType> attr.Value)
