namespace Fabulous

module Helpers =
    let canReuseView (prevWidget: Widget) (currWidget: Widget) =
        prevWidget.Key = currWidget.Key

    let canReuse<'T when 'T: equality> (prev: 'T) (curr: 'T) =
        prev = curr

    let createViewForWidget (context: ViewTreeContext) (widget: Widget) =
        let widgetDefinition = WidgetDefinitionStore.get widget.Key
        widgetDefinition.CreateView (widget, context)

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
          ApplyDiff: struct (WidgetCollectionChange[] * obj) -> unit
          UpdateTarget: struct (Widget[] voption * obj) -> unit }
                
        member x.WithValue(value: seq<Widget>) =
            { Key = x.Key
#if DEBUG
              DebugName = x.Name
#endif
              Value = Array.ofSeq value }
                
        interface IWidgetCollectionAttributeDefinition with
            member x.ApplyDiff(diff, target) =
                x.ApplyDiff(struct(diff, target))
            member x.UpdateTarget(newValueOpt, target) =
                let newValueOpt = match newValueOpt with ValueNone -> ValueNone | ValueSome v -> ValueSome (unbox<Widget[]> v)
                x.UpdateTarget(struct (newValueOpt, target))
                                
        interface IAttributeDefinition<seq<Widget>, Widget array> with
            member x.Key = x.Key
            member x.DefaultWith () = Array.empty
            member x.CompareBoxed(a, b) =
                let prevWidget = unbox<Widget array> a
                let currWidget = unbox<Widget array> b
                AttributeComparers.compareWidgetCollections Helpers.canReuseView struct (prevWidget, currWidget)


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
        let definition: WidgetAttributeDefinition =
            { Key = key
              Name = name
              ApplyDiff = applyDiff
              UpdateTarget = updateTarget }
        AttributeDefinitionStore.set key definition
        definition
        
    /// Define a custom attribute storing a widget collection
    let defineWidgetCollectionWithConverter name (applyDiff: struct (WidgetCollectionChange[] * obj) -> unit) (updateTarget: struct (Widget[] voption * obj) -> unit) =
        let key = AttributeDefinitionStore.getNextKey()
        let definition: WidgetCollectionAttributeDefinition =
            { Key = key
              Name = name
              ApplyDiff = applyDiff
              UpdateTarget = updateTarget }
        AttributeDefinitionStore.set key definition
        definition

    /// Define an attribute storing a Widget for a CLR property
    let defineWidget (getViewNode: obj -> IViewNode) name get set =
        let applyDiff struct (diff, parent) =
            let target = get parent
            let viewNode = getViewNode target
            viewNode.ApplyDiff(diff) |> ignore

        let updateTarget struct (newValueOpt: Widget voption, target) = 
            match newValueOpt with
            | ValueNone -> set target null
            | ValueSome widget ->
                let viewNode = getViewNode target :?> ViewNode
                let view = Helpers.createViewForWidget viewNode.Context widget
                set target view

        defineWidgetWithConverter name applyDiff updateTarget
        
    /// Define an attribute storing a collection of Widget
    let defineWidgetCollection<'itemType> (getViewNode: obj -> IViewNode) name (getCollection: obj -> System.Collections.Generic.IList<'itemType>) =
        let applyDiff struct(diffs: WidgetCollectionChange[], target: obj) =
            let viewNode = getViewNode target :?> ViewNode
            let targetColl = getCollection target
        
            for diff in diffs do
                match diff with
                | WidgetCollectionChange.Remove index ->
                    targetColl.RemoveAt(index)
                | _ -> ()
        
            for diff in diffs do
                match diff with
                | WidgetCollectionChange.Insert (index, widget) ->
                    let view = Helpers.createViewForWidget viewNode.Context widget
                    targetColl.Insert(index, unbox view)
        
                | WidgetCollectionChange.Update (index, changes) ->
                    let targetItem = targetColl.[index]
                    let viewNode = getViewNode targetItem
                    viewNode.ApplyDiff(changes)
        
                | WidgetCollectionChange.Replace (index, widget) ->
                    let view = Helpers.createViewForWidget viewNode.Context widget
                    targetColl.[index] <- unbox view
        
                | _ -> ()
        
        let updateTarget struct(newValueOpt: Widget[] voption, target: obj) =
            let viewNode = getViewNode target :?> ViewNode
            let targetColl = getCollection target
            targetColl.Clear()
        
            match newValueOpt with
            | ValueNone -> ()
            | ValueSome widgets ->
                for widget in widgets do
                    let view = Helpers.createViewForWidget viewNode.Context widget
                    targetColl.Add(unbox view)
        
        defineWidgetCollectionWithConverter name applyDiff updateTarget
        
    let inline define<'T when 'T: equality> name defaultValue updateTarget =
        defineScalarWithConverter<'T, 'T> name defaultValue id AttributeComparers.equalityCompare updateTarget