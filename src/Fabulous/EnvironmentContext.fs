namespace Fabulous

open System
open System.Collections.Generic

[<Struct>]
type EnvironmentValueChanged(originEnvId: Guid, fromUserCode: bool, key: EnvironmentAttributeKey, value: obj voption) =
    member this.OriginEnvId = originEnvId
    member this.FromUserCode = fromUserCode
    member this.Key = key
    member this.Value = value

[<NoComparison; NoEquality>]
type EnvironmentKey<'T>(key: string) =
    member this.Key = EnvironmentAttributeKey key

and [<AllowNullLiteral>] EnvironmentContext(logger: Logger, inheritedContext: EnvironmentContext) =
    let id = Guid.NewGuid()
    let values = Dictionary<EnvironmentAttributeKey, obj>()
    let valueChanged = Event<EnvironmentValueChanged>()

    do
        if inheritedContext = null then
            logger.Log(LogLevel.Debug, $"EnvironmentContext '{id}' created")
        else
            logger.Log(LogLevel.Debug, $"EnvironmentContext '{id}' created and inherited from '{inheritedContext.Id}'")

    let valuePropagationSubscription =
        if inheritedContext = null then
            null
        else
            inheritedContext.ValueChanged.Subscribe(fun args ->
                logger.Log(LogLevel.Debug, $"Env '{id}': Propagating '{args.Key}' change from '{args.OriginEnvId}'")
                valueChanged.Trigger(args))

    new(logger: Logger) = new EnvironmentContext(logger, null)

    member this.Id = id

    member private this.TryGetValue<'T>(key: EnvironmentAttributeKey) =
        if values.ContainsKey(key) then
            ValueSome(unbox<'T> values[key])
        elif inheritedContext <> null then
            inheritedContext.TryGetValue(key)
        else
            ValueNone

    member internal this.SetInternal<'T>(key: EnvironmentAttributeKey, value: 'T, fromUserCode: bool) =
        logger.Log(LogLevel.Debug, $"EnvironmentContext '{id}' set value '{key}' to '{value}'")
        let boxedValue = box value
        values[key] <- boxedValue
        valueChanged.Trigger(EnvironmentValueChanged(id, fromUserCode, key, ValueSome boxedValue))

    member internal this.RemoveInternal(key: EnvironmentAttributeKey, fromUserCode: bool) =
        if values.Remove(key) then
            valueChanged.Trigger(EnvironmentValueChanged(id, fromUserCode, key, ValueNone))

    member this.ValueChanged: IEvent<EnvironmentValueChanged> = valueChanged.Publish

    member this.Get<'T>(key: EnvironmentKey<'T>) =
        match this.TryGetValue<'T>(key.Key) with
        | ValueSome value -> value
        | ValueNone ->
            let (EnvironmentAttributeKey key) = key.Key
            failwithf $"EnvironmentContext '{id}' does not contain value for key '{key}'"

    member this.Set<'T>(key: EnvironmentKey<'T>, value: 'T, ?fromUserCode: bool) =
        let fromUserCode = defaultArg fromUserCode true

        if values.ContainsKey(key.Key) || inheritedContext = null then
            logger.Log(LogLevel.Debug, $"EnvironmentContext '{id}' set value '{key.Key}' to '{value}'")
            let boxedValue = box value
            values[key.Key] <- boxedValue
            valueChanged.Trigger(EnvironmentValueChanged(id, fromUserCode, key.Key, ValueSome boxedValue))
        else
            inheritedContext.Set<'T>(key, value, fromUserCode)

    interface IDisposable with
        member this.Dispose() =
            logger.Log(LogLevel.Debug, $"EnvironmentContext '{id}' disposed")

            if valuePropagationSubscription <> null then
                valuePropagationSubscription.Dispose()
