namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Input
open Fabulous

type IFabButton =
    inherit IFabContentControl

module Button =
    let WidgetKey = Widgets.register<Button>()

    let ClickMode =
        Attributes.defineAvaloniaPropertyWithEquality Button.ClickModeProperty


    let HotKey = Attributes.defineAvaloniaPropertyWithEquality Button.HotKeyProperty

    let IsDefault =
        Attributes.defineAvaloniaPropertyWithEquality Button.IsDefaultProperty

    let IsCancel = Attributes.defineAvaloniaPropertyWithEquality Button.IsCancelProperty

    let Flyout = Attributes.defineAvaloniaPropertyWidget Button.FlyoutProperty

type ButtonModifiers =
    /// <summary>Sets the ClickMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ClickMode value.</param>
    [<Extension>]
    static member inline clickMode(this: WidgetBuilder<'msg, #IFabButton>, value: ClickMode) =
        this.AddScalar(Button.ClickMode.WithValue(value))

    /// <summary>Sets the HotKey property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HotKey value.</param>
    [<Extension>]
    static member inline hotKey(this: WidgetBuilder<'msg, #IFabButton>, value: KeyGesture) =
        this.AddScalar(Button.HotKey.WithValue(value))

    /// <summary>Sets the IsDefault property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsDefault value.</param>
    [<Extension>]
    static member inline isDefault(this: WidgetBuilder<'msg, #IFabButton>, value: bool) =
        this.AddScalar(Button.IsDefault.WithValue(value))

    /// <summary>Sets the IsCancel property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsCancel value.</param>
    [<Extension>]
    static member inline isCancel(this: WidgetBuilder<'msg, #IFabButton>, value: bool) =
        this.AddScalar(Button.IsCancel.WithValue(value))

    /// <summary>Sets the Flyout property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Flyout value.</param>
    [<Extension>]
    static member inline flyout(this: WidgetBuilder<'msg, #IFabButton>, value: WidgetBuilder<'msg, #IFabFlyoutBase>) =
        this.AddWidget(Button.Flyout.WithValue(value.Compile()))

    /// <summary>Link a ViewRef to access the direct Button control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabButton>, value: ViewRef<Button>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
