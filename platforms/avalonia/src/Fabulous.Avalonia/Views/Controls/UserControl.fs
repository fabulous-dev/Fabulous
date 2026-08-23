namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabUserControl =
    inherit IFabContentControl

module UserControl =
    let WidgetKey = Widgets.register<UserControl>()

[<AutoOpen>]
module UserControlBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a UserControl widget.</summary>
        /// <param name="content">The content of the UserControl.</param>
        static member UserControl(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabUserControl>(UserControl.WidgetKey, ContentControl.ContentWidget.WithValue(content.Compile()))

type UserControlModifiers =
    /// <summary>Link a ViewRef to access the direct UserControl control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabUserControl>, value: ViewRef<UserControl>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
