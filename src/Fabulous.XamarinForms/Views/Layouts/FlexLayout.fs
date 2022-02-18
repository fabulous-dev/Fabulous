namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IFlexLayout =
    inherit ILayoutOfView

module FlexLayout =

    let WidgetKey = Widgets.register<FlexLayout> ()

    let AlignContent =
        Attributes.defineBindable<FlexAlignContent> FlexLayout.AlignContentProperty

    let AlignItems =
        Attributes.defineBindable<FlexAlignItems> FlexLayout.AlignItemsProperty

    let AlignSelf =
        Attributes.defineBindable<FlexAlignSelf> FlexLayout.AlignSelfProperty

    let Basis =
        Attributes.defineBindable<FlexBasis> FlexLayout.BasisProperty

    let Direction =
        Attributes.defineBindable<FlexDirection> FlexLayout.DirectionProperty

    let Grow =
        Attributes.defineBindable<float> FlexLayout.GrowProperty

    let JustifyContent =
        Attributes.defineBindable<FlexJustify> FlexLayout.JustifyContentProperty

    let Order =
        Attributes.defineBindable<int> FlexLayout.OrderProperty

    let Position =
        Attributes.defineBindable<FlexPosition> FlexLayout.PositionProperty

    let Shrink =
        Attributes.defineBindable<float> FlexLayout.ShrinkProperty

    let Wrap =
        Attributes.defineBindable<FlexWrap> FlexLayout.WrapProperty

[<AutoOpen>]
module FlexLayoutBuilders =
    type Fabulous.XamarinForms.View with
        static member inline FlexLayout<'msg>() =
            CollectionBuilder<'msg, IFlexLayout, IView>(FlexLayout.WidgetKey, LayoutOfView.Children)

[<Extension>]
type FlexLayoutModifiers =
    /// <summary>Sets a value that controls how multiple rows or columns of child elements are aligned.</summary>
    /// <param name="value">Enumerates values that control how multiple rows or columns of child elements are aligned.</param>
    [<Extension>]
    static member inline alignContent(this: WidgetBuilder<'msg, #IFlexLayout>, value: FlexAlignContent) =
        this.AddScalar(FlexLayout.AlignContent.WithValue(value))

    /// <summary>Sets a value that controls how child elements are laid out within their row or column.</summary>
    /// <param name="value">Enumerates values that control the alignment of child elements.</param>
    [<Extension>]
    static member inline alignItems(this: WidgetBuilder<'msg, #IFlexLayout>, value: FlexAlignItems) =
        this.AddScalar(FlexLayout.AlignItems.WithValue(value))

    /// <summary>Sets the flex direction for child elements within this layout.</summary>
    /// <param name="value">Enumerates values that specify row and colum in flex layout directions, relative to the directions for the device locale.</param>
    [<Extension>]
    static member inline direction(this: WidgetBuilder<'msg, #IFlexLayout>, value: FlexDirection) =
        this.AddScalar(FlexLayout.Direction.WithValue(value))

    /// <summary>Sets a value that controls whether and how child elements within this layout wrap.</summary>
    /// <param name="value">Enumerates values that control whether and how to wrap items in a FlexLayout.</param>
    [<Extension>]
    static member inline wrap(this: WidgetBuilder<'msg, #IFlexLayout>, value: FlexWrap) =
        this.AddScalar(FlexLayout.Wrap.WithValue(value))

    /// <summary>Sets a value that controls whether the coordinates of child elements are specified in absolute or relative terms.</summary>
    /// <param name="value">Enumerates values that control how layout coordinates are interpreted when specifying the positions of child elements.</param>
    [<Extension>]
    static member inline position(this: WidgetBuilder<'msg, #IFlexLayout>, value: FlexPosition) =
        this.AddScalar(FlexLayout.Position.WithValue(value))

    /// <summary>Sets a value that describes how child elements are justified when there is extra space around them.</summary>
    /// <param name="value">Enumerates values that control how child elements are justified when there is extra space around them.</param>
    [<Extension>]
    static member inline justifyContent(this: WidgetBuilder<'msg, #IFlexLayout>, value: FlexJustify) =
        this.AddScalar(FlexLayout.JustifyContent.WithValue(value))

[<Extension>]
type FlexLayoutAttachedModifiers =
    /// <summary>Sets a value that the element will use the alignment supplied by the FlexAlignItems</summary>
    /// <param name="value">Enumerates values that control how and whether a child element overrides alignment attributes applied by its parent.</param>
    [<Extension>]
    static member inline flexAlignSelf(this: WidgetBuilder<'msg, #IView>, value: FlexAlignSelf) =
        this.AddScalar(FlexLayout.AlignSelf.WithValue(value))

    /// <summary>Sets a value that controls the element's relative or absolute basis.</summary>
    /// <param name="value">Enumerates values that control the element's relative or absolute basis.</param>
    [<Extension>]
    static member inline flexBasis(this: WidgetBuilder<'msg, #IView>, value: FlexBasis) =
        this.AddScalar(FlexLayout.Basis.WithValue(value))

    /// <summary>Sets a value that controls the element's relative or absolute basis.</summary>
    /// <param name="value">Value that controls the element's relative or absolute basis.</param>
    [<Extension>]
    static member inline flexBasis(this: WidgetBuilder<'msg, #IView>, value: float) =
        this.AddScalar(FlexLayout.Basis.WithValue(FlexBasis.op_Implicit (float32 value)))

    /// <summary>Sets a value that that determines the proportional growth that this element will accept to accommodate the layout in the row or column.</summary>
    /// <param name="value">Value that determines the proportional growth.</param>
    [<Extension>]
    static member inline flexGrow(this: WidgetBuilder<'msg, #IView>, value: float) =
        this.AddScalar(FlexLayout.Grow.WithValue(value))

    /// <summary>Sets a value that that determines this element's visual order among its siblings.</summary>
    /// <param name="value">Value that determines this element's visual order.</param>
    [<Extension>]
    static member inline flexOrder(this: WidgetBuilder<'msg, #IView>, value: int) =
        this.AddScalar(FlexLayout.Order.WithValue(value))

    /// <summary>Sets a value that determines the proportional reduction in size that this element will accept to accommodate the layout in the row or column.</summary>
    /// <param name="value">Value that determines the proportional reduction in size.</param>
    [<Extension>]
    static member inline flexShrink(this: WidgetBuilder<'msg, #IView>, value: float) =
        this.AddScalar(FlexLayout.Shrink.WithValue(value))
