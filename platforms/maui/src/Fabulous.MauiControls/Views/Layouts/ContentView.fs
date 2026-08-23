namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls

type IFabContentView =
    inherit IFabTemplatedView

module ContentView =
    let WidgetKey = Widgets.register<ContentView>()

    let Content = Attributes.defineBindableWidget ContentView.ContentProperty

[<AutoOpen>]
module ContentViewBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a ContentView widget with a content</summary>
        /// <param name="content">The content widget</param>
        static member inline ContentView<'msg, 'marker when 'msg: equality and 'marker :> IFabView>(content: WidgetBuilder<'msg, 'marker>) =
            WidgetHelpers.buildWidgets<'msg, IFabContentView> ContentView.WidgetKey [| ContentView.Content.WithValue(content.Compile()) |]

[<Extension>]
type ContentViewModifiers =
    /// <summary>Link a ViewRef to access the direct ContentView control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabContentView>, value: ViewRef<ContentView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
