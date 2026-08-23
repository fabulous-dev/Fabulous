namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabVirtualizingStackPanel =
    inherit IFabVirtualizingPanel

module VirtualizingStackPanel =
    let WidgetKey = Widgets.register<VirtualizingStackPanel>()

    let Orientation =
        Attributes.defineAvaloniaPropertyWithEquality VirtualizingStackPanel.OrientationProperty

    let AreHorizontalSnapPointsRegular =
        Attributes.defineAvaloniaPropertyWithEquality VirtualizingStackPanel.AreHorizontalSnapPointsRegularProperty

    let AreVerticalSnapPointsRegular =
        Attributes.defineAvaloniaPropertyWithEquality VirtualizingStackPanel.AreVerticalSnapPointsRegularProperty

[<AutoOpen>]
module VirtualizingStackPanelBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a VirtualizingStackPanel widget.</summary>
        static member VirtualizingStackPanel() =
            WidgetBuilder<'msg, IFabVirtualizingStackPanel>(VirtualizingStackPanel.WidgetKey)

type VirtualizingStackPanelModifiers =
    /// <summary>Sets the AreHorizontalSnapPointsRegular property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AreHorizontalSnapPointsRegular value.</param>
    [<Extension>]
    static member inline areHorizontalSnapPointsRegular(this: WidgetBuilder<'msg, #IFabVirtualizingStackPanel>, value: bool) =
        this.AddScalar(VirtualizingStackPanel.AreHorizontalSnapPointsRegular.WithValue(value))

    /// <summary>Sets the AreVerticalSnapPointsRegular property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AreVerticalSnapPointsRegular value.</param>
    [<Extension>]
    static member inline areVerticalSnapPointsRegular(this: WidgetBuilder<'msg, #IFabVirtualizingStackPanel>, value: bool) =
        this.AddScalar(VirtualizingStackPanel.AreVerticalSnapPointsRegular.WithValue(value))

    /// <summary>Link a ViewRef to access the direct VirtualizingStackPanel control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabVirtualizingStackPanel>, value: ViewRef<VirtualizingStackPanel>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
