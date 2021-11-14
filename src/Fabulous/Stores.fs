namespace Fabulous

/// Dev notes:
///
/// This file contains all the instances Fabulous needs to keep in memory

open System.Collections.Generic
open Fabulous

module AttributeDefinitionStore =
    let private _attributes = Dictionary<AttributeKey, IAttributeDefinition>()
    let mutable private _nextKey = 0
    
    let get key = _attributes.[key]
    let set key value = _attributes.[key] <- value
    let remove key = _attributes.Remove(key) |> ignore

    let getNextKey () : AttributeKey =
        let key = _nextKey
        _nextKey <- _nextKey + 1
        key
    
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

module StateStore =
    type StateChangedEventArgs =
        { Key: StateKey
          NewState: obj }

    let private _states = Dictionary<StateKey, obj>()
    let private _stateChangedEvent = new Event<StateChangedEventArgs>()
    let mutable private _nextKey = 0

    let StateChanged = _stateChangedEvent.Publish
            
    let get key = _states.[key]
    
    let set key newState =
        match _states.TryGetValue(key) with
        | (true, prevState) when prevState = newState -> ()
        | _ ->
            _states.[key] <- newState
            _stateChangedEvent.Trigger({ Key = key; NewState = newState })

    let remove key = _states.Remove(key) |> ignore
    
    let getNextKey () : StateKey =
        let key = _nextKey
        _nextKey <- _nextKey + 1
        key
    
module RunnerStore =
    let private _runners = Dictionary<StateKey, IRunner>()

    let get key = _runners.[key]
    let set key value = _runners.[key] <- value
    let remove key = _runners.Remove(key) |> ignore

module ViewAdapterStore =
    let private _viewAdapters = Dictionary<ViewAdapterKey, IViewAdapter>()
    let mutable private _nextKey = 0
    
    let get key = _viewAdapters.[key]
    let set key value = _viewAdapters.[key] <- value
    let remove key =
        match _viewAdapters.TryGetValue(key) with
        | false, _ -> ()
        | true, value ->
            value.Dispose()
            _viewAdapters.Remove(key) |> ignore
            
    let getNextKey () : ViewAdapterKey =
        let key = _nextKey
        _nextKey <- _nextKey + 1
        key
