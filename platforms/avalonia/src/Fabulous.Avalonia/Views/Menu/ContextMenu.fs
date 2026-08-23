namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Primitives.PopupPositioning
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabContextMenu =
    inherit IFabMenuBase

module ContextMenu =
    let WidgetKey = Widgets.register<ContextMenu>()

    let HorizontalOffset =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.HorizontalOffsetProperty

    let VerticalOffset =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.VerticalOffsetProperty

    let PlacementConstraintAdjustment =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.PlacementConstraintAdjustmentProperty

    let PlacementAnchor =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.PlacementAnchorProperty

    let PlacementGravity =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.PlacementGravityProperty

    let Placement =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.PlacementProperty

    let PlacementRect =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.PlacementRectProperty

    let PlacementTarget =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.PlacementTargetProperty

    let WindowManagerAddShadowHint =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.WindowManagerAddShadowHintProperty

[<AutoOpen>]
module ContextMenuBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ContextMenu widget.</summary>
        /// <param name="placement">The placement mode of the ContextMenu.</param>
        static member ContextMenu(placement: PlacementMode) =
            CollectionBuilder<'msg, IFabContextMenu, IFabControl>(ContextMenu.WidgetKey, ItemsControl.Items, ContextMenu.Placement.WithValue(placement))

        /// <summary>Creates a ContextMenu widget.</summary>
        static member ContextMenu() =
            CollectionBuilder<'msg, IFabContextMenu, IFabControl>(
                ContextMenu.WidgetKey,
                ItemsControl.Items,
                ContextMenu.Placement.WithValue(PlacementMode.Bottom)
            )

type ContextMenuModifiers =
    /// <summary>Sets the HorizontalOffset property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HorizontalOffset value.</param>
    [<Extension>]
    static member inline horizontalOffset(this: WidgetBuilder<'msg, #IFabContextMenu>, value: float) =
        this.AddScalar(ContextMenu.HorizontalOffset.WithValue(value))

    /// <summary>Sets the VerticalOffset property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The VerticalOffset value.</param>
    [<Extension>]
    static member inline verticalOffset(this: WidgetBuilder<'msg, #IFabContextMenu>, value: float) =
        this.AddScalar(ContextMenu.VerticalOffset.WithValue(value))

    /// <summary>Sets the PlacementConstraintAdjustment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlacementConstraintAdjustment value.</param>
    [<Extension>]
    static member inline placementConstraintAdjustment(this: WidgetBuilder<'msg, #IFabContextMenu>, value: PopupPositionerConstraintAdjustment) =
        this.AddScalar(ContextMenu.PlacementConstraintAdjustment.WithValue(value))

    /// <summary>Sets the PlacementAnchor property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlacementAnchor value.</param>
    [<Extension>]
    static member inline placementAnchor(this: WidgetBuilder<'msg, #IFabContextMenu>, value: PopupAnchor) =
        this.AddScalar(ContextMenu.PlacementAnchor.WithValue(value))

    /// <summary>Sets the PlacementGravity property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlacementGravity value.</param>
    [<Extension>]
    static member inline placementGravity(this: WidgetBuilder<'msg, #IFabContextMenu>, value: PopupGravity) =
        this.AddScalar(ContextMenu.PlacementGravity.WithValue(value))

    /// <summary>Sets the PlacementRect property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlacementRect value.</param>
    [<Extension>]
    static member inline placementRect(this: WidgetBuilder<'msg, #IFabContextMenu>, value: Rect) =
        this.AddScalar(ContextMenu.PlacementRect.WithValue(value))

    /// <summary>Sets the WindowManagerAddShadowHint property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The WindowManagerAddShadowHint value.</param>
    [<Extension>]
    static member inline windowManagerAddShadowHint(this: WidgetBuilder<'msg, #IFabContextMenu>, value: bool) =
        this.AddScalar(ContextMenu.WindowManagerAddShadowHint.WithValue(value))

    /// <summary>Sets the PlacementTarget property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlacementTarget value.</param>
    [<Extension>]
    static member inline placementTarget(this: WidgetBuilder<'msg, #IFabContextMenu>, value: ViewRef<#Control>) =
        match value.TryValue with
        | None -> this
        | Some value -> this.AddScalar(ContextMenu.PlacementTarget.WithValue(value))

    /// <summary>Link a ViewRef to access the direct ContextMenu control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabContextMenu>, value: ViewRef<ContextMenu>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type ContextMenuAttachedModifiers =
    /// <summary>Sets the ContextMenu property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ContextMenu value.</param>
    [<Extension>]
    static member inline contextMenu(this: WidgetBuilder<'msg, #IFabControl>, value: WidgetBuilder<'msg, IFabContextMenu>) =
        this.AddWidget(Control.ContextMenu.WithValue(value.Compile()))

type ContextMenuCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabControl>
        (_: CollectionBuilder<'msg, 'marker, IFabControl>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabControl>
        (_: CollectionBuilder<'msg, 'marker, IFabControl>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
