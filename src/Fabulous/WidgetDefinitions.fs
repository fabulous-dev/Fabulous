namespace Fabulous

open System
open System.Collections.Generic
open Fabulous

/// Widget definition to create a control
type WidgetDefinition =
    {
        Key: WidgetKey
        Name: string
        TargetType: Type
        CreateView: Widget * ViewTreeContext * IViewNode voption -> struct (IViewNode * obj)
    }

module WidgetDefinitionStore =
    let private _widgets =
        Dictionary<WidgetKey, WidgetDefinition>()

    let mutable private _nextKey = 0

    let get key = _widgets.[key]
    let set key value = _widgets.[key] <- value
    let remove key = _widgets.Remove(key) |> ignore

    let getNextKey () : WidgetKey =
        let key = _nextKey
        _nextKey <- _nextKey + 1
        key
