namespace Fabulous

open System
open System.Runtime.CompilerServices
open Fabulous

module Helpers =
    let canReuseView (prevWidget: Widget) (currWidget: Widget) = prevWidget.Key = currWidget.Key

    let canReuse<'T when 'T: equality> (prev: 'T) (curr: 'T) = prev = curr

    let inline createViewForWidget (parent: IViewNode) (widget: Widget) =
        let widgetDefinition = WidgetDefinitionStore.get widget.Key

        let context: ViewTreeContext =
            { parent.Context with
                Ancestors = parent :: parent.Context.Ancestors
            }

        widgetDefinition.CreateView(widget, context)

module ScalarAttributeComparers =
    let noCompare (a, b) = ScalarAttributeComparison.Different b

    let equalityCompare (a, b) =
        if a = b then
            ScalarAttributeComparison.Identical
        else
            ScalarAttributeComparison.Different b

module Attributes =
    [<Struct>]
    type AttributesBuilder
        (
            scalarAttributes: ScalarAttribute [],
            widgetAttributes: WidgetAttribute [],
            widgetCollectionAttributes: WidgetCollectionAttribute []
        ) =
        member x.AddScalar(attr: ScalarAttribute) =
            let attribs = scalarAttributes

            let attribs2 =
                Array.zeroCreate(scalarAttributes.Length + 1)

            Array.blit scalarAttributes 0 attribs2 0 scalarAttributes.Length
            attribs2.[scalarAttributes.Length] <- attr
            AttributesBuilder(attribs2, widgetAttributes, widgetCollectionAttributes)

        member x.AddWidget(attr: WidgetAttribute) =
            let attribs = widgetAttributes

            let attribs2 =
                Array.zeroCreate(widgetAttributes.Length + 1)

            Array.blit widgetAttributes 0 attribs2 0 widgetAttributes.Length
            attribs2.[widgetAttributes.Length] <- attr
            AttributesBuilder(scalarAttributes, attribs2, widgetCollectionAttributes)

        member x.AddWidgetCollection(attr: WidgetCollectionAttribute) =
            let attribs = widgetCollectionAttributes

            let attribs2 =
                Array.zeroCreate(widgetCollectionAttributes.Length + 1)

            Array.blit widgetCollectionAttributes 0 attribs2 0 widgetCollectionAttributes.Length
            attribs2.[widgetCollectionAttributes.Length] <- attr
            AttributesBuilder(scalarAttributes, widgetAttributes, attribs2)

        member x.AddScalars(attrs: ScalarAttribute []) = x
        member x.AddWidgets(attrs: WidgetAttribute []) = x
        member x.AddWidgetCollections(attrs: WidgetCollectionAttribute []) = x

        member x.TryGetScalar(key: AttributeKey) =
            scalarAttributes
            |> Array.tryFind(fun attr -> attr.Key = key)

        member x.Build(key) =
            {
                Key = key
                ScalarAttributes = scalarAttributes
                WidgetAttributes = widgetAttributes
                WidgetCollectionAttributes = widgetCollectionAttributes
            }

    /// Define a custom attribute storing any value
    let defineScalarWithConverter<'inputType, 'modelType>
        name
        (convert: 'inputType -> 'modelType)
        (compare: 'modelType * 'modelType -> ScalarAttributeComparison)
        (updateTarget: 'modelType voption * IViewNode * obj -> unit)
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
        (applyDiff: WidgetDiff * obj -> unit)
        (updateTarget: Widget voption * IViewNode * obj -> unit)
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
        (applyDiff: WidgetCollectionItemChange [] * obj -> unit)
        (updateTarget: Widget [] voption * IViewNode * obj -> unit)
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
    let defineWidget (getViewNode: obj -> IViewNode) name get set =
        let applyDiff (diff: WidgetDiff, parent) =
            let target = get parent
            let viewNode = getViewNode target

            if diff.ScalarChanges.Length > 0 then
                viewNode.ApplyScalarDiff(diff.ScalarChanges)

            if diff.WidgetChanges.Length > 0 then
                viewNode.ApplyWidgetDiff(diff.WidgetChanges)

            if diff.WidgetCollectionChanges.Length > 0 then
                viewNode.ApplyWidgetCollectionDiff(diff.WidgetCollectionChanges)

        let updateTarget (newValueOpt: Widget voption, viewNode: IViewNode, target) =
            match newValueOpt with
            | ValueNone -> set target null
            | ValueSome widget ->
                let view =
                    Helpers.createViewForWidget viewNode widget

                set target view

        defineWidgetWithConverter name applyDiff updateTarget

    /// Define an attribute storing a collection of Widget
    let defineWidgetCollection<'itemType>
        (getViewNode: obj -> IViewNode)
        name
        (getCollection: obj -> System.Collections.Generic.IList<'itemType>)
        =
        let applyDiff (diffs: WidgetCollectionItemChange [], target: obj) =
            let viewNode = getViewNode target
            let targetColl = getCollection target

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Remove index -> targetColl.RemoveAt(index)
                | _ -> ()

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Insert (index, widget) ->
                    let view =
                        Helpers.createViewForWidget viewNode widget

                    targetColl.Insert(index, unbox view)

                | WidgetCollectionItemChange.Update (index, widgetDiff) ->
                    let targetItem = targetColl.[index]
                    let viewNode = getViewNode targetItem

                    if widgetDiff.ScalarChanges.Length > 0 then
                        viewNode.ApplyScalarDiff(widgetDiff.ScalarChanges)

                    if widgetDiff.WidgetChanges.Length > 0 then
                        viewNode.ApplyWidgetDiff(widgetDiff.WidgetChanges)

                    if widgetDiff.WidgetCollectionChanges.Length > 0 then
                        viewNode.ApplyWidgetCollectionDiff(widgetDiff.WidgetCollectionChanges)

                | WidgetCollectionItemChange.Replace (index, widget) ->
                    let view =
                        Helpers.createViewForWidget viewNode widget

                    targetColl.[index] <- unbox view

                | _ -> ()

        let updateTarget (newValueOpt: Widget [] voption, viewNode: IViewNode, target: obj) =
            let targetColl = getCollection target
            targetColl.Clear()

            match newValueOpt with
            | ValueNone -> ()
            | ValueSome widgets ->
                for widget in widgets do
                    let view =
                        Helpers.createViewForWidget viewNode widget

                    targetColl.Add(unbox view)

        defineWidgetCollectionWithConverter name applyDiff updateTarget

    let inline define<'T when 'T: equality> name updateTarget =
        defineScalarWithConverter<'T, 'T> name id ScalarAttributeComparers.equalityCompare updateTarget

    let dispatchMsgOnViewNode (viewNode: IViewNode) msg =
        let inline mapMsg (node: IViewNode) (m: obj) =
            match node.MapMsg with
            | ValueNone -> m
            | ValueSome fn -> fn m

        let mutable msgToDispatch = mapMsg viewNode msg

        let treeContext = viewNode.Context

        for ancestor in treeContext.Ancestors do
            msgToDispatch <- mapMsg ancestor msgToDispatch

        treeContext.Dispatch(msgToDispatch)

    let defineEventNoArg name (getEvent: obj -> IEvent<EventHandler, EventArgs>) =
        let key = AttributeDefinitionStore.getNextKey()

        let definition: ScalarAttributeDefinition<obj, obj> =
            {
                Key = key
                Name = name
                Convert = id
                Compare = ScalarAttributeComparers.noCompare
                UpdateTarget =
                    fun (newValueOpt, viewNode, target) ->
                        let event = getEvent target

                        match viewNode.TryGetHandler(key) with
                        | None -> ()
                        | Some handler -> event.RemoveHandler handler

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
                    fun (newValueOpt: ('args -> obj) voption, viewNode, target) ->

                        let event = getEvent target

                        match viewNode.TryGetHandler(key) with
                        | None -> printfn $"No old handler for {name}"
                        | Some handler ->
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
        defineScalarWithConverter<obj -> obj, _>
            "Fabulous_MapMsg"
            id
            ScalarAttributeComparers.noCompare
            (fun (value, node, _target) -> node.MapMsg <- value)

[<Extension>]
type WidgetExtensions() =
    [<Extension>]
    static member inline AddScalarAttribute(this: ^T, attr: ScalarAttribute) =
        let builder =
            (^T: (member Builder : Attributes.AttributesBuilder) this)

        let newBuilder = builder.AddScalar(attr)

        let result =
            (^T: (new : Attributes.AttributesBuilder -> ^T) newBuilder)

        result

    [<Extension>]
    static member inline AddScalarAttributes(this: ^T, attrs: ScalarAttribute []) =
        match attrs with
        | [||] -> this
        | attributes ->
            let builder =
                (^T: (member Builder : Attributes.AttributesBuilder) this)

            let newBuilder = builder.AddScalars(attrs)

            let result =
                (^T: (new : Attributes.AttributesBuilder -> ^T) newBuilder)

            result

    [<Extension>]
    static member inline AddWidgetCollectionAttribute(this: ^T, attr: WidgetCollectionAttribute) =
        let builder =
            (^T: (member Builder : Attributes.AttributesBuilder) this)

        let newBuilder = builder.AddWidgetCollection(attr)

        let result =
            (^T: (new : Attributes.AttributesBuilder -> ^T) newBuilder)

        result
