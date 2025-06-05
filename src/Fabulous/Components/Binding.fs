namespace Fabulous

open System
open System.ComponentModel
open System.Runtime.CompilerServices

type BindingRequest<'T> = delegate of unit -> StateValue<'T>

[<Struct>]
type BindingValue<'T> =
    [<EditorBrowsable(EditorBrowsableState.Never)>]
    val public SourceContext: ComponentContext

    [<EditorBrowsable(EditorBrowsableState.Never)>]
    val public SourceKey: int

    new(stateValue: StateValue<'T>) =
        { SourceContext = stateValue.Context
          SourceKey = stateValue.Key }

    member this.Current = this.SourceContext.TryGetValue<'T>(this.SourceKey).Value

    member inline this.Set(value: 'T) =
        this.SourceContext.SetValue(this.SourceKey, value)

[<AutoOpen>]
module BindingBuilders =
    type Context with
        [<Experimental("Binding is experimental and may change in the future")>]
        static member inline Binding(value: StateValue<'T>) = BindingRequest<'T>(fun () -> value)

type BindingExtensions =
    [<Extension>]
    static member inline Bind
        (
            _: ComponentBuilder<'parentMsg, 'marker>,
            [<InlineIfLambda>] fn: BindingRequest<'T>,
            [<InlineIfLambda>] continuation: BindingValue<'T> -> ComponentBodyBuilder<'msg, 'marker>
        ) =
        ComponentBodyBuilder<'msg, 'marker>(fun envContext treeContext context bindings ->
            let key = int bindings
            let stateValue = fn.Invoke()

            // Dispose previous subscription
            match context.TryGetValue<IDisposable>(key) with
            | ValueNone -> ()
            | ValueSome d -> d.Dispose()

            // Subscribe to source context changes
            let sourceKey = stateValue.Key

            //let sub =
            //    stateValue.Context.RenderNeeded.Subscribe(fun k ->
            //        if k = sourceKey then
            //            ctx.NeedsRender(key))
            //
            //ctx.SetValueInternal(key, sub)

            let bindingValue = BindingValue<'T>(stateValue)

            (continuation bindingValue).Invoke(envContext, treeContext, context, bindings + 1<binding>))
