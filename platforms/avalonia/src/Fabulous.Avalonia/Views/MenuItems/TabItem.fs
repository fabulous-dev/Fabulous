namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabTabItem =
    inherit IFabHeaderedContentControl

module TabItem =
    let WidgetKey = Widgets.register<TabItem>()

    let TabStripPlacement =
        Attributes.defineAvaloniaPropertyWithEquality TabItem.TabStripPlacementProperty

[<AutoOpen>]
module TabItemBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TabItem widget.</summary>
        /// <param name="header">The header of the TabItem.</param>
        /// <param name="content">The content of the TabItem.</param>
        static member TabItem(header: string, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabTabItem>(
                TabItem.WidgetKey,
                AttributesBundle(
                    StackList.one(HeaderedContentControl.HeaderString.WithValue(header)),
                    [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    [||],
                    [||]
                )
            )

        /// <summary>Creates a TabItem widget.</summary>
        /// <param name="header">The header of the TabItem.</param>
        /// <param name="content">The content of the TabItem.</param>
        static member TabItem(header: WidgetBuilder<'msg, #IFabControl>, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabTabItem>(
                TabItem.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile())
                       ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    [||],
                    [||]
                )
            )


type TabItemModifiers =
    /// <summary>Sets the TabStripPlacement property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TabStripPlacement value.</param>
    [<Extension>]
    static member inline tabStripPlacement(this: WidgetBuilder<'msg, #IFabTabItem>, value: Dock) =
        this.AddScalar(TabItem.TabStripPlacement.WithValue(value))

    /// <summary>Link a ViewRef to access the direct TabItem control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTabItem>, value: ViewRef<TabItem>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
