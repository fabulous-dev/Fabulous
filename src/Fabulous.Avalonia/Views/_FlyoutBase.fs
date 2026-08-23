namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives

type IFabFlyoutBase =
    inherit IFabElement

module FlyoutBase =
    let AttachedFlyout =
        Attributes.defineAvaloniaPropertyWidget FlyoutBase.AttachedFlyoutProperty
