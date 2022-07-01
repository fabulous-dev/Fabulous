namespace Fabulous

open System
open System.Runtime.CompilerServices
open Fabulous.ScalarAttributeDefinitions
open Fabulous.WidgetAttributeDefinitions
open Fabulous.WidgetCollectionAttributeDefinitions

module Helpers =
    let canReuse<'T when 'T: equality> (prev: 'T) (curr: 'T) = prev = curr

    let inline createViewForWidget (parent: IViewNode) (widget: Widget) =
        let widgetDefinition = WidgetDefinitionStore.get widget.Key

        widgetDefinition.CreateView(widget, parent.TreeContext, ValueSome parent)

module ScalarAttributeComparers =
    let inline noCompare _ _ = ScalarAttributeComparison.Different

    let inline equalityCompare a b =
        if a = b then
            ScalarAttributeComparison.Identical
        else
            ScalarAttributeComparison.Different

module SmallScalars =
    module Bool =
        let inline encode (v: bool) : uint64 = if v then 1UL else 0UL
        let inline decode (encoded: uint64) : bool = encoded = 1UL

    module Float =
        let inline encode (v: float) : uint64 =
            BitConverter.DoubleToInt64Bits v |> uint64

        let inline decode (encoded: uint64) : float =
            encoded |> int64 |> BitConverter.Int64BitsToDouble

    // TODO is there a better conversion algorithm?
    module Int =
        let inline encode (v: int) : uint64 = uint64 v

        let inline decode (encoded: uint64) : int = int encoded

    module UInt =
        let inline encode (v: uint) : uint64 = uint64 v

        let inline decode (encoded: uint64) : uint = uint encoded

    module IntEnum =
        let inline encode< ^T when ^T: enum<int> and ^T: (static member op_Explicit: ^T -> uint64)> (v: ^T) : uint64 =
            uint64 v

        let inline decode< ^T when ^T: enum<int>> (encoded: uint64) : ^T = enum< ^T>(int encoded)

[<Extension>]
type SmallScalarExtensions() =
    [<Extension>]
    static member inline WithValue(this: SmallScalarAttributeDefinition<bool>, value) =
        this.WithValue(value, SmallScalars.Bool.encode)

    [<Extension>]
    static member inline WithValue(this: SmallScalarAttributeDefinition<float>, value) =
        this.WithValue(value, SmallScalars.Float.encode)

    [<Extension>]
    static member inline WithValue(this: SmallScalarAttributeDefinition<int>, value) =
        this.WithValue(value, SmallScalars.Int.encode)

    [<Extension>]
    static member inline WithValue< ^T when ^T: enum<int> and ^T: (static member op_Explicit: ^T -> uint64)>
        (
            this: SmallScalarAttributeDefinition< ^T >,
            value
        ) =
        this.WithValue(value, SmallScalars.IntEnum.encode)


