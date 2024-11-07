namespace Fabulous

/// Delegate used by the ComponentBuilder to compose a component body
/// It will be aggressively inlined by the compiler leaving no overhead, only a pure function that returns a WidgetBuilder
type ComponentBodyBuilder<'msg, 'marker when 'msg: equality> =
    delegate of
        envContext: EnvironmentContext * treeContext: ViewTreeContext * context: ComponentContext * bindings: int<binding> ->
            struct (EnvironmentContext * ViewTreeContext * ComponentContext * int<binding> * WidgetBuilder<'msg, 'marker>)

type ComponentBuilder<'parentMsg, 'marker when 'parentMsg: equality> =
    val public Key: string

    new(key: string) = { Key = key }

    member inline this.Yield(widgetBuilder: WidgetBuilder<'msg, 'marker>) =
        ComponentBodyBuilder<'msg, 'marker>(fun envContext treeContext context bindings -> struct (envContext, treeContext, context, bindings, widgetBuilder))

    member inline this.Combine([<InlineIfLambda>] a: ComponentBodyBuilder<'msg, 'marker>, [<InlineIfLambda>] b: ComponentBodyBuilder<'msg, 'marker>) =
        ComponentBodyBuilder<'msg, 'marker>(fun envContext treeContext context bindings ->
            let struct (envA, treeA, ctxA, bindingsA, _) =
                a.Invoke(envContext, treeContext, context, bindings) // discard the previous widget in the chain but we still need to count the bindings

            let struct (envB, treeB, ctxB, bindingsB, widgetB) =
                b.Invoke(envA, treeA, ctxA, bindingsA)

            // Calculate the total number of bindings between A and B
            let combinedBindings = (bindingsA + bindingsB) - bindings

            struct (envB, treeB, ctxB, combinedBindings, widgetB))

    member inline this.Delay([<InlineIfLambda>] fn: unit -> ComponentBodyBuilder<'msg, 'marker>) =
        ComponentBodyBuilder<'msg, 'marker>(fun envContext treeContext context bindings ->
            let sub = fn()
            sub.Invoke(envContext, treeContext, context, bindings))

    member inline this.Run([<InlineIfLambda>] body: ComponentBodyBuilder<'msg, 'marker>) =
        let compiledBody =
            ComponentBody(fun envContext treeContext context ->
                let struct (envA, treeA, ctxA, _, result) =
                    body.Invoke(envContext, treeContext, context, 0<binding>)

                struct (envA, treeA, ctxA, result.Compile()))

        let data = { Key = this.Key; Body = compiledBody }

        WidgetBuilder<'parentMsg, 'marker>(Component'.WidgetKey, Component'.Data.WithValue(data))
