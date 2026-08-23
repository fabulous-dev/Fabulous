namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabStackPanel =
    inherit IFabPanel

module StackPanel =
    let WidgetKey = Widgets.register<StackPanel>()

    let Spacing =
        Attributes.defineAvaloniaPropertyWithEquality StackPanel.SpacingProperty

    let Orientation =
        Attributes.defineAvaloniaPropertyWithEquality StackPanel.OrientationProperty

    let AreHorizontalSnapPointsRegular =
        Attributes.defineAvaloniaPropertyWithEquality StackPanel.AreHorizontalSnapPointsRegularProperty

    let AreVerticalSnapPointsRegular =
        Attributes.defineAvaloniaPropertyWithEquality StackPanel.AreVerticalSnapPointsRegularProperty

type StackPanelModifiers =
    /// <summary>Sets the AreHorizontalSnapPointsRegular property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AreHorizontalSnapPointsRegular value.</param>
    [<Extension>]
    static member inline areHorizontalSnapPointsRegular(this: WidgetBuilder<'msg, #IFabStackPanel>, value: bool) =
        this.AddScalar(StackPanel.AreHorizontalSnapPointsRegular.WithValue(value))

    /// <summary>Sets the AreVerticalSnapPointsRegular property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AreVerticalSnapPointsRegular value.</param>
    [<Extension>]
    static member inline areVerticalSnapPointsRegular(this: WidgetBuilder<'msg, #IFabStackPanel>, value: bool) =
        this.AddScalar(StackPanel.AreVerticalSnapPointsRegular.WithValue(value))

    /// <summary>Link a ViewRef to access the direct StackPanel control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabStackPanel>, value: ViewRef<StackPanel>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
