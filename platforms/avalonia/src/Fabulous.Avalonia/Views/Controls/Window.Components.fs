namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia

module ComponentWindow =
    let WindowClosing =
        Attributes.Component.defineEvent "Window_Closing" (fun target -> (target :?> Window).Closing)

    let WindowClosed =
        Attributes.Component.defineRoutedEvent "Window_Closed" Window.WindowClosedEvent

    let WindowOpened =
        Attributes.Component.defineRoutedEvent "Window_Opened" Window.WindowOpenedEvent

type ComponentWindowModifiers =
    /// <summary>Listens to the Window WindowClosing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is closing.</param>
    [<Extension>]
    static member inline onWindowClosing(this: WidgetBuilder<'msg, #IFabWindow>, fn: WindowClosingEventArgs -> unit) =
        this.AddScalar(ComponentWindow.WindowClosing.WithValue(fn))

    /// <summary>Listens to the Window WindowClosed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is closed.</param>
    [<Extension>]
    static member inline onWindowClosed(this: WidgetBuilder<'msg, #IFabWindow>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentWindow.WindowClosed.WithValue(fn))

    /// <summary>Listens to the Window WindowOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is opened.</param>
    [<Extension>]
    static member inline onWindowOpened(this: WidgetBuilder<'msg, #IFabWindow>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentWindow.WindowOpened.WithValue(fn))
