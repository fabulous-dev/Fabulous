namespace Fabulous.XamarinForms

open System
open System.Collections
open System.Collections.Generic
open Fabulous
open Xamarin.Forms

type GroupItem(header: Widget, source: IEnumerable<Widget>) =
    member _.Header = header
    interface IEnumerable<Widget> with
        member this.GetEnumerator(): IEnumerator<Widget> = source.GetEnumerator()
        member this.GetEnumerator(): IEnumerator = source.GetEnumerator()

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
                
                let currWidget =
                    match value with
                    | :? Widget as widget -> widget
                    | :? GroupItem as groupItem -> groupItem.Header
                    | v -> failwith $"Unexpected {v.GetType().FullName} in BindingContext"
                    
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
type WidgetDataTemplateSelector internal (node: IViewNode, getWidget: obj -> Widget) =
    inherit DataTemplateSelector()
    
    /// Reuse data template for already known widget target type
    let cache = Dictionary<Type, WidgetDataTemplate>()
    
    override _.OnSelectTemplate(item, _) =
        let widget = getWidget item
        let widgetDefinition = WidgetDefinitionStore.get widget.Key
        let targetType = widgetDefinition.GetTargetType(widget)
        match cache.TryGetValue(targetType) with
        | true, dataTemplate -> dataTemplate
        | false, _ ->
            let dataTemplate = WidgetDataTemplate(targetType, node)
            cache.Add(targetType, dataTemplate)
            dataTemplate

type SimpleWidgetDataTemplateSelector(node: IViewNode) =
    inherit WidgetDataTemplateSelector(node, fun item -> item :?> Widget)
        
type GroupedWidgetDataTemplateSelector(node: IViewNode) =
    inherit WidgetDataTemplateSelector(node, fun item -> (item :?> GroupItem).Header)
        
type WidgetItems =
    { OriginalItems: IEnumerable
      Template: obj -> obj }