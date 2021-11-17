namespace Fabulous.XamarinForms.Widgets

open System
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms

type IWidgetBuilder =
    abstract Compile: unit -> Widget

type IWidgetBuilder<'msg> = inherit IWidgetBuilder
type IApplicationWidgetBuilder<'msg> = inherit IWidgetBuilder<'msg>
type IPageWidgetBuilder<'msg> = inherit IWidgetBuilder<'msg>
type IViewWidgetBuilder<'msg> = inherit IWidgetBuilder<'msg>
type ILayoutWidgetBuilder<'msg> = inherit IViewWidgetBuilder<'msg>
type ICellWidgetBuilder<'msg> = inherit IWidgetBuilder<'msg>
type IGestureRecognizerWidgetBuilder<'msg> = inherit IWidgetBuilder<'msg>
type IMenuItemWidgetBuilder<'msg> = inherit IWidgetBuilder<'msg>
type IToolbarItemWidgetBuilder<'msg> = inherit IMenuItemWidgetBuilder<'msg>

[<Extension>]
type IWidgetExtensions () =
    [<Extension>]
    static member inline AddScalarAttribute(this: ^T, attr: ScalarAttribute) =
        let scalars = (^T : (member ScalarAttributes: ScalarAttribute[]) this)
        let widgets = (^T : (member WidgetAttributes: WidgetAttribute[]) this)
        let widgetCollections = (^T : (member WidgetCollectionAttributes: WidgetCollectionAttribute[]) this)
        let attribs2 = Array.zeroCreate (scalars.Length + 1)
        Array.blit scalars 0 attribs2 0 scalars.Length
        attribs2.[scalars.Length] <- attr
        let result = (^T : (new : ScalarAttribute[] * WidgetAttribute[] * WidgetCollectionAttribute[] -> ^T) (attribs2, widgets, widgetCollections))
        result

    [<Extension>]
    static member inline AddScalarAttributes(this: ^T when ^T :> IWidgetBuilder, attrs: ScalarAttribute[]) =
        match attrs with
        | [||] ->
            this
        | attributes ->
            let scalars = (^T : (member ScalarAttributes: ScalarAttribute[]) this)
            let widgets = (^T : (member WidgetAttributes: WidgetAttribute[]) this)
            let widgetCollections = (^T : (member WidgetCollectionAttributes: WidgetCollectionAttribute[]) this)
            let attribs2 = Array.append scalars attributes
            let result = (^T : (new : ScalarAttribute[] * WidgetAttribute[] * WidgetCollectionAttribute[] -> ^T) (attribs2, widgets, widgetCollections))
            result

    [<Extension>]
    static member inline AddWidgetCollectionAttribute(this: ^T when ^T :> IWidgetBuilder, attr: WidgetCollectionAttribute) =
        let scalars = (^T : (member ScalarAttributes: ScalarAttribute[]) this)
        let widgets = (^T : (member WidgetAttributes: WidgetAttribute[]) this)
        let widgetCollections = (^T : (member WidgetCollectionAttributes: WidgetCollectionAttribute[]) this)
        let attribs2 = Array.zeroCreate (widgetCollections.Length + 1)
        Array.blit widgetCollections 0 attribs2 0 widgetCollections.Length
        attribs2.[widgetCollections.Length] <- attr
        let result = (^T : (new : ScalarAttribute[] * WidgetAttribute[] * WidgetCollectionAttribute[] -> ^T) (scalars, widgets, attribs2))
        result



module Widgets =
    let register<'T  when 'T :> Xamarin.Forms.BindableObject and 'T : (new: unit -> 'T)>() =
        let key = WidgetDefinitionStore.getNextKey()
        let definition =
            { Key = key
              Name = typeof<'T>.Name
              CreateView = fun (widget, context) ->
                let name = typeof<'T>.Name
                printfn $"Creating view for {name}"

                let view = new 'T()
                let weakReference = WeakReference(view)
                let viewNodeData = ViewNodeData(ViewNode(key, context, weakReference))
                view.SetValue(ViewNode.ViewNodeProperty, viewNodeData)

                Reconciler.update ViewNode.getViewNode context.CanReuseView ValueNone widget view

                box view }
        
        WidgetDefinitionStore.set key definition
        key