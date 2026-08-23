namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia

module MvuWindow =
    let WindowClosing =
        Attributes.Mvu.defineEvent "Window_Closing" (fun target -> (target :?> Window).Closing)

    let WindowClosed =
        Attributes.Mvu.defineRoutedEvent "Window_Closed" Window.WindowClosedEvent

    let WindowOpened =
        Attributes.Mvu.defineRoutedEvent "Window_Opened" Window.WindowOpenedEvent

type MvuWindowModifiers =
    /// <summary>Listens to the Window WindowClosing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is closing.</param>
    [<Extension>]
    static member inline onWindowClosing(this: WidgetBuilder<'msg, #IFabWindow>, fn: WindowClosingEventArgs -> 'msg) =
        this.AddScalar(MvuWindow.WindowClosing.WithValue(fn))

    /// <summary>Listens to the Window WindowClosed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is closed.</param>
    [<Extension>]
    static member inline onWindowClosed(this: WidgetBuilder<'msg, #IFabWindow>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MvuWindow.WindowClosed.WithValue(fn))

    /// <summary>Listens to the Window WindowOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is opened.</param>
    [<Extension>]
    static member inline onWindowOpened(this: WidgetBuilder<'msg, #IFabWindow>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MvuWindow.WindowOpened.WithValue(fn))
