namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabHeaderedContentControl =
    inherit IFabContentControl

module HeaderedContentControl =
    let WidgetKey = Widgets.register<HeaderedContentControl>()

    let HeaderString =
        Attributes.defineAvaloniaProperty<string, obj> HeaderedContentControl.HeaderProperty box ScalarAttributeComparers.equalityCompare

    let HeaderWidget =
        Attributes.defineAvaloniaPropertyWidget HeaderedContentControl.HeaderProperty

[<AutoOpen>]
module HeaderedContentControlBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a HeaderedContentControl widget.</summary>
        /// <param name="header">The header string.</param>
        /// <param name="content">The content widget.</param>
        static member HeaderedContentControl(header: string, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabHeaderedContentControl>(
                HeaderedContentControl.WidgetKey,
                AttributesBundle(
                    StackList.one(HeaderedContentControl.HeaderString.WithValue(header)),
                    [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    [||],
                    [||]
                )
            )

        /// <summary>Creates a HeaderedContentControl widget.</summary>
        /// <param name="header">The header widget.</param>
        /// <param name="content">The content widget.</param>
        static member HeaderedContentControl(header: WidgetBuilder<'msg, #IFabControl>, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabHeaderedContentControl>(
                HeaderedContentControl.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile())
                       ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    [||],
                    [||]
                )
            )

        /// <summary>Creates a HeaderedContentControl widget.</summary>
        /// <param name="header">The header string.</param>
        /// <param name="content">The content string.</param>
        static member HeaderedContentControl(header: string, content: string) =
            WidgetBuilder<'msg, IFabHeaderedContentControl>(
                HeaderedContentControl.WidgetKey,
                HeaderedContentControl.HeaderString.WithValue(header),
                ContentControl.ContentString.WithValue(content)
            )

type HeaderedContentControlModifiers =

    /// <summary>Link a ViewRef to access the direct HeaderedContentControl control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabHeaderedContentControl>, value: ViewRef<HeaderedContentControl>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
