namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia

module MvuSelectableTextBlock =
    let CopyingToClipboard =
        Attributes.Mvu.defineEvent "SelectableTextBlock_CopyingToClipboard" (fun target -> (target :?> SelectableTextBlock).CopyingToClipboard)

[<AutoOpen>]
module MvuSelectableTextBlockBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a SelectableTextBlock widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the user copies the text to the clipboard.</param>
        static member inline SelectableTextBlock(text: string, fn: RoutedEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabSelectableTextBlock>(
                SelectableTextBlock.WidgetKey,
                TextBlock.Text.WithValue(text),
                MvuSelectableTextBlock.CopyingToClipboard.WithValue(fn)
            )

        /// <summary>Creates a SelectableTextBlock widget.</summary>
        /// <param name="fn">Raised when the user copies the text to the clipboard.</param>
        static member inline SelectableTextBlock(fn: RoutedEventArgs -> 'msg) =
            CollectionBuilder<'msg, IFabSelectableTextBlock, IFabInline>(
                SelectableTextBlock.WidgetKey,
                TextBlock.Inlines,
                MvuSelectableTextBlock.CopyingToClipboard.WithValue(fn)
            )
