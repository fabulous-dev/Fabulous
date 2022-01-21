namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

type ITabbedPage =
    inherit IPage

module TabbedPage =
    let WidgetKey = Widgets.register<TabbedPage> ()

[<AutoOpen>]
module TabbedPageBuilders =
    type Fabulous.XamarinForms.View with
        static member inline TabbedPage<'msg>(title: string) =
            CollectionBuilder<'msg, ITabbedPage, IPage>(
                TabbedPage.WidgetKey,
                MultiPageOfPage.Children,
                Page.Title.WithValue(title)
            )
