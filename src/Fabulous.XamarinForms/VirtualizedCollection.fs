namespace Fabulous.XamarinForms

open System
open System.Collections
open System.Collections.Generic
open Fabulous
open Xamarin.Forms

module BindableHelpers =
    /// On BindableContextChanged triggered, call the Reconciler to update the cell
    let createOnBindingContextChanged canReuseView (target: BindableObject) =
        let mutable prevWidgetOpt: Widget voption = ValueNone
        
        let onBindingContextChanged () =
            match target.BindingContext with
            | null -> ()
            | value ->
                match prevWidgetOpt with
                | ValueNone -> printfn "Create new cell instance"
                | ValueSome _ -> printfn "Reuse cell instance"
                
                let currWidget = value :?> Widget
                let node = ViewNode.get target
                Reconciler.update canReuseView prevWidgetOpt currWidget node
                prevWidgetOpt <- ValueSome currWidget

        onBindingContextChanged

/// Create a DataTemplate for a specific root type (TextCell, ViewCell, etc.)
/// that listen for BindingContext change to apply the Widget content to the cell
type WidgetDataTemplate(``type``, parent: IViewNode) =
    inherit DataTemplate(fun () ->
        let bindableObject = Activator.CreateInstance ``type`` :?> BindableObject
        
        let viewNode = ViewNode(ValueSome parent, parent.TreeContext, WeakReference(bindableObject))
        bindableObject.SetValue(ViewNode.ViewNodeProperty, viewNode)
        
        let onBindingContextChanged = BindableHelpers.createOnBindingContextChanged parent.TreeContext.CanReuseView bindableObject
        bindableObject.BindingContextChanged.Add (fun _ -> onBindingContextChanged ())
        
        bindableObject :> obj
    )

/// Redirect to the right type of DataTemplate based on the target type of the current widget cell
type WidgetDataTemplateSelector(node: IViewNode) =
    inherit DataTemplateSelector()
    
    /// Reuse data template for already known widget target type
    let cache = Dictionary<Type, WidgetDataTemplate>()
    
    override _.OnSelectTemplate(item, _) =
        let widget = item :?> Widget
        let widgetDefinition = WidgetDefinitionStore.get widget.Key
        match cache.TryGetValue(widgetDefinition.TargetType) with
        | true, dataTemplate -> dataTemplate
        | false, _ ->
            let dataTemplate = WidgetDataTemplate(widgetDefinition.TargetType, node)
            cache.Add(widgetDefinition.TargetType, dataTemplate)
            dataTemplate
            
type WidgetItems =
    { Items: IEnumerable
      Template: obj -> Widget }