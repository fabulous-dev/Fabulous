namespace Fabulous.XamarinForms

open System.Collections.Generic
open Fabulous
open Xamarin.Forms.Shapes

type ITransformGroup =
    inherit ITransform

module TransformGroup =

    let WidgetKey = Widgets.register<TransformGroup>()

    let Children =
        Attributes.defineListWidgetCollection
            "TransformGroup_Children"
            ViewNode.get
            (fun target -> (target :?> TransformGroup).Children :> IList<_>)

[<AutoOpen>]
module TransformGroupBuilders =
    type Fabulous.XamarinForms.View with
        static member inline TransformGroup<'msg>() =
            CollectionBuilder<'msg, ITransformGroup, ITransform>(TransformGroup.WidgetKey, TransformGroup.Children)
