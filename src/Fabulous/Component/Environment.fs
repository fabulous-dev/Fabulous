namespace Fabulous

open System.Runtime.CompilerServices

type EnvironmentGetter<'T> = delegate of unit -> string
type EnvironmentSetter<'T> = delegate of unit -> struct (string * 'T)

type Environment =
    static member inline Get<'T>(key: string) = EnvironmentGetter<'T>(fun () -> key)

    static member inline Set<'T>(key: string, value: 'T) =
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
            let value = env.GetValue<'T>(key)
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
            env.SetValue<'T>(key, value)
            (continuation()).Invoke(bindings, env, ctx))
