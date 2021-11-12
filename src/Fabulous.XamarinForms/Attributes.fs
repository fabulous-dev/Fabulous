namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms
open System

module Helpers =
    let canReuseView (prevWidget: Widget) (currWidget: Widget) =
        true

    let canReuse<'T when 'T: equality> (prev: 'T) (curr: 'T) =
        prev = curr

module AttributeDefinitions =
    /// Attribute definiton for scalar properties
    type ScalarAttributeDefinition<'inputType, 'modelType> =
        { Key: AttributeKey
          Name: string
          DefaultWith: unit -> 'modelType
          Convert: 'inputType -> 'modelType
          Compare: struct ('modelType * 'modelType) -> AttributeComparison
          UpdateTarget: struct ('modelType voption * obj) -> unit }
    
        member x.WithValue(value) =
            { Key = x.Key
    #if DEBUG
              DebugName = x.Name
    #endif
              Value = x.Convert(value) }
    
        interface IScalarAttributeDefinition with
            member x.Name = x.Name
            member x.UpdateTarget(newValueOpt, target) =
                let newValueOpt = match newValueOpt with ValueNone -> ValueNone | ValueSome v -> ValueSome (unbox<'modelType> v)
                x.UpdateTarget(struct (newValueOpt, target))
    
        interface IAttributeDefinition<'inputType, 'modelType> with
            member x.Key = x.Key
            member x.DefaultWith () = x.DefaultWith ()
            member x.CompareBoxed(a, b) =
                x.Compare(struct (unbox<'modelType> a, unbox<'modelType> b))

    /// Attribute definition for widget properties
    type WidgetAttributeDefinition =
        { Key: AttributeKey
          Name: string
          ApplyDiff: struct (AttributeChange[] * obj) -> unit
          UpdateTarget: struct (Widget voption * obj) -> unit }

        member x.WithValue(value: Widget) =
            { Key = x.Key
#if DEBUG
              DebugName = x.Name
#endif
              Value = value }

        interface IWidgetAttributeDefinition with
            member x.Name = x.Name
            member x.ApplyDiff(diff, target) =
                x.ApplyDiff(struct(diff, target))
            member x.UpdateTarget(newValueOpt, target) =
                let newValueOpt = match newValueOpt with ValueNone -> ValueNone | ValueSome v -> ValueSome (unbox<Widget> v)
                x.UpdateTarget(struct (newValueOpt, target))
                
        interface IAttributeDefinition<Widget, Widget> with
            member x.Key = x.Key
            member x.DefaultWith () = Unchecked.defaultof<Widget>
            member x.CompareBoxed(a, b) =
                let prevWidget = unbox<Widget> a
                let currWidget = unbox<Widget> b
                AttributeComparers.compareWidgets Helpers.canReuseView struct (prevWidget, currWidget)
                
    /// Attribute definition for collection properties
    type WidgetCollectionAttributeDefinition =
        { Key: AttributeKey
          Name: string
          ApplyDiff: struct (CollectionChange[] * obj) -> unit }
                
        member x.WithValue(value: seq<Widget>) =
            { Key = x.Key
#if DEBUG
              DebugName = x.Name
#endif
              Value = Array.ofSeq value }
                
        interface ICollectionAttributeDefinition with
            member x.Name = x.Name
            member x.ApplyDiff(diff, target) =
                x.ApplyDiff(struct(diff, target))
                                
        interface IAttributeDefinition<seq<Widget>, Widget array> with
            member x.Key = x.Key
            member x.DefaultWith () = Array.empty
            member x.CompareBoxed(a, b) =
                let prevWidget = unbox<Widget array> a
                let currWidget = unbox<Widget array> b
                AttributeComparers.compareCollections Helpers.canReuse struct (prevWidget, currWidget)


module Attributes =
    open AttributeDefinitions

    /// Define a custom attribute storing any value
    let defineScalarWithConverter<'inputType, 'modelType> name defaultWith (convert: 'inputType -> 'modelType) (compare: struct ('modelType * 'modelType) -> AttributeComparison) (updateTarget: struct ('modelType voption * obj) -> unit) =
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

    /// Define a custom attribute storing a widget
    let defineWidgetWithConverter name (applyDiff: struct (AttributeChange[] * obj) -> unit) (updateTarget: struct (Widget voption * obj) -> unit) =
        let key = AttributeDefinitionStore.getNextKey()
        let definition =
            { Key = key
              Name = name
              ApplyDiff = applyDiff
              UpdateTarget = updateTarget }
        AttributeDefinitionStore.set key definition
        definition
        
    /// Define a custom attribute storing a widget collection
    let defineWidgetCollectionWithConverter name (applyDiff: struct (CollectionChange[] * obj) -> unit) =
        let key = AttributeDefinitionStore.getNextKey()
        let definition =
            { Key = key
              Name = name
              ApplyDiff = applyDiff }
        AttributeDefinitionStore.set key definition
        definition

    /// Define an attribute storing a Widget for a CLR property
    let defineWidget name get set =
        let applyDiff struct (diff, parent) =
            let target = get parent
            let viewNode = ViewNode.getViewNode target
            viewNode.ApplyDiff(diff) |> ignore

        let updateTarget struct (newValueOpt: Widget voption, target) = 
            match newValueOpt with
            | ValueNone -> set target null
            | ValueSome widget ->
                let viewNode = ViewNode.getViewNode target :?> ViewNode
                let widgetDefinition = WidgetDefinitionStore.get widget.Key
                let view = widgetDefinition.CreateView (widget, viewNode.Context)
                set target view

        defineWidgetWithConverter name applyDiff updateTarget

    /// Define an attribute storing a Widget for a bindable property
    let inline defineBindableWidget (bindableProperty: BindableProperty) =
        defineWidget
            bindableProperty.PropertyName
            (fun parent -> (parent :?> BindableObject).GetValue(bindableProperty))
            (fun target value ->
                let bindableObject = target :?> BindableObject
                if value = null then
                    bindableObject.ClearValue(bindableProperty)
                else
                    bindableObject.SetValue(bindableProperty, value)
            )

    /// Define an attribute storing a collection of Widget
    let defineWidgetCollection<'itemType> name (getCollection: obj -> System.Collections.Generic.IList<'itemType>) =
        let applyDiff struct(diff: CollectionChange[], target: obj) =
            let viewNode = ViewNode.getViewNode target :?> ViewNode
            let targetColl = getCollection target

            for change in diff do
                match change with
                | CollectionChange.Remove index ->
                    targetColl.RemoveAt(index)
                | _ -> ()

            for change in diff do
                match change with
                | CollectionChange.InsertWidget (index, widget) ->
                    let widgetDefinition = WidgetDefinitionStore.get widget.Key
                    let view = widgetDefinition.CreateView (widget, viewNode.Context)
                    targetColl.Insert(index, unbox view)

                | CollectionChange.UpdateWidget (index, changes) ->
                    let targetItem = targetColl.[index]
                    let viewNode = ViewNode.getViewNode targetItem
                    viewNode.ApplyDiff(changes)

                | CollectionChange.ReplaceWidget (index, widget) ->
                    let widgetDefinition = WidgetDefinitionStore.get widget.Key
                    let view = widgetDefinition.CreateView (widget, viewNode.Context)
                    targetColl.[index] <- unbox view

                | _ -> ()

        defineWidgetCollectionWithConverter name applyDiff

    let defineCollection<'elementType> name (canReuse: 'elementType -> 'elementType -> bool) (updateTarget: struct ('elementType array voption * obj) -> unit) =
        defineScalarWithConverter<'elementType seq, 'elementType array> name (fun () -> Array.empty) Seq.toArray (AttributeComparers.compareCollections canReuse) updateTarget

    let inline define<'T when 'T: equality> name defaultValue updateTarget =
        defineScalarWithConverter<'T, 'T> name defaultValue id AttributeComparers.equalityCompare updateTarget

    let defineBindableWithComparer<'inputType, 'modelType> (bindableProperty: Xamarin.Forms.BindableProperty) (convert: 'inputType -> 'modelType) (compare: struct ('modelType * 'modelType) -> AttributeComparison) =
        defineScalarWithConverter<'inputType, 'modelType>
            bindableProperty.PropertyName
            (fun () -> Unchecked.defaultof<'modelType>)
            convert
            compare
            (fun struct (newValueOpt, target) ->
                match newValueOpt with
                | ValueNone -> (target :?> BindableObject).ClearValue(bindableProperty)
                | ValueSome v -> (target :?> BindableObject).SetValue(bindableProperty, v)
            )

    let inline defineBindable<'T when 'T: equality> bindableProperty =
        defineBindableWithComparer<'T, 'T> bindableProperty id AttributeComparers.equalityCompare

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
