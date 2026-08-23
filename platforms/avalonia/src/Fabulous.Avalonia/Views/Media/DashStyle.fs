namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Collections
open Avalonia.Media
open Fabulous

type IFaDashStyle =
    inherit IFabAnimatable

module DashStyle =
    let WidgetKey = Widgets.register<DashStyle>()

    let Dashes =
        Attributes.defineSimpleScalarWithEquality<float list> "DashStyle_Dashes" (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(DashStyle.DashesProperty)
            | ValueSome points ->
                let coll = AvaloniaList<float>()
                points |> List.iter coll.Add
                target.SetValue(DashStyle.DashesProperty, coll) |> ignore)

    let Offset = Attributes.defineAvaloniaPropertyWithEquality DashStyle.OffsetProperty

[<AutoOpen>]
module DashStyleBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a DashStyle widget.</summary>
        /// <param name="dashes">The length of alternating dashes and gaps.</param>
        /// <param name="offset">How far in the dash sequence the stroke will start.</param>
        static member DashStyle(dashes: float list, offset: float) =
            WidgetBuilder<'msg, IFaDashStyle>(DashStyle.WidgetKey, DashStyle.Dashes.WithValue(dashes), DashStyle.Offset.WithValue(offset))

type DashStyleModifiers =

    /// <summary>Link a ViewRef to access the direct DashStyle control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFaDashStyle>, value: ViewRef<DashStyle>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
