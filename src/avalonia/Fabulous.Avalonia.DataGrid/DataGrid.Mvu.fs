namespace Fabulous.Avalonia

open System
open System.Collections
open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

module MvuDataGrid =

    let HorizontalScroll =
        Attributes.Mvu.defineEvent "DataGrid_HorizontalScroll" (fun target -> (target :?> DataGrid).HorizontalScroll)

    let VerticalScroll =
        Attributes.Mvu.defineEvent "DataGrid_VerticalScroll" (fun target -> (target :?> DataGrid).VerticalScroll)

    let AutoGeneratingColumn =
        Attributes.Mvu.defineEvent "DataGrid_AutoGeneratingColumn" (fun target -> (target :?> DataGrid).AutoGeneratingColumn)

    let BeginningEdit =
        Attributes.Mvu.defineEvent "DataGrid_BeginningEdit" (fun target -> (target :?> DataGrid).BeginningEdit)

    let CellEditEnded =
        Attributes.Mvu.defineEvent "DataGrid_CellEditEnded" (fun target -> (target :?> DataGrid).CellEditEnded)

    let CellEditEnding =
        Attributes.Mvu.defineEvent "DataGrid_CellEditEnding" (fun target -> (target :?> DataGrid).CellEditEnding)

    let CellPointerPressed =
        Attributes.Mvu.defineEvent "DataGrid_CellPointerPressed" (fun target -> (target :?> DataGrid).CellPointerPressed)

    let ColumnDisplayIndexChanged =
        Attributes.Mvu.defineEvent "DataGrid_ColumnDisplayIndexChanged" (fun target -> (target :?> DataGrid).ColumnDisplayIndexChanged)

    let ColumnReordered =
        Attributes.Mvu.defineEvent "DataGrid_ColumnReordered" (fun target -> (target :?> DataGrid).ColumnReordered)

    let ColumnReordering =
        Attributes.Mvu.defineEvent "DataGrid_ColumnReordering" (fun target -> (target :?> DataGrid).ColumnReordering)

    let CurrentCellChanged =
        Attributes.Mvu.defineEvent "DataGrid_CurrentCellChanged" (fun target -> (target :?> DataGrid).CurrentCellChanged)

    let LoadingRow =
        Attributes.Mvu.defineEvent "DataGrid_LoadingRow" (fun target -> (target :?> DataGrid).LoadingRow)

    let PreparingCellForEdit =
        Attributes.Mvu.defineEvent "DataGrid_PreparingCellForEdit" (fun target -> (target :?> DataGrid).PreparingCellForEdit)

    let RowEditEnded =
        Attributes.Mvu.defineEvent "DataGrid_RowEditEnded" (fun target -> (target :?> DataGrid).RowEditEnded)

    let RowEditEnding =
        Attributes.Mvu.defineEvent "DataGrid_RowEditEnding" (fun target -> (target :?> DataGrid).RowEditEnding)

    let SelectionChanged =
        Attributes.Mvu.defineEvent<SelectionChangedEventArgs> "DataGrid_SelectionChanged" (fun target -> (target :?> DataGrid).SelectionChanged)

    let Sorting =
        Attributes.Mvu.defineEvent "DataGrid_Sorting" (fun target -> (target :?> DataGrid).Sorting)

    let UnloadingRow =
        Attributes.Mvu.defineEvent "DataGrid_UnloadingRow" (fun target -> (target :?> DataGrid).UnloadingRow)

    let LoadingRowDetails =
        Attributes.Mvu.defineEvent "DataGrid_LoadingRowDetails" (fun target -> (target :?> DataGrid).LoadingRowDetails)

    let RowDetailsVisibilityChanged =
        Attributes.Mvu.defineEvent "DataGrid_RowDetailsVisibilityChanged" (fun target -> (target :?> DataGrid).RowDetailsVisibilityChanged)

    let UnloadingRowDetails =
        Attributes.Mvu.defineEvent "DataGrid_UnloadingRowDetails" (fun target -> (target :?> DataGrid).UnloadingRowDetails)

