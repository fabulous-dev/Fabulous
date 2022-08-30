namespace Fabulous.Maui

open System.Collections.Generic
open Fabulous
open Fabulous.ScalarAttributeDefinitions
open Fabulous.WidgetAttributeDefinitions
open Fabulous.WidgetCollectionAttributeDefinitions
open Microsoft.Maui

module Helpers =
    let createViewForWidget (node: IViewNode) (widget: Widget) =
        let struct (childNode, childView) = Fabulous.Helpers.createViewForWidget node widget
        (childView :?> Node).Attributes.ScalarAttributes <- ValueOption.defaultValue [||] widget.ScalarAttributes
        struct (childNode, childView)

module Attributes =
    let defineMauiScalar<'T>
        name
        (compare: 'T -> 'T -> ScalarAttributeComparison)
        : SimpleScalarAttributeDefinition<'T> =
            
        let updateNode _ _ (node: IViewNode) =
            let handler = (node.Target :?> IElement).Handler
            handler.UpdateValue(name)
        
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(compare, updateNode)
            |> AttributeDefinitionStore.registerScalar
            
        { Key = key; Name = name }
        
    let defineMauiScalar2<'T when 'T: equality>
        name
        : SimpleScalarAttributeDefinition<'T> =
            
        let updateNode _ _ (node: IViewNode) =
            let target = node.Target :?> IView
            let handler = target.Handler
            
            handler.UpdateValue(name)
            target.InvalidateMeasure()
        
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(ScalarAttributeComparers.equalityCompare, updateNode)
            |> AttributeDefinitionStore.registerScalar
            
        { Key = key; Name = name }
        
    let inline defineMauiScalarWithEquality<'T when 'T: equality>
        name
        : SimpleScalarAttributeDefinition<'T> =
            defineMauiScalar name ScalarAttributeComparers.equalityCompare
            
    let inline defineMauiEvent<'args>
        name
        : SimpleScalarAttributeDefinition<'args -> obj> =
            
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(ScalarAttributeComparers.noCompare, (fun _ _ _ -> ()))
            |> AttributeDefinitionStore.registerScalar
            
        { Key = key; Name = name }
        
    let inline defineMauiEventNoArgs name =
        defineMauiEvent<unit> name
        
    let inline defineMauiWidget name (get: obj -> obj): WidgetAttributeDefinition =
        let applyDiff (next: Widget) (diff: WidgetDiff) (node: IViewNode) =
            let childView = get node.Target :?> Node
            childView.Attributes.ScalarAttributes <- ValueOption.defaultValue [||] next.ScalarAttributes
            
            let childNode = node.TreeContext.GetViewNode(childView)
            childNode.ApplyDiff(&diff)
        
        let updateNode _ (newValueOpt: Widget voption) (node: IViewNode) =
            let targetNode = node.Target :?> Node
                
            match newValueOpt with
            | ValueNone ->
                targetNode.Attributes.Widgets.Remove(name) |> ignore
                
            | ValueSome widget ->
                let struct (_, view) = Helpers.createViewForWidget node widget
                targetNode.Attributes.Widgets[name] <- view
            
            let handler = (node.Target :?> IElement).Handler
            handler.UpdateValue(name)
        
        let key =
            AttributeDefinitionStore.registerWidget
                { ApplyDiff = applyDiff
                  UpdateNode = updateNode }
                
        { Key = key; Name = name }
        
    let defineMauiWidgetCollection name: WidgetCollectionAttributeDefinition =
        let applyDiff _ (diffs: WidgetCollectionItemChanges) (node: IViewNode) =
            let targetNode = node.Target :?> Node
            let targetColl =
                if targetNode.Attributes.WidgetCollections.ContainsKey(name) then
                    targetNode.Attributes.WidgetCollections[name]
                else
                    let lst = List<obj>()
                    targetNode.Attributes.WidgetCollections[name] <- lst
                    lst

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Remove (index, widget) ->
                    let itemNode =
                        node.TreeContext.GetViewNode(box targetColl.[index])

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

                | WidgetCollectionItemChange.Update (index, next, widgetDiff) ->
                    let childNode = node.TreeContext.GetViewNode(box targetColl.[index])
                    let childView = childNode.Target :?> Node
                    
                    childView.Attributes.ScalarAttributes <- ValueOption.defaultValue [||] next.ScalarAttributes
            
                    childNode.ApplyDiff(&widgetDiff)

                | WidgetCollectionItemChange.Replace (index, oldWidget, newWidget) ->
                    let prevItemNode =
                        node.TreeContext.GetViewNode(box targetColl.[index])

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
            let targetNode = node.Target :?> Node
            
            let targetColl =
                if targetNode.Attributes.WidgetCollections.ContainsKey(name) then
                    let lst = targetNode.Attributes.WidgetCollections[name]
                    lst.Clear()
                    lst
                else
                    let lst = List<obj>()
                    targetNode.Attributes.WidgetCollections[name] <- lst
                    lst
            
            match newValueOpt with
            | ValueNone -> ()
            | ValueSome widgets ->
                for widget in ArraySlice.toSpan widgets do
                    let struct (_, view) = Helpers.createViewForWidget node widget
                    targetColl.Add(view)
                    
            let handler = (node.Target :?> IElement).Handler
            handler.UpdateValue(name)
                
        let key =
            AttributeDefinitionStore.registerWidgetCollection
                { ApplyDiff = applyDiff
                  UpdateNode = updateNode }

        { Key = key; Name = name }
        
    let defineMauiWidgetCollectionLayout name: WidgetCollectionAttributeDefinition =
        let applyDiff _ (diffs: WidgetCollectionItemChanges) (node: IViewNode) =
            let targetNode = node.Target :?> NodeWithHandler
            let handler = targetNode.Handler
            let targetColl =
                if targetNode.Attributes.WidgetCollections.ContainsKey(name) then
                    targetNode.Attributes.WidgetCollections[name]
                else
                    let lst = List<obj>()
                    targetNode.Attributes.WidgetCollections[name] <- lst
                    lst

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Remove (index, widget) ->
                    let itemNode =
                        node.TreeContext.GetViewNode(box targetColl.[index])

                    // Trigger the unmounted event
                    Dispatcher.dispatchEventForAllChildren itemNode widget Lifecycle.Unmounted
                    itemNode.Disconnect()

                    // Remove the child from the UI tree
                    let removedView = targetColl[index] :?> IView
                    targetColl.RemoveAt(index)
                    handler.Invoke("Remove", Microsoft.Maui.Handlers.LayoutHandlerUpdate(index, removedView))

                | _ -> ()

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Insert (index, widget) ->
                    let struct (itemNode, view) = Helpers.createViewForWidget node widget

                    // Insert the new child into the UI tree
                    let insertedView = view :?> IView
                    targetColl.Insert(index, unbox insertedView)
                    handler.Invoke("Insert", Microsoft.Maui.Handlers.LayoutHandlerUpdate(index, insertedView))

                    // Trigger the mounted event
                    Dispatcher.dispatchEventForAllChildren itemNode widget Lifecycle.Mounted

                | WidgetCollectionItemChange.Update (index, next, widgetDiff) ->
                    let childNode = node.TreeContext.GetViewNode(box targetColl.[index])
                    let childView = childNode.Target :?> Node
                    
                    childView.Attributes.ScalarAttributes <- ValueOption.defaultValue [||] next.ScalarAttributes
            
                    childNode.ApplyDiff(&widgetDiff)

                | WidgetCollectionItemChange.Replace (index, oldWidget, newWidget) ->
                    let prevItemNode =
                        node.TreeContext.GetViewNode(box targetColl.[index])

                    let struct (nextItemNode, view) =
                        Helpers.createViewForWidget node newWidget

                    // Trigger the unmounted event for the old child
                    Dispatcher.dispatchEventForAllChildren prevItemNode oldWidget Lifecycle.Unmounted
                    prevItemNode.Disconnect()

                    // Replace the existing child in the UI tree at the index with the new one
                    let newView = view :?> IView
                    targetColl.[index] <- unbox newView
                    handler.Invoke("Update", Microsoft.Maui.Handlers.LayoutHandlerUpdate(index, newView))

                    // Trigger the mounted event for the new child
                    Dispatcher.dispatchEventForAllChildren nextItemNode newWidget Lifecycle.Mounted

                | _ -> ()
            
        let updateNode _ (newValueOpt: ArraySlice<Widget> voption) (node: IViewNode) =
            let targetNode = node.Target :?> NodeWithHandler
            let handler = targetNode.Handler
            
            let targetColl =
                if targetNode.Attributes.WidgetCollections.ContainsKey(name) then
                    let lst = targetNode.Attributes.WidgetCollections[name]
                    lst.Clear()
                    handler.Invoke("Clear")
                    lst
                else
                    let lst = List<obj>()
                    targetNode.Attributes.WidgetCollections[name] <- lst
                    lst
            
            match newValueOpt with
            | ValueNone -> ()
            | ValueSome widgets ->
                for widget in ArraySlice.toSpan widgets do
                    let struct (_, view) = Helpers.createViewForWidget node widget
                    let addedView = view :?> IView
                    targetColl.Add(addedView)
                    handler.Invoke("Add", Microsoft.Maui.Handlers.LayoutHandlerUpdate(targetColl.Count - 1, addedView))
                    
            let handler = (node.Target :?> IElement).Handler
            handler.UpdateValue(name)
                
        let key =
            AttributeDefinitionStore.registerWidgetCollection
                { ApplyDiff = applyDiff
                  UpdateNode = updateNode }

        { Key = key; Name = name }
        
    let defineMauiWidgetCollectionNavigation name: WidgetCollectionAttributeDefinition =
        let applyDiff _ (diffs: WidgetCollectionItemChanges) (node: IViewNode) =
            let targetNode = node.Target :?> Node
            let targetColl =
                if targetNode.Attributes.WidgetCollections.ContainsKey(name) then
                    targetNode.Attributes.WidgetCollections[name]
                else
                    let lst = List<obj>()
                    targetNode.Attributes.WidgetCollections[name] <- lst
                    lst

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Remove (index, widget) ->
                    let itemNode =
                        node.TreeContext.GetViewNode(box targetColl.[index])

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

                | WidgetCollectionItemChange.Update (index, next, widgetDiff) ->
                    let childNode = node.TreeContext.GetViewNode(box targetColl.[index])
                    let childView = childNode.Target :?> Node
                    
                    childView.Attributes.ScalarAttributes <- ValueOption.defaultValue [||] next.ScalarAttributes
            
                    childNode.ApplyDiff(&widgetDiff)

                | WidgetCollectionItemChange.Replace (index, oldWidget, newWidget) ->
                    let prevItemNode =
                        node.TreeContext.GetViewNode(box targetColl.[index])

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
                
            let handler = node.Target :?> IStackNavigation
            let stack = targetColl |> Seq.map unbox<IView> |> List<_>
            handler.RequestNavigation(NavigationRequest(stack.AsReadOnly(), true))
            
        let updateNode _ (newValueOpt: ArraySlice<Widget> voption) (node: IViewNode) =
            let targetNode = node.Target :?> Node
            
            let targetColl =
                if targetNode.Attributes.WidgetCollections.ContainsKey(name) then
                    let lst = targetNode.Attributes.WidgetCollections[name]
                    lst.Clear()
                    lst
                else
                    let lst = List<obj>()
                    targetNode.Attributes.WidgetCollections[name] <- lst
                    lst
            
            match newValueOpt with
            | ValueNone -> ()
            | ValueSome widgets ->
                for widget in ArraySlice.toSpan widgets do
                    let struct (_, view) = Helpers.createViewForWidget node widget
                    targetColl.Add(view)
                
            let handler = node.Target :?> IStackNavigation
            let stack = targetColl |> Seq.map unbox<IView> |> List<_>
            handler.RequestNavigation(NavigationRequest(stack.AsReadOnly(), true))
                
        let key =
            AttributeDefinitionStore.registerWidgetCollection
                { ApplyDiff = applyDiff
                  UpdateNode = updateNode }

        { Key = key; Name = name }