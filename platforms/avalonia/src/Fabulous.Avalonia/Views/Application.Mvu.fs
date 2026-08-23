namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia

module MvuApplication =
    let ActualThemeVariantChanged =
        Attributes.Mvu.defineAvaloniaPropertyWithChangedEvent' "Application_ActualThemeVariantChanged" FabApplication.ActualThemeVariantProperty

    let RequestedThemeChanged =
        Attributes.Mvu.defineAvaloniaPropertyWithChangedEvent' "Application_RequestedThemeChanged" FabApplication.RequestedThemeVariantProperty

    let ResourcesChanged =
        Attributes.Mvu.defineEvent "Application_ResourcesChangedEvent" (fun target -> (target :?> FabApplication).ResourcesChanged)

    let Activated =
        Attributes.Mvu.defineEvent "Application_Activated" (fun target ->
            (FabApplication.Current.TryGetFeature(typeof<IActivatableLifetime>) :?> IActivatableLifetime)
                .Activated)

    let Deactivated =
        Attributes.Mvu.defineEvent "Application_Deactivated" (fun target ->
            (FabApplication.Current.TryGetFeature(typeof<IActivatableLifetime>) :?> IActivatableLifetime)
                .Deactivated)

    let ColorValuesChanged =
        Attributes.Mvu.defineEvent "PlatformSettings_ColorValuesChanged" (fun target ->
            (target :?> FabApplication)
                .PlatformSettings.ColorValuesChanged)

    let SafeAreaChanged =
        Attributes.Mvu.defineEvent "PlatformSettings_SafeAreaChanged" (fun target -> (target :?> FabApplication).InsetsManager.SafeAreaChanged)

type MvuApplicationModifiers =
    /// <summary>Listens to the application ActualThemeVariantChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The new theme variant.</param>
    /// <param name="fn">Raised when the actual theme variant changes.</param>
    [<Extension>]
    static member inline onActualThemeVariantChanged(this: WidgetBuilder<'msg, #IFabApplication>, value: ThemeVariant, fn: ThemeVariant -> 'msg) =
        this.AddScalar(MvuApplication.ActualThemeVariantChanged.WithValue(ValueEventData.create value fn))

    /// <summary>Listens to the application RequestedThemeChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The new theme variant.</param>
    /// <param name="fn">Raised when the requested theme variant changes.</param>
    [<Extension>]
    static member inline onRequestedThemeChanged(this: WidgetBuilder<'msg, #IFabApplication>, value: ThemeVariant, fn: ThemeVariant -> 'msg) =
        this.AddScalar(MvuApplication.RequestedThemeChanged.WithValue(ValueEventData.create value fn))

    /// <summary>Listens to the application resources changed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the resources change.</param>
    [<Extension>]
    static member inline onResourcesChanged(this: WidgetBuilder<'msg, #IFabApplication>, fn: ResourcesChangedEventArgs -> 'msg) =
        this.AddScalar(MvuApplication.ResourcesChanged.WithValue(fn))

    /// <summary>Listens to the application activated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the application is activated.</param>
    [<Extension>]
    static member inline onActivated(this: WidgetBuilder<'msg, #IFabApplication>, fn: ActivatedEventArgs -> 'msg) =
        this.AddScalar(MvuApplication.Activated.WithValue(fn))

    /// <summary>Listens to the application deactivated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the application is deactivated.</param>
    [<Extension>]
    static member inline onDeactivated(this: WidgetBuilder<'msg, #IFabApplication>, fn: ActivatedEventArgs -> 'msg) =
        this.AddScalar(MvuApplication.Deactivated.WithValue(fn))

    /// <summary>Listens to the PlatformSettings color values changed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when current system color values are changed. Including changing of a dark mode and accent colors.</param>
    [<Extension>]
    static member inline onColorValuesChanged(this: WidgetBuilder<'msg, #IFabApplication>, fn: Platform.PlatformColorValues -> 'msg) =
        this.AddScalar(MvuApplication.ColorValuesChanged.WithValue(fn))

    /// <summary>Listens to the PlatformSettings safe area changed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the safe area is changed.</param>
    [<Extension>]
    static member inline onSafeAreaChanged(this: WidgetBuilder<'msg, #IFabApplication>, fn: Platform.SafeAreaChangedArgs -> 'msg) =
        this.AddScalar(MvuApplication.SafeAreaChanged.WithValue(fn))
