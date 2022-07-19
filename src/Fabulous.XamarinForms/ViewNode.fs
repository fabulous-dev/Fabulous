namespace Fabulous.XamarinForms

open System
open System.Collections.Generic
open Fabulous
open Xamarin.Forms

module BindableViewNode =
    let ViewNodeProperty =
        BindableProperty.Create("ViewNode", typeof<ViewNode>, typeof<View>, null)

    let get (target: obj) =
        (target :?> BindableObject)
            .GetValue(ViewNodeProperty)
        :?> IViewNode

    let set (node: IViewNode) (target: obj) =
        (target :?> BindableObject)
            .SetValue(ViewNodeProperty, node)

module StyleViewNode =
    let private registrar = Dictionary<WeakReference, IViewNode>()

    let get (target: obj) =
        let mutable node: IViewNode = Unchecked.defaultof<_>
        let keys = registrar.Keys |> Seq.toArray

        for key in keys do
            if key.IsAlive = false then
                registrar.Remove(key) |> ignore
            elif key.Target = target then
                node <- registrar.[key]

        node

    let set (node: IViewNode) (target: obj) =
        let weakRef = WeakReference(target)
        registrar.[weakRef] <- node

module ViewNode =
    let get (target: obj) =
        if target.GetType().IsAssignableFrom(typeof<Style>) then
            StyleViewNode.get target
        else
            BindableViewNode.get target
