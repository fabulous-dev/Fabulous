namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia

module ComponentApplication =
    let ActualThemeVariantChanged =
        Attributes.Component.defineAvaloniaPropertyWithChangedEvent' "Application_ActualThemeVariantChanged" FabApplication.ActualThemeVariantProperty

    let RequestedThemeChanged =
        Attributes.Component.defineAvaloniaPropertyWithChangedEvent' "Application_RequestedThemeChanged" FabApplication.RequestedThemeVariantProperty

    let ResourcesChanged =
        Attributes.Component.defineEvent "Application_ResourcesChangedEvent" (fun target -> (target :?> FabApplication).ResourcesChanged)

    let Activated =
        Attributes.Component.defineEvent "Application_Activated" (fun target ->
            (FabApplication.Current.TryGetFeature(typeof<IActivatableLifetime>) :?> IActivatableLifetime)
                .Activated)

    let Deactivated =
        Attributes.Component.defineEvent "Application_Deactivated" (fun target ->
            (FabApplication.Current.TryGetFeature(typeof<IActivatableLifetime>) :?> IActivatableLifetime)
                .Deactivated)

    let ColorValuesChanged =
        Attributes.Component.defineEvent "PlatformSettings_ColorValuesChanged" (fun target ->
            (target :?> FabApplication)
                .PlatformSettings.ColorValuesChanged)

    let SafeAreaChanged =
        Attributes.Component.defineEvent "PlatformSettings_SafeAreaChanged" (fun target -> (target :?> FabApplication).InsetsManager.SafeAreaChanged)

type ComponentApplicationModifiers =
    /// <summary>Listens to the application ActualThemeVariantChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The new theme variant.</param>
    /// <param name="fn">Raised when the actual theme variant changes.</param>
    [<Extension>]
    static member inline onActualThemeVariantChanged(this: WidgetBuilder<'msg, #IFabApplication>, value: ThemeVariant, fn: ThemeVariant -> unit) =
        this.AddScalar(ComponentApplication.ActualThemeVariantChanged.WithValue(ComponentValueEventData.create value fn))

    /// <summary>Listens to the application RequestedThemeChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The new theme variant.</param>
    /// <param name="fn">Raised when the requested theme variant changes.</param>
    [<Extension>]
    static member inline onRequestedThemeChanged(this: WidgetBuilder<'msg, #IFabApplication>, value: ThemeVariant, fn: ThemeVariant -> unit) =
        this.AddScalar(ComponentApplication.RequestedThemeChanged.WithValue(ComponentValueEventData.create value fn))

    /// <summary>Listens to the application resources changed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the resources change.</param>
    [<Extension>]
    static member inline onResourcesChanged(this: WidgetBuilder<'msg, #IFabApplication>, fn: ResourcesChangedEventArgs -> unit) =
        this.AddScalar(ComponentApplication.ResourcesChanged.WithValue(fn))

    /// <summary>Listens to the application activated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the application is activated.</param>
    [<Extension>]
    static member inline onActivated(this: WidgetBuilder<'msg, #IFabApplication>, fn: ActivatedEventArgs -> unit) =
        this.AddScalar(ComponentApplication.Activated.WithValue(fn))

    /// <summary>Listens to the application deactivated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the application is deactivated.</param>
    [<Extension>]
    static member inline onDeactivated(this: WidgetBuilder<'msg, #IFabApplication>, fn: ActivatedEventArgs -> unit) =
        this.AddScalar(ComponentApplication.Deactivated.WithValue(fn))

    /// <summary>Listens to the PlatformSettings color values changed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when current system color values are changed. Including changing of a dark mode and accent colors.</param>
    [<Extension>]
    static member inline onColorValuesChanged(this: WidgetBuilder<'msg, #IFabApplication>, fn: Platform.PlatformColorValues -> unit) =
        this.AddScalar(ComponentApplication.ColorValuesChanged.WithValue(fn))

    /// <summary>Listens to the PlatformSettings safe area changed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the safe area is changed.</param>
    [<Extension>]
    static member inline onSafeAreaChanged(this: WidgetBuilder<'msg, #IFabApplication>, fn: Platform.SafeAreaChangedArgs -> unit) =
        this.AddScalar(ComponentApplication.SafeAreaChanged.WithValue(fn))
