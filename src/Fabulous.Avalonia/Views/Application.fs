namespace Fabulous.Avalonia

open System.Collections.Generic
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Controls.Notifications
open Avalonia.Media
open Avalonia.Rendering
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabApplication =
    inherit IFabElement

type FabApplication() =
    inherit Application()

    let _windows = List<FabWindow>()

    let mutable _mainView: Control = null

    let mutable _shutdownMode: ShutdownMode = ShutdownMode.OnLastWindowClose

    let mutable _onFrameworkInitialized: Application -> unit = fun _ -> ()

    member this.InternalWindows = _windows :> IList<FabWindow>

    member this.AddWindow(window: FabWindow) =
        _windows.Add(window)
        this.UpdateLifetime()

    member this.RemoveWindow(window: FabWindow) = _windows.Remove(window) |> ignore

    member this.FindWindowById(id: string) =
        _windows |> Seq.tryFind(fun w -> w.WindowId = id)

    member this.ShowWindow(id: string) =
        match this.FindWindowById(id) with
        | Some window -> window.Show()
        | None -> failwithf $"Window with id %s{id} not found"

    member this.HideWindow(id: string) =
        match this.FindWindowById(id) with
        | Some window -> window.Hide()
        | None -> failwithf $"Window with id %s{id} not found"

    member this.CloseWindow(id: string) =
        match this.FindWindowById(id) with
        | Some window -> window.Close()
        | None -> failwithf $"Window with id %s{id} not found"

    member this.OnFrameworkInitialized
        with get () = _onFrameworkInitialized
        and set value = _onFrameworkInitialized <- value

    override this.OnFrameworkInitializationCompleted() =
        this.OnFrameworkInitialized(this)
        base.OnFrameworkInitializationCompleted()

    member private this.UpdateLifetime() =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime when _windows.Count > 0 -> desktopLifetime.MainWindow <- _windows[0]
        | :? ISingleViewApplicationLifetime as singleViewLifetime -> singleViewLifetime.MainView <- _mainView
        | _ -> ()

    /// <summary>Gets the top-level window or view for the application.</summary>
    member this.TopLevel =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime when _windows.Count > 0 -> TopLevel.GetTopLevel(_windows[0])
        | :? ISingleViewApplicationLifetime when not(isNull _mainView) -> TopLevel.GetTopLevel(_mainView)
        | _ -> failwith "ApplicationLifetime is not supported"

    /// <summary> Initializes a new instance of the WindowNotificationManager class.</summary>
    member this.WindowNotificationManager =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime when _windows.Count > 0 -> WindowNotificationManager(TopLevel.GetTopLevel(_windows[0]))
        | :? ISingleViewApplicationLifetime when not(isNull _mainView) -> WindowNotificationManager(TopLevel.GetTopLevel(_mainView))
        | _ -> failwith "ApplicationLifetime is not supported"

    /// <summary>Gets the platform's clipboard implementation</summary>
    member this.Clipboard =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime when _windows.Count > 0 -> TopLevel.GetTopLevel(_windows[0]).Clipboard
        | :? ISingleViewApplicationLifetime when not(isNull _mainView) -> TopLevel.GetTopLevel(_mainView).Clipboard
        | _ -> failwith "ApplicationLifetime is not supported"

    /// <summary>File System storage service used for file pickers and bookmarks.</summary>
    member this.StorageProvider =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime when _windows.Count > 0 -> TopLevel.GetTopLevel(_windows[0]).StorageProvider
        | :? ISingleViewApplicationLifetime when not(isNull _mainView) -> TopLevel.GetTopLevel(_mainView).StorageProvider
        | _ -> failwith "ApplicationLifetime is not supported"

    /// <summary>Manages focus for the application.</summary>
    member this.FocusManager =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime when _windows.Count > 0 -> TopLevel.GetTopLevel(_windows[0]).FocusManager
        | :? ISingleViewApplicationLifetime when not(isNull _mainView) -> TopLevel.GetTopLevel(_mainView).FocusManager
        | _ -> failwith "ApplicationLifetime is not supported"

    /// <summary>Gets the platform-specific settings for the application.</summary>
    member this.PlatformSettings =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime when _windows.Count > 0 -> TopLevel.GetTopLevel(_windows[0]).PlatformSettings
        | :? ISingleViewApplicationLifetime when not(isNull _mainView) -> TopLevel.GetTopLevel(_mainView).PlatformSettings
        | _ -> failwith "ApplicationLifetime is not supported"

    /// <summary>Gets the platform-specific insets manager for the application.</summary>
    member this.InsetsManager =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime when _windows.Count > 0 -> TopLevel.GetTopLevel(_windows[0]).InsetsManager
        | :? ISingleViewApplicationLifetime when not(isNull _mainView) -> TopLevel.GetTopLevel(_mainView).InsetsManager
        | _ -> failwith "ApplicationLifetime is not supported"

    member this.MainView
        with get () = _mainView
        and set value =
            _mainView <- value
            this.UpdateLifetime()

    member this.ShutdownMode
        with get () =
            match this.ApplicationLifetime with
            | :? IClassicDesktopStyleApplicationLifetime as lifeTime -> lifeTime.ShutdownMode
            | _ -> failwith "ShutdownMode is not supported for this ApplicationLifetime"
        and set value = _shutdownMode <- value

    /// <summary>Gets the current application instance.</summary>
    static member Current = Application.Current :?> FabApplication

