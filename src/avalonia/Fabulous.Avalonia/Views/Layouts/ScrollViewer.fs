namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabScrollViewer =
    inherit IFabContentControl

module ScrollViewer =
    let WidgetKey = Widgets.register<ScrollViewer>()

    let Extent =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.ExtentProperty

    let Offset =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.OffsetProperty

    let BringIntoViewOnFocusChange =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.BringIntoViewOnFocusChangeProperty

    let HorizontalScrollBarVisibility =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.HorizontalScrollBarVisibilityProperty

    let VerticalScrollBarVisibility =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.VerticalScrollBarVisibilityProperty

    let AllowAutoHide =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.AllowAutoHideProperty

    let IsScrollChainingEnabled =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.IsScrollChainingEnabledProperty

    let HorizontalSnapPointsAlignment =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.HorizontalSnapPointsAlignmentProperty

    let HorizontalSnapPointsType =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.HorizontalSnapPointsTypeProperty

    let VerticalSnapPointsAlignment =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.VerticalSnapPointsAlignmentProperty

    let VerticalSnapPointsType =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.VerticalSnapPointsTypeProperty

    let IsScrollInertiaEnabled =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.IsScrollInertiaEnabledProperty

    let IsDeferredScrollingEnabled =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.IsDeferredScrollingEnabledProperty

[<AutoOpen>]
module ScrollViewerBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ScrollViewer widget</summary>
        /// <param name="content">The content to display</param>
        static member ScrollViewer(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabScrollViewer>(ScrollViewer.WidgetKey, ContentControl.ContentWidget.WithValue(content.Compile()))

type ScrollViewerModifiers =
    /// <summary>Sets the Extent property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsNativeMenuExported value.</param>
    [<Extension>]
    static member inline extent(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: Size) =
        this.AddScalar(ScrollViewer.Extent.WithValue(value))

    /// <summary>Sets the Offset property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Offset value.</param>
    [<Extension>]
    static member inline offset(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: Vector) =
        this.AddScalar(ScrollViewer.Offset.WithValue(value))

    /// <summary>Sets the HorizontalScrollBarVisibility property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HorizontalScrollBarVisibility value.</param>
    [<Extension>]
    static member inline horizontalScrollBarVisibility(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: ScrollBarVisibility) =
        this.AddScalar(ScrollViewer.HorizontalScrollBarVisibility.WithValue(value))

    /// <summary>Sets the VerticalScrollBarVisibility property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The VerticalScrollBarVisibility value.</param>
    [<Extension>]
    static member inline verticalScrollBarVisibility(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: ScrollBarVisibility) =
        this.AddScalar(ScrollViewer.VerticalScrollBarVisibility.WithValue(value))

    /// <summary>Sets the AllowAutoHide property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AllowAutoHide value.</param>
    [<Extension>]
    static member inline allowAutoHide(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: bool) =
        this.AddScalar(ScrollViewer.AllowAutoHide.WithValue(value))

    /// <summary>Sets the IsScrollChainingEnabled property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsScrollChainingEnabled value.</param>
    [<Extension>]
    static member inline isScrollChainingEnabled(this: WidgetBuilder<'msg, #IFabControl>, value: bool) =
        this.AddScalar(ScrollViewer.IsScrollChainingEnabled.WithValue(value))

    /// <summary>Sets the HorizontalSnapPointsAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HorizontalSnapPointsAlignment value.</param>
    [<Extension>]
    static member inline horizontalSnapPointsAlignment(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: SnapPointsAlignment) =
        this.AddScalar(ScrollViewer.HorizontalSnapPointsAlignment.WithValue(value))

    /// <summary>Sets the HorizontalSnapPointsType property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HorizontalSnapPointsType value.</param>
    [<Extension>]
    static member inline horizontalSnapPointsType(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: SnapPointsType) =
        this.AddScalar(ScrollViewer.HorizontalSnapPointsType.WithValue(value))

    /// <summary>Sets the VerticalSnapPointsAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The VerticalSnapPointsAlignment value.</param>
    [<Extension>]
    static member inline verticalSnapPointsAlignment(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: SnapPointsAlignment) =
        this.AddScalar(ScrollViewer.VerticalSnapPointsAlignment.WithValue(value))

    /// <summary>Sets the VerticalSnapPointsType property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The VerticalSnapPointsType value.</param>
    [<Extension>]
    static member inline verticalSnapPointsType(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: SnapPointsType) =
        this.AddScalar(ScrollViewer.VerticalSnapPointsType.WithValue(value))

    /// <summary>Sets the IsScrollInertiaEnabled property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsScrollInertiaEnabled value.</param>
    [<Extension>]
    static member inline isScrollInertiaEnabled(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: bool) =
        this.AddScalar(ScrollViewer.IsScrollInertiaEnabled.WithValue(value))

    /// <summary>Sets the IsDeferredScrollingEnabled property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsDeferredScrollingEnabled value.</param>
    [<Extension>]
    static member inline isDeferredScrollingEnabled(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: bool) =
        this.AddScalar(ScrollViewer.IsDeferredScrollingEnabled.WithValue(value))

    /// <summary>Link a ViewRef to access the direct ScrollViewer control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabScrollViewer>, value: ViewRef<ScrollViewer>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type ScrollViewerAttachedModifiers =
    /// <summary>Sets the BringIntoViewOnFocusChange property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BringIntoViewOnFocusChange value.</param>
    [<Extension>]
    static member inline bringIntoViewOnFocusChange(this: WidgetBuilder<'msg, #IFabControl>, value: bool) =
        this.AddScalar(ScrollViewer.BringIntoViewOnFocusChange.WithValue(value))
