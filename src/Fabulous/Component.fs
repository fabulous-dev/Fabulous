namespace Fabulous

open System
open System.ComponentModel
open System.Runtime.CompilerServices
open System.Collections.Generic
open Fabulous.ScalarAttributeDefinitions

////////////// CONTEXT //////////////
type ComponentContext() =
    let values = Dictionary<int, obj>()
    let mutable _current = -1
    
    let renderNeeded = Event<unit>()
    member this.RenderNeeded = renderNeeded.Publish
    member this.NeedsRender() = renderNeeded.Trigger()
    
    member this.MoveNext() =
        _current <- _current + 1
        _current
        
    member this.Current
        with get () =
            match values.TryGetValue(_current) with
            | false, _ -> ValueNone
            | true, value -> ValueSome value
    
    member this.SetCurrentValue(value: 'T) =
        values[_current] <- value
        
    member this.SetValue(key: int, value: 'T) =
        values[key] <- value
        this.NeedsRender()
        
    member this.AfterRender() =
        _current <- -1
        


////////////// ViewBuilder //////////////
type ComponentBody = delegate of ComponentContext -> Widget
type ComponentBodyBuilder<'msg, 'marker> = delegate of ComponentContext -> WidgetBuilder<'msg, 'marker>

type ViewBuilder() =        
    member inline this.Yield(widget: WidgetBuilder<'msg, 'marker>) =
        ComponentBodyBuilder(fun ctx -> widget)
        
    member inline this.Combine([<InlineIfLambda>] a: ComponentBodyBuilder<'msg, 'marker>, [<InlineIfLambda>] b: ComponentBodyBuilder<'msg, 'marker>) =
        ComponentBodyBuilder(fun ctx ->
            let _ = a.Invoke(ctx) // discard the previous widget in the chain
            let result = b.Invoke(ctx)
            result
        )
        
    member inline this.Delay([<InlineIfLambda>] fn: unit -> ComponentBodyBuilder<'msg, 'marker>) =
        ComponentBodyBuilder(fun ctx ->
            let sub = fn()
            sub.Invoke(ctx)
        )
        
    member inline this.Run([<InlineIfLambda>] result: ComponentBodyBuilder<'msg, 'marker>) =
        result

[<AutoOpen>]
module ViewBuilder =
    let view = ViewBuilder()
    
    
    
    
    
////////////// Component holder //////////////

type Component(treeContext: ViewTreeContext, body: ComponentBody, context: ComponentContext) =
    let mutable _body = body
    let mutable _context = context
    let mutable _widget = Unchecked.defaultof<_>
    let mutable _view = null
    let mutable _contextSubscription: IDisposable = null
    
    // TODO: This is a big code smell. We should not do this but I can't think of a better way to do it right now.
    // The implementation of this method is set by the consuming project: Fabulous.XamarinForms, Fabulous.Maui, Fabulous.Avalonia
    static let mutable _setAttachedComponent: obj -> Component -> unit = fun _ _ -> failwith "Please call Component.SetComponentFunctions() before using Component"
    static let mutable _getAttachedComponent: obj -> Component = fun _ -> failwith "Please call Component.SetComponentFunctions() before using Component"
    static member SetComponentFunctions(get: obj -> Component, set: obj -> Component -> unit) =
        _getAttachedComponent <- get
        _setAttachedComponent <- set
        
    static member GetAttachedComponent(view: obj) = _getAttachedComponent view
    static member SetAttachedComponent(view: obj, comp: Component) = _setAttachedComponent view comp
        
    member this.Body
        with get () = _body
        and set value =
            _body <- value
            this.Render()
            
    member this.Context
        with get () = _context
        and set value =
            if _contextSubscription <> null then
                _contextSubscription.Dispose()
            
            _context <- value
            
            _contextSubscription <- this.Context.RenderNeeded.Subscribe(this.Render)
            
            this.Render()
        
    member this.CreateView() =
        _contextSubscription <- this.Context.RenderNeeded.Subscribe(this.Render)
        
        let rootWidget = this.Body.Invoke(context)
        _widget <- rootWidget
        
        this.Context.AfterRender()
        
        let widgetDef = WidgetDefinitionStore.get rootWidget.Key
        let struct (node, view) = widgetDef.CreateView(rootWidget, treeContext, ValueNone)
        _view <- view

        Component.SetAttachedComponent(view, this)
        
        struct (node, view)
        
    member this.Render() =
        let prevRootWidget = _widget
        let currRootWidget = this.Body.Invoke(context)
        _widget <- currRootWidget
        
        this.Context.AfterRender()
        
        let viewNode = treeContext.GetViewNode _view
        
        Reconciler.update treeContext.CanReuseView (ValueSome prevRootWidget) currRootWidget viewNode
        
    interface IDisposable with
        member this.Dispose() =
            if _contextSubscription <> null then
                _contextSubscription.Dispose()
                _contextSubscription <- null
    
    
    
    
////////////// Component widget //////////////
module Component =
    /// TODO: This is actually broken. On every call of the parent, the body will be reassigned to the Component triggering a re-render because of the noCompare.
    /// This is not what was expected. The body should actually be invalidated based on its context.
    let Body: SimpleScalarAttributeDefinition<ComponentBody> = Attributes.defineSimpleScalar "Component_Body" ScalarAttributeComparers.noCompare (fun _ currOpt node ->
        let target = Component.GetAttachedComponent(node.Target)
        match currOpt with
        | ValueNone -> failwith "Component widget must have a body"
        | ValueSome curr -> target.Body <- curr
    )
    let Context: SimpleScalarAttributeDefinition<ComponentContext> = Attributes.defineSimpleScalar "Component_Context" ScalarAttributeComparers.equalityCompare (fun _ currOpt node ->
        let target = Component.GetAttachedComponent(node.Target)
        match currOpt with
        | ValueNone -> target.Context <- ComponentContext()
        | ValueSome curr -> target.Context <- curr
    )
    
    let WidgetKey =
        let key = WidgetDefinitionStore.getNextKey()
        
        let definition =
            { Key = key
              Name = "Component"
              TargetType = typeof<Component>
              AttachView = fun _ -> failwith "Component widget cannot be attached"
              CreateView =
                fun (widget, treeContext, _) ->
                    match widget.ScalarAttributes with
                    | ValueNone -> failwith "Component widget must have a body"
                    | ValueSome attrs ->                            
                        let body =
                            match Array.tryFind (fun (attr: ScalarAttribute) -> attr.Key = Body.Key) attrs with
                            | Some attr -> attr.Value :?> ComponentBody
                            | None -> failwith "Component widget must have a body"

                        let context =
                            match Array.tryFind (fun (attr: ScalarAttribute) -> attr.Key = Context.Key) attrs with
                            | Some attr -> attr.Value :?> ComponentContext
                            | None -> ComponentContext()

                        let comp = new Component(treeContext, body, context)
                        let struct(node, view) = comp.CreateView()

                        struct (node, view) }
            
        WidgetDefinitionStore.set key definition

        key
        
[<Extension>]
type ComponentExtensions =
    [<Extension>]
    static member inline WithValue(this: SimpleScalarAttributeDefinition<ComponentBody>, [<InlineIfLambda>] value: ComponentBodyBuilder<'msg, 'marker>) =
        let compiledBody =
            ComponentBody(fun ctx ->
                let widgetBuilder = value.Invoke(ctx)
                widgetBuilder.Compile()
            )
        
        this.WithValue(compiledBody)

            
////////////// State //////////////

type StateRequest<'T> = delegate of unit -> 'T

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
type [<Struct>] State<'T>=
    [<EditorBrowsable(EditorBrowsableState.Never)>]
    val public Context: ComponentContext
    
    [<EditorBrowsable(EditorBrowsableState.Never)>]
    val public Key: int
    
    val public Current: 'T
    
    new (ctx, key, value) = { Context = ctx; Key = key; Current = value }
    
    member inline this.Set(value: 'T) =
        this.Context.SetValue(this.Key, value)

[<Extension>]
type StateExtensions =
    [<Extension>]
    static member inline Bind(_: ViewBuilder, [<InlineIfLambda>] fn: StateRequest<'T>, [<InlineIfLambda>] continuation: State<'T> -> ComponentBodyBuilder<'msg, 'marker>) =
        ComponentBodyBuilder<'msg, 'marker>(fun ctx ->
            let key = ctx.MoveNext()
            
            let value =
                match ctx.Current with
                | ValueSome value -> unbox<'T> value
                | ValueNone ->
                    let value = fn.Invoke()
                    ctx.SetCurrentValue(value)
                    value
                    
            let state = State(ctx, key, value)
            (continuation state).Invoke(ctx)
        )
        
[<AutoOpen>]
module StateHelpers =
    let inline state value = StateRequest(fun () -> value)
    
    
////////////// Binding //////////////

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

type BindingRequest<'T> = delegate of unit -> State<'T>

type [<Struct>] Binding<'T> =
    val public Context: ComponentContext
    val public Source: State<'T>
    
    new (ctx, source) = { Context = ctx; Source = source }
        
    member inline this.Current = this.Source.Current
    
    member inline this.Set(value: 'T) =
        this.Source.Set(value)
        this.Context.NeedsRender()

[<Extension>]
type BindingExtensions =
    [<Extension>]
    static member inline Bind(_: ViewBuilder, [<InlineIfLambda>] request: BindingRequest<'T>, [<InlineIfLambda>] continuation: Binding<'T> -> ComponentBodyBuilder<'msg, 'marker>) =
        ComponentBodyBuilder(fun ctx ->
            let source = request.Invoke()
            let state = Binding<'T>(ctx, source)
            (continuation state).Invoke(ctx)
        )
        
[<AutoOpen>]
module BindingHelpers =
    let inline ofState (source: State<'T>) = BindingRequest(fun () -> source)
    let inline bind (binding: Binding<'T>) = binding