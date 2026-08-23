namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous
open System.Runtime.CompilerServices

type IFabButtonSpinner =
    inherit IFabSpinner

module ButtonSpinner =
    let WidgetKey = Widgets.register<ButtonSpinner>()

    let AllowSpin =
        Attributes.defineAvaloniaPropertyWithEquality ButtonSpinner.AllowSpinProperty

    let ButtonSpinnerLocation =
        Attributes.defineAvaloniaPropertyWithEquality ButtonSpinner.ButtonSpinnerLocationProperty

    let ShowButtonSpinner =
        Attributes.defineAvaloniaPropertyWithEquality ButtonSpinner.ShowButtonSpinnerProperty

type ButtonSpinnerModifiers =

    /// <summary>Sets the AllowSpin property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AllowSpin value.</param>
    [<Extension>]
    static member inline allowSpin(this: WidgetBuilder<'msg, #IFabButtonSpinner>, value: bool) =
        this.AddScalar(ButtonSpinner.AllowSpin.WithValue(value))

    /// <summary>Sets the ButtonSpinnerLocation property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ButtonSpinnerLocation value.</param>
    [<Extension>]
    static member inline buttonSpinnerLocation(this: WidgetBuilder<'msg, #IFabButtonSpinner>, value: Location) =
        this.AddScalar(ButtonSpinner.ButtonSpinnerLocation.WithValue(value))

    /// <summary>Sets the ShowButtonSpinner property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ShowButtonSpinner value.</param>
    [<Extension>]
    static member inline showButtonSpinner(this: WidgetBuilder<'msg, #IFabButtonSpinner>, value: bool) =
        this.AddScalar(ButtonSpinner.ShowButtonSpinner.WithValue(value))

    /// <summary>Link a ViewRef to access the direct ButtonSpinner control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabButtonSpinner>, value: ViewRef<ButtonSpinner>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
