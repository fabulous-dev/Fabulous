namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

type IScrollView =
    inherit Fabulous.XamarinForms.ILayout

module ScrollView =
    let WidgetKey = Widgets.register<ScrollView> ()

    let Content =
        Attributes.defineWidget
            "ScrollView_Content"
            (fun target -> ViewNode.get (target :?> ScrollView).Content)
            (fun target value -> (target :?> ScrollView).Content <- value)

[<AutoOpen>]
module ScrollViewBuilders =
    type Fabulous.XamarinForms.View with
        static member inline ScrollView<'msg, 'marker when 'marker :> IView>(content: WidgetBuilder<'msg, 'marker>) =
            WidgetHelpers.buildWidgets<'msg, IScrollView>
                ScrollView.WidgetKey
                [| ScrollView.Content.WithValue(content.Compile()) |]
