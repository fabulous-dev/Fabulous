namespace Fabulous.XamarinForms

open System
open System.Collections.Generic
open Fabulous
open Xamarin.Forms

module BindableHelpers =
    /// On BindableContextChanged triggered, call the Reconciler to update the cell
    let createOnBindingContextChanged canReuseView templateFn (target: BindableObject) =
        let mutable prevWidgetOpt: Widget voption = ValueNone

        let onBindingContextChanged () =
            match target.BindingContext with
            | null -> ()
            | value ->
                let currWidget = templateFn value

                let node = ViewNode.get target
                Reconciler.update canReuseView prevWidgetOpt currWidget node
                prevWidgetOpt <- ValueSome currWidget

        onBindingContextChanged

/// Create a DataTemplate for a specific root type (TextCell, ViewCell, etc.)
/// that listen for BindingContext change to apply the Widget content to the cell
type WidgetDataTemplate(parent: IViewNode, ``type``: Type, templateFn: obj -> Widget) =
    inherit DataTemplate(fun () ->
        let bindableObject =
            Activator.CreateInstance ``type`` :?> BindableObject

        let viewNode =
            ViewNode(ValueSome parent, parent.TreeContext, WeakReference(bindableObject))

        bindableObject.SetValue(ViewNode.ViewNodeProperty, viewNode)

        let onBindingContextChanged =
            BindableHelpers.createOnBindingContextChanged parent.TreeContext.CanReuseView templateFn bindableObject

        bindableObject.BindingContextChanged.Add(fun _ -> onBindingContextChanged ())

        bindableObject :> obj)

/// Redirect to the right type of DataTemplate based on the target type of the current widget cell
type WidgetDataTemplateSelector internal (node: IViewNode, templateFn: obj -> Widget) =
    inherit DataTemplateSelector()

    /// Reuse data template for already known widget target type
    let cache = Dictionary<Type, DataTemplate>()

    override _.OnSelectTemplate(item, _) =
        let widget = templateFn item
        let widgetDefinition = WidgetDefinitionStore.get widget.Key
        let targetType = widgetDefinition.TargetType

        match cache.TryGetValue(targetType) with
        | true, dataTemplate -> dataTemplate
        | false, _ ->
            let dataTemplate =
                WidgetDataTemplate(node, targetType, templateFn) :> DataTemplate

            cache.Add(targetType, dataTemplate)
            dataTemplate

type WidgetItems<'T> =
    { OriginalItems: IEnumerable<'T>
      Template: 'T -> Widget }

type GroupedWidgetItems<'groupData, 'itemData> =
    { OriginalItems: IEnumerable<'groupData>
      HeaderTemplate: 'groupData -> Widget
      FooterTemplate: ('groupData -> Widget) option
      ItemTemplate: 'itemData -> Widget }
