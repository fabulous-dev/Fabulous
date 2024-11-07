namespace Fabulous

open System.Runtime.CompilerServices

type EnvironmentObjectRequest<'T> = delegate of unit -> EnvironmentKey<'T>

[<AbstractClass>]
type EnvironmentObject() =
    let changed = Event<unit>()
    member this.Changed = changed.Publish
    member this.NotifyChanged() = changed.Trigger()

[<AutoOpen>]
module EnvironmentObjectBuilders =
    type Context with
        static member inline EnvironmentObject<'T when 'T :> EnvironmentObject>(key: EnvironmentKey<'T>) = EnvironmentObjectRequest(fun () -> key)

[<Extension>]
type EnvironmentObjectExtensions =
    [<Extension>]
    static member inline Bind<'parentMsg, 'marker, 'msg, 'T when 'parentMsg: equality and 'msg: equality and 'T :> EnvironmentObject>
        (
            _: ComponentBuilder<'parentMsg, 'marker>,
            [<InlineIfLambda>] value: EnvironmentObjectRequest<'T>,
            [<InlineIfLambda>] continuation: 'T -> ComponentBodyBuilder<'msg, 'marker>
        ) =
        ComponentBodyBuilder<'msg, 'marker>(fun envContext treeContext context bindings ->
            let envKey = value.Invoke()

            // Listen to changes in the environment
            context.LinkDisposable(
                $"env_{envKey.Key}",
                fun () ->
                    envContext.ValueChanged.Subscribe(fun args ->
                        if args.Key = envKey.Key then
                            context.NeedsRender())
            )
            |> ignore

            let state = envContext.Get(envKey)

            // Listen to changes in the object
            context.LinkDisposable($"env_{envKey.Key}_sub", fun () -> state.Changed.Subscribe(fun () -> context.NeedsRender()))
            |> ignore

            (continuation state).Invoke(envContext, treeContext, context, bindings))
