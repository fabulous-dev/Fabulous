namespace Fabulous

open System.Collections.Generic

type EnvironmentKey = EnvironmentKey of string

[<AllowNullLiteral>]
type EnvironmentContext(inheritedContext: EnvironmentContext) =
    let valueChanged = Event<_>()
    let values = Dictionary<EnvironmentKey, obj>()
    
    new () = EnvironmentContext(null)
    
    member private this.Values = values

    member this.ValueChanged = valueChanged.Publish
        
    member this.Get<'T>(key: EnvironmentKey) =
        if values.ContainsKey(key) then
            unbox<'T> values[key]
        elif inheritedContext <> null then
            inheritedContext.Get<'T>(key)
        else
            failwithf $"Key '%A{key}' not found in environment"

    member this.Set<'T>(key: EnvironmentKey, value: 'T) =
        values[key] <- box value
        valueChanged.Trigger(key)
        
    member this.Remove(key: EnvironmentKey) =
        values.Remove(key) |> ignore