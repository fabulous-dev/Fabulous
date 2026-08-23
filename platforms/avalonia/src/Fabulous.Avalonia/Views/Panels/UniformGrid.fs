namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous

type IFabUniformGrid =
    inherit IFabPanel

module UniformGrid =
    let WidgetKey = Widgets.register<UniformGrid>()

    let Rows = Attributes.defineAvaloniaPropertyWithEquality UniformGrid.RowsProperty

    let Columns =
        Attributes.defineAvaloniaPropertyWithEquality UniformGrid.ColumnsProperty

    let FirstColumn =
        Attributes.defineAvaloniaPropertyWithEquality UniformGrid.FirstColumnProperty

    let RowSpacing =
        Attributes.defineAvaloniaPropertyWithEquality UniformGrid.RowSpacingProperty

    let ColumnSpacing =
        Attributes.defineAvaloniaPropertyWithEquality UniformGrid.ColumnSpacingProperty

[<AutoOpen>]
module UniformGridBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a UniformGrid widget.</summary>
        /// <param name="cols">The number of columns in the grid.</param>
        /// <param name="rows">The number of rows in the grid.</param>
        static member UniformGrid(?cols: int, ?rows: int) =
            match cols, rows with
            | Some cols, Some rows ->
                CollectionBuilder<'msg, IFabUniformGrid, IFabControl>(
                    UniformGrid.WidgetKey,
                    Panel.Children,
                    UniformGrid.Columns.WithValue(cols),
                    UniformGrid.Rows.WithValue(rows)
                )
            | Some cols, None ->
                CollectionBuilder<'msg, IFabUniformGrid, IFabControl>(
                    UniformGrid.WidgetKey,
                    Panel.Children,
                    UniformGrid.Columns.WithValue(cols),
                    UniformGrid.Rows.WithValue(0)
                )

            | None, Some rows ->
                CollectionBuilder<'msg, IFabUniformGrid, IFabControl>(
                    UniformGrid.WidgetKey,
                    Panel.Children,
                    UniformGrid.Columns.WithValue(0),
                    UniformGrid.Rows.WithValue(rows)
                )

            | None, None ->
                CollectionBuilder<'msg, IFabUniformGrid, IFabControl>(
                    UniformGrid.WidgetKey,
                    Panel.Children,
                    UniformGrid.Columns.WithValue(0),
                    UniformGrid.Rows.WithValue(0)
                )

type UniformGridModifiers =
    /// <summary>Sets the FirstColumn property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FirstColumn value.</param>
    [<Extension>]
    static member inline firstColumn(this: WidgetBuilder<'msg, #IFabUniformGrid>, value: int) =
        this.AddScalar(UniformGrid.FirstColumn.WithValue(value))

    /// <summary>Sets the RowSpacing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The RowSpacing value.</param>
    [<Extension>]
    static member inline rowSpacing(this: WidgetBuilder<'msg, #IFabUniformGrid>, value: float) =
        this.AddScalar(UniformGrid.RowSpacing.WithValue(value))

    /// <summary>Sets the ColumnSpacing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ColumnSpacing value.</param>
    [<Extension>]
    static member inline columnSpacing(this: WidgetBuilder<'msg, #IFabUniformGrid>, value: float) =
        this.AddScalar(UniformGrid.ColumnSpacing.WithValue(value))

    /// <summary>Link a ViewRef to access the direct UniformGrid control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabUniformGrid>, value: ViewRef<UniformGrid>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
