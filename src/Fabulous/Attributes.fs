namespace Fabulous

open System
open Fabulous

module Helpers =
    let canReuse<'T when 'T: equality> (prev: 'T) (curr: 'T) = prev = curr

    let inline createViewForWidget (parent: IViewNode) (widget: Widget) =
        let widgetDefinition = WidgetDefinitionStore.get widget.Key

        let struct (_node, view) =
            widgetDefinition.CreateView(widget, parent.TreeContext, ValueSome parent)

        view

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
        (updateNode: 'valueType voption -> IViewNode -> unit)
        =
        let key = AttributeDefinitionStore.getNextKey ()

        let definition =
            { Key = key
              Name = name
              Convert = convert
              ConvertValue = convertValue
              Compare = compare
              UpdateNode = updateNode }

        AttributeDefinitionStore.set key definition
        definition

    /// Define a custom attribute storing a widget
    let defineWidgetWithConverter
        name
        (applyDiff: WidgetDiff -> IViewNode -> unit)
        (updateNode: Widget voption -> IViewNode -> unit)
        =
        let key = AttributeDefinitionStore.getNextKey ()

        let definition: WidgetAttributeDefinition =
            { Key = key
              Name = name
              ApplyDiff = applyDiff
              UpdateNode = updateNode }

        AttributeDefinitionStore.set key definition
        definition

    /// Define a custom attribute storing a widget collection
    let defineWidgetCollectionWithConverter
        name
        (applyDiff: WidgetCollectionItemChanges -> IViewNode -> unit)
        (updateNode: ArraySlice<Widget> voption -> IViewNode -> unit)
        =
        let key = AttributeDefinitionStore.getNextKey ()

        let definition: WidgetCollectionAttributeDefinition =
            { Key = key
              Name = name
              ApplyDiff = applyDiff
              UpdateNode = updateNode }

        AttributeDefinitionStore.set key definition
        definition

    /// Define an attribute storing a Widget for a CLR property
    let defineWidget<'T when 'T: null> (name: string) (get: obj -> IViewNode) (set: obj -> 'T -> unit) =
        let applyDiff (diff: WidgetDiff) (node: IViewNode) =
            let childNode = get node.Target

            childNode.ApplyDiff(&diff)


        let updateNode (newValueOpt: Widget voption) (node: IViewNode) =
            match newValueOpt with
            | ValueNone -> set node.Target null
            | ValueSome widget ->
                let view =
                    Helpers.createViewForWidget node widget |> unbox

                set node.Target view

        defineWidgetWithConverter name applyDiff updateNode

    /// Define an attribute storing a collection of Widget
    let defineWidgetCollection<'itemType> name (getCollection: obj -> System.Collections.Generic.IList<'itemType>) =
        let applyDiff (diffs: WidgetCollectionItemChanges) (node: IViewNode) =
            let targetColl = getCollection node.Target

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Remove index -> targetColl.RemoveAt(index)
                | _ -> ()

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Insert (index, widget) ->
                    let view = Helpers.createViewForWidget node widget
                    targetColl.Insert(index, unbox view)

                | WidgetCollectionItemChange.Update (index, widgetDiff) ->
                    let childNode =
                        node.TreeContext.GetViewNode(box targetColl.[index])

                    childNode.ApplyDiff(&widgetDiff)

                | WidgetCollectionItemChange.Replace (index, widget) ->
                    let view = Helpers.createViewForWidget node widget
                    targetColl.[index] <- unbox view

                | _ -> ()

        let updateNode (newValueOpt: ArraySlice<Widget> voption) (node: IViewNode) =
            let targetColl = getCollection node.Target
            targetColl.Clear()

            match newValueOpt with
            | ValueNone -> ()
            | ValueSome widgets ->
                for widget in ArraySlice.toSpan widgets do
                    let view = Helpers.createViewForWidget node widget
                    targetColl.Add(unbox view)

        defineWidgetCollectionWithConverter name applyDiff updateNode

    let inline define<'T when 'T: equality> name updateTarget =
        defineScalarWithConverter<'T, 'T, 'T> name id id ScalarAttributeComparers.equalityCompare updateTarget

    let dispatchMsgOnViewNode (node: IViewNode) msg =
        let mutable parentOpt = node.Parent

        let mutable mapMsg =
            match node.MapMsg with
            | ValueNone -> id
            | ValueSome fn -> fn

        while parentOpt.IsSome do
            let parent = parentOpt.Value
            parentOpt <- parent.Parent

            mapMsg <-
                match parent.MapMsg with
                | ValueNone -> mapMsg
                | ValueSome fn -> mapMsg >> fn

        let newMsg = mapMsg msg
        node.TreeContext.Dispatch(newMsg)

    let defineEventNoArg name (getEvent: obj -> IEvent<EventHandler, EventArgs>) =
        let key = AttributeDefinitionStore.getNextKey ()

        let definition: ScalarAttributeDefinition<obj, obj, obj> =
            { Key = key
              Name = name
              Convert = id
              ConvertValue = id
              Compare = ScalarAttributeComparers.noCompare
              UpdateNode =
                  fun newValueOpt node ->
                      let event = getEvent node.Target

                      match node.TryGetHandler(key) with
                      | ValueNone -> ()
                      | ValueSome handler -> event.RemoveHandler handler

                      match newValueOpt with
                      | ValueNone -> node.SetHandler(key, ValueNone)

                      | ValueSome msg ->
                          let handler =
                              EventHandler(fun _ _ -> dispatchMsgOnViewNode node msg)

                          event.AddHandler handler
                          node.SetHandler(key, ValueSome handler) }

        AttributeDefinitionStore.set key definition
        definition

    let defineEventWithAdditionalStep name (getEvent: obj -> IEvent<EventHandler, EventArgs>) =
        let key = AttributeDefinitionStore.getNextKey ()

        let definition: ScalarAttributeDefinition<_, _, _> =
            { Key = key
              Name = name
              Convert = id
              ConvertValue = id
              Compare = ScalarAttributeComparers.noCompare
              UpdateNode =
                  fun (newValueOpt: (obj -> obj) voption) node ->
                      let event = getEvent node.Target

                      match node.TryGetHandler(key) with
                      | ValueNone -> ()
                      | ValueSome handler -> event.RemoveHandler handler

                      match newValueOpt with
                      | ValueNone -> node.SetHandler(key, ValueNone)
                      | ValueSome fn ->
                          let handler =
                              EventHandler
                                  (fun sender _ ->
                                      printfn $"Handler for {name} triggered"
                                      let r = fn sender
                                      dispatchMsgOnViewNode node r)

                          node.SetHandler(key, ValueSome handler)
                          event.AddHandler handler
                          printfn $"Added new handler for {name}" }

        AttributeDefinitionStore.set key definition
        definition


    let defineEvent<'args> name (getEvent: obj -> IEvent<EventHandler<'args>, 'args>) =
        let key = AttributeDefinitionStore.getNextKey ()

        let definition: ScalarAttributeDefinition<_, _, _> =
            { Key = key
              Name = name
              Convert = id
              ConvertValue = id
              Compare = ScalarAttributeComparers.noCompare
              UpdateNode =
                  fun (newValueOpt: ('args -> obj) voption) (node: IViewNode) ->
                      let event = getEvent node.Target

                      match node.TryGetHandler(key) with
                      | ValueNone -> printfn $"No old handler for {name}"
                      | ValueSome handler ->
                          printfn $"Removed old handler for {name}"
                          event.RemoveHandler handler

                      match newValueOpt with
                      | ValueNone -> node.SetHandler(key, ValueNone)

                      | ValueSome fn ->
                          let handler =
                              EventHandler<'args>
                                  (fun _ args ->
                                      printfn $"Handler for {name} triggered"
                                      let r = fn args
                                      dispatchMsgOnViewNode node r)

                          node.SetHandler(key, ValueSome handler)
                          event.AddHandler handler
                          printfn $"Added new handler for {name}" }

        AttributeDefinitionStore.set key definition
        definition
