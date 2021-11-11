namespace Fabulous.XamarinForms

open Fabulous
open Fabulous.Attributes
open Xamarin.Forms
open System

module XamarinFormsAttributeComparers =
    let widgetComparer (struct (prev: Widget, curr: Widget)) =
        AttributeComparison.Different (ValueSome (box curr))

module XamarinFormsAttributes =
    let defineWithConverter<'inputType, 'modelType> name defaultWith (convert: 'inputType -> 'modelType) (compare: struct ('modelType * 'modelType) -> AttributeComparison) (updateTarget: struct ('modelType voption * obj) -> unit) =
        let key = AttributeDefinitionStore.getNextKey()
        let definition =
            { Key = key
              Name = name
              DefaultWith = defaultWith
              Convert = convert
              Compare = compare
              UpdateTarget = updateTarget }
        AttributeDefinitionStore.set key definition
        definition

    let defineCollection<'elementType> name (updateTarget: struct ('elementType array voption * obj) -> unit) =
        defineWithConverter<'elementType seq, 'elementType array> name (fun () -> Array.empty) Seq.toArray AttributeComparers.collectionComparer updateTarget

    let defineWidgetCollection name =
        defineCollection<Widget> name ignore

    let inline define<'T when 'T: equality> name defaultValue updateTarget =
        defineWithConverter<'T, 'T> name defaultValue id AttributeComparers.equalityComparer updateTarget

    let defineBindableWithComparer<'inputType, 'modelType> (bindableProperty: Xamarin.Forms.BindableProperty) (convert: 'inputType -> 'modelType) (comparer: struct ('modelType * 'modelType) -> AttributeComparison) =
        let key = AttributeDefinitionStore.getNextKey()
        let definition =
            { Key = key
              Name = bindableProperty.PropertyName
              DefaultWith = fun () -> Unchecked.defaultof<'modelType>
              Convert = convert
              Compare = comparer
              UpdateTarget = fun struct(newValueOpt, target) ->
                match newValueOpt with
                | ValueNone -> (target :?> BindableObject).ClearValue(bindableProperty)
                | ValueSome v -> (target :?> BindableObject).SetValue(bindableProperty, v) }
        AttributeDefinitionStore.set key definition
        definition

    let inline defineBindableWidget (bindableProperty: Xamarin.Forms.BindableProperty) =
        let key = AttributeDefinitionStore.getNextKey()
        let definition =
            { Key = key
              Name = bindableProperty.PropertyName
              DefaultWith = fun () -> Unchecked.defaultof<Widget>
              Convert = id
              Compare = XamarinFormsAttributeComparers.widgetComparer
              UpdateTarget = fun struct(newValueOpt, target) ->
                match newValueOpt with
                | ValueNone -> (target :?> BindableObject).ClearValue(bindableProperty)
                | ValueSome widget ->
                    let bindableObject = (target :?> BindableObject)
                    let currValue = bindableObject.GetValue(bindableProperty)

                    if currValue = null then
                        let viewNode = ViewNode.getViewNode target :?> ViewNode
                        let widgetDefinition = WidgetDefinitionStore.get widget.Key
                        let view = widgetDefinition.CreateView (widget, viewNode.Context)
                        bindableObject.SetValue(bindableProperty, view)
                    else
                        Reconciler.update ViewNode.getViewNode currValue widget.Attributes
            }

        AttributeDefinitionStore.set key definition
        definition

    let inline defineBindable<'T when 'T: equality> bindableProperty =
        defineBindableWithComparer<'T, 'T> bindableProperty id AttributeComparers.equalityComparer

    let defineEventNoArg name (getEvent: obj -> IEvent<EventHandler, EventArgs>) =
        let key = AttributeDefinitionStore.getNextKey()
        let definition =
            { Key = key
              Name = name
              DefaultWith = fun () -> null
              Convert = id
              Compare = AttributeComparers.noCompare
              UpdateTarget = fun struct (newValueOpt, target) ->
                let event = getEvent target
                let viewNodeData = (target :?> Xamarin.Forms.BindableObject).GetValue(ViewNode.ViewNodeProperty) :?> ViewNodeData

                match viewNodeData.TryGetHandler(key) with
                | None -> ()
                | Some handler -> event.RemoveHandler handler

                match newValueOpt with
                | ValueNone ->
                    viewNodeData.SetHandler(key, ValueNone)

                | ValueSome msg ->
                    let handler = EventHandler(fun _ _ ->
                        viewNodeData.ViewNode.Context.Dispatch msg
                    )
                    event.AddHandler handler
                    viewNodeData.SetHandler(key, ValueSome handler) }
        AttributeDefinitionStore.set key definition
        definition

    let defineEvent<'args> name (getEvent: obj -> IEvent<EventHandler<'args>, 'args>) =
        let key = AttributeDefinitionStore.getNextKey()
        let definition =
            { Key = key
              Name = name
              DefaultWith = fun () -> fun _ -> null
              Convert = id
              Compare = AttributeComparers.noCompare
              UpdateTarget = fun struct (newValueOpt: ('args -> obj) voption, target) ->

                let event = getEvent target
                let viewNodeData = (target :?> Xamarin.Forms.BindableObject).GetValue(ViewNode.ViewNodeProperty) :?> ViewNodeData

                match viewNodeData.TryGetHandler(key) with
                | None ->
                    printfn $"No old handler for {name}"
                | Some handler ->
                    printfn $"Removed old handler for {name}"
                    event.RemoveHandler handler

                match newValueOpt with
                | ValueNone ->
                    viewNodeData.SetHandler(key, ValueNone)

                | ValueSome fn ->
                    let handler = EventHandler<'args>(fun sender args ->
                        printfn $"Handler for {name} triggered"
                        let viewNodeData = (sender :?> Xamarin.Forms.BindableObject).GetValue(ViewNode.ViewNodeProperty) :?> ViewNodeData
                        let r = fn args
                        viewNodeData.ViewNode.Context.Dispatch r
                    )
                    viewNodeData.SetHandler(key, ValueSome handler)
                    event.AddHandler handler
                    printfn $"Added new handler for {name}"
            }
        AttributeDefinitionStore.set key definition
        definition
