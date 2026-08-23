namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

/// Represents a dimension for either the row or column definition of a Grid
type Dimension =
    /// Use a size that fits the children of the row or column.
    | Auto
    /// Use a proportional size of 1
    | Star
    /// Use a proportional size defined by the associated value
    | Stars of float
    /// Use the associated value as the number of device-specific units.
    | Absolute of float

type IFabGrid =
    inherit IFabLayoutOfView

module GridUpdaters =
    let updateGridColumnDefinitions _ (newValueOpt: Dimension[] voption) (node: IViewNode) =
        let grid = node.Target :?> Grid

        match newValueOpt with
        | ValueNone -> grid.ColumnDefinitions.Clear()
        | ValueSome coll ->
            grid.ColumnDefinitions.Clear()

            for c in coll do
                let gridLength =
                    match c with
                    | Auto -> GridLength.Auto
                    | Star -> GridLength.Star
                    | Stars x -> GridLength(x, GridUnitType.Star)
                    | Absolute x -> GridLength(x, GridUnitType.Absolute)

                grid.ColumnDefinitions.Add(ColumnDefinition(Width = gridLength))

    let updateGridRowDefinitions _ (newValueOpt: Dimension[] voption) (node: IViewNode) =
        let grid = node.Target :?> Grid

        match newValueOpt with
        | ValueNone -> grid.RowDefinitions.Clear()
        | ValueSome coll ->
            grid.RowDefinitions.Clear()

            for c in coll do
                let gridLength =
                    match c with
                    | Auto -> GridLength.Auto
                    | Star -> GridLength.Star
                    | Stars x -> GridLength(x, GridUnitType.Star)
                    | Absolute x -> GridLength(x, GridUnitType.Absolute)

                grid.RowDefinitions.Add(RowDefinition(Height = gridLength))

module Grid =
    let WidgetKey = Widgets.register<Grid>()

    let ColumnDefinitions =
        Attributes.defineSimpleScalarWithEquality<Dimension array> "Grid_ColumnDefinitions" GridUpdaters.updateGridColumnDefinitions

    let ColumnSpacing = Attributes.defineBindableFloat Grid.ColumnSpacingProperty

    let RowDefinitions =
        Attributes.defineSimpleScalarWithEquality<Dimension array> "Grid_RowDefinitions" GridUpdaters.updateGridRowDefinitions

    let RowSpacing = Attributes.defineBindableFloat Grid.RowSpacingProperty

module GridAttached =
    let Column = Attributes.defineBindableInt Grid.ColumnProperty

    let ColumnSpan = Attributes.defineBindableInt Grid.ColumnSpanProperty

    let Row = Attributes.defineBindableInt Grid.RowProperty

    let RowSpan = Attributes.defineBindableInt Grid.RowSpanProperty

[<AutoOpen>]
module GridBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a Grid widget with only one cell</summary>
        static member inline Grid<'msg when 'msg: equality>() =
            CollectionBuilder<'msg, IFabGrid, IFabView>(Grid.WidgetKey, LayoutOfView.Children)

        /// <summary>Create a Grid widget with the given column and row definitions</summary>
        /// <param name="coldefs">The column definitions</param>
        /// <param name="rowdefs">The row definitions</param>
        static member inline Grid<'msg when 'msg: equality>(coldefs: seq<Dimension>, rowdefs: seq<Dimension>) =
            CollectionBuilder<'msg, IFabGrid, IFabView>(
                Grid.WidgetKey,
                LayoutOfView.Children,
                Grid.ColumnDefinitions.WithValue(Array.ofSeq coldefs),
                Grid.RowDefinitions.WithValue(Array.ofSeq rowdefs)
            )

[<Extension>]
type GridModifiers =
    /// <summary>Set the spacing between each column</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The spacing value</param>
    [<Extension>]
    static member inline columnSpacing(this: WidgetBuilder<'msg, #IFabGrid>, value: float) =
        this.AddScalar(Grid.ColumnSpacing.WithValue(value))

    /// <summary>Set the spacing between each row</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The spacing value</param>
    [<Extension>]
    static member inline rowSpacing(this: WidgetBuilder<'msg, #IFabGrid>, value: float) =
        this.AddScalar(Grid.RowSpacing.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Grid control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabGrid>, value: ViewRef<Grid>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type GridAttachedModifiers =
    /// <summary>Set the column this widget will be in</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The grid column index. Starts at 0</param>
    [<Extension>]
    static member inline gridColumn(this: WidgetBuilder<'msg, #IFabView>, value: int) =
        this.AddScalar(GridAttached.Column.WithValue(value))

    /// <summary>Set how many columns this widget will span</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The number of columns to span</param>
    [<Extension>]
    static member inline gridColumnSpan(this: WidgetBuilder<'msg, #IFabView>, value: int) =
        this.AddScalar(GridAttached.ColumnSpan.WithValue(value))

    /// <summary>Set the row this widget will be in</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The grid row index. Starts at 0</param>
    [<Extension>]
    static member inline gridRow(this: WidgetBuilder<'msg, #IFabView>, value: int) =
        this.AddScalar(GridAttached.Row.WithValue(value))

    /// <summary>Set how many rows this widget will span</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The number of rows to span</param>
    [<Extension>]
    static member inline gridRowSpan(this: WidgetBuilder<'msg, #IFabView>, value: int) =
        this.AddScalar(GridAttached.RowSpan.WithValue(value))
