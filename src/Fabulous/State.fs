namespace Fabulous

module States =
    let mutable private _states : Map<RunnerKey, obj> = Map.empty
    let setState key value =
        _states <- _states.Change(key, fun _ -> Some value)
        
    let getState key = _states.[key]

