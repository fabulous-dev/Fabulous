namespace Gallery


open Fabulous.Avalonia
open type Fabulous.Avalonia.View

module TabStripPage =
    let view () =
        TabStrip([ "Tab 1"; "Tab 2"; "Tab 3" ], (fun x -> TextBlock(x)))
