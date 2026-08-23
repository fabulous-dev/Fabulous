namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Data
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabDataGridTextColumn =
    inherit IFabDataGridColumn

module DataGridTextColumn =
    let WidgetKey = Widgets.register<DataGridTextColumn>()

    let FontFamily =
        Attributes.defineAvaloniaPropertyWithEquality DataGridTextColumn.FontFamilyProperty

    let FontSize =
        Attributes.defineAvaloniaPropertyWithEquality DataGridTextColumn.FontSizeProperty

    let FontStyle =
        Attributes.defineAvaloniaPropertyWithEquality DataGridTextColumn.FontStyleProperty

    let FontWeight =
        Attributes.defineAvaloniaPropertyWithEquality DataGridTextColumn.FontWeightProperty

    let FontStretch =
        Attributes.defineAvaloniaPropertyWithEquality DataGridTextColumn.FontStretchProperty

    let Foreground =
        Attributes.defineAvaloniaPropertyWithEquality DataGridTextColumn.ForegroundProperty

    let ForegroundWidget =
        Attributes.defineAvaloniaPropertyWidget DataGridTextColumn.ForegroundProperty

[<AutoOpen>]
module DataGridTextColumnBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a DataGridTextColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridTextColumn(header: string, binding: IBinding) =
            WidgetBuilder<'msg, IFabDataGridTextColumn>(
                DataGridTextColumn.WidgetKey,
                DataGridColumn.HeaderString.WithValue(header),
                DataGridBoundColumn.Binding.WithValue(binding)
            )

        /// <summary>Creates a DataGridTextColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridTextColumn(header: string, binding: string) =
            WidgetBuilder<'msg, IFabDataGridTextColumn>(
                DataGridTextColumn.WidgetKey,
                DataGridColumn.HeaderString.WithValue(header),
                DataGridBoundColumn.Binding.WithValue(Binding(binding))
            )

        /// <summary>Creates a DataGridTextColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridTextColumn(header: WidgetBuilder<'msg, #IFabControl>, binding: IBinding) =
            WidgetBuilder<'msg, IFabDataGridTextColumn>(
                DataGridTextColumn.WidgetKey,
                AttributesBundle(
                    StackList.one(DataGridBoundColumn.Binding.WithValue(binding)),
                    [| DataGridColumn.HeaderWidget.WithValue(header.Compile()) |],
                    [||],
                    [||]
                )
            )

        /// <summary>Creates a DataGridTextColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridTextColumn(header: WidgetBuilder<'msg, #IFabControl>, binding: string) =
            WidgetBuilder<'msg, IFabDataGridTextColumn>(
                DataGridTextColumn.WidgetKey,
                AttributesBundle(
                    StackList.one(DataGridBoundColumn.Binding.WithValue(Binding(binding))),
                    [| DataGridColumn.HeaderWidget.WithValue(header.Compile()) |],
                    [||],
                    [||]
                )
            )

type DataGridTextColumnModifiers =
    /// <summary>Link a ViewRef to access the direct DataGridTextColumn control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabDataGridTextColumn>, value: ViewRef<DataGridTextColumn>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

    /// <summary>Set the FontFamily property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontFamily property value.</param>
    [<Extension>]
    static member inline fontFamily(this: WidgetBuilder<'msg, #IFabDataGridTextColumn>, value: FontFamily) =
        this.AddScalar(DataGridTextColumn.FontFamily.WithValue(value))

    /// <summary>Set the FontSize property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontSize property value.</param>
    [<Extension>]
    static member inline fontSize(this: WidgetBuilder<'msg, #IFabDataGridTextColumn>, value: float) =
        this.AddScalar(DataGridTextColumn.FontSize.WithValue(value))

    /// <summary>Set the FontStyle property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontStyle property value.</param>
    [<Extension>]
    static member inline fontStyle(this: WidgetBuilder<'msg, #IFabDataGridTextColumn>, value: FontStyle) =
        this.AddScalar(DataGridTextColumn.FontStyle.WithValue(value))

    /// <summary>Set the FontWeight property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontWeight property value.</param>
    [<Extension>]
    static member inline fontWeight(this: WidgetBuilder<'msg, #IFabDataGridTextColumn>, value: FontWeight) =
        this.AddScalar(DataGridTextColumn.FontWeight.WithValue(value))

    /// <summary>Set the FontStretch property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontStretch property value.</param>
    [<Extension>]
    static member inline fontStretch(this: WidgetBuilder<'msg, #IFabDataGridTextColumn>, value: FontStretch) =
        this.AddScalar(DataGridTextColumn.FontStretch.WithValue(value))

    /// <summary>Set the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground property value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabDataGridTextColumn>, value: IBrush) =
        this.AddScalar(DataGridTextColumn.Foreground.WithValue(value))

    /// <summary>Set the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground property value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, IFabDataGridTextColumn>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(DataGridTextColumn.ForegroundWidget.WithValue(value.Compile()))

    /// <summary>Set the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground property value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, IFabDataGridTextColumn>, value: Color) =
        DataGridTextColumnModifiers.foreground(this, View.SolidColorBrush(value))

    /// <summary>Set the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground property value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, IFabDataGridTextColumn>, value: string) =
        DataGridTextColumnModifiers.foreground(this, View.SolidColorBrush(Color.Parse(value)))
