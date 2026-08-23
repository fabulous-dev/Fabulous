namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Notifications
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia

module MvuNotificationCard =
    let NotificationClosed =
        Attributes.Mvu.defineRoutedEvent "NotificationCard_NotificationClosed" NotificationCard.NotificationClosedEvent

type MvuNotificationCardModifiers =
    /// <summary>Listens to the NotificationCard NotificationClosed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the NotificationCard is closed.</param>
    [<Extension>]
    static member inline onNotificationClosed(this: WidgetBuilder<'msg, #IFabNotificationCard>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MvuNotificationCard.NotificationClosed.WithValue(fn))
