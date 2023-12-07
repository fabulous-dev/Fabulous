namespace Fabulous

open System.ComponentModel
open System.Runtime.CompilerServices

type State<'T> = delegate of unit -> 'T

/// DESIGN: State<'T> is meant to be very short lived.
/// It is created on Bind (let!) and destroyed at the end of a single ViewBuilder CE execution.
/// Due to its nature, it is very likely it will be captured by a closure and allocated to the memory heap when it's not needed.
///
/// e.g.
///
/// Button("Increment", fun () -> state.Set(state.Current + 1))
///
/// will become
///
/// class Closure {
///     public State<int> state; // Storing a struct on a class will allocate it on the heap
///
///     public void Invoke() {
///         state.Set(state.Current + 1);
///     }
/// }
///
/// class Program {
///    public void View()
///    {
///       var state = new State<int>(...);
///
///       // This will allocate both the closure and the state on the heap
///       // which the GC will have to clean up later
///       var closure = new Closure(state = state);
///
///       return Button("Increment", closure);
///    }
/// }
///
///
/// The Set method is therefore marked inlinable to avoid creating a closure capturing State<'T>
/// Instead the closure will only capture Context (already a reference type), Key (int) and Current (can be consider to be obj).
/// The compiler will rewrite the lambda as follow:
/// Button("Increment", fun () -> ctx.SetValue(key, current + 1))
///
/// State<'T> is no longer involved in the closure and will be kept on the stack.
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

[<Extension>]
type StateExtensions =
    [<Extension>]
    static member inline Bind
        (
            _: ComponentBuilder<'msg, 'marker>,
            [<InlineIfLambda>] fn: State<'T>,
            [<InlineIfLambda>] continuation: StateValue<'T> -> ComponentBodyBuilder<'marker>
        ) =
        ComponentBodyBuilder<'marker>(fun bindings env ctx ->
            let key = int bindings

            let value =
                match ctx.TryGetValue<'T>(key) with
                | ValueSome value -> value
                | ValueNone ->
                    let newValue = fn.Invoke()
                    ctx.SetValue(key, newValue)
                    newValue

            let state = StateValue(ctx, key, value)
            (continuation state).Invoke((bindings + 1<binding>), env, ctx))
