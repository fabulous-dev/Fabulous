namespace Fabulous.Maui

open Microsoft.Maui.Controls

type IFabStackBase =
    inherit IFabLayoutOfView

module StackBase =
    let Spacing = Attributes.defineBindableFloat StackBase.SpacingProperty
