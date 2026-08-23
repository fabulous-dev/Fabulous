namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module MvuItemsControl =
    let ContainerClearing =
        Attributes.Mvu.defineEvent "ItemsControl_ContainerClearing" (fun target -> (target :?> ItemsControl).ContainerClearing)

    let ContainerIndexChanged =
        Attributes.Mvu.defineEvent "ItemsControl_ContainerIndexChanged" (fun target -> (target :?> ItemsControl).ContainerIndexChanged)

    let ContainerPrepared =
        Attributes.Mvu.defineEvent "ItemsControl_ContainerPrepared" (fun target -> (target :?> ItemsControl).ContainerPrepared)

type MvuItemsControlModifiers =
    /// <summary>Listens to the ItemsControl ContainerClearing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the actual theme variant changes.</param>
    [<Extension>]
    static member inline onContainerClearing(this: WidgetBuilder<'msg, #IFabItemsControl>, fn: ContainerClearingEventArgs -> 'msg) =
        this.AddScalar(MvuItemsControl.ContainerClearing.WithValue(fn))

    /// <summary>Listens to the ItemsControl ContainerIndexChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the index for the item it represents has changed.</param>
    [<Extension>]
    static member inline onContainerIndexChanged(this: WidgetBuilder<'msg, #IFabItemsControl>, fn: ContainerIndexChangedEventArgs -> 'msg) =
        this.AddScalar(MvuItemsControl.ContainerIndexChanged.WithValue(fn))

    /// <summary>Listens to the ItemsControl ContainerPrepared event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a container is prepared for use.</param>
    [<Extension>]
    static member inline onContainerPrepared(this: WidgetBuilder<'msg, #IFabItemsControl>, fn: ContainerPreparedEventArgs -> 'msg) =
        this.AddScalar(MvuItemsControl.ContainerPrepared.WithValue(fn))
