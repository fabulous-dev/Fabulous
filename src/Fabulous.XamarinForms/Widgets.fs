namespace Fabulous.XamarinForms.Widgets

open System
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Widgets
open Fabulous.XamarinForms

type IWidgetBuilder =
    abstract Attributes: Attribute[]
    abstract Compile: unit -> Widget

type IWidgetBuilder<'msg> = inherit IWidgetBuilder
type IApplicationWidgetBuilder<'msg> = inherit IWidgetBuilder<'msg>
type IPageWidgetBuilder<'msg> = inherit IWidgetBuilder<'msg>
type IViewWidgetBuilder<'msg> = inherit IWidgetBuilder<'msg>
type ILayoutWidgetBuilder<'msg> = inherit IViewWidgetBuilder<'msg>
type ICellWidgetBuilder<'msg> = inherit IWidgetBuilder<'msg>

[<Extension>]
type IWidgetExtensions () =
    [<Extension>]
    static member inline AddAttribute(this: ^T when ^T :> IWidgetBuilder, attr: Attribute) =
        let attribs = this.Attributes
        let attribs2 = Array.zeroCreate (attribs.Length + 1)
        Array.blit attribs 0 attribs2 0 attribs.Length
        attribs2.[attribs.Length] <- attr
        let result = (^T : (new : Attribute[] -> ^T) attribs2)
        result

    [<Extension>]
    static member inline AddAttributes(this: ^T when ^T :> IWidgetBuilder, attrs: Attribute[]) =
        let attribs2 = Array.append this.Attributes attrs
        let result = (^T : (new : Attribute[] -> ^T) attribs2)
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

                Reconciler.update ViewNode.getViewNode view widget.Attributes

                box view }
        
        WidgetDefinitionStore.set key definition
        key