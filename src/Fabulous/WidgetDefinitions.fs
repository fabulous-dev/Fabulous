namespace Fabulous

open System.Collections.Generic
open Fabulous

/// Widget definition to create a control
type WidgetDefinition =
    { Key: WidgetKey
      Name: string
      CreateView: Widget * ViewTreeContext * IViewNode list -> obj }
    
module WidgetDefinitionStore =
    let private _widgets = Dictionary<WidgetKey, WidgetDefinition>()
    let mutable private _nextKey = 0
    
    let get key = _widgets.[key]
    let set key value = _widgets.[key] <- value
    let remove key = _widgets.Remove(key) |> ignore
    
    let getNextKey () : WidgetKey =
        let key = _nextKey
        _nextKey <- _nextKey + 1
        key