module ApplicationUpdaters =
    let mainViewApplyDiff (diff: WidgetDiff) (node: IViewNode) =
        let target = node.Target :?> FabApplication
        let childViewNode = node.TreeContext.GetViewNode(target.MainView)
        childViewNode.ApplyDiff(&diff)

    let mainViewUpdateNode (_: Widget voption) (currOpt: Widget voption) (node: IViewNode) =
        let target = node.Target :?> FabApplication

        match currOpt with
        | ValueNone -> target.MainView <- Unchecked.defaultof<_>
        | ValueSome widget ->
            let struct (_, view) = Helpers.createViewForWidget node widget
            target.MainView <- view :?> Control

module Application =
    let WidgetKey = Widgets.register<FabApplication>()

    let TrayIcons =
        Attributes.defineAvaloniaListWidgetCollection "TrayIcon_TrayIcons" (fun target ->
            let target = target :?> FabApplication
            let trayIcons = TrayIcon.GetIcons(target)

            if trayIcons = null then
                let trayIcons = TrayIcons()
                TrayIcon.SetIcons(target, trayIcons)
                trayIcons
            else
                trayIcons)

    let Windows =
        Attributes.defineAvaloniaListWidgetCollectionWithCustomDiff<FabWindow>
            "Application_Windows"
            (fun target -> (target :?> FabApplication).InternalWindows)
            (fun target _ view ->
                let app = target :?> FabApplication
                let window = view :?> FabWindow
                app.AddWindow(window))
            (fun target _ view ->
                let app = target :?> FabApplication
                let window = view :?> FabWindow
                app.RemoveWindow(window))
            (fun target _ oldView newView ->
                let app = target :?> FabApplication
                let oldWindow = oldView :?> FabWindow
                let newWindow = newView :?> FabWindow
                app.RemoveWindow(oldWindow)
                app.AddWindow(newWindow))

    let MainView =
        Attributes.defineWidget "MainView" ApplicationUpdaters.mainViewApplyDiff ApplicationUpdaters.mainViewUpdateNode

    let Name = Attributes.defineAvaloniaPropertyWithEquality Application.NameProperty

    let DebugOverlays =
        Attributes.definePropertyWithGetSet
            "Application_DebugOverlays"
            (fun target ->
                (target :?> FabApplication)
                    .TopLevel.RendererDiagnostics.DebugOverlays)
            (fun target value ->
                (target :?> FabApplication)
                    .TopLevel.RendererDiagnostics.DebugOverlays <- value)

    let IsSystemBarVisible =
        Attributes.definePropertyWithGetSet
            "Application_IsSystemBarVisible"
            (fun target -> (target :?> FabApplication).InsetsManager.IsSystemBarVisible)
            (fun target value -> (target :?> FabApplication).InsetsManager.IsSystemBarVisible <- value)

    let DisplayEdgeToEdge =
        Attributes.definePropertyWithGetSet
            "Application_DisplayEdgeToEdge"
            (fun target -> (target :?> FabApplication).InsetsManager.DisplayEdgeToEdge)
            (fun target value -> (target :?> FabApplication).InsetsManager.DisplayEdgeToEdge <- value)

    let SystemBarColor =
        Attributes.definePropertyWithGetSet
            "Application_SystemBarColor"
            (fun target -> (target :?> FabApplication).InsetsManager.SystemBarColor)
            (fun target value -> (target :?> FabApplication).InsetsManager.SystemBarColor <- value)

    let ShutdownMode =
        Attributes.definePropertyWithGetSet "Application_ShutdownMode" (fun target -> (target :?> FabApplication).ShutdownMode) (fun target value ->
            (target :?> FabApplication).ShutdownMode <- value)

    let RequestedThemeVariant =
        Attributes.defineAvaloniaPropertyWithEquality Application.RequestedThemeVariantProperty

    let ActualThemeVariant =
        Attributes.defineAvaloniaPropertyWithEquality Application.ActualThemeVariantProperty

