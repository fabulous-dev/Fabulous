namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type IContentView =
    inherit ITemplatedView

module ContentView =
    let WidgetKey = Widgets.register<ContentView>()

    let Content =
        Attributes.defineBindableWidget ContentView.ContentProperty

[<AutoOpen>]
module ContentViewBuilders =
    type Fabulous.Maui.View with
        static member inline ContentView<'msg, 'marker when 'marker :> IView>(content: WidgetBuilder<'msg, 'marker>) =
            WidgetHelpers.buildWidgets<'msg, IContentView>
                ContentView.WidgetKey
                [| ContentView.Content.WithValue(content.Compile()) |]

[<Extension>]
type ContentViewModifiers =
    /// <summary>Link a ViewRef to access the direct ContentView control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IContentView>, value: ViewRef<ContentView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
