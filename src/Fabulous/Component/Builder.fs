namespace Fabulous

/// Delegate used by the ComponentBuilder to compose a component body
/// It will be aggressively inlined by the compiler leaving no overhead, only a pure function that returns a WidgetBuilder
type ComponentBodyBuilder<'msg, 'marker> = delegate of bindings: int<binding> * context: ComponentContext -> struct (int<binding> * WidgetBuilder<'msg, 'marker>)

type ComponentBuilder() =        
    member inline this.Yield(widgetBuilder: WidgetBuilder<'msg, 'marker>) =
        ComponentBodyBuilder<'msg, 'marker>(fun bindings ctx ->
            struct(
                bindings,
                widgetBuilder
            )
        )
        
    member inline this.Combine([<InlineIfLambda>] a: ComponentBodyBuilder<'msg, 'marker>, [<InlineIfLambda>] b: ComponentBodyBuilder<'msg, 'marker>) =
        ComponentBodyBuilder<'msg, 'marker>(fun bindings ctx ->
            let struct (bindingsA, _) = a.Invoke(bindings, ctx) // discard the previous widget in the chain but we still need to count the bindings
            let struct (bindingsB, resultB) = b.Invoke(bindings, ctx)
            
            // Calculate the total number of bindings between A and B
            let resultBindings = (bindingsA + bindingsB) - bindings
            
            struct (resultBindings, resultB)
        )
        
    member inline this.Delay([<InlineIfLambda>] fn: unit -> ComponentBodyBuilder<'msg, 'marker>) =
        ComponentBodyBuilder<'msg, 'marker>(fun bindings ctx ->
            let sub = fn()
            sub.Invoke(bindings, ctx)
        )
        
    member inline this.Run([<InlineIfLambda>] body: ComponentBodyBuilder<'msg, 'marker>) =
        let compiledBody =
            ComponentBody(fun ctxOpt ->
                let ctx =
                    match ctxOpt with
                    | ValueNone -> ComponentContext()
                    | ValueSome ctx -> ctx
                
                let struct (_, result) = body.Invoke(0<binding>, ctx)
                struct (ctx, result.Compile())
            )
            
        WidgetBuilder<'msg, 'marker>(
            Component.WidgetKey,
            Component.Body.WithValue(compiledBody)
        )