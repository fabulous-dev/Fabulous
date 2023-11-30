namespace Fabulous

open System
open Fabulous

/// Widget definition to create a control
type WidgetDefinition =
    { Key: WidgetKey
      Name: string
      TargetType: Type
      CreateView: Widget * ViewTreeContext * EnvironmentContext * IViewNode voption -> struct (IViewNode * obj)
      AttachView: Widget * ViewTreeContext * EnvironmentContext * IViewNode voption * obj -> IViewNode }

module WidgetDefinitionStore =
    let private _widgets = ResizeArray<WidgetDefinition>()

    let mutable private _nextKey = 0

    let get key = _widgets.[key]
    let set key value = _widgets.[key] <- value

    let getNextKey () : WidgetKey =
        _widgets.Add(Unchecked.defaultof<WidgetDefinition>)
        let key = _nextKey
        _nextKey <- _nextKey + 1
        key
