namespace Fabulous.Avalonia

open System
open System.Collections
open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

module ComponentDataGrid =
    let HorizontalScroll =
        Attributes.Component.defineEvent "DataGrid_HorizontalScroll" (fun target -> (target :?> DataGrid).HorizontalScroll)

    let VerticalScroll =
        Attributes.Component.defineEvent "DataGrid_VerticalScroll" (fun target -> (target :?> DataGrid).VerticalScroll)

    let AutoGeneratingColumn =
        Attributes.Component.defineEvent "DataGrid_AutoGeneratingColumn" (fun target -> (target :?> DataGrid).AutoGeneratingColumn)

    let BeginningEdit =
        Attributes.Component.defineEvent "DataGrid_BeginningEdit" (fun target -> (target :?> DataGrid).BeginningEdit)

    let CellEditEnded =
        Attributes.Component.defineEvent "DataGrid_CellEditEnded" (fun target -> (target :?> DataGrid).CellEditEnded)

    let CellEditEnding =
        Attributes.Component.defineEvent "DataGrid_CellEditEnding" (fun target -> (target :?> DataGrid).CellEditEnding)

    let CellPointerPressed =
        Attributes.Component.defineEvent "DataGrid_CellPointerPressed" (fun target -> (target :?> DataGrid).CellPointerPressed)

    let ColumnDisplayIndexChanged =
        Attributes.Component.defineEvent "DataGrid_ColumnDisplayIndexChanged" (fun target -> (target :?> DataGrid).ColumnDisplayIndexChanged)

    let ColumnReordered =
        Attributes.Component.defineEvent "DataGrid_ColumnReordered" (fun target -> (target :?> DataGrid).ColumnReordered)

    let ColumnReordering =
        Attributes.Component.defineEvent "DataGrid_ColumnReordering" (fun target -> (target :?> DataGrid).ColumnReordering)

    let CurrentCellChanged =
        Attributes.Component.defineEvent "DataGrid_CurrentCellChanged" (fun target -> (target :?> DataGrid).CurrentCellChanged)

    let LoadingRow =
        Attributes.Component.defineEvent "DataGrid_LoadingRow" (fun target -> (target :?> DataGrid).LoadingRow)

    let PreparingCellForEdit =
        Attributes.Component.defineEvent "DataGrid_PreparingCellForEdit" (fun target -> (target :?> DataGrid).PreparingCellForEdit)

    let RowEditEnded =
        Attributes.Component.defineEvent "DataGrid_RowEditEnded" (fun target -> (target :?> DataGrid).RowEditEnded)

    let RowEditEnding =
        Attributes.Component.defineEvent "DataGrid_RowEditEnding" (fun target -> (target :?> DataGrid).RowEditEnding)

    let SelectionChanged =
        Attributes.Component.defineEvent<SelectionChangedEventArgs> "DataGrid_SelectionChanged" (fun target -> (target :?> DataGrid).SelectionChanged)

    let Sorting =
        Attributes.Component.defineEvent "DataGrid_Sorting" (fun target -> (target :?> DataGrid).Sorting)

    let UnloadingRow =
        Attributes.Component.defineEvent "DataGrid_UnloadingRow" (fun target -> (target :?> DataGrid).UnloadingRow)

    let LoadingRowDetails =
        Attributes.Component.defineEvent "DataGrid_LoadingRowDetails" (fun target -> (target :?> DataGrid).LoadingRowDetails)

    let RowDetailsVisibilityChanged =
        Attributes.Component.defineEvent "DataGrid_RowDetailsVisibilityChanged" (fun target -> (target :?> DataGrid).RowDetailsVisibilityChanged)

    let UnloadingRowDetails =
        Attributes.Component.defineEvent "DataGrid_UnloadingRowDetails" (fun target -> (target :?> DataGrid).UnloadingRowDetails)

