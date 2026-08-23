namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Fabulous.Avalonia

module ComponentRangeBase =
    let ValueChanged =
        Attributes.Component.defineAvaloniaPropertyWithChangedEvent' "RangeBase_ValueChanged" RangeBase.ValueProperty
