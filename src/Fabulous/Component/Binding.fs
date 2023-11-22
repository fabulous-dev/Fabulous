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

type ComponentBindingRequest<'T> = delegate of unit -> ComponentState<'T>

type [<Struct>] ComponentBinding<'T> =
    val public Context: ComponentContext
    val public Source: ComponentState<'T>
    
    new (ctx, source) = { Context = ctx; Source = source }
        
    member inline this.Current = this.Source.Current
    
    member inline this.Set(value: 'T) =
        this.Source.Set(value)

[<Extension>]
type BindingExtensions =
    [<Extension>]
    static member inline Bind(_: ComponentBuilder, [<InlineIfLambda>] request: ComponentBindingRequest<'T>, [<InlineIfLambda>] continuation: ComponentBinding<'T> -> ComponentBodyBuilder<'msg, 'marker>) =
        // Despite its name, ComponentBinding actual value is not stored in this component, but in the source component
        // So, we do not need to increment the number of bindings here
        ComponentBodyBuilder(fun bindings ctx ->
            let source = request.Invoke()
            
            source.Context.RenderNeeded.Add(fun () -> ctx.NeedsRender())
            
            let state = ComponentBinding<'T>(ctx, source)
            (continuation state).Invoke(bindings, ctx)
        )
        
[<AutoOpen>]
module BindingHelpers =
    let inline ofState (source: ComponentState<'T>) = ComponentBindingRequest(fun () -> source)
    let inline bind (binding: ComponentBinding<'T>) = binding

