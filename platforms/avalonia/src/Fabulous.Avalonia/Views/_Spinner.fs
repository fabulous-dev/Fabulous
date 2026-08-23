namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous
open System.Runtime.CompilerServices

type IFabSpinner =
    inherit IFabContentControl

module Spinner =

    let ValidSpinDirection =
        Attributes.defineAvaloniaPropertyWithEquality Spinner.ValidSpinDirectionProperty

type SpinnerModifiers =

    /// <summary>Sets the ValidSpinDirection property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ValidSpinDirection value.</param>
    [<Extension>]
    static member inline validSpinDirection(this: WidgetBuilder<'msg, #IFabSpinner>, value: ValidSpinDirections) =
        this.AddScalar(Spinner.ValidSpinDirection.WithValue(value))
