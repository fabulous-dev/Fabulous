namespace Fabulous.XamarinForms.Widgets

open System
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Widgets
open Fabulous.XamarinForms
open Fabulous.XamarinForms.XamarinFormsAttributes

type IWidgetBuilder =
    abstract Attributes: Attribute[]
    abstract Compile: unit -> Widget

type IWidgetBuilder<'msg> = inherit IWidgetBuilder
type IApplicationWidgetBuilder<'msg> = inherit IWidgetBuilder<'msg>
type IPageWidgetBuilder<'msg> = inherit IWidgetBuilder<'msg>
type IViewWidgetBuilder<'msg> = inherit IWidgetBuilder<'msg>
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

type LayoutOfViewViewContainer(ref: WeakReference) =
    interface IXamarinFormsViewContainer with
        member this.ChildrenAttributeKey = Fabulous.XamarinForms.Attributes.LayoutOfView.Children.Key

        member this.Children =
            if ref.IsAlive then
                (ref.Target :?> Xamarin.Forms.Layout<Xamarin.Forms.View>).Children
                |> Seq.map box
                |> Seq.toArray
            else
                Array.empty

        member this.UpdateChildren diff =
            let children = (ref.Target :?> Xamarin.Forms.Layout<Xamarin.Forms.View>).Children
            let count = children.Count

            while count > diff.ChildrenAfterUpdate.Length do
                children.RemoveAt(children.Count - 1)

            for i = 0 to count - 1 do
                let child = diff.ChildrenAfterUpdate.[i] :?> Xamarin.Forms.View
                match children.IndexOf(child) with

                // Same index, do nothing
                | index when index = i -> ()

                // New child, replace the current index
                | -1 ->
                    children.[i] <- child

                // Child is moved, remove it and reinsert it at the right place
                | index ->
                    children.RemoveAt(index)
                    children.Insert(i, child)

module Widgets =
    let register<'T  when 'T :> Xamarin.Forms.BindableObject and 'T : (new: unit -> 'T)> (getViewContainer: WeakReference -> IXamarinFormsViewContainer option) =
        let key = WidgetDefinitionStore.getNextKey()
        let definition =
            { Key = key
              Name = nameof<'T>
              CreateView = fun (widget, context) ->
                  let view = new 'T()
                  let weakReference = WeakReference(view)
                  let viewNodeData = ViewNodeData(ViewNode(key, context, weakReference, getViewContainer weakReference))
                  view.SetValue(ViewNode.ViewNodeProperty, viewNodeData)

                  Reconciler.update ViewNode.getViewNode view widget.Attributes

                  box view }
        
        WidgetDefinitionStore.set key definition
        key

    let registerNoChildren<'T when 'T :> Xamarin.Forms.BindableObject and 'T : (new: unit -> 'T)> () =
        register<'T> (fun _ -> None)