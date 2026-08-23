namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabSelectableTextBlock =
    inherit IFabTextBlock

module SelectableTextBlock =
    let WidgetKey = Widgets.register<SelectableTextBlock>()

    let SelectionStart =
        Attributes.defineAvaloniaPropertyWithEquality SelectableTextBlock.SelectionStartProperty

    let SelectionEnd =
        Attributes.defineAvaloniaPropertyWithEquality SelectableTextBlock.SelectionEndProperty

    let SelectionBrushWidget =
        Attributes.defineAvaloniaPropertyWidget SelectableTextBlock.SelectionBrushProperty

    let SelectionBrush =
        Attributes.defineAvaloniaPropertyWithEquality SelectableTextBlock.SelectionBrushProperty

type SelectableTextBlockModifiers =

    /// <summary>Sets the SelectionStart property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionStart value.</param>
    [<Extension>]
    static member inline selectionStart(this: WidgetBuilder<'msg, #IFabSelectableTextBlock>, value: int) =
        this.AddScalar(SelectableTextBlock.SelectionStart.WithValue(value))

    /// <summary>Sets the SelectionEnd property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionEnd value.</param>
    [<Extension>]
    static member inline selectionEnd(this: WidgetBuilder<'msg, #IFabSelectableTextBlock>, value: int) =
        this.AddScalar(SelectableTextBlock.SelectionEnd.WithValue(value))

    /// <summary>Sets the SelectionBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionBrush value.</param>
    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<'msg, #IFabSelectableTextBlock>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(SelectableTextBlock.SelectionBrushWidget.WithValue(value.Compile()))

    /// <summary>Sets the SelectionBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionBrush value.</param>
    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<'msg, #IFabSelectableTextBlock>, value: IBrush) =
        this.AddScalar(SelectableTextBlock.SelectionBrush.WithValue(value))

    /// <summary>Sets the SelectionBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionBrush value.</param>
    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<'msg, #IFabSelectableTextBlock>, value: Color) =
        SelectableTextBlockModifiers.selectionBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the SelectionBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionBrush value.</param>
    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<'msg, #IFabSelectableTextBlock>, value: string) =
        SelectableTextBlockModifiers.selectionBrush(this, View.SolidColorBrush(value))

    /// <summary>Link a ViewRef to access the direct SelectableTextBlock control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabSelectableTextBlock>, value: ViewRef<SelectableTextBlock>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type SelectableTextBlockCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabInline>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabInline>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabInline>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabInline>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
