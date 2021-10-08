namespace Fabulous

module Reconciler =
    let diff (previousOpt: Widget voption) (current: Widget) =
        WidgetDiff.ReplacedBy current
