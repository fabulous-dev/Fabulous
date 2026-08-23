namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections

[<AutoOpen>]
module PanelBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Panel widget.</summary>
        static member Panel() =
            CollectionBuilder<'msg, IFabPanel, IFabControl>(Panel.WidgetKey, Panel.Children)

type PanelModifiers =
    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabPanel>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Panel.BackgroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabPanel>, value: IBrush) =
        this.AddScalar(Panel.Background.WithValue(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabPanel>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TextElement.ForegroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabPanel>, value: IBrush) =
        this.AddScalar(TextElement.Foreground.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Panel control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPanel>, value: ViewRef<Panel>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type PanelExtraModifiers =
    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabPanel>, value: Color) =
        PanelModifiers.background(this, View.SolidColorBrush(value))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabPanel>, value: string) =
        PanelModifiers.background(this, View.SolidColorBrush(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabPanel>, value: Color) =
        PanelModifiers.foreground(this, View.SolidColorBrush(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabPanel>, value: string) =
        PanelModifiers.foreground(this, View.SolidColorBrush(value))

type PanelCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'marker :> IFabPanel and 'itemType :> IFabControl>
        (_: CollectionBuilder<'msg, 'marker, IFabControl>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'marker :> IFabPanel and 'itemType :> IFabControl>
        (_: CollectionBuilder<'msg, 'marker, IFabControl>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
