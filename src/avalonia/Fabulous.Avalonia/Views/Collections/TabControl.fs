namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Layout
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabTabControl =
    inherit IFabSelectingItemsControl

module TabControl =
    let WidgetKey = Widgets.register<TabControl>()

    let TabStripPlacement =
        Attributes.defineAvaloniaPropertyWithEquality TabControl.TabStripPlacementProperty

    let HorizontalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality TabControl.HorizontalContentAlignmentProperty

    let VerticalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality TabControl.VerticalContentAlignmentProperty


[<AutoOpen>]
module TabControlBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TabControl widget.</summary>
        /// <param name="placement">The placement of the tab strip.</param>
        static member TabControl(placement: Dock) =
            CollectionBuilder<'msg, IFabTabControl, IFabTabItem>(TabControl.WidgetKey, ItemsControl.Items, TabControl.TabStripPlacement.WithValue(placement))

        /// <summary>Creates a TabControl widget.</summary>
        static member TabControl() =
            CollectionBuilder<'msg, IFabTabControl, IFabTabItem>(TabControl.WidgetKey, ItemsControl.Items, TabControl.TabStripPlacement.WithValue(Dock.Top))

type TabControlModifiers =
    /// <summary>Sets the HorizontalContentAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HorizontalContentAlignment value.</param>
    [<Extension>]
    static member inline horizontalContentAlignment(this: WidgetBuilder<'msg, #IFabTabControl>, value: HorizontalAlignment) =
        this.AddScalar(TabControl.HorizontalContentAlignment.WithValue(value))

    /// <summary>Sets the VerticalContentAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The VerticalContentAlignment value.</param>
    [<Extension>]
    static member inline verticalContentAlignment(this: WidgetBuilder<'msg, #IFabTabControl>, value: VerticalAlignment) =
        this.AddScalar(TabControl.VerticalContentAlignment.WithValue(value))

    /// <summary>Link a ViewRef to access the direct TabControl control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTabControl>, value: ViewRef<TabControl>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type TabControlExtraModifiers =

    /// <summary>Sets the HorizontalContentAlignment property to center.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline centerHorizontal(this: WidgetBuilder<'msg, #IFabTabControl>) =
        TabControlModifiers.horizontalContentAlignment(this, HorizontalAlignment.Center)

    /// <summary>Sets the VerticalContentAlignment property to center.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline centerVertical(this: WidgetBuilder<'msg, #IFabTabControl>) =
        TabControlModifiers.verticalContentAlignment(this, VerticalAlignment.Center)

    // <summary>Sets the HorizontalContentAlignment and VerticalContentAlignment properties to center.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline center(this: WidgetBuilder<'msg, #IFabTabControl>) =
        this.centerHorizontal().centerVertical()

type TabControlCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabTabItem>
        (_: CollectionBuilder<'msg, 'marker, IFabTabItem>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabTabItem>
        (_: CollectionBuilder<'msg, 'marker, IFabTabItem>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
