namespace Fabulous.XamarinForms

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms.Shapes

type ITransformGroup =
    inherit ITransform

module TransformGroup =

    let WidgetKey = Widgets.register<TransformGroup> ()

    let Children =
        Attributes.defineWidgetCollection "TransformGroup_Children" (fun target -> (target :?> TransformGroup).Children)

[<AutoOpen>]
module TransformGroupBuilders =
    type Fabulous.XamarinForms.View with
        static member inline TransformGroup<'msg>() =
            CollectionBuilder<'msg, ITransformGroup, ITransform>(TransformGroup.WidgetKey, TransformGroup.Children)
