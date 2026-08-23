namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous

type IFabToggleButton =
    inherit IFabButton

module ThreeState =
    let inline fromOption (value: bool option) =
        match value with
        | Some true -> ValueSome(Nullable(true))
        | Some false -> ValueSome(Nullable(false))
        | None -> ValueNone

    let inline fromOption' (value: bool option) =
        match value with
        | Some true -> Nullable(true)
        | Some false -> Nullable(false)
        | None -> Nullable()

    let inline toOption (value: Nullable<bool>) = Option.ofNullable value

module ToggleButton =
    let WidgetKey = Widgets.register<ToggleButton>()

    let IsThreeState =
        Attributes.defineAvaloniaPropertyWithEquality ToggleButton.IsThreeStateProperty

type ToggleButtonModifiers =
    /// <summary>Link a ViewRef to access the direct ToggleButton control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabToggleButton>, value: ViewRef<ToggleButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