[<AutoOpen>]
module ApplicationBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a DesktopApplication widget with a content widget.</summary>
        static member DesktopApplication() =
            CollectionBuilder<'msg, IFabApplication, IFabWindow>(
                Application.WidgetKey,
                Application.Windows,
                AttributesBundle(StackList.empty(), [||], [||], [||])
            )

        /// <summary>Creates a SingleViewApplication widget with a content widget.</summary>
        /// <param name="view">The main View of the Application.</param>
        static member SingleViewApplication(view: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabApplication>(Application.WidgetKey, Application.MainView.WithValue(view.Compile()))

type ApplicationModifiers =
    /// <summary>Sets the application name.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">Application name to be used for various platform-specific purposes.</param>
    [<Extension>]
    static member inline name(this: WidgetBuilder<'msg, #IFabApplication>, value: string) =
        this.AddScalar(Application.Name.WithValue(value))

    /// <summary>Sets the application debug overlays.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">Debug overlays to be used for the application.</param>
    [<Extension>]
    static member inline debugOverlays(this: WidgetBuilder<'msg, #IFabApplication>, value: RendererDebugOverlays) =
        this.AddScalar(Application.DebugOverlays.WithValue(value))

    /// <summary>Sets the application system bar visibility.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">System bar visibility to be used for the application.</param>
    [<Extension>]
    static member inline isSystemBarVisible(this: WidgetBuilder<'msg, #IFabApplication>, value: bool) =
        this.AddScalar(Application.IsSystemBarVisible.WithValue(value))

    /// <summary>Sets the application display edge to edge.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">Display edge to edge to be used for the application.</param>
    [<Extension>]
    static member inline displayEdgeToEdge(this: WidgetBuilder<'msg, #IFabApplication>, value: bool) =
        this.AddScalar(Application.DisplayEdgeToEdge.WithValue(value))

    /// <summary>Sets the application system bar color.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">System bar color to be used for the application.</param>
    [<Extension>]
    static member inline systemBarColor(this: WidgetBuilder<'msg, #IFabApplication>, value: Color) =
        this.AddScalar(Application.SystemBarColor.WithValue(value))

    /// <summary>Sets the application RequestedThemeVariant.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">System bar color to be used for the application.</param>
    [<Extension>]
    static member inline requestedThemeVariant(this: WidgetBuilder<'msg, #IFabApplication>, value: ThemeVariant) =
        this.AddScalar(Application.RequestedThemeVariant.WithValue(value))

    /// <summary>Sets the application ActualThemeVariant.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">System bar color to be used for the application.</param>
    [<Extension>]
    static member inline actualThemeVariant(this: WidgetBuilder<'msg, #IFabApplication>, value: ThemeVariant) =
        this.AddScalar(Application.ActualThemeVariant.WithValue(value))

    /// <summary>Sets the application ShutdownMode.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">ShutdownMode to be used for the application.</param>
    [<Extension>]
    static member inline shutdownMode(this: WidgetBuilder<'msg, #IFabApplication>, value: ShutdownMode) =
        this.AddScalar(Application.ShutdownMode.WithValue(value))

    /// <summary>Links a ViewRef to access the direct Application control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabApplication>, value: ViewRef<FabApplication>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type ApplicationYieldExtensions =
    [<Extension>]
    static member inline Yield(_: AttributeCollectionBuilder<'msg, #IFabApplication, IFabTrayIcon>, x: WidgetBuilder<'msg, #IFabTrayIcon>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (_: AttributeCollectionBuilder<'msg, #IFabApplication, IFabTrayIcon>, x: WidgetBuilder<'msg, Memo.Memoized<#IFabTrayIcon>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'marker :> IFabApplication and 'itemType :> IFabWindow>
        (_: CollectionBuilder<'msg, 'marker, IFabWindow>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'marker :> IFabApplication and 'itemType :> IFabWindow>
        (_: CollectionBuilder<'msg, 'marker, IFabWindow>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

type TrayIconAttachedModifiers =
    /// <summary>Sets the tray icons for the application.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline trayIcons<'msg, 'marker when 'msg: equality and 'marker :> IFabApplication>(this: WidgetBuilder<'msg, 'marker>) =
        AttributeCollectionBuilder<'msg, 'marker, IFabTrayIcon>(this, Application.TrayIcons)

    /// <summary>Sets the tray icon for the application.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="trayIcon">The TrayIcon value</param>
    [<Extension>]
    static member inline trayIcon(this: WidgetBuilder<'msg, #IFabApplication>, trayIcon: WidgetBuilder<'msg, IFabTrayIcon>) =
        AttributeCollectionBuilder<'msg, #IFabApplication, IFabTrayIcon>(this, Application.TrayIcons) { trayIcon }
