namespace Fabulous

module ScalarAttributeDefinitions =
    /// A small scalar attribute.
    /// When we can encode the value as a uint64 (64 bits), we should prefer this type.
    /// The value will be kept on the stack avoiding GC pressure.
    [<Struct>]
    type SmallScalarAttributeData =
        { UpdateNode: uint64 voption -> uint64 voption -> IViewNode -> unit }

    /// A regular scalar attribute.
    /// The value will be boxed and put on the heap, which can trigger GC to pass.
    /// Prefer small scalar attribute when possible.
    [<Struct>]
    type ScalarAttributeData =
        { UpdateNode: obj voption -> obj voption -> IViewNode -> unit
          CompareBoxed: obj -> obj -> ScalarAttributeComparison }

    /// Attribute definition for small scalar properties (encodable on 64 bits)
    [<Struct>]
    type SmallScalarAttributeDefinition<'T> =
        { Key: ScalarAttributeKey
          Name: string }

        member inline x.WithValue(value: 'T, [<InlineIfLambda>] encode: 'T -> uint64) : ScalarAttribute =
            { Key = x.Key
#if DEBUG
              DebugName = x.Name
#endif
              NumericValue = encode(value)
              Value = null }

        static member inline CreateAttributeData<'T>
            ([<InlineIfLambda>] decode: uint64 -> 'T, [<InlineIfLambda>] updateNode: 'T voption -> 'T voption -> IViewNode -> unit)
            : SmallScalarAttributeData =
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

    /// Attribute definition for boxed scalar properties
    [<Struct>]
    type SimpleScalarAttributeDefinition<'T> =
        { Key: ScalarAttributeKey
          Name: string }

        member inline x.WithValue(value: 'T) : ScalarAttribute =
            { Key = x.Key
#if DEBUG
              DebugName = x.Name
#endif
              NumericValue = 0UL
              Value = value }

        static member CreateAttributeData
            (compare: 'T -> 'T -> ScalarAttributeComparison, updateNode: 'T voption -> 'T voption -> IViewNode -> unit)
            : ScalarAttributeData =
            { CompareBoxed = (fun a b -> compare (unbox<'T> a) (unbox<'T> b))
              UpdateNode =
                (fun oldValueOpt newValueOpt node ->
                    let oldValueOpt =
                        match oldValueOpt with
                        | ValueNone -> ValueNone
                        | ValueSome v -> ValueSome(unbox<'T> v)

                    let newValueOpt =
                        match newValueOpt with
                        | ValueNone -> ValueNone
                        | ValueSome v -> ValueSome(unbox<'T> v)

                    updateNode oldValueOpt newValueOpt node) }

    /// Attribute definition for boxed scalar properties with a custom conversion before being applied to the view
    [<Struct>]
    type ScalarAttributeDefinition<'modelType, 'valueType> =
        { Key: ScalarAttributeKey
          Name: string }

        member inline x.WithValue(value: 'modelType) : ScalarAttribute =
            { Key = x.Key
#if DEBUG
              DebugName = x.Name
#endif
              NumericValue = 0UL
              Value = value }

        static member inline CreateAttributeData<'modelType, 'valueType>
            (
                [<InlineIfLambda>] convertValue: 'modelType -> 'valueType,
                [<InlineIfLambda>] compare: 'modelType -> 'modelType -> ScalarAttributeComparison,
                [<InlineIfLambda>] updateNode: 'valueType voption -> 'valueType voption -> IViewNode -> unit
            ) : ScalarAttributeData =
            { CompareBoxed = (fun a b -> compare (unbox<'modelType> a) (unbox<'modelType> b))
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

module WidgetAttributeDefinitions =
    [<Struct>]
    type WidgetAttributeData =
        { ApplyDiff: WidgetDiff -> IViewNode -> unit
          UpdateNode: Widget voption -> Widget voption -> IViewNode -> unit }

    /// Attribute definition for widget properties
    [<Struct>]
    type WidgetAttributeDefinition =
        { Key: WidgetAttributeKey
          Name: string }

        member inline x.WithValue(value: Widget) : WidgetAttribute =
            { Key = x.Key
#if DEBUG
              DebugName = x.Name
#endif
              Value = value }

module WidgetCollectionAttributeDefinitions =
    [<Struct>]
    type WidgetCollectionAttributeData =
        { ApplyDiff: ArraySlice<Widget> -> WidgetCollectionItemChanges -> IViewNode -> unit
          UpdateNode: ArraySlice<Widget> voption -> ArraySlice<Widget> voption -> IViewNode -> unit }

    /// Attribute definition for collection properties
    [<Struct>]
    type WidgetCollectionAttributeDefinition =
        { Key: WidgetCollectionAttributeKey
          Name: string }

        member inline x.WithValue(value: ArraySlice<Widget>) : WidgetCollectionAttribute =
            { Key = x.Key
#if DEBUG
              DebugName = x.Name
#endif
              Value = value }

module AttributeDefinitionStore =
    open ScalarAttributeDefinitions
    open WidgetAttributeDefinitions
    open WidgetCollectionAttributeDefinitions

    let private _scalars = ResizeArray<ScalarAttributeData>()
    let private _smallScalars = ResizeArray<SmallScalarAttributeData>()
    let private _widgets = ResizeArray<WidgetAttributeData>()

    let private _widgetCollections = ResizeArray<WidgetCollectionAttributeData>()

    let registerSmallScalar (data: SmallScalarAttributeData) : ScalarAttributeKey =
        let index = _smallScalars.Count
        _smallScalars.Add(data)

        (index ||| ScalarAttributeKey.Code.Inline) * 1<scalarAttributeKey>

    let registerScalar (data: ScalarAttributeData) : ScalarAttributeKey =
        let index = _scalars.Count
        _scalars.Add(data)

        (index ||| ScalarAttributeKey.Code.Boxed) * 1<scalarAttributeKey>

    let registerWidget (data: WidgetAttributeData) : WidgetAttributeKey =
        let index = _widgets.Count
        _widgets.Add(data)
        index * 1<widgetAttributeKey>

    let registerWidgetCollection (data: WidgetCollectionAttributeData) : WidgetCollectionAttributeKey =
        let index = _widgetCollections.Count
        _widgetCollections.Add(data)
        index * 1<widgetCollectionAttributeKey>

    let getScalar (key: ScalarAttributeKey) : ScalarAttributeData =
        let index = ScalarAttributeKey.getKeyValue key
        _scalars[index]

    let getSmallScalar (key: ScalarAttributeKey) : SmallScalarAttributeData =
        let index = ScalarAttributeKey.getKeyValue key
        _smallScalars[index]

    let getWidget (key: WidgetAttributeKey) : WidgetAttributeData = _widgets[int key]

    let getWidgetCollection (key: WidgetCollectionAttributeKey) : WidgetCollectionAttributeData = _widgetCollections[int key]

module AttributeHelpers =
    open ScalarAttributeDefinitions

    let tryFindSimpleScalarAttribute (definition: SimpleScalarAttributeDefinition<'T>) (widget: Widget) =
        match widget.ScalarAttributes with
        | ValueNone -> ValueNone
        | ValueSome attrs ->
            match attrs |> Array.tryFind(fun attr -> attr.Key = definition.Key) with
            | None -> ValueNone
            | Some attr -> ValueSome(unbox<'T> attr.Value)
