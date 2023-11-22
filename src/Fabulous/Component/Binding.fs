namespace Fabulous

open System.Runtime.CompilerServices

(*

The idea of Binding is to listen to a State<'T> that is managed by another Context and be able to update it
while notifying the two Contexts involved (source and target)

let child (count: BindingRequest<int>) =
    view {
        let! boundCount = bind count
    
        Button($"Count is {boundCount.Value}", fun () -> boundCount.Set(boundCount.Value + 1))
    }
    
let parent =
    view {
        let! count = state 0
        
        VStack() {
            Text($"Count is {count.Value}")
            child (Binding.ofState count)
        }
    }

*)

type Binding<'T> = delegate of unit -> StateValue<'T>

[<Struct>]
type BindingValue<'T> =
    val public Context: ComponentContext
    val public SourceContext: ComponentContext
    val public SourceKey: int
    val public SourceCurrentValue: 'T

    new(ctx, sourceCtx, sourceKey, sourceCurrentValue) =
        { Context = ctx
          SourceContext = sourceCtx
          SourceKey = sourceKey
          SourceCurrentValue = sourceCurrentValue }

    member inline this.Current = this.SourceCurrentValue

    member inline this.Set(value: 'T) =
        this.SourceContext.SetValue(this.SourceKey, value)
        this.Context.NeedsRender()

[<Extension>]
type BindingExtensions =
    [<Extension>]
    static member inline Bind
        (
            _: ComponentBuilder,
            [<InlineIfLambda>] request: Binding<'T>,
            [<InlineIfLambda>] continuation: BindingValue<'T> -> ComponentBodyBuilder<'msg, 'marker>
        ) =
        // Despite its name, ComponentBinding actual value is not stored in this component, but in the source component
        // So, we do not need to increment the number of bindings here
        ComponentBodyBuilder(fun bindings ctx ->
            let source = request.Invoke()

            source.Context.RenderNeeded.Add(fun () -> ctx.NeedsRender())

            let state = BindingValue<'T>(ctx, source.Context, source.Key, source.Current)
            (continuation state).Invoke(bindings, ctx))

[<AutoOpen>]
module BindingHelpers =
    let inline ``$`` (source: StateValue<'T>) = Binding(fun () -> source)
