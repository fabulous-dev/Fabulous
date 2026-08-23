namespace Fabulous.Avalonia

open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

[<AutoOpen>]
module MvuDropDownButtonBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a DropDownButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the DropDownButton is clicked.</param>
        static member DropDownButton(text: string, fn: RoutedEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabDropDownButton>(DropDownButton.WidgetKey, ContentControl.ContentString.WithValue(text), MvuButton.Clicked.WithValue(fn))

        /// <summary>Creates a DropDownButton widget.</summary>
        /// <param name="fn">Raised when the DropDownButton is clicked.</param>
        /// <param name="content">The content of the DropDownButton.</param>
        static member DropDownButton(fn: RoutedEventArgs -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabDropDownButton>(
                DropDownButton.WidgetKey,
                AttributesBundle(StackList.one(MvuButton.Clicked.WithValue(fn)), [| ContentControl.ContentWidget.WithValue(content.Compile()) |], [||], [||])
            )
