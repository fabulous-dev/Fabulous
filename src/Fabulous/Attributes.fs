namespace Fabulous

open System
open Fabulous

module Helpers =
    let canReuseView (prevWidget: Widget) (currWidget: Widget) = prevWidget.Key = currWidget.Key

    let canReuse<'T when 'T: equality> (prev: 'T) (curr: 'T) = prev = curr

    let inline createViewForWidget (parent: IViewNode) (widget: Widget) =
        let widgetDefinition = WidgetDefinitionStore.get widget.Key

        let context =
            { Key = widget.Key
              ViewTreeContext = parent.Context.ViewTreeContext
              Ancestors = parent :: parent.Context.Ancestors }

        widgetDefinition.CreateView(widget, context)

module ScalarAttributeComparers =
    let noCompare (_, b) = ScalarAttributeComparison.Different b

    let equalityCompare (a, b) =
        if a = b then
            ScalarAttributeComparison.Identical
        else
            ScalarAttributeComparison.Different b

module Attributes =
    /// Define a custom attribute storing any value
    let defineScalarWithConverter<'inputType, 'modelType>
        name
        (convert: 'inputType -> 'modelType)
        (compare: 'modelType * 'modelType -> ScalarAttributeComparison)
        (updateTarget: 'modelType voption * ViewNodeContext * obj -> unit)
        =
        let key = AttributeDefinitionStore.getNextKey()

        let definition =
            {
                Key = key
                Name = name
                Convert = convert
                Compare = compare
                UpdateTarget = updateTarget
            }

        AttributeDefinitionStore.set key definition
        definition

    /// Define a custom attribute storing a widget
    let defineWidgetWithConverter
        name
        (applyDiff: WidgetDiff * ViewNodeContext * obj -> unit)
        (updateTarget: Widget voption * ViewNodeContext * obj -> unit)
        =
        let key = AttributeDefinitionStore.getNextKey()

        let definition: WidgetAttributeDefinition =
            {
                Key = key
                Name = name
                ApplyDiff = applyDiff
                UpdateTarget = updateTarget
            }

        AttributeDefinitionStore.set key definition
        definition

    /// Define a custom attribute storing a widget collection
    let defineWidgetCollectionWithConverter
        name
        (applyDiff: WidgetCollectionItemChange [] * ViewNodeContext * obj -> unit)
        (updateTarget: Widget [] voption * ViewNodeContext * obj -> unit)
        =
        let key = AttributeDefinitionStore.getNextKey()

        let definition: WidgetCollectionAttributeDefinition =
            {
                Key = key
                Name = name
                ApplyDiff = applyDiff
                UpdateTarget = updateTarget
            }

        AttributeDefinitionStore.set key definition
        definition

    /// Define an attribute storing a Widget for a CLR property
    let defineWidget<'T when 'T : null> (name: string) (get: obj -> 'T) (set: obj -> 'T -> unit) =
        let applyDiff (diff: WidgetDiff, context: ViewNodeContext, parent) =
            let target = get parent
            let viewNode = context.ViewTreeContext.GetViewNode(box target)

            if diff.ScalarChanges.Length > 0 then
                viewNode.ApplyScalarDiff(diff.ScalarChanges)

            if diff.WidgetChanges.Length > 0 then
                viewNode.ApplyWidgetDiff(diff.WidgetChanges)

            if diff.WidgetCollectionChanges.Length > 0 then
                viewNode.ApplyWidgetCollectionDiff(diff.WidgetCollectionChanges)

        let updateTarget (newValueOpt: Widget voption, context, target) =
            match newValueOpt with
            | ValueNone -> set target null
            | ValueSome widget ->
                let viewNode = context.ViewTreeContext.GetViewNode(target)
                let view = Helpers.createViewForWidget viewNode widget |> unbox
                set target view

        defineWidgetWithConverter name applyDiff updateTarget

    /// Define an attribute storing a collection of Widget
    let defineWidgetCollection<'itemType>
        name
        (getCollection: obj -> System.Collections.Generic.IList<'itemType>)
        =
        let applyDiff (diffs: WidgetCollectionItemChange [], context: ViewNodeContext, target: obj) =
            let viewNode = context.ViewTreeContext.GetViewNode(target)
            let targetColl = getCollection target

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Remove index -> targetColl.RemoveAt(index)
                | _ -> ()

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Insert (index, widget) ->
                    let view = Helpers.createViewForWidget viewNode widget
                    targetColl.Insert(index, unbox view)

                | WidgetCollectionItemChange.Update (index, widgetDiff) ->
                    let targetItem = targetColl.[index]
                    let viewNode = context.ViewTreeContext.GetViewNode(box targetItem)

                    if widgetDiff.ScalarChanges.Length > 0 then
                        viewNode.ApplyScalarDiff(widgetDiff.ScalarChanges)

                    if widgetDiff.WidgetChanges.Length > 0 then
                        viewNode.ApplyWidgetDiff(widgetDiff.WidgetChanges)

                    if widgetDiff.WidgetCollectionChanges.Length > 0 then
                        viewNode.ApplyWidgetCollectionDiff(widgetDiff.WidgetCollectionChanges)

                | WidgetCollectionItemChange.Replace (index, widget) ->                      
                    let view = Helpers.createViewForWidget viewNode widget
                    targetColl.[index] <- unbox view

                | _ -> ()

        let updateTarget (newValueOpt: Widget [] voption, context: ViewNodeContext, target: obj) =
            let targetColl = getCollection target
            targetColl.Clear()

            match newValueOpt with
            | ValueNone -> ()
            | ValueSome widgets ->
                let viewNode = context.ViewTreeContext.GetViewNode(target)
                
                for widget in widgets do
                    let view = Helpers.createViewForWidget viewNode widget
                    targetColl.Add(unbox view)

        defineWidgetCollectionWithConverter name applyDiff updateTarget

    let inline define<'T when 'T: equality> name updateTarget =
        defineScalarWithConverter<'T, 'T> name id ScalarAttributeComparers.equalityCompare updateTarget

    let dispatchMsgOnViewNode (viewNode: IViewNode) msg =
        let mutable mapMsg = viewNode.MapMsg
        let mutable canPropagate = viewNode.CanPropagateEvents

        for ancestor in viewNode.Context.Ancestors do
            mapMsg <- ancestor.MapMsg >> mapMsg
            canPropagate <- ancestor.CanPropagateEvents && canPropagate

        if canPropagate then
            viewNode.Context.ViewTreeContext.Dispatch(mapMsg msg)

    let defineEventNoArg name (getEvent: obj -> IEvent<EventHandler, EventArgs>) =
        let key = AttributeDefinitionStore.getNextKey()

        let definition: ScalarAttributeDefinition<obj, obj> =
            {
                Key = key
                Name = name
                Convert = id
                Compare = ScalarAttributeComparers.noCompare
                UpdateTarget =
                    fun (newValueOpt, context, target) ->
                        let event = getEvent target
                        let viewNode = context.ViewTreeContext.GetViewNode(target)
                        
                        match viewNode.TryGetHandler(key) with
                        | ValueNone -> ()
                        | ValueSome handler -> event.RemoveHandler handler

                        match newValueOpt with
                        | ValueNone -> viewNode.SetHandler(key, ValueNone)

                        | ValueSome msg ->
                            let handler =
                                EventHandler(fun _ _ -> dispatchMsgOnViewNode viewNode msg)

                            event.AddHandler handler
                            viewNode.SetHandler(key, ValueSome handler)
            }

        AttributeDefinitionStore.set key definition
        definition

    let defineEvent<'args> name (getEvent: obj -> IEvent<EventHandler<'args>, 'args>) =
        let key = AttributeDefinitionStore.getNextKey()

        let definition: ScalarAttributeDefinition<_, _> =
            {
                Key = key
                Name = name
                Convert = id
                Compare = ScalarAttributeComparers.noCompare
                UpdateTarget =
                    fun (newValueOpt: ('args -> obj) voption, context, target) ->
                        let event = getEvent target
                        let viewNode = context.ViewTreeContext.GetViewNode(target)

                        match viewNode.TryGetHandler(key) with
                        | ValueNone -> printfn $"No old handler for {name}"
                        | ValueSome handler ->
                            printfn $"Removed old handler for {name}"
                            event.RemoveHandler handler

                        match newValueOpt with
                        | ValueNone -> viewNode.SetHandler(key, ValueNone)

                        | ValueSome fn ->
                            let handler =
                                EventHandler<'args>
                                    (fun _ args ->
                                        printfn $"Handler for {name} triggered"
                                        let r = fn args
                                        dispatchMsgOnViewNode viewNode r)

                            viewNode.SetHandler(key, ValueSome handler)
                            event.AddHandler handler
                            printfn $"Added new handler for {name}"
            }

        AttributeDefinitionStore.set key definition
        definition


    let MapMsg =
        defineScalarWithConverter<obj -> obj, _> "Fabulous_MapMsg" id ScalarAttributeComparers.noCompare (fun (value, context, target) ->
            let mapMsg = match value with ValueNone -> id | ValueSome fn -> fn
            let viewNode = context.ViewTreeContext.GetViewNode(target)
            viewNode.SetMapMsg(mapMsg)
        )
