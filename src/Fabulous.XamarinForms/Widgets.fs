namespace Fabulous.XamarinForms

open System
open Fabulous
open Fabulous.XamarinForms

type IMarker = interface end
type IApplicationMarker = inherit IMarker
type IPageMarker = inherit IMarker
type IViewMarker = inherit IMarker
type ICellMarker = inherit IMarker
type IMenuItemMarker = inherit IMarker
type IGestureRecognizerMarker = inherit IMarker
type ILayoutMarker = inherit IViewMarker
type IToolbarItemMarker = inherit IMenuItemMarker

module Widgets =
    let register<'T when 'T :> Xamarin.Forms.BindableObject and 'T: (new : unit -> 'T)> () =
        let key = WidgetDefinitionStore.getNextKey()

        let definition =
            {
                Key = key
                Name = typeof<'T>.Name
                CreateView =
                    fun (widget, context) ->
                        let name = typeof<'T>.Name
                        printfn $"Creating view for {name}"

                        let view = new 'T()
                        let weakReference = WeakReference(view)
                        
                        let viewNode =
                            ViewNode(context, weakReference)

                        view.SetValue(ViewNode.ViewNodeProperty, viewNode)

                        Reconciler.update context.ViewTreeContext.GetViewNode context.ViewTreeContext.CanReuseView ValueNone widget view

                        box view
            }

        WidgetDefinitionStore.set key definition
        key

    let inline map (fn: 'oldMsg -> 'newMsg) (this: ^T :> IWidgetBuilder<'oldMsg>) : ^U :> IWidgetBuilder<'newMsg> =
        (^T: (member MapMsg : ('oldMsg -> 'newMsg) -> 'U) (this, fn))