type ComponentDataGridModifiers =
    /// <summary>Listens to the HorizontalScroll Scroll event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the HorizontalScroll value changes.</param>
    [<Extension>]
    static member inline onHorizontalScroll(this: WidgetBuilder<'msg, IFabDataGrid>, fn: ScrollEventArgs -> unit) =
        this.AddScalar(ComponentDataGrid.HorizontalScroll.WithValue(fn))

    /// <summary>Listens to the VerticalScroll Scroll event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the VerticalScroll value changes.</param>
    [<Extension>]
    static member inline onVerticalScroll(this: WidgetBuilder<'msg, IFabDataGrid>, fn: ScrollEventArgs -> unit) =
        this.AddScalar(ComponentDataGrid.VerticalScroll.WithValue(fn))

    /// <summary>Listens to the AutoGeneratingColumn event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a column is auto generated.</param>
    [<Extension>]
    static member inline onAutoGeneratingColumn(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridAutoGeneratingColumnEventArgs -> unit) =
        this.AddScalar(ComponentDataGrid.AutoGeneratingColumn.WithValue(fn))

    /// <summary>Listens to the BeginningEdit event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a cell or row begins editing.</param>
    [<Extension>]
    static member inline onBeginningEdit(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridBeginningEditEventArgs -> unit) =
        this.AddScalar(ComponentDataGrid.BeginningEdit.WithValue(fn))

    /// <summary>Listens to the CellEditEnded event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a cell edit has ended.</param>
    [<Extension>]
    static member inline onCellEditEnded(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridCellEditEndedEventArgs -> unit) =
        this.AddScalar(ComponentDataGrid.CellEditEnded.WithValue(fn))

    /// <summary>Listens to the CellEditEnding event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a cell edit is ending.</param>
    [<Extension>]
    static member inline onCellEditEnding(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridCellEditEndingEventArgs -> unit) =
        this.AddScalar(ComponentDataGrid.CellEditEnding.WithValue(fn))

    /// <summary>Listens to the CellPointerPressed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a cell is clicked.</param>
    [<Extension>]
    static member inline onCellPointerPressed(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridCellPointerPressedEventArgs -> unit) =
        this.AddScalar(ComponentDataGrid.CellPointerPressed.WithValue(fn))

    /// <summary>Listens to the ColumnDisplayIndexChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a column's DisplayIndex changes.</param>
    [<Extension>]
    static member inline onColumnDisplayIndexChanged(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridColumnEventArgs -> unit) =
        this.AddScalar(ComponentDataGrid.ColumnDisplayIndexChanged.WithValue(fn))

    /// <summary>Listens to the ColumnReordered event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a column is reordered.</param>
    [<Extension>]
    static member inline onColumnReordered(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridColumnEventArgs -> unit) =
        this.AddScalar(ComponentDataGrid.ColumnReordered.WithValue(fn))

    /// <summary>Listens to the ColumnReordering event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a column is being reordered.</param>
    [<Extension>]
    static member inline onColumnReordering(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridColumnReorderingEventArgs -> unit) =
        this.AddScalar(ComponentDataGrid.ColumnReordering.WithValue(fn))

    /// <summary>Listens to the CurrentCellChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the current cell changes.</param>
    [<Extension>]
    static member inline onCurrentCellChanged(this: WidgetBuilder<'msg, IFabDataGrid>, fn: EventArgs -> unit) =
        this.AddScalar(ComponentDataGrid.CurrentCellChanged.WithValue(fn))

    /// <summary>Listens to the LoadingRow event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row is loading.</param>
    [<Extension>]
    static member inline onLoadingRow(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridRowEventArgs -> unit) =
        this.AddScalar(ComponentDataGrid.LoadingRow.WithValue(fn))

    /// <summary>Listens to the PreparingCellForEdit event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a cell is being prepared for editing.</param>
    [<Extension>]
    static member inline onPreparingCellForEdit(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridPreparingCellForEditEventArgs -> unit) =
        this.AddScalar(ComponentDataGrid.PreparingCellForEdit.WithValue(fn))

    /// <summary>Listens to the RowEditEnded event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row edit has ended.</param>
    [<Extension>]
    static member inline onRowEditEnded(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridRowEditEndedEventArgs -> unit) =
        this.AddScalar(ComponentDataGrid.RowEditEnded.WithValue(fn))

    /// <summary>Listens to the RowEditEnding event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row edit is ending.</param>
    [<Extension>]
    static member inline onRowEditEnding(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridRowEditEndingEventArgs -> unit) =
        this.AddScalar(ComponentDataGrid.RowEditEnding.WithValue(fn))

    /// <summary>Listens to the SelectionChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the selection changes.</param>
    [<Extension>]
    static member inline onSelectionChanged(this: WidgetBuilder<'msg, IFabDataGrid>, fn: SelectionChangedEventArgs -> unit) =
        this.AddScalar(ComponentDataGrid.SelectionChanged.WithValue(fn))

    /// <summary>Listens to the Sorting event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the data is being sorted.</param>
    [<Extension>]
    static member inline onSorting(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridColumnEventArgs -> unit) =
        this.AddScalar(ComponentDataGrid.Sorting.WithValue(fn))

    /// <summary>Listens to the UnloadingRow event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row is unloading.</param>
    [<Extension>]
    static member inline onUnloadingRow(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridRowEventArgs -> unit) =
        this.AddScalar(ComponentDataGrid.UnloadingRow.WithValue(fn))

    /// <summary>Listens to the LoadingRowDetails event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row details is loading.</param>
    [<Extension>]
    static member inline onLoadingRowDetails(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridRowDetailsEventArgs -> unit) =
        this.AddScalar(ComponentDataGrid.LoadingRowDetails.WithValue(fn))

    /// <summary>Listens to the RowDetailsVisibilityChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row details visibility changes.</param>
    [<Extension>]
    static member inline onRowDetailsVisibilityChanged(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridRowDetailsEventArgs -> unit) =
        this.AddScalar(ComponentDataGrid.RowDetailsVisibilityChanged.WithValue(fn))

    /// <summary>Listens to the UnloadingRowDetails event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row details is unloading.</param>
    [<Extension>]
    static member inline onUnloadingRowDetails(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridRowDetailsEventArgs -> unit) =
        this.AddScalar(ComponentDataGrid.UnloadingRowDetails.WithValue(fn))
