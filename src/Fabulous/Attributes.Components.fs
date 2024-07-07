namespace Fabulous

open System
open Fabulous
open Fabulous.ScalarAttributeDefinitions

module ComponentAttributes =
    /// Define an attribute storing a collection of Widget for a List<T> property
    let inline defineListWidgetCollection<'itemType> name ([<InlineIfLambda>] getCollection: obj -> System.Collections.Generic.IList<'itemType>) =
        let applyDiff _ (diffs: WidgetCollectionItemChanges) (node: IViewNode) =
            let targetColl = getCollection node.Target

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Remove(index, widget) ->
                    let itemNode = node.TreeContext.GetViewNode(box targetColl[index])

                    // Trigger the unmounted event
                    // TODO: Trigger Unmounted function for all children - Dispatcher.dispatchEventForAllChildren itemNode widget Lifecycle.Unmounted
                    itemNode.Dispose()

                    // Remove the child from the UI tree
                    targetColl.RemoveAt(index)

                | _ -> ()

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Insert(index, widget) ->
                    let struct (itemNode, view) = Helpers.createViewForWidget node widget

                    // Insert the new child into the UI tree
                    targetColl.Insert(index, unbox view)

                // Trigger the mounted event
                // TODO: Trigger Mounted function for all children - Dispatcher.dispatchEventForAllChildren itemNode widget Lifecycle.Mounted

                | WidgetCollectionItemChange.Update(index, widgetDiff) ->
                    let childNode = node.TreeContext.GetViewNode(box targetColl[index])

                    childNode.ApplyDiff(&widgetDiff)

                | WidgetCollectionItemChange.Replace(index, oldWidget, newWidget) ->
                    let prevItemNode = node.TreeContext.GetViewNode(box targetColl[index])

                    let struct (nextItemNode, view) = Helpers.createViewForWidget node newWidget

                    // Trigger the unmounted event for the old child
                    // TODO: Trigger Unmounted function for all children - Dispatcher.dispatchEventForAllChildren prevItemNode oldWidget Lifecycle.Unmounted
                    prevItemNode.Dispose()

                    // Replace the existing child in the UI tree at the index with the new one
                    targetColl[index] <- unbox view

                // Trigger the mounted event for the new child
                // TODO: Trigger Mounted function for all children - Dispatcher.dispatchEventForAllChildren nextItemNode newWidget Lifecycle.Mounted

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

        Attributes.defineWidgetCollection name applyDiff updateNode

    /// Define an attribute for EventHandler
    let inline defineEventNoArg name ([<InlineIfLambda>] getEvent: obj -> IEvent<EventHandler, EventArgs>) : SimpleScalarAttributeDefinition<unit -> unit> =
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                ScalarAttributeComparers.noCompare,
                (fun _ (newValueOpt: (unit -> unit) voption) node ->
                    match node.TryGetHandler(name) with
                    | ValueNone -> ()
                    | ValueSome handler -> handler.Dispose()

                    match newValueOpt with
                    | ValueNone -> node.RemoveHandler(name)
                    | ValueSome(fn) ->
                        let event = getEvent node.Target
                        node.SetHandler(name, event.Subscribe(fun _ -> fn())))
            )

            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }

    /// Define an attribute for EventHandler<'T>
    let inline defineEvent<'args>
        name
        ([<InlineIfLambda>] getEvent: obj -> IEvent<EventHandler<'args>, 'args>)
        : SimpleScalarAttributeDefinition<'args -> unit> =
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                ScalarAttributeComparers.noCompare,
                (fun _ (newValueOpt: ('args -> unit) voption) node ->
                    match node.TryGetHandler(name) with
                    | ValueNone -> ()
                    | ValueSome handler -> handler.Dispose()

                    match newValueOpt with
                    | ValueNone -> node.RemoveHandler(name)
                    | ValueSome(fn) ->
                        let event = getEvent node.Target
                        node.SetHandler(name, event.Subscribe(fun args -> fn args)))
            )

            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }
