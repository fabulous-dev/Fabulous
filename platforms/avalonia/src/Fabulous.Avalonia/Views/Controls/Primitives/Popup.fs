namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Controls.Primitives.PopupPositioning
open Avalonia.Input
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabPopup =
    inherit IFabControl

module Popup =
    let WidgetKey = Widgets.register<Popup>()

    let WindowManagerAddShadowHint =
        Attributes.defineAvaloniaPropertyWithEquality Popup.WindowManagerAddShadowHintProperty

    let Child = Attributes.defineAvaloniaPropertyWidget Popup.ChildProperty

    let InheritsTransform =
        Attributes.defineAvaloniaPropertyWithEquality Popup.InheritsTransformProperty

    let IsOpen = Attributes.defineAvaloniaPropertyWithEquality Popup.IsOpenProperty

    let PlacementAnchor =
        Attributes.defineAvaloniaPropertyWithEquality Popup.PlacementAnchorProperty

    let PlacementConstraintAdjustment =
        Attributes.defineAvaloniaPropertyWithEquality Popup.PlacementConstraintAdjustmentProperty

    let PlacementGravity =
        Attributes.defineAvaloniaPropertyWithEquality Popup.PlacementGravityProperty

    let Placement =
        Attributes.defineAvaloniaPropertyWithEquality Popup.PlacementProperty

    let PlacementTarget =
        Attributes.defineAvaloniaPropertyWithEquality Popup.PlacementTargetProperty

    let PlacementRect =
        Attributes.defineAvaloniaPropertyWithEquality Popup.PlacementRectProperty

    let OverlayDismissEventPassThrough =
        Attributes.defineAvaloniaPropertyWithEquality Popup.OverlayDismissEventPassThroughProperty

    let HorizontalOffset =
        Attributes.defineAvaloniaPropertyWithEquality Popup.HorizontalOffsetProperty

    let IsLightDismissEnabled =
        Attributes.defineAvaloniaPropertyWithEquality Popup.IsLightDismissEnabledProperty

    let VerticalOffset =
        Attributes.defineAvaloniaPropertyWithEquality Popup.VerticalOffsetProperty

    let Topmost = Attributes.defineAvaloniaPropertyWithEquality Popup.TopmostProperty

    let OverlayInputPassThroughElement =
        Attributes.defineAvaloniaPropertyWithEquality Popup.OverlayInputPassThroughElementProperty

    let CustomPopupPlacementCallback =
        Attributes.defineAvaloniaPropertyWithEquality Popup.CustomPopupPlacementCallbackProperty

    let ShouldUseOverlayLayer =
        Attributes.defineAvaloniaPropertyWithEquality Popup.ShouldUseOverlayLayerProperty

    let TakesFocusFromNativeControl =
        Attributes.defineAvaloniaPropertyWithEquality Popup.TakesFocusFromNativeControlProperty

[<AutoOpen>]
module PopupBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Popup widget.</summary>
        /// <param name="isOpen">Whether the popup is open or not.</param>
        /// <param name="content">The content of the popup.</param>
        static member Popup(isOpen: bool, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabPopup>(
                Popup.WidgetKey,
                AttributesBundle(StackList.one(Popup.IsOpen.WithValue(isOpen)), [| Popup.Child.WithValue(content.Compile()) |], [||], [||])
            )

type PopupModifiers =
    /// <summary>Sets the WindowManagerAddShadowHint property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The WindowManagerAddShadowHint value.</param>
    [<Extension>]
    static member inline windowManagerAddShadowHint(this: WidgetBuilder<'msg, #IFabPopup>, value: bool) =
        this.AddScalar(Popup.WindowManagerAddShadowHint.WithValue(value))

    /// <summary>Sets the InheritsTransform property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The InheritsTransform value.</param>
    [<Extension>]
    static member inline inheritsTransform(this: WidgetBuilder<'msg, #IFabPopup>, value: bool) =
        this.AddScalar(Popup.InheritsTransform.WithValue(value))

    /// <summary>Sets the PlacementAnchor property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlacementAnchor value.</param>
    [<Extension>]
    static member inline placementAnchor(this: WidgetBuilder<'msg, #IFabPopup>, value: PopupAnchor) =
        this.AddScalar(Popup.PlacementAnchor.WithValue(value))

    /// <summary>Sets the PlacementConstraintAdjustment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlacementConstraintAdjustment value.</param>
    [<Extension>]
    static member inline placementConstraintAdjustment(this: WidgetBuilder<'msg, #IFabPopup>, value: PopupPositionerConstraintAdjustment) =
        this.AddScalar(Popup.PlacementConstraintAdjustment.WithValue(value))

    /// <summary>Sets the PlacementGravity property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlacementGravity value.</param>
    [<Extension>]
    static member inline placementGravity(this: WidgetBuilder<'msg, #IFabPopup>, value: PopupGravity) =
        this.AddScalar(Popup.PlacementGravity.WithValue(value))

    /// <summary>Sets the Placement property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Placement value.</param>
    [<Extension>]
    static member inline placement(this: WidgetBuilder<'msg, #IFabPopup>, value: PlacementMode) =
        this.AddScalar(Popup.Placement.WithValue(value))

    /// <summary>Sets the PlacementTarget property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlacementTarget value.</param>
    [<Extension>]
    static member inline placementTarget(this: WidgetBuilder<'msg, #IFabPopup>, value: ViewRef<#Control>) =
        match value.TryValue with
        | None -> this
        | Some value -> this.AddScalar(Popup.PlacementTarget.WithValue(value))

    /// <summary>Sets the PlacementRect property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlacementRect value.</param>
    [<Extension>]
    static member inline placementRect(this: WidgetBuilder<'msg, #IFabPopup>, value: Rect) =
        this.AddScalar(Popup.PlacementRect.WithValue(value))

    /// <summary>Sets the OverlayDismissEventPassThrough property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OverlayDismissEventPassThrough value.</param>
    [<Extension>]
    static member inline overlayDismissEventPassThrough(this: WidgetBuilder<'msg, #IFabPopup>, value: bool) =
        this.AddScalar(Popup.OverlayDismissEventPassThrough.WithValue(value))

    /// <summary>Sets the HorizontalOffset property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HorizontalOffset value.</param>
    [<Extension>]
    static member inline horizontalOffset(this: WidgetBuilder<'msg, #IFabPopup>, value: float) =
        this.AddScalar(Popup.HorizontalOffset.WithValue(value))

    /// <summary>Sets the IsLightDismissEnabled property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsLightDismissEnabled value.</param>
    [<Extension>]
    static member inline isLightDismissEnabled(this: WidgetBuilder<'msg, #IFabPopup>, value: bool) =
        this.AddScalar(Popup.IsLightDismissEnabled.WithValue(value))

    /// <summary>Sets the VerticalOffset property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The VerticalOffset value.</param>
    [<Extension>]
    static member inline verticalOffset(this: WidgetBuilder<'msg, #IFabPopup>, value: float) =
        this.AddScalar(Popup.VerticalOffset.WithValue(value))

    /// <summary>Sets the Topmost property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Topmost value.</param>
    [<Extension>]
    static member inline topmost(this: WidgetBuilder<'msg, #IFabPopup>, value: bool) =
        this.AddScalar(Popup.Topmost.WithValue(value))

    /// <summary>Sets the OverlayInputPassThroughElement property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OverlayInputPassThroughElement value.</param>
    [<Extension>]
    static member inline overlayInputPassThroughElement(this: WidgetBuilder<'msg, #IFabPopup>, value: IInputElement) =
        this.AddScalar(Popup.OverlayInputPassThroughElement.WithValue(value))

    /// <summary>Sets the CustomPopupPlacementCallback property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CustomPopupPlacementCallback value.</param>
    [<Extension>]
    static member inline customPopupPlacementCallback(this: WidgetBuilder<'msg, #IFabPopup>, value: CustomPopupPlacement -> unit) =
        this.AddScalar(Popup.CustomPopupPlacementCallback.WithValue(CustomPopupPlacementCallback(value)))

    /// <summary>Sets the ShouldUseOverlayLayer property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ShouldUseOverlayLayer value.</param>
    [<Extension>]
    static member inline shouldUseOverlayLayer(this: WidgetBuilder<'msg, #IFabPopup>, value: bool) =
        this.AddScalar(Popup.ShouldUseOverlayLayer.WithValue(value))

    /// <summary>Sets the TakesFocusFromNativeControl property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TakesFocusFromNativeControl value.</param>
    [<Extension>]
    static member inline takesFocusFromNativeControl(this: WidgetBuilder<'msg, #IFabPopup>, value: bool) =
        this.AddScalar(Popup.TakesFocusFromNativeControl.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Popup control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPopup>, value: ViewRef<Popup>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
