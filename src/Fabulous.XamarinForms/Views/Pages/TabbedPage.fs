namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
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

[<Extension>]
type TabbedPageModifiers =
    /// <summary>Link a ViewRef to access the direct TabbedPage control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, ITabbedPage>, value: ViewRef<TabbedPage>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
