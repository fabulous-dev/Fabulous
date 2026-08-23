namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Primitives.PopupPositioning
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabToolTip =
    inherit IFabContentControl

module ToolTip =
    let WidgetKey = Widgets.register<ToolTip>()

    let TipWidget = Attributes.defineAvaloniaPropertyWidget ToolTip.TipProperty

    let TipString =
        Attributes.defineAvaloniaProperty<string, obj> ToolTip.TipProperty box ScalarAttributeComparers.equalityCompare

    let IsOpen = Attributes.defineAvaloniaPropertyWithEquality ToolTip.IsOpenProperty

    let Placement =
        Attributes.defineAvaloniaPropertyWithEquality ToolTip.PlacementProperty

    let HorizontalOffset =
        Attributes.defineAvaloniaPropertyWithEquality ToolTip.HorizontalOffsetProperty

    let VerticalOffset =
        Attributes.defineAvaloniaPropertyWithEquality ToolTip.VerticalOffsetProperty

    let ShowDelay =
        Attributes.defineAvaloniaPropertyWithEquality ToolTip.ShowDelayProperty

    let BetweenShowDelay =
        Attributes.defineAvaloniaPropertyWithEquality ToolTip.BetweenShowDelayProperty

    let ShowOnDisabled =
        Attributes.defineAvaloniaPropertyWithEquality ToolTip.ShowOnDisabledProperty

    let ServiceEnabled =
        Attributes.defineAvaloniaPropertyWithEquality ToolTip.ServiceEnabledProperty

    let CustomPopupPlacementCallback =
        Attributes.defineAvaloniaPropertyWithEquality ToolTip.CustomPopupPlacementCallbackProperty

[<AutoOpen>]
module ToolTipBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ToolTip widget.</summary>
        static member ToolTip(content: string) =
            WidgetBuilder<'msg, IFabToolTip>(ToolTip.WidgetKey, ContentControl.ContentString.WithValue(content))

        /// <summary>Creates a ToolTip widget.</summary>
        static member ToolTip(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabToolTip>(ToolTip.WidgetKey, ContentControl.ContentWidget.WithValue(content.Compile()))

type ToolTipModifiers =
    /// <summary>Sets the Tip property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Tip value.</param>
    [<Extension>]
    static member inline tip(this: WidgetBuilder<'msg, #IFabControl>, value: WidgetBuilder<'msg, #IFabToolTip>) =
        this.AddWidget(ToolTip.TipWidget.WithValue(value.Compile()))

    /// <summary>Sets the Tip property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Tip value.</param>
    [<Extension>]
    static member inline tip(this: WidgetBuilder<'msg, #IFabControl>, value: string) =
        this.AddScalar(ToolTip.TipString.WithValue(value))

    /// <summary>Sets the IsOpen property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsOpen value.</param>
    [<Extension>]
    static member inline isOpen(this: WidgetBuilder<'msg, #IFabControl>, value: bool) =
        this.AddScalar(ToolTip.IsOpen.WithValue(value))

    /// <summary>Sets the Placement property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Placement value.</param>
    [<Extension>]
    static member inline tooltipPlacement(this: WidgetBuilder<'msg, #IFabControl>, value: PlacementMode) =
        this.AddScalar(ToolTip.Placement.WithValue(value))

    /// <summary>Sets the HorizontalOffset property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HorizontalOffset value.</param>
    [<Extension>]
    static member inline tooltipHorizontalOffset(this: WidgetBuilder<'msg, #IFabControl>, value: double) =
        this.AddScalar(ToolTip.HorizontalOffset.WithValue(value))

    /// <summary>Sets the VerticalOffset property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The VerticalOffset value.</param>
    [<Extension>]
    static member inline tooltipVerticalOffset(this: WidgetBuilder<'msg, #IFabControl>, value: double) =
        this.AddScalar(ToolTip.VerticalOffset.WithValue(value))

    /// <summary>Sets the ShowDelay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ShowDelay value.</param>
    [<Extension>]
    static member inline tooltipShowDelay(this: WidgetBuilder<'msg, #IFabControl>, value: int) =
        this.AddScalar(ToolTip.ShowDelay.WithValue(value))

    /// <summary>Sets the BetweenShowDelay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BetweenShowDelay value.</param>
    [<Extension>]
    static member inline tooltipBetweenShowDelay(this: WidgetBuilder<'msg, #IFabControl>, value: int) =
        this.AddScalar(ToolTip.BetweenShowDelay.WithValue(value))

    /// <summary>Sets the ShowOnDisabled property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ShowOnDisabled value.</param>
    [<Extension>]
    static member inline tooltipShowOnDisabled(this: WidgetBuilder<'msg, #IFabControl>, value: bool) =
        this.AddScalar(ToolTip.ShowOnDisabled.WithValue(value))

    /// <summary>Sets the ServiceEnabled property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ServiceEnabled value.</param>
    [<Extension>]
    static member inline tooltipServiceEnabled(this: WidgetBuilder<'msg, #IFabControl>, value: bool) =
        this.AddScalar(ToolTip.ServiceEnabled.WithValue(value))

    /// <summary>Sets the CustomPopupPlacementCallback property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CustomPopupPlacementCallback value.</param>
    [<Extension>]
    static member inline tooltipCustomPopupPlacementCallback(this: WidgetBuilder<'msg, #IFabControl>, value: CustomPopupPlacement -> unit) =
        this.AddScalar(ToolTip.CustomPopupPlacementCallback.WithValue(CustomPopupPlacementCallback(value)))

    /// <summary>Link a ViewRef to access the direct ToolTip control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabToolTip>, value: ViewRef<ToolTip>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
