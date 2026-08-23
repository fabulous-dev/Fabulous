namespace Gallery

open System
open System.Diagnostics
open Avalonia
open Avalonia.Controls.Notifications
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Threading
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module NotificationsPage =
    type Model =
        { NotificationManager: WindowNotificationManager
          NotificationPosition: NotificationPosition
          ShowInlined: bool }

    type Msg =
        | ShowBasicNotification
        | ShowINotification
        | ShowYesNoNotification
        | ShowNativeNotification
        | ShowAsyncCompletedNotification
        | ShowAsyncStatusNotifications
        | ToggleInlinedNotification
        | NotifyInfo of string
        | AttachedToVisualTreeChanged of VisualTreeAttachmentEventArgs // event after which WindowNotificationManager is available
        | ControlNotificationsShow
        | NotificationShown
        | PositionChanged of SelectionChangedEventArgs

    let notifyOneAsync () =
        Cmd.OfAsync.msg(
            async {
                do! Async.Sleep 1000
                return NotifyInfo "async operation completed"
            }
        )

    let notifyAsyncStatusUpdates () =
        Cmd.ofEffect(fun dispatch ->
            async {
                // This will queue up msgs/notifications that will be dispatched by the Fabulous runner
                dispatch(NotifyInfo "started")
                do! Async.Sleep(1000)
                dispatch(NotifyInfo "5")
                do! Async.Sleep 1000
                dispatch(NotifyInfo "4")
                do! Async.Sleep 1000
                dispatch(NotifyInfo "3")
                do! Async.Sleep 1000
                dispatch(NotifyInfo "2")
                do! Async.Sleep 1000
                dispatch(NotifyInfo "1")
                do! Async.Sleep 1000
                dispatch(NotifyInfo "completed")
            }
            |> Async.Start)

    let showNotification (notificationManager: WindowNotificationManager) notification =
        Cmd.ofEffect(fun dispatch ->
            Dispatcher.UIThread.Post(fun () ->
                notificationManager.Show(notification)
                dispatch(NotificationShown)))

    let notifyComponent<'msg, 'marker when 'msg: equality>
        (notificationManager: WindowNotificationManager)
        (content: WidgetBuilder<'msg, 'marker>)
        : Cmd<'msg> =
        Cmd.ofEffect(fun dispatch ->
            Dispatcher.UIThread.Post(fun () ->
                // Compile with the real dispatcher so events inside the notification can send messages
                let widget = content.Compile()
                let widgetDef = WidgetDefinitionStore.get widget.Key
                let logger = ProgramDefaults.defaultLogger()
                let syncAction = ViewHelpers.defaultSyncAction

                let treeContext: ViewTreeContext =
                    { CanReuseView = ViewHelpers.canReuseView
                      GetViewNode = ViewNode.get
                      GetComponent = Component.get
                      SetComponent = Component.set
                      SyncAction = syncAction
                      Logger = logger
                      Dispatch = (fun m -> dispatch(unbox m)) }

                let envContext = new EnvironmentContext(logger)

                let struct (_node, view) =
                    widgetDef.CreateView(widget, envContext, treeContext, ValueNone)

                notificationManager.Show(view, NotificationType.Warning, TimeSpan.Zero)))

    let controlNotificationsRef = ViewRef<WindowNotificationManager>()

    let init () =
        { NotificationManager = null
          NotificationPosition = NotificationPosition.TopRight
          ShowInlined = false },
        []

    let private createYesNoQuestion title question =
        InlinedYesNoQuestion(title, question, NotifyInfo "Wise choice.", NotifyInfo "Why wouldn't you?")

    let update msg model =
        match msg with
        | ShowBasicNotification ->
            model,
            Notification("Avalonia supports basic Notifications", "via the built-in Notification type.", NotificationType.Information)
            |> showNotification model.NotificationManager

        | ShowINotification ->
            model,
            { new INotification with
                member this.Title = "You can implement custom Notifications"
                member this.Message = "via the INotification interface."
                member this.Expiration = TimeSpan.FromSeconds(5.)
                member this.OnClick = Action(fun _ -> Console.WriteLine("Clicked"))
                member this.OnClose = Action(fun _ -> Console.WriteLine("Closed"))
                member this.Type = NotificationType.Error }
            |> showNotification model.NotificationManager

        | ShowYesNoNotification ->
            model,
            createYesNoQuestion "Can you dig it?" "You can use standard widgets in notifications!"
            |> notifyComponent model.NotificationManager

        | ShowNativeNotification ->
            model,
            Notification("Error", "Native Notifications are not quite ready. Coming soon.", NotificationType.Error)
            |> showNotification model.NotificationManager

        | ShowAsyncCompletedNotification -> model, notifyOneAsync()
        | ShowAsyncStatusNotifications -> model, notifyAsyncStatusUpdates()
        | ToggleInlinedNotification ->
            { model with
                ShowInlined = not model.ShowInlined },
            Cmd.none

        | NotifyInfo message ->
            model,
            Notification(message, "", NotificationType.Information)
            |> showNotification model.NotificationManager

        (*  WindowNotificationManager can't be used immediately after creating it,
            so we need to wait for it to be attached to the visual tree.
            See https://github.com/AvaloniaUI/Avalonia/issues/5442 *)
        | AttachedToVisualTreeChanged _ ->
            { model with
                NotificationManager = FabApplication.Current.WindowNotificationManager },
            Cmd.none

        | ControlNotificationsShow ->
            model, showNotification controlNotificationsRef.Value (Notification("Control Notifications", "This notification is shown by the control itself."))

        | NotificationShown -> model, Cmd.none

        | PositionChanged args ->
            let control = args.Source :?> ComboBox
            let selectedItem = control.SelectedItem :?> ComboBoxItem
            let position = Enum.Parse<NotificationPosition>(selectedItem.Content.ToString())

            { model with
                NotificationPosition = position },
            Cmd.none

    let program =
        Program.statefulWithCmd init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component("NotificationsPage") {
            let! model = Context.Mvu program

            (Grid() {
                Dock() {
                    TextBlock("TopLevel bound notification manager")
                        .dock(Dock.Top)
                        .margin(20.)
                        .classes([ "h2" ])
                        .textWrapping(TextWrapping.Wrap)

                    Button("A basic Notification", ShowBasicNotification)
                        .dock(Dock.Top)

                    Button("A custom INotification", ShowINotification)
                        .dock(Dock.Top)

                    Button("A Managed Notification with custom content", ShowYesNoNotification)
                        .dock(Dock.Top)

                    Button("Notify async operation completed", ShowAsyncCompletedNotification)
                        .dock(Dock.Top)

                    Button("Notify status updates from async operation", ShowAsyncStatusNotifications)
                        .dock(Dock.Top)

                    Button("Toggle inlined notifications", ToggleInlinedNotification)
                        .dock(Dock.Top)

                    TextBlock("Widget-only notification manager")
                        .dock(Dock.Top)
                        .margin(20.)
                        .classes([ "h2" ])
                        .textWrapping(TextWrapping.Wrap)

                    (HStack(5) {
                        Button("Show widget-only notification", ControlNotificationsShow)
                            .horizontalAlignment(HorizontalAlignment.Left)

                        Label "on the"

                        (ComboBox() {
                            ComboBoxItem(nameof(NotificationPosition.TopRight))
                            ComboBoxItem(nameof(NotificationPosition.TopLeft))
                            ComboBoxItem(nameof(NotificationPosition.BottomRight))
                            ComboBoxItem(nameof(NotificationPosition.BottomLeft))
                        })
                            .selectedIndex(0)
                            .onSelectionChanged(PositionChanged)
                    })
                        .dock(Dock.Top)

                    (createYesNoQuestion "Can you believe it?" "You can also roll your own inlined dialogs using standard widgets.")
                        .isVisible(model.ShowInlined)
                        .dock(Dock.Top)

                    if model.ShowInlined then
                        NotificationCard("I was here all along, just hidden!")
                            .size(300., 70.)
                            .dock(Dock.Top)
                            .padding(10)
                            .borderBrush(SolidColorBrush(Colors.Blue))
                }

                (*  Use the WindowNotificationManager widget to create a NotificationManager
                    separate from the FabApplication.Current.WindowNotificationManager
                    allowing you to control e.g., the Position of specific notifications. *)
                WindowNotificationManager(controlNotificationsRef)
                    .position(model.NotificationPosition)
                    .dock(Dock.Top)
                    .maxItems(3)
            })
                .onAttachedToVisualTree(AttachedToVisualTreeChanged)
        }
