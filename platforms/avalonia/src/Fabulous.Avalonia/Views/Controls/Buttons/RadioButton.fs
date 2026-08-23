namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabRadioButton =
    inherit IFabToggleButton

module RadioButton =
    let WidgetKey = Widgets.register<RadioButton>()

    let GroupName =
        Attributes.defineAvaloniaPropertyWithEquality RadioButton.GroupNameProperty


type RadioButtonAttachedModifiers =
    /// <summary>Sets the GroupName property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The GroupName value.</param>
    [<Extension>]
    static member inline groupName(this: WidgetBuilder<'msg, #IFabControl>, value: string) =
        this.AddScalar(RadioButton.GroupName.WithValue(value))

    /// <summary>Link a ViewRef to access the direct RadioButton control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabRadioButton>, value: ViewRef<RadioButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
