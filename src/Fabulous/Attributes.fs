namespace Fabulous

open System
open Fabulous

module Helpers =
    let canReuse<'T when 'T: equality> (prev: 'T) (curr: 'T) = prev = curr

    let inline createViewForWidget (parent: IViewNode) (widget: Widget) =
        let widgetDefinition = WidgetDefinitionStore.get widget.Key
        widgetDefinition.CreateView(widget, parent.TreeContext, ValueSome parent)

module ScalarAttributeComparers =
    let noCompare _ _ = ScalarAttributeComparison.Different

    let equalityCompare a b =
        if a = b then
            ScalarAttributeComparison.Identical
        else
            ScalarAttributeComparison.Different

module Attributes =
    /// Define a custom attribute storing any value
    let defineScalarWithConverter<'inputType, 'modelType, 'valueType>
        name
        (convert: 'inputType -> 'modelType)
        (convertValue: 'modelType -> 'valueType)
        (compare: 'modelType -> 'modelType -> ScalarAttributeComparison)
        (updateNode: 'valueType voption -> 'valueType voption -> IViewNode -> unit)
        =
        let key = AttributeDefinitionStore.getNextKey()

        let definition =
            { Key = key
              Name = name
              Convert = convert
              ConvertValue = convertValue
              Compare = compare
              UpdateNode = updateNode }

        AttributeDefinitionStore.set key (definition.ToAttributeDefinition())
        definition

    /// Define a custom attribute that can fit into 8 bytes encoded as uint64 (such as float or bool)
    let defineSmallScalarWithConverter<'modelType>
        name
        (convert: 'modelType -> uint64)
        (convertValue: uint64 -> 'modelType)
        (updateNode: 'modelType voption -> 'modelType voption -> IViewNode -> unit)
        : SmallScalarAttributeDefinition<'modelType> =
        let key =
            AttributeDefinitionStore.getInlineNextKey()

        let definition =
            { Key = key
              Name = name
              Convert = convert
              ConvertValue = convertValue
              UpdateNode = updateNode }

        AttributeDefinitionStore.set key (definition.ToAttributeDefinition())
        definition

//    /// Define a custom float attribute that is encoded into uint64, wrapper on top of defineSmallScalarWithConverter
//    let defineFloat
//        name
//        (updateNode: float voption -> float voption -> IViewNode -> unit)
//        : SmallScalarAttributeDefinition<float> =
//
//        defineSmallScalarWithConverter
//            name
//            BitConverter.DoubleToUInt64Bits
//            BitConverter.UInt64BitsToDouble
//            updateNode

    /// Define a custom bool attribute that is encoded into uint64, wrapper on top of defineSmallScalarWithConverter
    let defineBool
        name
        (updateNode: bool voption -> bool voption -> IViewNode -> unit)
        : SmallScalarAttributeDefinition<bool> =

        defineSmallScalarWithConverter
            name
            (fun (input:bool) -> if input then 1UL else 0UL )
            (fun (encoded:uint64) -> encoded = 1UL )
            updateNode
            
    /// Define a custom attribute storing a widget
    let defineWidgetWithConverter
        name
        (applyDiff: WidgetDiff -> IViewNode -> unit)
        (updateNode: Widget voption -> Widget voption -> IViewNode -> unit)
        =
        let key = AttributeDefinitionStore.getNextKey()

        let definition: WidgetAttributeDefinition =
            { Key = key
              Name = name
              ApplyDiff = applyDiff
              UpdateNode = updateNode }

        AttributeDefinitionStore.set key (definition.ToAttributeDefinition())
        definition

    /// Define a custom attribute storing a widget collection
    let defineWidgetCollectionWithConverter
        name
        (applyDiff: ArraySlice<Widget> -> WidgetCollectionItemChanges -> IViewNode -> unit)
        (updateNode: ArraySlice<Widget> voption -> ArraySlice<Widget> voption -> IViewNode -> unit)
        =
        let key = AttributeDefinitionStore.getNextKey()

        let definition: WidgetCollectionAttributeDefinition =
            { Key = key
              Name = name
              ApplyDiff = applyDiff
              UpdateNode = updateNode }

        AttributeDefinitionStore.set key (definition.ToAttributeDefinition())
        definition

    /// Define an attribute storing a Widget for a CLR property
    let defineWidget<'T when 'T: null> (name: string) (get: obj -> IViewNode) (set: obj -> 'T -> unit) =
        let applyDiff (diff: WidgetDiff) (node: IViewNode) =
            let childNode = get node.Target

            childNode.ApplyDiff(&diff)


        let updateNode _ (newValueOpt: Widget voption) (node: IViewNode) =
            match newValueOpt with
            | ValueNone -> set node.Target null
            | ValueSome widget ->
                let struct (_, view) = Helpers.createViewForWidget node widget

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
                    let itemNode = getViewNode targetColl.[index]

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
                    let prevItemNode = getViewNode targetColl.[index]

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

        defineWidgetCollectionWithConverter name applyDiff updateNode

    let inline define<'T when 'T: equality> name updateTarget =
        defineScalarWithConverter<'T, 'T, 'T> name id id ScalarAttributeComparers.equalityCompare updateTarget

    let defineEventNoArg name (getEvent: obj -> IEvent<EventHandler, EventArgs>) =
        let key = AttributeDefinitionStore.getNextKey()

        let definition: ScalarAttributeDefinition<obj, obj, obj> =
            { Key = key
              Name = name
              Convert = id
              ConvertValue = id
              Compare = ScalarAttributeComparers.noCompare
              UpdateNode =
                  fun _ newValueOpt node ->
                      let event = getEvent node.Target

                      match node.TryGetHandler(key) with
                      | ValueNone -> ()
                      | ValueSome handler -> event.RemoveHandler handler

                      match newValueOpt with
                      | ValueNone -> node.SetHandler(key, ValueNone)

                      | ValueSome msg ->
                          let handler =
                              EventHandler(fun _ _ -> Dispatcher.dispatch node msg)

                          event.AddHandler handler
                          node.SetHandler(key, ValueSome handler) }

        AttributeDefinitionStore.set key (definition.ToAttributeDefinition())
        definition

    let defineEvent<'args> name (getEvent: obj -> IEvent<EventHandler<'args>, 'args>) =
        let key = AttributeDefinitionStore.getNextKey()

        let definition: ScalarAttributeDefinition<_, _, _> =
            { Key = key
              Name = name
              Convert = id
              ConvertValue = id
              Compare = ScalarAttributeComparers.noCompare
              UpdateNode =
                  fun _ (newValueOpt: ('args -> obj) voption) (node: IViewNode) ->
                      let event = getEvent node.Target

                      match node.TryGetHandler(key) with
                      | ValueNone -> ()
                      | ValueSome handler -> event.RemoveHandler handler

                      match newValueOpt with
                      | ValueNone -> node.SetHandler(key, ValueNone)

                      | ValueSome fn ->
                          let handler =
                              EventHandler<'args>
                                  (fun _ args ->
                                      let r = fn args
                                      Dispatcher.dispatch node r)

                          node.SetHandler(key, ValueSome handler)
                          event.AddHandler handler }

        AttributeDefinitionStore.set key (definition.ToAttributeDefinition())
        definition
