namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Fabulous.Avalonia

module MvuRangeBase =
    let ValueChanged =
        Attributes.Mvu.defineAvaloniaPropertyWithChangedEvent' "RangeBase_ValueChanged" RangeBase.ValueProperty
