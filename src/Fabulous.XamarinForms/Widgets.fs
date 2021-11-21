namespace Fabulous.XamarinForms

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
              CreateView = fun (widget, parentContext) ->
                let name = typeof<'T>.Name
                printfn $"Creating view for {name}"

                let mapMsg = widget.GetScalarOrDefault<obj -> obj>(Fabulous.Attributes.MapMsg.Key, id)
                let context =
                    { parentContext with
                        Dispatch = mapMsg >> parentContext.Dispatch
                        CanReuseView = parentContext.CanReuseView }

                let view = new 'T()
                let weakReference = WeakReference(view)
                let viewNode = ViewNode(key, context, mapMsg, weakReference)
                view.SetValue(ViewNode.ViewNodeProperty, viewNode)

                Reconciler.update ViewNode.getViewNode context.CanReuseView ValueNone widget view

                box view }
        
        WidgetDefinitionStore.set key definition
        key

    let inline map (fn: 'oldMsg -> 'newMsg) (this: ^T when ^T :> IWidgetBuilder<'oldMsg>) : ^U when ^U :> IWidgetBuilder<'newMsg> =
        (^T: (member MapMsg: ('oldMsg -> 'newMsg) -> 'U) (this, fn))