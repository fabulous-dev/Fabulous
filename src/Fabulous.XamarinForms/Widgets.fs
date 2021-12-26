namespace Fabulous.XamarinForms

open System
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms

type IMarker =
    interface
    end

type IApplication =
    inherit IMarker

type IPage =
    inherit IMarker

type IView =
    inherit IMarker

type ICell =
    inherit IMarker

type IMenuItem =
    inherit IMarker

type IGestureRecognizer =
    inherit IMarker

type ILayout =
    inherit IView

type IToolbarItem =
    inherit IMenuItem

module Widgets =
    let register<'T when 'T :> Xamarin.Forms.BindableObject and 'T: (new : unit -> 'T)> () =
        let key = WidgetDefinitionStore.getNextKey()

        let definition =
            {
                Key = key
                Name = typeof<'T>.Name
                CreateView =
                    fun (widget, treeContext, parentNode) ->
                        let name = typeof<'T>.Name
                        printfn $"Creating view for {name}"

                        let view = new 'T()
                        let weakReference = WeakReference(view)

                        let node =
                            ViewNode(parentNode, treeContext, weakReference)

                        view.SetValue(ViewNode.ViewNodeProperty, node)

                        Reconciler.update treeContext.CanReuseView ValueNone widget node
                        struct (node, box view)
            }

        WidgetDefinitionStore.set key definition
        key

[<Extension>]
type CollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IPage>
        (
            _: CollectionBuilder<'msg, 'marker, IPage>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = [ x.Compile() ] }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IView>
        (
            _: CollectionBuilder<'msg, 'marker, IView>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = [ x.Compile() ] }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IGestureRecognizer>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IGestureRecognizer>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = [ x.Compile() ] }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IToolbarItem>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IToolbarItem>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = [ x.Compile() ] }

module ViewHelpers =
    let inline compileSeq (items: seq<WidgetBuilder<'msg, #IMarker>>) =
        items
        |> Seq.map(fun item -> item.Compile())
        |> Seq.toArray

    let inline buildScalars<'msg, 'marker> (key: WidgetKey) (attrs: ScalarAttribute []) =
        WidgetBuilder<'msg, 'marker>(key, struct (attrs, [||], [||]))

    let inline buildWidgets<'msg, 'marker> (key: WidgetKey) (attrs: WidgetAttribute []) =
        WidgetBuilder<'msg, 'marker>(key, struct ([||], attrs, [||]))

    let inline build<'msg, 'marker>
        (key: WidgetKey)
        (scalars: ScalarAttribute [])
        (widgets: WidgetAttribute [])
        (widgetColls: WidgetCollectionAttribute [])
        =
        WidgetBuilder<'msg, 'marker>(key, struct (scalars, widgets, widgetColls))

    let inline buildCollectionNoScalar<'msg, 'marker, 'item>
        (key: WidgetKey)
        (collectionAttributeDefinition: WidgetCollectionAttributeDefinition)
        =
        CollectionBuilder<'msg, 'marker, 'item>(key, ValueNone, collectionAttributeDefinition)

    let inline buildCollection<'msg, 'marker, 'item>
        (key: WidgetKey)
        (collectionAttributeDefinition: WidgetCollectionAttributeDefinition)
        (scalars: ScalarAttribute [])
        =
        CollectionBuilder<'msg, 'marker, 'item>(key, ValueSome scalars, collectionAttributeDefinition)

    let inline buildAttributeCollection<'msg, 'marker, 'item>
        (collectionAttributeDefinition: WidgetCollectionAttributeDefinition)
        (widget: WidgetBuilder<'msg, 'marker>)
        =
        AttributeCollectionBuilder<'msg, 'marker, 'item>(widget, collectionAttributeDefinition)
