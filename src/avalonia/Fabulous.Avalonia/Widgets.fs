namespace Fabulous.Avalonia

open System
open System.Collections
open Avalonia
open Fabulous
open Fabulous.ScalarAttributeDefinitions


type WidgetItems =
    { OriginalItems: IEnumerable
      Template: obj -> Widget }

type WidgetOps<'T when 'T :> AvaloniaObject and 'T: (new: unit -> 'T)> = 'T

module Widgets =
    /// Registers a widget with the given factory function.
    let registerWithFactory<'T when 'T :> AvaloniaObject> (factory: unit -> 'T) =
        let key = WidgetDefinitionStore.getNextKey()

        let definition =
            { Key = key
              Name = typeof<'T>.Name
              TargetType = typeof<'T>
              CreateView =
                fun (widget, envContext, treeContext, parentNode) ->
                    treeContext.Logger.Debug("Creating view for {0}", typeof<'T>.Name)

                    let view = factory()
                    let weakReference = WeakReference(view)

                    let parentNode =
                        match parentNode with
                        | ValueNone -> None
                        | ValueSome node -> Some node

                    let node = new ViewNode(parentNode, envContext, treeContext, weakReference)

                    ViewNode.set node view

                    // additionalSetup view node

                    Reconciler.update treeContext.CanReuseView ValueNone widget node
                    struct (node :> IViewNode, box view)
              AttachView =
                fun (widget, envContext, treeContext, parentNode, view) ->
                    treeContext.Logger.Debug("Attaching view for {0}", typeof<'T>.Name)

                    let weakReference = WeakReference(view)

                    let parentNode =
                        match parentNode with
                        | ValueNone -> None
                        | ValueSome node -> Some node

                    let node = new ViewNode(parentNode, envContext, treeContext, weakReference)

                    ViewNode.set node view

                    // additionalSetup view node

                    Reconciler.update treeContext.CanReuseView ValueNone widget node
                    node :> IViewNode }

        WidgetDefinitionStore.set key definition
        key

    /// Registers a widget with the given constructor.
    let register<'T when WidgetOps<'T>> () = registerWithFactory(fun () -> new 'T())

module WidgetHelpers =
    /// Compiles the templateBuilder into a template.
    let compileTemplate (templateBuilder: 'item -> WidgetBuilder<'msg, 'widget>) item =
        let itm = unbox<'item> item
        (templateBuilder itm).Compile()

    /// Creates a widget with the given key and attributes.
    let inline buildItems<'msg, 'marker, 'itemData, 'itemMarker when 'msg: equality>
        key
        (attrDef: SimpleScalarAttributeDefinition<WidgetItems>)
        (items: seq<'itemData>)
        (itemTemplate: 'itemData -> WidgetBuilder<'msg, 'itemMarker>)
        =
        let data: WidgetItems =
            { OriginalItems = items
              Template = compileTemplate itemTemplate }

        WidgetBuilder<'msg, 'marker>(key, attrDef.WithValue(data))

    /// Creates a widget with the given key and attributes.
    let inline buildWidgets<'msg, 'marker when 'msg: equality> (key: WidgetKey) scalars (attrs: WidgetAttribute[]) =
        WidgetBuilder<'msg, 'marker>(key, struct (scalars, attrs, [||], [||]))
