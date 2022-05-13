namespace Fabulous

open System
open System.Runtime.CompilerServices
open Fabulous.ScalarAttributeDefinitions
open Fabulous.WidgetAttributeDefinitions
open Fabulous.WidgetCollectionAttributeDefinitions

module Helpers =
    let canReuse<'T when 'T: equality> (prev: 'T) (curr: 'T) = prev = curr

    let inline createViewForWidget (parent: IViewNode) (widget: Widget) =
        let widgetDefinition =
            WidgetDefinitionStore.get widget.Key

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
        let inline encode (v: float) : uint64 = BitConverter.DoubleToUInt64Bits v
        let inline decode (encoded: uint64) : float = BitConverter.UInt64BitsToDouble encoded

    // TODO is there a better conversion algorithm?
    module Int =
        let inline encode (v: int) : uint64 =
            uint64 v

        let inline decode (encoded: uint64) : int =
            int encoded
    
[<Extension>]
type SmallScalarExtensions () =
    [<Extension>]
    static member inline WithValue (this: SmallScalarAttributeDefinition<bool>, value) =
        this.WithValue(value, SmallScalars.Bool.encode)
        
    [<Extension>]
    static member inline WithValue (this: SmallScalarAttributeDefinition<float>, value) =
        this.WithValue(value, SmallScalars.Float.encode)
        
    [<Extension>]
    static member inline WithValue (this: SmallScalarAttributeDefinition<int>, value) =
        this.WithValue(value, SmallScalars.Int.encode)
        
module Attributes =
    /// Define a custom attribute storing any value
    let inline defineScalarWithConverter<'inputType, 'modelType, 'valueType>
        name
        ([<InlineIfLambda>] convert: 'inputType -> 'modelType)
        ([<InlineIfLambda>] convertValue: 'modelType -> 'valueType)
        ([<InlineIfLambda>] compare: 'modelType -> 'modelType -> ScalarAttributeComparison)
        ([<InlineIfLambda>] updateNode: 'valueType voption -> 'valueType voption -> IViewNode -> unit)
        : ScalarAttributeDefinition<'inputType, 'modelType, 'valueType> =
        let key =
            ScalarAttributeDefinition.CreateAttributeData<'modelType, 'valueType>(convertValue, compare, updateNode)
            |> AttributeDefinitionStore.registerScalar

        { Key = key
          Name = name
          Convert = convert }



    /// Define a custom attribute that can fit into 8 bytes encoded as uint64 (such as float or bool)
    let inline defineSmallScalar<'modelType>
        name
        ([<InlineIfLambda>] decode: uint64 -> 'modelType)
        ([<InlineIfLambda>] updateNode: 'modelType voption -> 'modelType voption -> IViewNode -> unit)
        : SmallScalarAttributeDefinition<'modelType> =
        let key =
            SmallScalarAttributeDefinition.CreateAttributeData<'modelType>(decode, updateNode)
            |> AttributeDefinitionStore.registerSmallScalar

        { Key = key; Name = name }


    /// Define a custom float attribute that is encoded into uint64, wrapper on top of defineSmallScalarWithConverter
    let inline defineFloat
        name
        (updateNode: float voption -> float voption -> IViewNode -> unit)
        : SmallScalarAttributeDefinition<float> =

        defineSmallScalar name SmallScalars.Float.decode updateNode

    /// Define a custom bool attribute that is encoded into uint64, wrapper on top of defineSmallScalarWithConverter
    let inline defineBool
        name
        ([<InlineIfLambda>] updateNode: bool voption -> bool voption -> IViewNode -> unit)
        : SmallScalarAttributeDefinition<bool> =

        defineSmallScalar name SmallScalars.Bool.decode updateNode

    /// Define a custom attribute storing a widget
    let inline defineWidgetWithConverter
        name
        (applyDiff: WidgetDiff -> IViewNode -> unit)
        (updateNode: Widget voption -> Widget voption -> IViewNode -> unit)
        : WidgetAttributeDefinition =

        let key =
            AttributeDefinitionStore.registerWidget
                { ApplyDiff = applyDiff
                  UpdateNode = updateNode }

        { Key = key; Name = name }



    /// Define a custom attribute storing a widget collection
    let inline defineWidgetCollectionWithConverter
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
    let inline defineWidget<'T when 'T: null>
        (name: string)
        ([<InlineIfLambda>] get: obj -> IViewNode)
        ([<InlineIfLambda>] set: obj -> 'T -> unit)
        =
        let applyDiff (diff: WidgetDiff) (node: IViewNode) =
            let childNode = get node.Target

            childNode.ApplyDiff(&diff)


        let updateNode _ (newValueOpt: Widget voption) (node: IViewNode) =
            match newValueOpt with
            | ValueNone -> set node.Target null
            | ValueSome widget ->
                let struct (_, view) =
                    Helpers.createViewForWidget node widget

                set node.Target (unbox view)

        defineWidgetWithConverter name applyDiff updateNode

    /// Define an attribute storing a collection of Widget
    let defineWidgetCollection<'itemType>
        name
        (getViewNode: obj -> IViewNode)
        (getCollection: obj -> System.Collections.Generic.IList<'itemType>)
        =
        let applyDiff _ (diffs: WidgetCollectionItemChanges) (node: IViewNode) =
            let targetColl = getCollection node.Target

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Remove (index, widget) ->
                    let itemNode =
                        getViewNode targetColl.[index]

                    // Trigger the unmounted event
                    Dispatcher.dispatchEventForAllChildren itemNode widget Lifecycle.Unmounted
                    itemNode.Disconnect()

                    // Remove the child from the UI tree
                    targetColl.RemoveAt(index)

                | _ -> ()

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Insert (index, widget) ->
                    let struct (itemNode, view) =
                        Helpers.createViewForWidget node widget

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
                        getViewNode targetColl.[index]

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
                    let struct (_, view) =
                        Helpers.createViewForWidget node widget

                    targetColl.Add(unbox view)

        defineWidgetCollectionWithConverter name applyDiff updateNode

    let inline define<'T when 'T: equality>
        name
        ([<InlineIfLambda>] updateTarget: 'T voption -> 'T voption -> IViewNode -> unit)
        : SimpleScalarAttributeDefinition<'T> =
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(ScalarAttributeComparers.equalityCompare, updateTarget)
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }


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
                            EventHandler<'args> (fun _ args ->
                                let r = fn args
                                Dispatcher.dispatch node r)

                        node.SetHandler(name, ValueSome handler)
                        event.AddHandler handler)
            )
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }
