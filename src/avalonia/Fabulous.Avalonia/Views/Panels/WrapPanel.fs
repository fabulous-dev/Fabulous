namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Layout
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabWrapPanel =
    inherit IFabPanel

module WrapPanel =
    let WidgetKey = Widgets.register<WrapPanel>()

    let Orientation =
        Attributes.defineAvaloniaPropertyWithEquality WrapPanel.OrientationProperty

    let ItemWidth =
        Attributes.defineAvaloniaPropertyWithEquality WrapPanel.ItemWidthProperty

    let ItemHeight =
        Attributes.defineAvaloniaPropertyWithEquality WrapPanel.ItemHeightProperty

    let ItemsAlignment =
        Attributes.defineAvaloniaPropertyWithEquality WrapPanel.ItemsAlignmentProperty

    let ItemSpacing =
        Attributes.defineAvaloniaPropertyWithEquality WrapPanel.ItemSpacingProperty

    let LineSpacing =
        Attributes.defineAvaloniaPropertyWithEquality WrapPanel.LineSpacingProperty

[<AutoOpen>]
module WrapPanelBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a <see cref="WrapPanel" /> with <see cref="WrapPanel.Orientation" /> set to <see cref="Orientation.Vertical" />
        /// rendering child elements from left to right while they fit the width and starting a new line when there is no space left
        /// (including any margins and borders). See <seealso href="https://docs.avaloniaui.net/docs/reference/controls/detailed-reference/wrappanel" />.</summary>
        static member VWrap() =
            CollectionBuilder<'msg, IFabWrapPanel, IFabControl>(WrapPanel.WidgetKey, Panel.Children, WrapPanel.Orientation.WithValue(Orientation.Vertical))

        /// <summary>Creates a <see cref="WrapPanel" /> with <see cref="WrapPanel.Orientation" /> set to <see cref="Orientation.Vertical" />
        /// rendering child elements from left to right while they fit the width and starting a new line when there is no space left
        /// (including any margins and borders). See <seealso href="https://docs.avaloniaui.net/docs/reference/controls/detailed-reference/wrappanel" />.</summary>
        /// <param name="alignment">The ItemsAlignment value.</param>
        static member VWrap(alignment: WrapPanelItemsAlignment) =
            CollectionBuilder<'msg, IFabWrapPanel, IFabControl>(
                WrapPanel.WidgetKey,
                Panel.Children,
                AttributesBundle(
                    StackList.two(WrapPanel.Orientation.WithValue(Orientation.Vertical), WrapPanel.ItemsAlignment.WithValue(alignment)),
                    [||],
                    [||],
                    [||]
                )
            )

        /// <summary>Creates a <see cref="WrapPanel" /> with <see cref="WrapPanel.Orientation" /> set to <see cref="Orientation.Horizontal" />
        /// rendering child elements from top to bottom while they fit the height and starting a new column when there is no space left
        /// (including any margins and borders). See <seealso href="https://docs.avaloniaui.net/docs/reference/controls/detailed-reference/wrappanel" />.</summary>
        static member HWrap() =
            CollectionBuilder<'msg, IFabWrapPanel, IFabControl>(WrapPanel.WidgetKey, Panel.Children, WrapPanel.Orientation.WithValue(Orientation.Horizontal))

        /// <summary>Creates a <see cref="WrapPanel" /> with <see cref="WrapPanel.Orientation" /> set to <see cref="Orientation.Horizontal" />
        /// </summary>
        /// <param name="alignment">The ItemsAlignment value.</param>
        static member HWrap(alignment: WrapPanelItemsAlignment) =
            CollectionBuilder<'msg, IFabWrapPanel, IFabControl>(
                WrapPanel.WidgetKey,
                Panel.Children,
                AttributesBundle(
                    StackList.two(WrapPanel.Orientation.WithValue(Orientation.Horizontal), WrapPanel.ItemsAlignment.WithValue(alignment)),
                    [||],
                    [||],
                    [||]
                )
            )

type WrapPanelModifiers =
    /// <summary>Sets the <see cref="WrapPanel.ItemWidth" /> property, i.e. the width of all items in the <see cref="WrapPanel" />.
    /// See <seealso href="https://reference.avaloniaui.net/api/Avalonia.Controls/WrapPanel/B89757B8" />.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The <see cref="WrapPanel.ItemWidth" /> value.</param>
    [<Extension>]
    static member inline itemWidth(this: WidgetBuilder<'msg, #IFabWrapPanel>, value: float) =
        this.AddScalar(WrapPanel.ItemWidth.WithValue(value))

    /// <summary>Sets the <see cref="WrapPanel.ItemHeight" /> property, i.e. the height of all items in the <see cref="WrapPanel" />.
    /// See <seealso href="https://reference.avaloniaui.net/api/Avalonia.Controls/WrapPanel/3AAE129B" />.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The <see cref="WrapPanel.ItemHeight" /> value.</param>
    [<Extension>]
    static member inline itemHeight(this: WidgetBuilder<'msg, #IFabWrapPanel>, value: float) =
        this.AddScalar(WrapPanel.ItemHeight.WithValue(value))

    /// <summary>Sets the ItemSpacing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ItemSpacing value.</param>
    [<Extension>]
    static member inline itemSpacing(this: WidgetBuilder<'msg, #IFabWrapPanel>, value: float) =
        this.AddScalar(WrapPanel.ItemSpacing.WithValue(value))

    /// <summary>Sets the LineSpacing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The LineSpacing value.</param>
    [<Extension>]
    static member inline lineSpacing(this: WidgetBuilder<'msg, #IFabWrapPanel>, value: float) =
        this.AddScalar(WrapPanel.LineSpacing.WithValue(value))

    /// <summary>Link a ViewRef to access the direct WrapPanel control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabWrapPanel>, value: ViewRef<WrapPanel>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
