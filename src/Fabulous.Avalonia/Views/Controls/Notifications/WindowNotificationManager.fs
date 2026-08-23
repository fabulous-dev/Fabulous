namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Notifications
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabWindowNotificationManager =
    inherit IFabTemplatedControl

module WindowNotificationManager =
    let WidgetKey =
        Widgets.registerWithFactory(fun _ -> WindowNotificationManager(null))

    let Position =
        Attributes.defineAvaloniaPropertyWithEquality WindowNotificationManager.PositionProperty

    let MaxItems =
        Attributes.defineAvaloniaPropertyWithEquality WindowNotificationManager.MaxItemsProperty

[<AutoOpen>]
module WindowNotificationManagerBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a WindowNotificationManager widget.</summary>
        static member WindowNotificationManager(viewRef: ViewRef<WindowNotificationManager>) =
            WidgetBuilder<'msg, IFabWindowNotificationManager>(WindowNotificationManager.WidgetKey, ViewRefAttributes.ViewRef.WithValue(viewRef.Unbox))


type WindowNotificationManagerModifiers =
    /// <summary>Sets the MaxItems property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MaxItems value.</param>
    [<Extension>]
    static member inline maxItems(this: WidgetBuilder<'msg, #IFabWindowNotificationManager>, value: int) =
        this.AddScalar(WindowNotificationManager.MaxItems.WithValue(value))

    /// <summary>Sets the Position property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Position value.</param>
    [<Extension>]
    static member inline position(this: WidgetBuilder<'msg, #IFabWindowNotificationManager>, value: NotificationPosition) =
        this.AddScalar(WindowNotificationManager.Position.WithValue(value))
