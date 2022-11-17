namespace Fabulous.Maui

open System
open Fabulous
open Fabulous.ScalarAttributeDefinitions
open Fabulous.WidgetCollectionAttributeDefinitions
open Fabulous.StackAllocatedCollections.StackList
open Fabulous.StackAllocatedCollections
open Fabulous.Maui
open Microsoft.FSharp.Core

[<AbstractClass; Sealed>]
type View =
    class
    end

module Widgets =
    let registerWithAdditionalSetup<'T when 'T :> Microsoft.Maui.Controls.BindableObject and 'T: (new: unit -> 'T)>
        (additionalSetup: 'T -> IViewNode -> unit)
        =
        let key = WidgetDefinitionStore.getNextKey()

        let definition =
            { Key = key
              Name = typeof<'T>.Name
              TargetType = typeof<'T>
              CreateView =
                  fun (widget, treeContext, parentNode) ->
                      treeContext.Logger.Debug("Creating view for {0}", typeof<'T>.Name)

                      let view = new 'T()
                      let weakReference = WeakReference(view)

                      let parentNode =
                          match parentNode with
                          | ValueNone -> None
                          | ValueSome node -> Some node

                      let node =
                          ViewNode(parentNode, treeContext, weakReference)

                      ViewNode.set node view

                      additionalSetup view node

                      Reconciler.update treeContext.CanReuseView ValueNone widget node
                      struct (node :> IViewNode, box view)
              AttachView =
                  fun (widget, treeContext, parentNode, view) ->
                      treeContext.Logger.Debug("Attaching view for {0}", typeof<'T>.Name)

                      let view = unbox<'T> view
                      let weakReference = WeakReference(view)

                      let parentNode =
                          match parentNode with
                          | ValueNone -> None
                          | ValueSome node -> Some node

                      let node =
                          ViewNode(parentNode, treeContext, weakReference)

                      ViewNode.set node view

                      additionalSetup view node

                      Reconciler.update treeContext.CanReuseView ValueNone widget node
                      node :> IViewNode }

        WidgetDefinitionStore.set key definition
        key

    let register<'T when 'T :> Microsoft.Maui.Controls.BindableObject and 'T: (new: unit -> 'T)> () =
        registerWithAdditionalSetup<'T>(fun _ _ -> ())

module WidgetHelpers =
    let inline compileSeq (items: seq<WidgetBuilder<'msg, 'marker>>) =
        items
        |> Seq.map(fun item -> item.Compile())
        |> Seq.toArray

    let inline buildWidgets<'msg, 'marker> (key: WidgetKey) (attrs: WidgetAttribute []) =
        WidgetBuilder<'msg, 'marker>(key, struct (StackList.empty(), ValueSome attrs, ValueNone))

    let inline buildAttributeCollection<'msg, 'marker, 'item>
        (collectionAttributeDefinition: WidgetCollectionAttributeDefinition)
        (widget: WidgetBuilder<'msg, 'marker>)
        =
        AttributeCollectionBuilder<'msg, 'marker, 'item>(widget, collectionAttributeDefinition)

    let buildItems<'msg, 'marker, 'itemData, 'itemMarker>
        key
        (attrDef: SimpleScalarAttributeDefinition<WidgetItems<'itemData>>)
        (items: seq<'itemData>)
        (itemTemplate: 'itemData -> WidgetBuilder<'msg, 'itemMarker>)
        =
        let template (item: obj) =
            let item = unbox<'itemData> item
            (itemTemplate item).Compile()

        let data: WidgetItems<'itemData> =
            { OriginalItems = items
              Template = template }

        WidgetBuilder<'msg, 'marker>(key, attrDef.WithValue(data))

    let buildGroupItems<'msg, 'marker, 'groupData, 'itemData, 'groupMarker, 'itemMarker when 'groupData :> seq<'itemData>>
        key
        (attrDef: SimpleScalarAttributeDefinition<GroupedWidgetItems<'groupData, 'itemData>>)
        (items: seq<'groupData>)
        (groupHeaderTemplate: 'groupData -> WidgetBuilder<'msg, 'groupMarker>)
        (itemTemplate: 'itemData -> WidgetBuilder<'msg, 'itemMarker>)
        (groupFooterTemplate: 'groupData -> WidgetBuilder<'msg, 'groupMarker>)
        =
        let data: GroupedWidgetItems<'groupData, 'itemData> =
            { OriginalItems = items
              HeaderTemplate = fun d -> (groupHeaderTemplate d).Compile()
              FooterTemplate = Some(fun d -> (groupFooterTemplate d).Compile())
              ItemTemplate = fun d -> (itemTemplate d).Compile() }

        WidgetBuilder<'msg, 'marker>(key, attrDef.WithValue(data))

    let buildGroupItemsNoFooter<'msg, 'marker, 'groupData, 'itemData, 'groupMarker, 'itemMarker when 'groupData :> seq<'itemData>>
        key
        (attrDef: SimpleScalarAttributeDefinition<GroupedWidgetItems<'groupData, 'itemData>>)
        (items: seq<'groupData>)
        (groupHeaderTemplate: 'groupData -> WidgetBuilder<'msg, 'groupMarker>)
        (itemTemplate: 'itemData -> WidgetBuilder<'msg, 'itemMarker>)
        =
        let data: GroupedWidgetItems<'groupData, 'itemData> =
            { OriginalItems = items
              HeaderTemplate = fun d -> (groupHeaderTemplate d).Compile()
              FooterTemplate = None
              ItemTemplate = fun d -> (itemTemplate d).Compile() }

        WidgetBuilder<'msg, 'marker>(key, attrDef.WithValue(data))
