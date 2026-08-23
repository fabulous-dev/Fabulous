namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia

module ComponentSelectableTextBlock =
    let CopyingToClipboard =
        Attributes.Component.defineEvent "SelectableTextBlock_CopyingToClipboard" (fun target -> (target :?> SelectableTextBlock).CopyingToClipboard)

[<AutoOpen>]
module ComponentSelectableTextBlockBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a SelectableTextBlock widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the user copies the text to the clipboard.</param>
        static member inline SelectableTextBlock(text: string, fn: RoutedEventArgs -> unit) =
            WidgetBuilder<'msg, IFabSelectableTextBlock>(
                SelectableTextBlock.WidgetKey,
                TextBlock.Text.WithValue(text),
                ComponentSelectableTextBlock.CopyingToClipboard.WithValue(fn)
            )

        /// <summary>Creates a SelectableTextBlock widget.</summary>
        /// <param name="fn">Raised when the user copies the text to the clipboard.</param>
        static member inline SelectableTextBlock(fn: RoutedEventArgs -> unit) =
            CollectionBuilder<'msg, IFabSelectableTextBlock, IFabInline>(
                SelectableTextBlock.WidgetKey,
                TextBlock.Inlines,
                ComponentSelectableTextBlock.CopyingToClipboard.WithValue(fn)
            )
