namespace Fabulous

open System.Runtime.CompilerServices

type EnvironmentGetter<'T> = delegate of unit -> EnvironmentKey<'T>
type EnvironmentSetter<'T> = delegate of unit -> struct (EnvironmentKey<'T> * 'T)

type Environment =
    static member inline Get<'T>(key: EnvironmentKey<'T>) = EnvironmentGetter<'T>(fun () -> key)

    static member inline Set<'T>(key: EnvironmentKey<'T>, value: 'T) =
        EnvironmentSetter<'T>(fun () -> struct (key, value))

[<Extension>]
type EnvironmentExtensions =
    [<Extension>]
    static member inline Bind
        (
            _: ComponentBuilder,
            [<InlineIfLambda>] fn: EnvironmentGetter<'T>,
            [<InlineIfLambda>] continuation: 'T -> ComponentBodyBuilder<'marker>
        ) =
        ComponentBodyBuilder<'marker>(fun bindings env ctx ->
            let key = fn.Invoke()
            let value = env.Get<'T>(key)
            (continuation value).Invoke(bindings, env, ctx))

    [<Extension>]
    static member inline Bind
        (
            _: ComponentBuilder,
            [<InlineIfLambda>] fn: EnvironmentSetter<'T>,
            [<InlineIfLambda>] continuation: unit -> ComponentBodyBuilder<'marker>
        ) =
        ComponentBodyBuilder<'marker>(fun bindings env ctx ->
            let struct (key, value) = fn.Invoke()
            env.Set<'T>(key, value)
            (continuation()).Invoke(bindings, env, ctx))



// type EnvironmentValue(key: string, value: obj) =
//     member this.Key = key
//     member this.Value = value
//
// module EnvironmentAttributes =
//     let Environment = Attributes.defineSimpleScalarWithEquality<EnvironmentValue> "Environment" (fun prevOpt currOpt node ->
//         match struct (prevOpt, currOpt) with
//         | ValueNone, ValueNone -> ()
//         | ValueSome prev, ValueNone -> node.EnvironmentContext.Remove(prev.Key)
//         | _, ValueSome curr -> node.EnvironmentContext.Set(curr.Key, curr.Value)
//     )
//     
// [<Extension>]
// type EnvironmentModifiers =
//     [<Extension>]
//     static member inline environment(this: WidgetBuilder<'msg, 'marker>, key: string, value: obj) =
//         this.AddScalar(EnvironmentAttributes.Environment.WithValue(EnvironmentValue(key, value)))