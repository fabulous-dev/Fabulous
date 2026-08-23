namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

module ComponentTopLevel =
    let Opened =
        Attributes.Component.defineEventNoArg "TopLevel_OpenedEvent" (fun target -> (target :?> TopLevel).Opened)

    let Closed =
        Attributes.Component.defineEventNoArg "TopLevel_ClosedEvent" (fun target -> (target :?> TopLevel).Closed)

    let ScalingChanged =
        Attributes.Component.defineEventNoArg "TopLevel_ScalingChangedEvent" (fun target -> (target :?> TopLevel).ScalingChanged)

    let BackRequested =
        Attributes.Component.defineEvent "TopLevel_BackRequestedEvent" (fun target -> (target :?> TopLevel).BackRequested)

    let ActualThemeVariantChanged =
        Attributes.Component.defineEventNoArg "TopLevel_ThemeVariantChanged" (fun target -> (target :?> TopLevel).ActualThemeVariantChanged)

type ComponentTopLevelModifiers =
    /// <summary>Listens to the TopLevel ThemeVariantChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the actual theme variant changes.</param>
    [<Extension>]
    static member inline onActualThemeVariantChanged(this: WidgetBuilder<'msg, #IFabTopLevel>, fn: unit -> unit) =
        this.AddScalar(ComponentTopLevel.ActualThemeVariantChanged.WithValue(fn))

    /// <summary>Listens the TopLevel Opened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is opened.</param>
    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<'msg, #IFabTopLevel>, fn: unit -> unit) =
        this.AddScalar(ComponentTopLevel.Opened.WithValue(fn))

    /// <summary>Listens the TopLevel Closed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is closed.</param>
    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<'msg, #IFabTopLevel>, fn: unit -> unit) =
        this.AddScalar(ComponentTopLevel.Closed.WithValue(fn))

    /// <summary>Listens the TopLevel BackRequested event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the back button is pressed.</param>
    [<Extension>]
    static member inline onBackRequested(this: WidgetBuilder<'msg, #IFabTopLevel>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentTopLevel.BackRequested.WithValue(fn))

    /// <summary>Listens the TopLevel ScalingChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the TopLevel's scaling changes.</param>
    [<Extension>]
    static member inline onScalingChanged(this: WidgetBuilder<'msg, #IFabTopLevel>, fn: unit -> unit) =
        this.AddScalar(ComponentTopLevel.ScalingChanged.WithValue(fn))
