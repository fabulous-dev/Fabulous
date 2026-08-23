namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

module ComponentExpander =
    let ExpandedChanged =
        Attributes.Component.defineAvaloniaPropertyWithChangedEvent' "Expander_IsExpandedChanged" Expander.IsExpandedProperty

    let Collapsing =
        Attributes.Component.defineEvent "Expander_Collapsing" (fun target -> (target :?> Expander).Collapsing)

    let Expanding =
        Attributes.Component.defineEvent "Expander_Expanding" (fun target -> (target :?> Expander).Expanding)

[<AutoOpen>]
module ComponentExpanderBuilders =
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

type ComponentExpanderModifiers =
    /// <summary>Listens to the Expander ExpandedChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="isExpanded">The IsExpanded value.</param>
    /// <param name="fn">Raised when the ExpandedChanged event fires.</param>
    [<Extension>]
    static member inline onExpandedChanged(this: WidgetBuilder<'msg, #IFabExpander>, isExpanded: bool, fn: bool -> unit) =
        this.AddScalar(ComponentExpander.ExpandedChanged.WithValue(ComponentValueEventData.create isExpanded fn))

    /// <summary>Listens to the Expander Collapsing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Collapsing event fires.</param>
    [<Extension>]
    static member inline onCollapsing(this: WidgetBuilder<'msg, #IFabExpander>, fn: CancelRoutedEventArgs -> unit) =
        this.AddScalar(ComponentExpander.Collapsing.WithValue(fn))

    /// <summary>Listens to the Expander Expanding event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Expanding event fires.</param>
    [<Extension>]
    static member inline onExpanding(this: WidgetBuilder<'msg, #IFabExpander>, fn: CancelRoutedEventArgs -> unit) =
        this.AddScalar(ComponentExpander.Expanding.WithValue(fn))
