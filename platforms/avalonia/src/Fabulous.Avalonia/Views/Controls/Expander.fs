namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Animation
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabExpander =
    inherit IFabHeaderedContentControl

module Expander =
    let WidgetKey = Widgets.register<Expander>()

    let ContentTransition =
        Attributes.defineAvaloniaPropertyWithEquality Expander.ContentTransitionProperty

    let ExpandDirection =
        Attributes.defineAvaloniaPropertyWithEquality Expander.ExpandDirectionProperty

    let IsExpanded =
        Attributes.defineAvaloniaPropertyWithEquality Expander.IsExpandedProperty

[<AutoOpen>]
module ExpanderBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Expander widget.</summary>
        /// <param name="header">The header of the expander.</param>
        /// <param name="content">The content of the expander.</param>
        static member Expander(header: string, content: string) =
            WidgetBuilder<'msg, IFabExpander>(
                Expander.WidgetKey,
                HeaderedContentControl.HeaderString.WithValue(header),
                ContentControl.ContentString.WithValue(content)
            )

        /// <summary>Creates a Expander widget.</summary>
        /// <param name="header">The header of the expander.</param>
        /// <param name="content">The content of the expander.</param>
        static member Expander(header: WidgetBuilder<'msg, #IFabControl>, content: string) =
            WidgetBuilder<'msg, IFabExpander>(
                Expander.WidgetKey,
                AttributesBundle(
                    StackList.one(ContentControl.ContentString.WithValue(content)),
                    [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile()) |],
                    [||],
                    [||]
                )
            )

        /// <summary>Creates a Expander widget.</summary>
        /// <param name="header">The header of the expander.</param>
        /// <param name="content">The content of the expander.</param>
        static member Expander(header: string, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabExpander>(
                Expander.WidgetKey,
                AttributesBundle(
                    StackList.one(HeaderedContentControl.HeaderString.WithValue(header)),
                    [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    [||],
                    [||]
                )
            )

        /// <summary>Creates a Expander widget.</summary>
        /// <param name="header">The header of the expander.</param>
        /// <param name="content">The content of the expander.</param>
        static member Expander(header: WidgetBuilder<'msg, #IFabControl>, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabExpander>(
                Expander.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile())
                       ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    [||],
                    [||]
                )
            )

type ExpanderModifiers =
    /// <summary>Sets the ContentTransition property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ContentTransition value.</param>
    [<Extension>]
    static member inline contentTransition(this: WidgetBuilder<'msg, #IFabExpander>, value: IPageTransition) =
        this.AddScalar(Expander.ContentTransition.WithValue(value))

    /// <summary>Sets the ExpandDirection property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ExpandDirection value.</param>
    [<Extension>]
    static member inline expandDirection(this: WidgetBuilder<'msg, #IFabExpander>, value: ExpandDirection) =
        this.AddScalar(Expander.ExpandDirection.WithValue(value))

    /// <summary>Sets the IsExpanded property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsExpanded value.</param>
    [<Extension>]
    static member inline isExpanded(this: WidgetBuilder<'msg, #IFabExpander>, value: bool) =
        this.AddScalar(Expander.IsExpanded.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Expander control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabExpander>, value: ViewRef<Expander>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
