namespace Fabulous

open System.Collections.Generic

type EnvironmentContext() =
    let values = Dictionary<string, obj>()
    
    member this.GetValue<'T>(key: string) =
        unbox<'T> values[key]
        
    member this.SetValue<'T>(key: string, value: 'T) =
        values.[key] <- box value