namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Media
open Fabulous

type IFabControl =
    inherit IFabInputElement

module Control =

    let Tag =
        Attributes.defineAvaloniaProperty<string, obj> Control.TagProperty box ScalarAttributeComparers.equalityCompare

    let ContextMenu =
        Attributes.defineAvaloniaPropertyWidget Control.ContextMenuProperty

    let HotKey =
        Attributes.defineAvaloniaPropertyWithEquality HotKeyManager.HotKeyProperty

    let ContextFlyout =
        Attributes.defineAvaloniaPropertyWidget Control.ContextFlyoutProperty

    let FlowDirection =
        Attributes.defineAvaloniaPropertyWithEquality Control.FlowDirectionProperty

type ControlModifiers =
    /// <summary>Sets the ContextFlyout property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ContextFlyout value.</param>
    [<Extension>]
    static member inline contextFlyout(this: WidgetBuilder<'msg, #IFabControl>, value: WidgetBuilder<'msg, #IFabFlyoutBase>) =
        this.AddWidget(Control.ContextFlyout.WithValue(value.Compile()))

    /// <summary>Sets the Tag property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Tag value.</param>
    [<Extension>]
    static member inline tag(this: WidgetBuilder<'msg, #IFabControl>, value: string) =
        this.AddScalar(Control.Tag.WithValue(value))

    /// <summary>Sets the HotKey property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HotKey value.</param>
    [<Extension>]
    static member inline hotKey(this: WidgetBuilder<'msg, #IFabControl>, value: KeyGesture) =
        this.AddScalar(Control.HotKey.WithValue(value))

    /// <summary>Sets the HotKey property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HotKey value.</param>
    [<Extension>]
    static member inline hotKey(this: WidgetBuilder<'msg, #IFabControl>, value: string) =
        this.AddScalar(Control.HotKey.WithValue(KeyGesture.Parse(value)))

    /// <summary>Sets the FlowDirection property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FlowDirection value.</param>
    [<Extension>]
    static member inline flowDirection(this: WidgetBuilder<'msg, #IFabControl>, value: FlowDirection) =
        this.AddScalar(Control.FlowDirection.WithValue(value))
