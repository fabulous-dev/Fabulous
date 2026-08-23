namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Notifications
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia

module ComponentNotificationCard =
    let NotificationClosed =
        Attributes.Component.defineRoutedEvent "NotificationCard_NotificationClosed" NotificationCard.NotificationClosedEvent

type ComponentNotificationCardModifiers =
    /// <summary>Listens to the NotificationCard NotificationClosed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the NotificationCard is closed.</param>
    [<Extension>]
    static member inline onNotificationClosed(this: WidgetBuilder<'msg, #IFabNotificationCard>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentNotificationCard.NotificationClosed.WithValue(fn))