type MvuDataGridModifiers =
    /// <summary>Listens to the HorizontalScroll Scroll event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the HorizontalScroll value changes.</param>
    [<Extension>]
    static member inline onHorizontalScroll(this: WidgetBuilder<'msg, IFabDataGrid>, fn: ScrollEventArgs -> 'msg) =
        this.AddScalar(MvuDataGrid.HorizontalScroll.WithValue(fn))

    /// <summary>Listens to the VerticalScroll Scroll event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the VerticalScroll value changes.</param>
    [<Extension>]
    static member inline onVerticalScroll(this: WidgetBuilder<'msg, IFabDataGrid>, fn: ScrollEventArgs -> 'msg) =
        this.AddScalar(MvuDataGrid.VerticalScroll.WithValue(fn))

    /// <summary>Listens to the AutoGeneratingColumn event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a column is auto generated.</param>
    [<Extension>]
    static member inline onAutoGeneratingColumn(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridAutoGeneratingColumnEventArgs -> 'msg) =
        this.AddScalar(MvuDataGrid.AutoGeneratingColumn.WithValue(fn))

    /// <summary>Listens to the BeginningEdit event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a cell or row begins editing.</param>
    [<Extension>]
    static member inline onBeginningEdit(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridBeginningEditEventArgs -> 'msg) =
        this.AddScalar(MvuDataGrid.BeginningEdit.WithValue(fn))

    /// <summary>Listens to the CellEditEnded event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a cell edit has ended.</param>
    [<Extension>]
    static member inline onCellEditEnded(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridCellEditEndedEventArgs -> 'msg) =
        this.AddScalar(MvuDataGrid.CellEditEnded.WithValue(fn))

    /// <summary>Listens to the CellEditEnding event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a cell edit is ending.</param>
    [<Extension>]
    static member inline onCellEditEnding(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridCellEditEndingEventArgs -> 'msg) =
        this.AddScalar(MvuDataGrid.CellEditEnding.WithValue(fn))

    /// <summary>Listens to the CellPointerPressed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a cell is clicked.</param>
    [<Extension>]
    static member inline onCellPointerPressed(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridCellPointerPressedEventArgs -> 'msg) =
        this.AddScalar(MvuDataGrid.CellPointerPressed.WithValue(fn))

    /// <summary>Listens to the ColumnDisplayIndexChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a column's DisplayIndex changes.</param>
    [<Extension>]
    static member inline onColumnDisplayIndexChanged(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridColumnEventArgs -> 'msg) =
        this.AddScalar(MvuDataGrid.ColumnDisplayIndexChanged.WithValue(fn))

    /// <summary>Listens to the ColumnReordered event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a column is reordered.</param>
    [<Extension>]
    static member inline onColumnReordered(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridColumnEventArgs -> 'msg) =
        this.AddScalar(MvuDataGrid.ColumnReordered.WithValue(fn))

    /// <summary>Listens to the ColumnReordering event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a column is being reordered.</param>
    [<Extension>]
    static member inline onColumnReordering(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridColumnReorderingEventArgs -> 'msg) =
        this.AddScalar(MvuDataGrid.ColumnReordering.WithValue(fn))

    /// <summary>Listens to the CurrentCellChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the current cell changes.</param>
    [<Extension>]
    static member inline onCurrentCellChanged(this: WidgetBuilder<'msg, IFabDataGrid>, fn: EventArgs -> 'msg) =
        this.AddScalar(MvuDataGrid.CurrentCellChanged.WithValue(fn))

    /// <summary>Listens to the LoadingRow event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row is loading.</param>
    [<Extension>]
    static member inline onLoadingRow(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridRowEventArgs -> 'msg) =
        this.AddScalar(MvuDataGrid.LoadingRow.WithValue(fn))

    /// <summary>Listens to the PreparingCellForEdit event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a cell is being prepared for editing.</param>
    [<Extension>]
    static member inline onPreparingCellForEdit(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridPreparingCellForEditEventArgs -> 'msg) =
        this.AddScalar(MvuDataGrid.PreparingCellForEdit.WithValue(fn))

    /// <summary>Listens to the RowEditEnded event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row edit has ended.</param>
    [<Extension>]
    static member inline onRowEditEnded(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridRowEditEndedEventArgs -> 'msg) =
        this.AddScalar(MvuDataGrid.RowEditEnded.WithValue(fn))

    /// <summary>Listens to the RowEditEnding event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row edit is ending.</param>
    [<Extension>]
    static member inline onRowEditEnding(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridRowEditEndingEventArgs -> 'msg) =
        this.AddScalar(MvuDataGrid.RowEditEnding.WithValue(fn))

    /// <summary>Listens to the SelectionChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the selection changes.</param>
    [<Extension>]
    static member inline onSelectionChanged(this: WidgetBuilder<'msg, IFabDataGrid>, fn: SelectionChangedEventArgs -> 'msg) =
        this.AddScalar(MvuDataGrid.SelectionChanged.WithValue(fn))

    /// <summary>Listens to the Sorting event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the data is being sorted.</param>
    [<Extension>]
    static member inline onSorting(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridColumnEventArgs -> 'msg) =
        this.AddScalar(MvuDataGrid.Sorting.WithValue(fn))

    /// <summary>Listens to the UnloadingRow event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row is unloading.</param>
    [<Extension>]
    static member inline onUnloadingRow(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridRowEventArgs -> 'msg) =
        this.AddScalar(MvuDataGrid.UnloadingRow.WithValue(fn))

    /// <summary>Listens to the LoadingRowDetails event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row details is loading.</param>
    [<Extension>]
    static member inline onLoadingRowDetails(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridRowDetailsEventArgs -> 'msg) =
        this.AddScalar(MvuDataGrid.LoadingRowDetails.WithValue(fn))

    /// <summary>Listens to the RowDetailsVisibilityChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row details visibility changes.</param>
    [<Extension>]
    static member inline onRowDetailsVisibilityChanged(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridRowDetailsEventArgs -> 'msg) =
        this.AddScalar(MvuDataGrid.RowDetailsVisibilityChanged.WithValue(fn))

    /// <summary>Listens to the UnloadingRowDetails event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row details is unloading.</param>
    [<Extension>]
    static member inline onUnloadingRowDetails(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridRowDetailsEventArgs -> 'msg) =
        this.AddScalar(MvuDataGrid.UnloadingRowDetails.WithValue(fn))
