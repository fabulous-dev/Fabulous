namespace Fabulous.XamarinForms

open System
open Fabulous
open Fabulous.XamarinForms

type IMarker = interface end
type IApplication = inherit IMarker
type IPage = inherit IMarker
type IView = inherit IMarker
type ICell = inherit IMarker
type IMenuItem = inherit IMarker
type IGestureRecognizer = inherit IMarker
type ILayout = inherit IView
type IToolbarItem = inherit IMenuItem

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
