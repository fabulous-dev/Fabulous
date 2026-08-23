namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Avalonia.Interactivity
open Fabulous.Avalonia

module MvuTextBox =
    let TextChanged =
        Attributes.Mvu.defineAvaloniaPropertyWithChangedEvent' "TextBox_TextChanged" TextBox.TextProperty

    let CopyingToClipboard =
        Attributes.Mvu.defineEvent<RoutedEventArgs> "TextBox_CopyingToClipboardEvent" (fun target -> (target :?> TextBox).CopyingToClipboard)

    let CuttingToClipboard =
        Attributes.Mvu.defineEvent<RoutedEventArgs> "TextBox_CuttingToClipboard" (fun target -> (target :?> TextBox).CuttingToClipboard)

    let PastingFromClipboard =
        Attributes.Mvu.defineEvent<RoutedEventArgs> "TextBox_PastingFromClipboardEvent" (fun target -> (target :?> TextBox).PastingFromClipboard)

[<AutoOpen>]
module MvuTextBoxBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TextBox widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the text changes.</param>
        static member inline TextBox(text: string, fn: string -> 'msg) =
            WidgetBuilder<'msg, IFabTextBox>(TextBox.WidgetKey, MvuTextBox.TextChanged.WithValue(ValueEventData.create text fn))

type MvuTextBoxModifiers =
    /// /// <summary>Listens to the TexBox CopyingToClipboard event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the CopyingToClipboard changes.</param>
    [<Extension>]
    static member inline onCopyingToClipboard(this: WidgetBuilder<'msg, #IFabTextBox>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MvuTextBox.CopyingToClipboard.WithValue(fn))

    /// <summary>Listens to the TexBox CuttingToClipboard event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the CuttingToClipboard changes.</param>
    [<Extension>]
    static member inline onCuttingToClipboard(this: WidgetBuilder<'msg, #IFabTextBox>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MvuTextBox.CuttingToClipboard.WithValue(fn))

    /// <summary>Listens to the TexBox PastingFromClipboard event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PastingFromClipboard changes.</param>
    [<Extension>]
    static member inline onPastingFromClipboard(this: WidgetBuilder<'msg, #IFabTextBox>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MvuTextBox.PastingFromClipboard.WithValue(fn))
