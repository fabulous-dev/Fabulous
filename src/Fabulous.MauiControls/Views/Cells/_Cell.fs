namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections
open Microsoft.Maui.Controls

type IFabCell =
    inherit IFabElement

module Cell =
    let Appearing =
        Attributes.Mvu.defineEventNoArg "Cell_Appearing" (fun target -> (target :?> Cell).Appearing)

    let Disappearing =
        Attributes.Mvu.defineEventNoArg "Cell_Disappearing" (fun target -> (target :?> Cell).Disappearing)

    let Height =
        Attributes.defineFloat "Cell_Height" (fun _ newValueOpt node ->
            let cell = node.Target :?> Cell

            let value =
                match newValueOpt with
                | ValueNone -> cell.Height
                | ValueSome v -> v

            cell.Height <- value)

    let IsEnabled = Attributes.defineBindableBool Cell.IsEnabledProperty

    let Tapped =
        Attributes.Mvu.defineEventNoArg "Cell_Tapped" (fun target -> (target :?> Cell).Tapped)

    let ContextActions =
        Attributes.defineListWidgetCollection "Cell_ContextActions" (fun target -> (target :?> Cell).ContextActions)

[<Extension>]
type CellModifiers =
    /// <summary>Set a value that indicates whether the cell is enabled</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">true if the cell is enabled; otherwise, false</param>
    [<Extension>]
    static member inline isEnabled(this: WidgetBuilder<'msg, #IFabCell>, value: bool) =
        this.AddScalar(Cell.IsEnabled.WithValue(value))

    /// <summary>Set the desired height override of this widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The height this widget desires to be</param>
    [<Extension>]
    static member inline height(this: WidgetBuilder<'msg, #IFabCell>, value: float) =
        this.AddScalar(Cell.Height.WithValue(value))

    /// <summary>Listen to the Appearing event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="msg">Message to dispatch</param>
    [<Extension>]
    static member inline onAppearing(this: WidgetBuilder<'msg, #IFabCell>, msg: 'msg) =
        this.AddScalar(Cell.Appearing.WithValue(MsgValue(msg)))

    /// <summary>Listen to the Disappearing event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="msg">Message to dispatch</param>
    [<Extension>]
    static member inline onDisappearing(this: WidgetBuilder<'msg, #IFabCell>, msg: 'msg) =
        this.AddScalar(Cell.Disappearing.WithValue(MsgValue(msg)))

    /// <summary>Listen to the Tapped event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="msg">Message to dispatch</param>
    [<Extension>]
    static member inline onTapped(this: WidgetBuilder<'msg, #IFabCell>, msg: 'msg) =
        this.AddScalar(Cell.Tapped.WithValue(MsgValue(msg)))

    /// <summary>Set the context actions of the cell</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline contextActions<'msg, 'marker when 'msg: equality and 'marker :> IFabCell>(this: WidgetBuilder<'msg, 'marker>) =
        WidgetHelpers.buildAttributeCollection<'msg, 'marker, IFabMenuItem> Cell.ContextActions this

[<Extension>]
type CellYieldExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'marker :> IFabCell and 'itemType :> IFabMenuItem>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IFabMenuItem>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
