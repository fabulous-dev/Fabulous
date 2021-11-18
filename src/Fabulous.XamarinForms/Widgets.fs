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