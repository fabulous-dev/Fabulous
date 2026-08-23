namespace Fabulous.Avalonia

open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

[<AutoOpen>]
module ComponentRepeatButtonBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a RepeatButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="msg">Raised when the button is clicked.</param>
        static member RepeatButton(text: string, msg: RoutedEventArgs -> unit) =
            WidgetBuilder<'msg, IFabRepeatButton>(RepeatButton.WidgetKey, ContentControl.ContentString.WithValue(text), ComponentButton.Clicked.WithValue(msg))

        /// <summary>Creates a RepeatButton widget.</summary>
        /// <param name="content">The content to display.</param>
        /// M<param name="fn">Raised when the button is clicked.</param>
        static member RepeatButton(fn: RoutedEventArgs -> unit, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabRepeatButton>(
                RepeatButton.WidgetKey,
                AttributesBundle(
                    StackList.one(ComponentButton.Clicked.WithValue(fn)),
                    [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    [||],
                    [||]
                )
            )
