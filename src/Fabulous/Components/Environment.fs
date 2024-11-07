namespace Fabulous

open System.Runtime.CompilerServices
open Fabulous.ScalarAttributeDefinitions

type EnvironmentRequest<'T> = delegate of unit -> EnvironmentKey<'T>

[<AutoOpen>]
module EnvironmentBuilders =
    type Context with
        static member inline Environment(key: EnvironmentKey<'T>) = EnvironmentRequest(fun () -> key)

type EnvironmentAttrValue = { Key: string; Value: obj }

module Environment' =
    let Environment =
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                ScalarAttributeComparers.noCompare,
                (fun oldValueOpt (newValueOpt: EnvironmentAttrValue voption) node ->
                    match struct (oldValueOpt, newValueOpt) with
                    | ValueNone, ValueNone -> ()
                    | ValueSome prev, ValueNone -> node.EnvironmentContext.RemoveInternal(prev.Key, true)
                    | _, ValueSome curr -> node.EnvironmentContext.SetInternal(curr.Key, curr.Value, true))
            )
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = "Environment" }: SimpleScalarAttributeDefinition<EnvironmentAttrValue>

[<Extension>]
type EnvironmentExtensions =
    [<Extension>]
    static member inline Bind
        (
            _: ComponentBuilder<'parentMsg, 'marker>,
            [<InlineIfLambda>] value: EnvironmentRequest<'T>,
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
            (continuation state).Invoke(envContext, treeContext, context, bindings))

[<Extension>]
type EnvironmentModifiers =
    [<Extension>]
    static member inline environment(this: WidgetBuilder<'msg, 'marker>, key: EnvironmentKey<'T>, value: 'T) =
        this.AddScalar(Environment'.Environment.WithValue(({ Key = key.Key; Value = box value }: EnvironmentAttrValue)))
