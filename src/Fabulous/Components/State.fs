namespace Fabulous

open System.ComponentModel
open System.Runtime.CompilerServices

type StateRequest<'T> = delegate of unit -> 'T

/// DESIGN: StateValue<'T> is meant to be very short lived.
/// It is created on Bind (let!) and destroyed at the end of a single ViewBuilder CE execution.
/// Due to its nature, it is very likely it will be captured by a closure and allocated to the memory heap when it's not needed.
///
/// e.g.
///
/// Button("Increment", fun () -> stateValue.Set(stateValue.Current + 1))
///
/// will become
///
/// class Closure {
///     public StateValue<int> stateValue; // Storing a struct on a class will allocate it on the heap
///
///     public void Invoke() {
///         stateValue.Set(stateValue.Current + 1);
///     }
/// }
///
/// class Program {
///    public void View()
///    {
///       var stateValue = new StateValue<int>(...);
///
///       // This will allocate both the closure and the stateValue on the heap
///       // which the GC will have to clean up later
///       var closure = new Closure(stateValue = stateValue);
///
///       return Button("Increment", closure);
///    }
/// }
///
///
/// The Set method is therefore marked inlinable to avoid creating a closure capturing StateValue<'T>
/// Instead the closure will only capture Context (already a reference type), Key (int) and Current (can be consider to be obj).
/// The compiler will rewrite the lambda as follow:
///
/// Button("Increment", fun () -> ctx.SetValue(key, current + 1))
///
/// StateValue<'T> is no longer involved in the closure and will be kept on the stack.
///
/// One constraint of inlining is to have all used fields public: Context, Key, Current
/// But we don't wish to expose the Context and Key fields to the user, so we mark them as EditorBrowsable.Never
[<Struct>]
type StateValue<'T> =
    [<EditorBrowsable(EditorBrowsableState.Never)>]
    val public Context: ComponentContext

    [<EditorBrowsable(EditorBrowsableState.Never)>]
    val public Key: int

    val public Current: 'T

    new(ctx, key, value) =
        { Context = ctx
          Key = key
          Current = value }

    member inline this.Set(value: 'T) = this.Context.SetValue(this.Key, value)

[<AutoOpen>]
module StateBuilders =
    type Context with

        static member inline State(defaultValue: 'T) =
            StateRequest<'T>(fun () -> defaultValue)

[<Extension>]
type StateExtensions =
    [<Extension>]
    static member inline Bind
        (
            _: ComponentBuilder<'parentMsg, 'marker>,
            [<InlineIfLambda>] fn: StateRequest<'T>,
            [<InlineIfLambda>] continuation: StateValue<'T> -> ComponentBodyBuilder<'msg, 'marker>
        ) =
        ComponentBodyBuilder<'msg, 'marker>(fun envContext treeContext context bindings ->
            let key = int bindings

            let value =
                match context.TryGetValue<'T>(key) with
                | ValueSome value -> value
                | ValueNone ->
                    let value = fn.Invoke()
                    context.SetValue(key, value)
                    value

            let stateValue = StateValue<'T>(context, key, value)

            (continuation stateValue).Invoke(envContext, treeContext, context, bindings + 1<binding>))
