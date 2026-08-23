namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabDropDownButton =
    inherit IFabButton

module DropDownButton =
    let WidgetKey = Widgets.register<DropDownButton>()

type DropDownButtonModifiers =
    /// <summary>Link a ViewRef to access the direct DropDownButton control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabDropDownButton>, value: ViewRef<DropDownButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
