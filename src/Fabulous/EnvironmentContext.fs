namespace Fabulous

open System.Collections.Generic

type DecodedEnvironmentKey = DecodedEnvironmentKey of string
type EnvironmentKey<'T> =
    { Key: string }
    
type EnvironmentKey =
    static member inline Create<'T>(key: string) = { Key = key } : EnvironmentKey<'T>

[<AllowNullLiteral>]
type EnvironmentContext(inheritedContext: EnvironmentContext) =
    let values = Dictionary<DecodedEnvironmentKey, obj>()
    
    new () = EnvironmentContext(null)
    
    member private this.Values = values
        
    member this.Get<'T>(key: EnvironmentKey<'T>) =
        let actualKey = DecodedEnvironmentKey key.Key
        
        if values.ContainsKey(actualKey) then
            unbox<'T> values[actualKey]
        elif inheritedContext <> null then
            inheritedContext.Get(key)
        else
            failwithf $"Key '%A{key}' not found in environment"

    member this.Set<'T>(key: EnvironmentKey<'T>, value: 'T) =
        let actualKey = DecodedEnvironmentKey key.Key
        values[actualKey] <- box value
        
    member this.Remove(key: EnvironmentKey<'T>) =
        let actualKey = DecodedEnvironmentKey key.Key
        values.Remove(actualKey) |> ignore