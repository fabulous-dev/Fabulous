namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabSplitButton =
    inherit IFabContentControl

module SplitButton =
    let WidgetKey = Widgets.register<SplitButton>()
    let Flyout = Attributes.defineAvaloniaPropertyWidget SplitButton.FlyoutProperty


type SplitButtonModifiers =
    /// <summary>Sets the Flyout property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Flyout value.</param>
    [<Extension>]
    static member inline flyout(this: WidgetBuilder<'msg, #IFabSplitButton>, value: WidgetBuilder<'msg, #IFabFlyoutBase>) =
        this.AddWidget(SplitButton.Flyout.WithValue(value.Compile()))

    /// <summary>Link a ViewRef to access the direct SplitButton control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabSplitButton>, value: ViewRef<SplitButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
