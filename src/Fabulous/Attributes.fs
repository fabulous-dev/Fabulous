namespace Fabulous

module Helpers =
    let canReuseView (prevWidget: Widget) (currWidget: Widget) =
        prevWidget.Key = currWidget.Key

    let canReuse<'T when 'T: equality> (prev: 'T) (curr: 'T) =
        prev = curr

    let createViewForWidget (context: ViewTreeContext) (widget: Widget) =
        let widgetDefinition = WidgetDefinitionStore.get widget.Key
        widgetDefinition.CreateView (widget, context)

module ScalarAttributeComparers =
    let noCompare (a, b) = ScalarAttributeComparison.Different b

    let equalityCompare (a, b) =
        if a = b then
            ScalarAttributeComparison.Identical
        else
            ScalarAttributeComparison.Different b

module Attributes =
    /// Define a custom attribute storing any value
    let defineScalarWithConverter<'inputType, 'modelType> name defaultWith (convert: 'inputType -> 'modelType) (compare: 'modelType * 'modelType -> ScalarAttributeComparison) (updateTarget: 'modelType voption * obj -> unit) =
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
    let defineWidgetWithConverter name (applyDiff: WidgetDiff * obj -> unit) (updateTarget: Widget voption * obj -> unit) =
        let key = AttributeDefinitionStore.getNextKey()
        let definition: WidgetAttributeDefinition =
            { Key = key
              Name = name
              ApplyDiff = applyDiff
              UpdateTarget = updateTarget }
        AttributeDefinitionStore.set key definition
        definition
        
    /// Define a custom attribute storing a widget collection
    let defineWidgetCollectionWithConverter name (applyDiff: WidgetCollectionItemChange[] * obj -> unit) (updateTarget: Widget[] voption * obj -> unit) =
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
        let applyDiff (diff: WidgetDiff, parent) =
            let target = get parent
            let viewNode = getViewNode target
            if diff.ScalarChanges.Length > 0 then viewNode.ApplyScalarDiff(diff.ScalarChanges)
            if diff.WidgetChanges.Length > 0 then viewNode.ApplyWidgetDiff(diff.WidgetChanges)
            if diff.WidgetCollectionChanges.Length > 0 then viewNode.ApplyWidgetCollectionDiff(diff.WidgetCollectionChanges)

        let updateTarget (newValueOpt: Widget voption, target) = 
            match newValueOpt with
            | ValueNone -> set target null
            | ValueSome widget ->
                let viewNode = getViewNode target :?> ViewNode
                let view = Helpers.createViewForWidget viewNode.Context widget
                set target view

        defineWidgetWithConverter name applyDiff updateTarget
        
    /// Define an attribute storing a collection of Widget
    let defineWidgetCollection<'itemType> (getViewNode: obj -> IViewNode) name (getCollection: obj -> System.Collections.Generic.IList<'itemType>) =
        let applyDiff (diffs: WidgetCollectionItemChange[], target: obj) =
            let viewNode = getViewNode target :?> ViewNode
            let targetColl = getCollection target
        
            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Remove index ->
                    targetColl.RemoveAt(index)
                | _ -> ()
        
            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Insert (index, widget) ->
                    let view = Helpers.createViewForWidget viewNode.Context widget
                    targetColl.Insert(index, unbox view)
        
                | WidgetCollectionItemChange.Update (index, widgetDiff) ->
                    let targetItem = targetColl.[index]
                    let viewNode = getViewNode targetItem
                    if widgetDiff.ScalarChanges.Length > 0 then viewNode.ApplyScalarDiff(widgetDiff.ScalarChanges)
                    if widgetDiff.WidgetChanges.Length > 0 then viewNode.ApplyWidgetDiff(widgetDiff.WidgetChanges)
                    if widgetDiff.WidgetCollectionChanges.Length > 0 then viewNode.ApplyWidgetCollectionDiff(widgetDiff.WidgetCollectionChanges)
        
                | WidgetCollectionItemChange.Replace (index, widget) ->
                    let view = Helpers.createViewForWidget viewNode.Context widget
                    targetColl.[index] <- unbox view
        
                | _ -> ()
        
        let updateTarget (newValueOpt: Widget[] voption, target: obj) =
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
        defineScalarWithConverter<'T, 'T> name defaultValue id ScalarAttributeComparers.equalityCompare updateTarget