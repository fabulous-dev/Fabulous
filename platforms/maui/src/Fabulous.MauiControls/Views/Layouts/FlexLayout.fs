namespace Fabulous.Maui

open System
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Layouts

type IFabFlexLayout =
    inherit IFabLayoutOfView

module FlexLayout =
    let WidgetKey = Widgets.register<FlexLayout>()

    let AlignContent =
        Attributes.defineBindableEnum<FlexAlignContent> FlexLayout.AlignContentProperty

    let AlignItems =
        Attributes.defineBindableEnum<FlexAlignItems> FlexLayout.AlignItemsProperty

    let Direction =
        Attributes.defineBindableEnum<FlexDirection> FlexLayout.DirectionProperty

    let JustifyContent =
        Attributes.defineBindableEnum<FlexJustify> FlexLayout.JustifyContentProperty

    let Position =
        Attributes.defineBindableEnum<FlexPosition> FlexLayout.PositionProperty

    let Wrap = Attributes.defineBindableEnum<FlexWrap> FlexLayout.WrapProperty

module FlexLayoutAttached =
    let AlignSelf =
        Attributes.defineBindableEnum<FlexAlignSelf> FlexLayout.AlignSelfProperty

    let Basis =
        Attributes.defineBindableWithEquality<FlexBasis> FlexLayout.BasisProperty

    let Grow = Attributes.defineBindableFloat FlexLayout.GrowProperty

    let Order = Attributes.defineBindableInt FlexLayout.OrderProperty

    let Shrink = Attributes.defineBindableFloat FlexLayout.ShrinkProperty

[<AutoOpen>]
module FlexLayoutBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a FlexLayout</summary>
        static member inline FlexLayout<'msg when 'msg: equality>() =
            CollectionBuilder<'msg, IFabFlexLayout, IFabView>(FlexLayout.WidgetKey, LayoutOfView.Children)

        /// <summary>Create a FlexLayout widget with a wrap value</summary>
        /// <param name="wrap">The wrap value</param>
        static member inline FlexLayout<'msg when 'msg: equality>(wrap: FlexWrap) =
            CollectionBuilder<'msg, IFabFlexLayout, IFabView>(FlexLayout.WidgetKey, LayoutOfView.Children, FlexLayout.Wrap.WithValue(wrap))

[<Extension>]
type FlexLayoutModifiers =
    /// <summary>Set a value that controls how multiple rows or columns of child elements are aligned</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value that controls how multiple rows or columns of child elements are aligned</param>
    [<Extension>]
    static member inline alignContent(this: WidgetBuilder<'msg, #IFabFlexLayout>, value: FlexAlignContent) =
        this.AddScalar(FlexLayout.AlignContent.WithValue(value))

    /// <summary>Set a value that controls how child elements are laid out within their row or column</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value that controls how child elements are laid out within their row or column</param>
    [<Extension>]
    static member inline alignItems(this: WidgetBuilder<'msg, #IFabFlexLayout>, value: FlexAlignItems) =
        this.AddScalar(FlexLayout.AlignItems.WithValue(value))

    /// <summary>Set the flex direction for child elements within this layout</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The flex direction</param>
    [<Extension>]
    static member inline direction(this: WidgetBuilder<'msg, #IFabFlexLayout>, value: FlexDirection) =
        this.AddScalar(FlexLayout.Direction.WithValue(value))

    /// <summary>Set a value that controls whether the coordinates of child elements are specified in absolute or relative terms</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value that controls whether the coordinates of child elements are specified in absolute or relative terms</param>
    [<Extension>]
    static member inline position(this: WidgetBuilder<'msg, #IFabFlexLayout>, value: FlexPosition) =
        this.AddScalar(FlexLayout.Position.WithValue(value))

    /// <summary>Set a value that describes how child elements are justified when there is extra space around them</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value that describes how child elements are justified when there is extra space around them</param>
    [<Extension>]
    static member inline justifyContent(this: WidgetBuilder<'msg, #IFabFlexLayout>, value: FlexJustify) =
        this.AddScalar(FlexLayout.JustifyContent.WithValue(value))

    /// <summary>Link a ViewRef to access the direct FlexLayout control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabFlexLayout>, value: ViewRef<FlexLayout>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type FlexLayoutAttachedModifiers =
    /// <summary>Set a value that the element will use the alignment supplied by the FlexAlignItems</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value that the element will use the alignment supplied by the FlexAlignItems</param>
    [<Extension>]
    static member inline flexAlignSelf(this: WidgetBuilder<'msg, #IFabView>, value: FlexAlignSelf) =
        this.AddScalar(FlexLayoutAttached.AlignSelf.WithValue(value))

    /// <summary>Set a value that controls the element's relative or absolute basis</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value that controls the element's relative or absolute basis</param>
    [<Extension>]
    static member inline flexBasis(this: WidgetBuilder<'msg, #IFabView>, value: FlexBasis) =
        this.AddScalar(FlexLayoutAttached.Basis.WithValue(value))

    /// <summary>Set a value that that determines the proportional growth that this element will accept to accommodate the layout in the row or column</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value that that determines the proportional growth that this element will accept to accommodate the layout in the row or column</param>
    [<Extension>]
    static member inline flexGrow(this: WidgetBuilder<'msg, #IFabView>, value: float) =
        this.AddScalar(FlexLayoutAttached.Grow.WithValue(value))

    /// <summary>Set a value that that determines this element's visual order among its siblings</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value that that determines this element's visual order among its siblings</param>
    [<Extension>]
    static member inline flexOrder(this: WidgetBuilder<'msg, #IFabView>, value: int) =
        this.AddScalar(FlexLayoutAttached.Order.WithValue(value))

    /// <summary>Set a value that determines the proportional reduction in size that this element will accept to accommodate the layout in the row or column</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value that determines the proportional reduction in size that this element will accept to accommodate the layout in the row or column</param>
    [<Extension>]
    static member inline flexShrink(this: WidgetBuilder<'msg, #IFabView>, value: float) =
        this.AddScalar(FlexLayoutAttached.Shrink.WithValue(value))

[<Extension>]
type FlexLayoutExtraModifiers =
    /// <summary>Set a value that controls the element's relative or absolute basis</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value that controls the element's relative or absolute basis</param>
    [<Extension>]
    static member inline flexBasis(this: WidgetBuilder<'msg, #IFabView>, value: float) =
        this.flexBasis(FlexBasis.op_Implicit(float32 value))
