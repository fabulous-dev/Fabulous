namespace Fabulous.Maui

open Fabulous
open Fabulous.ScalarAttributeDefinitions
open Fabulous.WidgetAttributeDefinitions
open Fabulous.WidgetCollectionAttributeDefinitions
open Microsoft.Maui

module Attributes =
    let inline defineMauiScalar<'T>
        name
        ([<InlineIfLambda>] compare: 'T -> 'T -> ScalarAttributeComparison)
        : SimpleScalarAttributeDefinition<'T> =
            
        let updateNode _ _ (node: IViewNode) =
            let handler = (node.Target :?> IElement).Handler
            handler.UpdateValue(name)
        
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(compare, updateNode)
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
        
    let inline defineMauiWidgetCollection name: WidgetCollectionAttributeDefinition =
        let applyDiff _ (diffs: WidgetCollectionItemChanges) (node: IViewNode) =
            () // TODO: Need to be implemented
            
        let updateNode _ (newValueOpt: ArraySlice<Widget> voption) (node: IViewNode) =
            () // TODO: Need to be implemented
        
        let key =
            AttributeDefinitionStore.registerWidgetCollection
                { ApplyDiff = applyDiff
                  UpdateNode = updateNode }

        { Key = key; Name = name }