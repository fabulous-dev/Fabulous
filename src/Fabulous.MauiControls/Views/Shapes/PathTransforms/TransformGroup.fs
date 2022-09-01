namespace Fabulous.Maui

open System.Collections.Generic
open Fabulous
open Microsoft.Maui.Controls.Shapes

type ITransformGroup =
    inherit Fabulous.Maui.ITransform

module TransformGroup =

    let WidgetKey = Widgets.register<TransformGroup>()

    let Children =
        Attributes.defineListWidgetCollection
            "TransformGroup_Children"
            (fun target -> (target :?> TransformGroup).Children :> IList<_>)

[<AutoOpen>]
module TransformGroupBuilders =
    type Fabulous.Maui.View with
        static member inline TransformGroup<'msg>() =
            CollectionBuilder<'msg, ITransformGroup, ITransform>(TransformGroup.WidgetKey, TransformGroup.Children)
