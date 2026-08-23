namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls

open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia

module MvuMenuItem =
    let Click =
        Attributes.Mvu.defineEvent "MenuItem_Clicked" (fun target -> (target :?> MenuItem).Click)

    let PointerEnteredItem =
        Attributes.Mvu.defineEvent "MenuItem_PointerEnteredItem" (fun target -> (target :?> MenuItem).PointerEnteredItem)

    let PointerExitedItem =
        Attributes.Mvu.defineEvent "MenuItem_PointerExitedItem" (fun target -> (target :?> MenuItem).PointerExitedItem)

    let SubmenuOpened =
        Attributes.Mvu.defineAvaloniaPropertyWithChangedEvent' "MvuMenuItem_SubmenuOpened" MenuItem.IsSubMenuOpenProperty

type MvuMenuItemModifiers =
    /// <summary>Listens to the MenuItem PointerEnteredItem event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PointerEnteredItem event is fired.</param>
    [<Extension>]
    static member inline onPointerEnteredItem(this: WidgetBuilder<'msg, #IFabMenuItem>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MvuMenuItem.PointerEnteredItem.WithValue(fn))

    /// <summary>Listens to the MenuItem PointerExitedItem event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PointerExitedItem event is fired.</param>
    [<Extension>]
    static member inline onPointerExitedItem(this: WidgetBuilder<'msg, #IFabMenuItem>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MvuMenuItem.PointerExitedItem.WithValue(fn))

    /// <summary>Listens to the MenuItem SubmenuOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">Whether the Submenu is open.</param>
    /// <param name="fn">Raised when the SubmenuOpened event is fired.</param>
    [<Extension>]
    static member inline onSubmenuOpened(this: WidgetBuilder<'msg, #IFabMenuItem>, value: bool, fn: bool -> 'msg) =
        this.AddScalar(MvuMenuItem.SubmenuOpened.WithValue(ValueEventData.create value fn))

    /// <summary>Listens to the MenuItem Click event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the MenuItem is clicked.</param>
    [<Extension>]
    static member inline onClick(this: WidgetBuilder<'msg, #IFabMenuItem>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MvuMenuItem.Click.WithValue(fn))
