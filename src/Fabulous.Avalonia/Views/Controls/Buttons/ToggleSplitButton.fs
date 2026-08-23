namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabToggleSplitButton =
    inherit IFabSplitButton

module ToggleSplitButton =
    let WidgetKey = Widgets.register<ToggleSplitButton>()

type ToggleSplitButtonModifiers =
    /// <summary>Link a ViewRef to access the direct ToggleSplitButton control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabToggleSplitButton>, value: ViewRef<ToggleSplitButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
