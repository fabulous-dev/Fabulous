namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Data
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabDataGridCheckBoxColumn =
    inherit IFabDataGridColumn

module DataGridCheckBoxColumn =
    let WidgetKey = Widgets.register<DataGridCheckBoxColumn>()

    let IsThreeState =
        Attributes.defineAvaloniaPropertyWithEquality DataGridCheckBoxColumn.IsThreeStateProperty

[<AutoOpen>]
module DataGridCheckBoxColumnBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a DataGridCheckBoxColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridCheckBoxColumn(header: string, binding: IBinding) =
            WidgetBuilder<'msg, IFabDataGridCheckBoxColumn>(
                DataGridCheckBoxColumn.WidgetKey,
                DataGridColumn.HeaderString.WithValue(header),
                DataGridBoundColumn.Binding.WithValue(binding)
            )

        /// <summary>Creates a DataGridCheckBoxColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridCheckBoxColumn(header: string, binding: string) =
            WidgetBuilder<'msg, IFabDataGridCheckBoxColumn>(
                DataGridCheckBoxColumn.WidgetKey,
                DataGridColumn.HeaderString.WithValue(header),
                DataGridBoundColumn.Binding.WithValue(Binding(binding))
            )

        /// <summary>Creates a DataGridCheckBoxColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridCheckBoxColumn(header: WidgetBuilder<'msg, #IFabControl>, binding: IBinding) =
            WidgetBuilder<'msg, IFabDataGridCheckBoxColumn>(
                DataGridCheckBoxColumn.WidgetKey,
                AttributesBundle(
                    StackList.one(DataGridBoundColumn.Binding.WithValue(binding)),
                    [| DataGridColumn.HeaderWidget.WithValue(header.Compile()) |],
                    [||],
                    [||]
                )
            )

        /// <summary>Creates a DataGridCheckBoxColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridCheckBoxColumn(header: WidgetBuilder<'msg, #IFabControl>, binding: string) =
            WidgetBuilder<'msg, IFabDataGridCheckBoxColumn>(
                DataGridCheckBoxColumn.WidgetKey,
                AttributesBundle(
                    StackList.one(DataGridBoundColumn.Binding.WithValue(Binding(binding))),
                    [| DataGridColumn.HeaderWidget.WithValue(header.Compile()) |],
                    [||],
                    [||]
                )
            )

type DataGridCheckBoxColumnModifiers =
    /// <summary>Link a ViewRef to access the direct DataGridCheckBoxColumn control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabDataGridCheckBoxColumn>, value: ViewRef<DataGridCheckBoxColumn>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

    /// <summary>Set the IsThreeState property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsThreeState property value.</param>
    [<Extension>]
    static member inline isThreeState(this: WidgetBuilder<'msg, #IFabDataGridCheckBoxColumn>, value: bool) =
        this.AddScalar(DataGridCheckBoxColumn.IsThreeState.WithValue(value))
