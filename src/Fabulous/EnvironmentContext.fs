namespace Fabulous

open System
open System.Collections.Generic

[<NoComparison; NoEquality>]
type EnvironmentKey<'T>(key: string, defaultValue: 'T) =
    member this.Key = key
    member this.DefaultValue = defaultValue

[<Struct>]
type EnvironmentValueChanged(originEnvId: Guid, fromUserCode: bool, key: string, value: obj voption) =
    member this.OriginEnvId = originEnvId
    member this.FromUserCode = fromUserCode
    member this.Key = key
    member this.Value = value

[<AllowNullLiteral>]
type EnvironmentContext(inheritedContext: EnvironmentContext) =
    let id = Guid.NewGuid()
    let values = Dictionary<string, obj>()
    let valueChanged = Event<EnvironmentValueChanged>()

    do printfn $"EnvironmentContext '{id}' created"

    let valuePropagationSubscription =
        if inheritedContext = null then
            null
        else
            printfn $"EnvironmentContext '{id}' inherited from '{inheritedContext.Id}'"

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
        | ValueNone ->
            let value = unbox<'T> key.DefaultValue
            this.Set(key, value)
            value

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