module Attributes =
    /// Define an attribute that can fit into 8 bytes encoded as uint64 (such as float or bool)
    let inline defineSmallScalar<'T>
        name
        ([<InlineIfLambda>] decode: uint64 -> 'T)
        ([<InlineIfLambda>] updateNode: 'T voption -> 'T voption -> IViewNode -> unit)
        : SmallScalarAttributeDefinition<'T> =
        let key =
            SmallScalarAttributeDefinition.CreateAttributeData<'T>(decode, updateNode)
            |> AttributeDefinitionStore.registerSmallScalar

        { Key = key; Name = name }

    /// Define an attribute that can store any value with no conversion.
    /// The value will be boxed and allocated on the heap.
    /// For better performance, use defineSmallScalar instead.
    let inline defineSimpleScalar<'T>
        name
        ([<InlineIfLambda>] compare: 'T -> 'T -> ScalarAttributeComparison)
        ([<InlineIfLambda>] updateNode: 'T voption -> 'T voption -> IViewNode -> unit)
        : SimpleScalarAttributeDefinition<'T> =
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(compare, updateNode)
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }

    /// Define an attribute that can store any value with a conversion.
    /// The value will be boxed and allocated on the heap.
    /// For better performance, use defineSmallScalar instead.
    let inline defineScalar<'modelType, 'valueType>
        name
        ([<InlineIfLambda>] convertValue: 'modelType -> 'valueType)
        ([<InlineIfLambda>] compare: 'modelType -> 'modelType -> ScalarAttributeComparison)
        ([<InlineIfLambda>] updateNode: 'valueType voption -> 'valueType voption -> IViewNode -> unit)
        : ScalarAttributeDefinition<'modelType, 'valueType> =
        let key =
            ScalarAttributeDefinition.CreateAttributeData<'modelType, 'valueType>(convertValue, compare, updateNode)
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }

    /// Define an int attribute that is encoded into uint64
    let inline defineInt
        name
        ([<InlineIfLambda>] updateNode: int voption -> int voption -> IViewNode -> unit)
        : SmallScalarAttributeDefinition<int> =

        defineSmallScalar name SmallScalars.Int.decode updateNode

    /// Define a float attribute that is encoded into uint64
    let inline defineFloat
        name
        ([<InlineIfLambda>] updateNode: float voption -> float voption -> IViewNode -> unit)
        : SmallScalarAttributeDefinition<float> =

        defineSmallScalar name SmallScalars.Float.decode updateNode

    /// Define a enum attribute that is encoded into uint64
    let inline defineEnum< ^T when ^T: enum<int>>
        name
        ([<InlineIfLambda>] updateNode: ^T voption -> ^T voption -> IViewNode -> unit)
        : SmallScalarAttributeDefinition< ^T > =
        defineSmallScalar name SmallScalars.IntEnum.decode updateNode

    /// Define a boolean attribute that is encoded into uint64
    let inline defineBool
        name
        ([<InlineIfLambda>] updateNode: bool voption -> bool voption -> IViewNode -> unit)
        : SmallScalarAttributeDefinition<bool> =

        defineSmallScalar name SmallScalars.Bool.decode updateNode

    /// Define an attribute storing a single Widget.
    /// Used for storing the single child of a view
    let inline defineWidget
        name
        (applyDiff: WidgetDiff -> IViewNode -> unit)
        (updateNode: Widget voption -> Widget voption -> IViewNode -> unit)
        : WidgetAttributeDefinition =

        let key =
            AttributeDefinitionStore.registerWidget
                { ApplyDiff = applyDiff
                  UpdateNode = updateNode }

        { Key = key; Name = name }

    /// Define an attribute storing a collection of Widgets
    /// Used for storing children of a view
    let inline defineWidgetCollection
        name
        (applyDiff: ArraySlice<Widget> -> WidgetCollectionItemChanges -> IViewNode -> unit)
        (updateNode: ArraySlice<Widget> voption -> ArraySlice<Widget> voption -> IViewNode -> unit)
        : WidgetCollectionAttributeDefinition =

        let key =
            AttributeDefinitionStore.registerWidgetCollection
                { ApplyDiff = applyDiff
                  UpdateNode = updateNode }

        { Key = key; Name = name }

    /// Define an attribute storing a Widget for a CLR property
    let definePropertyWidget<'T when 'T: null>
        (name: string)
        ([<InlineIfLambda>] get: obj -> obj)
        ([<InlineIfLambda>] set: obj -> 'T -> unit)
        =
        let applyDiff (diff: WidgetDiff) (node: IViewNode) =
            let childView = get node.Target

            let childNode = node.TreeContext.GetViewNode(childView)

            childNode.ApplyDiff(&diff)

        let updateNode _ (newValueOpt: Widget voption) (node: IViewNode) =
            match newValueOpt with
            | ValueNone -> set node.Target null
            | ValueSome widget ->
                let struct (_, view) = Helpers.createViewForWidget node widget

                set node.Target (unbox view)

        defineWidget name applyDiff updateNode

    /// Define an attribute storing a collection of Widget for a List<T> property
    let inline defineListWidgetCollection<'itemType>
        name
        ([<InlineIfLambda>] getCollection: obj -> System.Collections.Generic.IList<'itemType>)
        =
        let applyDiff _ (diffs: WidgetCollectionItemChanges) (node: IViewNode) =
            let targetColl = getCollection node.Target

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Remove (index, widget) ->
                    let itemNode =
                        node.TreeContext.GetViewNode(box targetColl.[index])

                    // Trigger the unmounted event
                    Dispatcher.dispatchEventForAllChildren itemNode widget Lifecycle.Unmounted
                    itemNode.Disconnect()

                    // Remove the child from the UI tree
                    targetColl.RemoveAt(index)

                | _ -> ()

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Insert (index, widget) ->
                    let struct (itemNode, view) = Helpers.createViewForWidget node widget

                    // Insert the new child into the UI tree
                    targetColl.Insert(index, unbox view)

                    // Trigger the mounted event
                    Dispatcher.dispatchEventForAllChildren itemNode widget Lifecycle.Mounted

                | WidgetCollectionItemChange.Update (index, widgetDiff) ->
                    let childNode =
                        node.TreeContext.GetViewNode(box targetColl.[index])

                    childNode.ApplyDiff(&widgetDiff)

                | WidgetCollectionItemChange.Replace (index, oldWidget, newWidget) ->
                    let prevItemNode =
                        node.TreeContext.GetViewNode(box targetColl.[index])

                    let struct (nextItemNode, view) =
                        Helpers.createViewForWidget node newWidget

                    // Trigger the unmounted event for the old child
                    Dispatcher.dispatchEventForAllChildren prevItemNode oldWidget Lifecycle.Unmounted
                    prevItemNode.Disconnect()

                    // Replace the existing child in the UI tree at the index with the new one
                    targetColl.[index] <- unbox view

                    // Trigger the mounted event for the new child
                    Dispatcher.dispatchEventForAllChildren nextItemNode newWidget Lifecycle.Mounted

                | _ -> ()

        let updateNode _ (newValueOpt: ArraySlice<Widget> voption) (node: IViewNode) =
            let targetColl = getCollection node.Target
            targetColl.Clear()

            match newValueOpt with
            | ValueNone -> ()
            | ValueSome widgets ->
                for widget in ArraySlice.toSpan widgets do
                    let struct (_, view) = Helpers.createViewForWidget node widget

                    targetColl.Add(unbox view)

        defineWidgetCollection name applyDiff updateNode

    /// Define an attribute for a value supporting equality comparison
    let inline defineSimpleScalarWithEquality<'T when 'T: equality>
        name
        ([<InlineIfLambda>] updateTarget: 'T voption -> 'T voption -> IViewNode -> unit)
        : SimpleScalarAttributeDefinition<'T> =
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(ScalarAttributeComparers.equalityCompare, updateTarget)
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }

    /// Define an attribute for EventHandler
    let inline defineEventNoArg
        name
        ([<InlineIfLambda>] getEvent: obj -> IEvent<EventHandler, EventArgs>)
        : SimpleScalarAttributeDefinition<obj> =
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                ScalarAttributeComparers.noCompare,
                (fun _ newValueOpt node ->
                    let event = getEvent node.Target

                    match node.TryGetHandler(name) with
                    | ValueNone -> ()
                    | ValueSome handler -> event.RemoveHandler handler

                    match newValueOpt with
                    | ValueNone -> node.SetHandler(name, ValueNone)

                    | ValueSome msg ->
                        let handler =
                            EventHandler(fun _ _ -> Dispatcher.dispatch node msg)

                        event.AddHandler handler
                        node.SetHandler(name, ValueSome handler))
            )

            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }

    /// Define an attribute for EventHandler<'T>
    let inline defineEvent<'args>
        name
        ([<InlineIfLambda>] getEvent: obj -> IEvent<EventHandler<'args>, 'args>)
        : SimpleScalarAttributeDefinition<'args -> obj> =
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                ScalarAttributeComparers.noCompare,
                (fun _ (newValueOpt: ('args -> obj) voption) (node: IViewNode) ->
                    let event = getEvent node.Target

                    match node.TryGetHandler(name) with
                    | ValueNone -> ()
                    | ValueSome handler -> event.RemoveHandler handler

                    match newValueOpt with
                    | ValueNone -> node.SetHandler(name, ValueNone)

                    | ValueSome fn ->
                        let handler =
                            EventHandler<'args>
                                (fun _ args ->
                                    let r = fn args
                                    Dispatcher.dispatch node r)

                        node.SetHandler(name, ValueSome handler)
                        event.AddHandler handler)
            )
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }
