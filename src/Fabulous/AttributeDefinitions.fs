namespace Fabulous

open System.Collections.Generic
open Fabulous

[<Struct>]
type ScalarAttributeData =
    { UpdateNode: obj voption -> obj voption -> IViewNode -> unit
      CompareBoxed: obj -> obj -> ScalarAttributeComparison }

[<Struct>]
type SmallScalarAttributeData =
    { UpdateNode: uint64 voption -> uint64 voption -> IViewNode -> unit }

[<Struct>]
type WidgetAttributeData =
    { ApplyDiff: WidgetDiff -> IViewNode -> unit
      UpdateNode: Widget voption -> Widget voption -> IViewNode -> unit }

[<Struct>]
type WidgetCollectionAttributeData =
    { ApplyDiff: ArraySlice<Widget> -> WidgetCollectionItemChanges -> IViewNode -> unit
      UpdateNode: ArraySlice<Widget> voption -> ArraySlice<Widget> voption -> IViewNode -> unit }

/// Attribute definition for scalar properties
type ScalarAttributeDefinition<'inputType, 'modelType, 'valueType> =
    { Key: ScalarAttributeKey
      Name: string
      Convert: 'inputType -> 'modelType }

    member inline x.WithValue(value) : ScalarAttribute =
        { Key = x.Key
#if DEBUG
          DebugName = x.Name
#endif
          NumericValue = 0UL
          Value = x.Convert(value) }

    static member inline CreateAttributeData<'modelType, 'valueType>
        (
            [<InlineIfLambda>] convertValue: 'modelType -> 'valueType,
            [<InlineIfLambda>] compare: 'modelType -> 'modelType -> ScalarAttributeComparison,
            [<InlineIfLambda>] updateNode: 'valueType voption -> 'valueType voption -> IViewNode -> unit
        ) : ScalarAttributeData =
        { CompareBoxed = (fun a b -> compare(unbox<'modelType> a) (unbox<'modelType> b))
          UpdateNode =
              (fun oldValueOpt newValueOpt node ->
                  let oldValueOpt =
                      match oldValueOpt with
                      | ValueNone -> ValueNone
                      | ValueSome v -> ValueSome(convertValue(unbox<'modelType> v))

                  let newValueOpt =
                      match newValueOpt with
                      | ValueNone -> ValueNone
                      | ValueSome v -> ValueSome(convertValue(unbox<'modelType> v))

                  updateNode oldValueOpt newValueOpt node) }


type SimpleScalarAttributeDefinition<'modelType> =
    { Key: ScalarAttributeKey
      Name: string }

    member inline x.WithValue(value: 'modelType) : ScalarAttribute =
        { Key = x.Key
#if DEBUG
          DebugName = x.Name
#endif
          NumericValue = 0UL
          Value = value }

    static member inline CreateAttributeData<'modelType>
        (
            [<InlineIfLambda>] compare: 'modelType -> 'modelType -> ScalarAttributeComparison,
            [<InlineIfLambda>] updateNode: 'modelType voption -> 'modelType voption -> IViewNode -> unit
        ) : ScalarAttributeData =
        { CompareBoxed = (fun a b -> compare(unbox<'modelType> a) (unbox<'modelType> b))
          UpdateNode =
              (fun oldValueOpt newValueOpt node ->
                  let oldValueOpt =
                      match oldValueOpt with
                      | ValueNone -> ValueNone
                      | ValueSome v -> ValueSome(unbox<'modelType> v)

                  let newValueOpt =
                      match newValueOpt with
                      | ValueNone -> ValueNone
                      | ValueSome v -> ValueSome(unbox<'modelType> v)

                  updateNode oldValueOpt newValueOpt node) }


/// Attribute definition for scalar properties
type SmallScalarAttributeDefinition<'modelType> =
    { Key: ScalarAttributeKey
      Name: string
      Encode: 'modelType -> uint64 }

    member x.WithValue(value: 'modelType) : ScalarAttribute =
        { Key = x.Key
#if DEBUG
          DebugName = x.Name
#endif
          NumericValue = x.Encode(value)
          Value = null }

    static member inline CreateAttributeData<'modelType>
        (
            [<InlineIfLambda>] decode: uint64 -> 'modelType,
            [<InlineIfLambda>] updateNode: 'modelType voption -> 'modelType voption -> IViewNode -> unit
        ) : SmallScalarAttributeData =
        { UpdateNode =
              (fun oldValueOpt newValueOpt node ->
                  let oldValueOpt =
                      match oldValueOpt with
                      | ValueNone -> ValueNone
                      | ValueSome v -> ValueSome(decode(v))

                  let newValueOpt =
                      match newValueOpt with
                      | ValueNone -> ValueNone
                      | ValueSome v -> ValueSome(decode(v))

                  updateNode oldValueOpt newValueOpt node) }


/// Attribute definition for widget properties
type WidgetAttributeDefinition =
    { Key: WidgetAttributeKey
      Name: string }

    member x.WithValue(value: Widget) : WidgetAttribute =
        { Key = x.Key
#if DEBUG
          DebugName = x.Name
#endif
          Value = value }



/// Attribute definition for collection properties
type WidgetCollectionAttributeDefinition =
    { Key: WidgetCollectionAttributeKey
      Name: string }

    member x.WithValue(value: ArraySlice<Widget>) : WidgetCollectionAttribute =
        { Key = x.Key
#if DEBUG
          DebugName = x.Name
#endif
          Value = value }



module AttributeDefinitionStore =
    let private _scalars = ResizeArray<ScalarAttributeData>()
    let private _smallScalars = ResizeArray<SmallScalarAttributeData>()
    let private _widgets = ResizeArray<WidgetAttributeData>()

    let private _widgetCollections =
        ResizeArray<WidgetCollectionAttributeData>()

    let registerScalar (data: ScalarAttributeData) : ScalarAttributeKey =
        let index = _scalars.Count
        _scalars.Add(data)

        (index ||| ScalarAttributeKey.Code.Boxed)
        * 1<attributeKey>

    let registerSmallScalar (data: SmallScalarAttributeData) : ScalarAttributeKey =
        let index = _smallScalars.Count
        _smallScalars.Add(data)

        (index ||| ScalarAttributeKey.Code.Inline)
        * 1<attributeKey>

    let registerWidget (data: WidgetAttributeData) : WidgetAttributeKey =
        let index = _widgets.Count
        _widgets.Add(data)
        index * 1<attributeWidgetKey>

    let registerWidgetCollection (data: WidgetCollectionAttributeData) : WidgetCollectionAttributeKey =
        let index = _widgetCollections.Count
        _widgetCollections.Add(data)
        index * 1<attributeWidgetCollectionKey>

    let getScalar (key: ScalarAttributeKey) : ScalarAttributeData =
        let index = ScalarAttributeKey.getKeyValue key
        _scalars.[index]

    let getSmallScalar (key: ScalarAttributeKey) : SmallScalarAttributeData =
        let index = ScalarAttributeKey.getKeyValue key
        _smallScalars.[index]


    let getWidget (key: WidgetAttributeKey) : WidgetAttributeData = _widgets.[int key]

    let getWidgetCollection (key: WidgetCollectionAttributeKey) : WidgetCollectionAttributeData =
        _widgetCollections.[int key]

module AttributeHelpers =
    let tryFindScalarAttribute
        (definition: ScalarAttributeDefinition<'inputType, 'modelType, 'valueType>)
        (widget: Widget)
        =
        match widget.ScalarAttributes with
        | ValueNone -> ValueNone
        | ValueSome attrs ->
            match attrs
                  |> Array.tryFind(fun attr -> attr.Key = definition.Key) with
            | None -> ValueNone
            | Some attr -> ValueSome(unbox<'modelType> attr.Value)
