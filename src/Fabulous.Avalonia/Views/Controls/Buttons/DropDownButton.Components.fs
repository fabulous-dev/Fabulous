namespace Fabulous.Avalonia

open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

[<AutoOpen>]
module ComponentDropDownButtonBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a DropDownButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="msg">Raised when the DropDownButton is clicked.</param>
        static member DropDownButton(text: string, msg: RoutedEventArgs -> unit) =
            WidgetBuilder<'msg, IFabDropDownButton>(
                DropDownButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ComponentButton.Clicked.WithValue(msg)
            )

        /// <summary>Creates a DropDownButton widget.</summary>
        /// <param name="msg">Raised when the DropDownButton is clicked.</param>
        /// <param name="content">The content of the DropDownButton.</param>
        static member DropDownButton(msg: RoutedEventArgs -> unit, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabDropDownButton>(
                DropDownButton.WidgetKey,
                AttributesBundle(
                    StackList.one(ComponentButton.Clicked.WithValue(msg)),
                    [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    [||],
                    [||]
                )
            )
