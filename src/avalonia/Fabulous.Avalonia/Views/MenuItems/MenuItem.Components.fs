namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls

open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

module ComponentMenuItem =
    let Click =
        Attributes.Component.defineEvent "MenuItem_Clicked" (fun target -> (target :?> MenuItem).Click)

    let PointerEnteredItem =
        Attributes.Component.defineEvent "MenuItem_PointerEnteredItem" (fun target -> (target :?> MenuItem).PointerEnteredItem)

    let PointerExitedItem =
        Attributes.Component.defineEvent "MenuItem_PointerExitedItem" (fun target -> (target :?> MenuItem).PointerExitedItem)

    let SubmenuOpened =
        Attributes.Component.defineAvaloniaPropertyWithChangedEvent' "MvuMenuItem_SubmenuOpened" MenuItem.IsSubMenuOpenProperty

type ComponentMenuItemModifiers =
    /// <summary>Listens to the MenuItem PointerEnteredItem event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PointerEnteredItem event is fired.</param>
    [<Extension>]
    static member inline onPointerEnteredItem(this: WidgetBuilder<'msg, #IFabMenuItem>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentMenuItem.PointerEnteredItem.WithValue(fn))

    /// <summary>Listens to the MenuItem PointerExitedItem event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PointerExitedItem event is fired.</param>
    [<Extension>]
    static member inline onPointerExitedItem(this: WidgetBuilder<'msg, #IFabMenuItem>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentMenuItem.PointerExitedItem.WithValue(fn))

    /// <summary>Listens to the MenuItem SubmenuOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">Whether the Submenu is open.</param>
    /// <param name="fn">Raised when the SubmenuClosed event is fired.</param>
    [<Extension>]
    static member inline onSubmenuOpened(this: WidgetBuilder<'msg, #IFabMenuItem>, value: bool, fn: bool -> unit) =
        this.AddScalar(ComponentMenuItem.SubmenuOpened.WithValue(ComponentValueEventData.create value fn))

    /// <summary>Listens to the MenuItem Click event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the MenuItem is clicked.</param>
    [<Extension>]
    static member inline onClick(this: WidgetBuilder<'msg, #IFabMenuItem>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentMenuItem.Click.WithValue(fn))
