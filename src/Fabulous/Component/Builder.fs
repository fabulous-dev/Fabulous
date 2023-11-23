namespace Fabulous

/// Delegate used by the ComponentBuilder to compose a component body
/// It will be aggressively inlined by the compiler leaving no overhead, only a pure function that returns a WidgetBuilder
type ComponentBodyBuilder<'marker> =
    delegate of bindings: int<binding> * context: ComponentContext -> struct (int<binding> * WidgetBuilder<unit, 'marker>)

type ComponentBuilder() =
    member inline this.Yield(widgetBuilder: WidgetBuilder<unit, 'marker>) =
        ComponentBodyBuilder<'marker>(fun bindings ctx -> struct (bindings, widgetBuilder))

    member inline this.Combine([<InlineIfLambda>] a: ComponentBodyBuilder<'marker>, [<InlineIfLambda>] b: ComponentBodyBuilder<'marker>) =
        ComponentBodyBuilder<'marker>(fun bindings ctx ->
            let struct (bindingsA, _) = a.Invoke(bindings, ctx) // discard the previous widget in the chain but we still need to count the bindings
            let struct (bindingsB, resultB) = b.Invoke(bindings, ctx)

            // Calculate the total number of bindings between A and B
            let resultBindings = (bindingsA + bindingsB) - bindings

            struct (resultBindings, resultB))

    member inline this.Delay([<InlineIfLambda>] fn: unit -> ComponentBodyBuilder<'marker>) =
        ComponentBodyBuilder<'marker>(fun bindings ctx ->
            let sub = fn()
            sub.Invoke(bindings, ctx))

    member inline this.Run([<InlineIfLambda>] body: ComponentBodyBuilder<'marker>) =
        let compiledBody =
            ComponentBody(fun ctx ->
                let struct (_, result) = body.Invoke(0<binding>, ctx)
                struct (ctx, result.Compile()))

        WidgetBuilder<unit, 'marker>(
            ComponentWidget.WidgetKey,
            Component.Body.WithValue(compiledBody)
        )
