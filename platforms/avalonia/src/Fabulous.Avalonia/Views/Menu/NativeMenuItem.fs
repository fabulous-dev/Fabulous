namespace Fabulous.Avalonia

open System
open System.IO
open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Media.Imaging
open Fabulous

type IFabNativeMenuItem =
    inherit IFabElement

module NativeMenuItem =
    let WidgetKey = Widgets.register<NativeMenuItem>()

    let Menu = Attributes.defineAvaloniaPropertyWidget NativeMenuItem.MenuProperty

    let Icon = Attributes.defineBindableImageSource NativeMenuItem.IconProperty

    let Header =
        Attributes.defineAvaloniaPropertyWithEquality NativeMenuItem.HeaderProperty

    let Gesture =
        Attributes.defineAvaloniaPropertyWithEquality NativeMenuItem.GestureProperty

    let IsChecked =
        Attributes.defineAvaloniaPropertyWithEquality NativeMenuItem.IsCheckedProperty

    let ToggleType =
        Attributes.defineAvaloniaPropertyWithEquality NativeMenuItem.ToggleTypeProperty

    let IsEnabled =
        Attributes.defineAvaloniaPropertyWithEquality NativeMenuItem.IsEnabledProperty

    let ToolTip =
        Attributes.defineAvaloniaPropertyWithEquality NativeMenuItem.ToolTipProperty

[<AutoOpen>]
module NativeMenuItemBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a NativeMenuItem widget.</summary>
        /// <param name="header">The header of the Flyout.</param>
        static member NativeMenuItem(header: string) =
            WidgetBuilder<'msg, IFabNativeMenuItem>(NativeMenuItem.WidgetKey, NativeMenuItem.Header.WithValue(header))

type NativeMenuItemModifiers =
    /// <summary>Sets the Gesture property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Gesture value.</param>
    [<Extension>]
    static member inline gesture(this: WidgetBuilder<'msg, #IFabNativeMenuItem>, value: KeyGesture) =
        this.AddScalar(NativeMenuItem.Gesture.WithValue(value))

    /// <summary>Sets the IsChecked property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsChecked value.</param>
    [<Extension>]
    static member inline isChecked(this: WidgetBuilder<'msg, #IFabNativeMenuItem>, value: bool) =
        this.AddScalar(NativeMenuItem.IsChecked.WithValue(value))

    /// <summary>Sets the ToggleType property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ToggleType value.</param>
    [<Extension>]
    static member inline toggleType(this: WidgetBuilder<'msg, #IFabNativeMenuItem>, value: NativeMenuItemToggleType) =
        this.AddScalar(NativeMenuItem.ToggleType.WithValue(value))

    /// <summary>Sets the IsEnabled property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsEnabled value.</param>
    [<Extension>]
    static member inline isEnabled(this: WidgetBuilder<'msg, #IFabNativeMenuItem>, value: bool) =
        this.AddScalar(NativeMenuItem.IsEnabled.WithValue(value))

    /// <summary>Sets the ToolTip property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ToolTip value.</param>
    [<Extension>]
    static member inline toolTip(this: WidgetBuilder<'msg, #IFabNativeMenuItem>, value: string) =
        this.AddScalar(NativeMenuItem.ToolTip.WithValue(value))

    /// <summary>Link a ViewRef to access the direct NativeMenuItem control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabNativeMenuItem>, value: ViewRef<NativeMenuItem>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type NativeMenuItemExtraModifiers =
    /// <summary>Sets the Icon property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Icon value.</param>
    [<Extension>]
    static member inline icon(this: WidgetBuilder<'msg, #IFabNativeMenuItem>, value: Bitmap) =
        this.AddScalar(NativeMenuItem.Icon.WithValue(ImageSourceValue.Bitmap(value)))

    /// <summary>Sets the Icon property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Icon value.</param>
    [<Extension>]
    static member inline icon(this: WidgetBuilder<'msg, #IFabNativeMenuItem>, value: string) =
        this.AddScalar(NativeMenuItem.Icon.WithValue(ImageSourceValue.File(value)))

    /// <summary>Sets the Icon property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Icon value.</param>
    [<Extension>]
    static member inline icon(this: WidgetBuilder<'msg, #IFabNativeMenuItem>, value: Uri) =
        this.AddScalar(NativeMenuItem.Icon.WithValue(ImageSourceValue.Uri(value)))

    /// <summary>Sets the Icon property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Icon value.</param>
    [<Extension>]
    static member inline icon(this: WidgetBuilder<'msg, #IFabNativeMenuItem>, value: Stream) =
        this.AddScalar(NativeMenuItem.Icon.WithValue(ImageSourceValue.Stream(value)))
