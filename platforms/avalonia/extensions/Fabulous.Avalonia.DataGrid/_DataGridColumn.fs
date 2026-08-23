namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia

type IFabDataGridColumn =
    inherit IFabElement

module DataGridColumn =
    let HeaderWidget =
        Attributes.defineAvaloniaPropertyWidget DataGridColumn.HeaderProperty

    let HeaderString =
        Attributes.defineAvaloniaProperty<string, obj> DataGridColumn.HeaderProperty box ScalarAttributeComparers.equalityCompare

    let CellTheme =
        Attributes.defineAvaloniaPropertyWithEquality DataGridColumn.CellThemeProperty

    let Width =
        Attributes.defineAvaloniaPropertyWithEquality DataGridColumn.WidthProperty

    let IsVisible =
        Attributes.defineAvaloniaPropertyWithEquality DataGridColumn.IsVisibleProperty

type DataGridColumnModifiers =

    /// <summary>Sets the CellTheme property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CellTheme value.</param>
    [<Extension>]
    static member inline cellTheme(this: WidgetBuilder<'msg, #IFabDataGridColumn>, value: ControlTheme) =
        this.AddScalar(DataGridColumn.CellTheme.WithValue(value))

    /// <summary>Sets the Width property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Width value.</param>
    [<Extension>]
    static member inline width(this: WidgetBuilder<'msg, #IFabDataGridColumn>, value: DataGridLength) =
        this.AddScalar(DataGridColumn.Width.WithValue(value))

    /// <summary>Sets the Width property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Width value.</param>
    [<Extension>]
    static member inline width(this: WidgetBuilder<'msg, #IFabDataGridColumn>, value: float) =
        this.AddScalar(DataGridColumn.Width.WithValue(DataGridLength(value)))

    /// <summary>Sets the IsVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsVisible value.</param>
    [<Extension>]
    static member inline isVisible(this: WidgetBuilder<'msg, #IFabDataGridColumn>, value: bool) =
        this.AddScalar(DataGridColumn.IsVisible.WithValue(value))
