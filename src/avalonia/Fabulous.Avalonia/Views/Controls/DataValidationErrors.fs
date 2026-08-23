namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Fabulous

type IFabDataValidationErrors =
    inherit IFabContentControl

module DataValidationErrors =
    let WidgetKey = Widgets.register<DataValidationErrors>()

    let Errors =
        Attributes.defineSimpleScalarWithEquality<Exception list> "DataValidationErrors_Errors" (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(DataValidationErrors.ErrorsProperty)
            | ValueSome errors -> target.SetValue(DataValidationErrors.ErrorsProperty, errors) |> ignore)

    let HasErrors =
        Attributes.defineAvaloniaPropertyWithEquality DataValidationErrors.HasErrorsProperty

type DataValidationErrorsModifiers =

    /// <summary>Sets the HasErrors property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HasErrors value.</param>
    [<Extension>]
    static member inline hasErrors(this: WidgetBuilder<'msg, #IFabDataValidationErrors>, value: bool) =
        this.AddScalar(DataValidationErrors.HasErrors.WithValue(value))

    /// <summary>Sets the Errors property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Errors value.</param>
    [<Extension>]
    static member inline dataValidationErrors(this: WidgetBuilder<'msg, #IFabControl>, value: Exception list) =
        this.AddScalar(DataValidationErrors.Errors.WithValue(value))
