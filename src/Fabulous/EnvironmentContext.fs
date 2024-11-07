namespace Fabulous

open System
open System.Collections.Generic

[<Struct>]
type EnvironmentValueChanged(originEnvId: Guid, fromUserCode: bool, key: string, value: obj voption) =
    member this.OriginEnvId = originEnvId
    member this.FromUserCode = fromUserCode
    member this.Key = key
    member this.Value = value

[<NoComparison; NoEquality>]
type EnvironmentKey<'T>(key: string) =
    member this.Key = key

and [<AllowNullLiteral>] EnvironmentContext(inheritedContext: EnvironmentContext) =
    let id = Guid.NewGuid()
    let values = Dictionary<string, obj>()
    let valueChanged = Event<EnvironmentValueChanged>()

    do
        if inheritedContext = null then
            printfn $"EnvironmentContext '{id}' created"
        else
            printfn $"EnvironmentContext '{id}' created and inherited from '{inheritedContext.Id}'"

    let valuePropagationSubscription =
        if inheritedContext = null then
            null
        else
            inheritedContext.ValueChanged.Subscribe(fun args ->
                printfn $"Env '{id}': Propagating '{args.Key}' change from '{args.OriginEnvId}'"
                valueChanged.Trigger(args))

    new() = new EnvironmentContext(null)

    member this.Id = id

    member private this.TryGetValue<'T>(key: string) =
        if values.ContainsKey(key) then
            ValueSome(unbox<'T> values[key])
        elif inheritedContext <> null then
            inheritedContext.TryGetValue(key)
        else
            ValueNone

    member internal this.SetInternal<'T>(key: string, value: 'T, fromUserCode: bool) =
        printfn $"EnvironmentContext '{id}' set value '{key}' to '{value}'"
        let boxedValue = box value
        values[key] <- boxedValue
        valueChanged.Trigger(EnvironmentValueChanged(id, fromUserCode, key, ValueSome boxedValue))

    member internal this.RemoveInternal(key: string, fromUserCode: bool) =
        if values.Remove(key) then
            valueChanged.Trigger(EnvironmentValueChanged(id, fromUserCode, key, ValueNone))

    member this.ValueChanged: IEvent<EnvironmentValueChanged> = valueChanged.Publish

    member this.Get<'T>(key: EnvironmentKey<'T>) =
        match this.TryGetValue<'T>(key.Key) with
        | ValueSome value -> value
        | ValueNone -> failwithf $"EnvironmentContext '{id}' does not contain value for key '{key.Key}'"

    member this.Set<'T>(key: EnvironmentKey<'T>, value: 'T, ?fromUserCode: bool) =
        let fromUserCode = defaultArg fromUserCode true

        if values.ContainsKey(key.Key) || inheritedContext = null then
            printfn $"EnvironmentContext '{id}' set value '{key.Key}' to '{value}'"
            let boxedValue = box value
            values[key.Key] <- boxedValue
            valueChanged.Trigger(EnvironmentValueChanged(id, fromUserCode, key.Key, ValueSome boxedValue))
        else
            inheritedContext.Set<'T>(key, value, fromUserCode)

    interface IDisposable with
        member this.Dispose() =
            printfn $"EnvironmentContext '{id}' disposed"

            if valuePropagationSubscription <> null then
                valuePropagationSubscription.Dispose()
