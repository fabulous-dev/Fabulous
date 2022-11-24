namespace Fabulous.Maui

open Microsoft.Maui.Controls

type IStackBase =
    inherit Fabulous.Maui.ILayoutOfView
    
module StackBase =
    let Spacing =
        Attributes.defineBindableFloat StackBase.SpacingProperty
