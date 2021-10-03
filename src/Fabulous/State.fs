namespace Fabulous

module States =
    let mutable private _states : Map<RunnerKey, obj> = Map.empty

    let private updatedEvent = new Event<RunnerKey * obj>()
    let updated = updatedEvent.Publish

    let setState key value =
        _states <- _states.Change(key, fun _ -> Some value)
        updatedEvent.Trigger(key, value)
        
    let getState key = _states.[key]

