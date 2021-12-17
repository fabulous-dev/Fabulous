namespace Fabulous

open System.Collections.Generic

module StateStore =
    type StateChangedEventArgs =
        { Key: StateKey
          NewState: obj }

    let private _states = Dictionary<StateKey, obj>()
    let private _stateChangedEvent = Event<StateChangedEventArgs>()
    let mutable private _nextKey = 0

    let StateChanged = _stateChangedEvent.Publish
            
    let get key = _states.[key]
    
    let set key newState =
        match _states.TryGetValue(key) with
        | true, prevState when prevState = newState -> ()
        | _ ->
            _states.[key] <- newState
            _stateChangedEvent.Trigger({ Key = key; NewState = newState })

    let remove key = _states.Remove(key) |> ignore
    
    let getNextKey () : StateKey =
        let key = _nextKey
        _nextKey <- _nextKey + 1
        key
