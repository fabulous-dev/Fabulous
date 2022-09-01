namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui
open Microsoft.Maui.Controls

type IContentPage =
    inherit IPage

module ContentPage =
    let WidgetKey = Widgets.register<FabulousContentPage>()

    let Content =
        Attributes.defineBindableWidget ContentPage.ContentProperty

    let SizeAllocated =
        Attributes.defineEvent<SizeAllocatedEventArgs>
            "ContentPage_SizeAllocated"
            (fun target -> (target :?> FabulousContentPage).SizeAllocated)

[<AutoOpen>]
module ContentPageBuilders =
    type Fabulous.Maui.View with
        static member inline ContentPage<'msg, 'marker when 'marker :> IView>
            (
                title: string,
                content: WidgetBuilder<'msg, 'marker>
            ) =
            WidgetBuilder<'msg, IContentPage>(
                ContentPage.WidgetKey,
                AttributesBundle(
                    StackList.one(Page.Title.WithValue(title)),
                    ValueSome [| ContentPage.Content.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type ContentPageModifiers =
    [<Extension>]
    static member inline onSizeAllocated(this: WidgetBuilder<'msg, #IContentPage>, fn: SizeAllocatedEventArgs -> 'msg) =
        this.AddScalar(ContentPage.SizeAllocated.WithValue(fn >> box))

    /// <summary>Link a ViewRef to access the direct ContentPage control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IContentPage>, value: ViewRef<ContentPage>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
