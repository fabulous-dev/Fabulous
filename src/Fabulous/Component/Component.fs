namespace Fabulous

open System
open Fabulous.ScalarAttributeDefinitions

(*

## What's going on here:
This is an attempt at making re-executable computation expressions with a context being passed implicitly.

## History and constraints
Today in Fabulous, there is only one source of truth for the whole app: it's root state.

Whenever a change happens in this root state, the whole view hierarchy is re-evaluated to check for any
UI update that needs to be applied on the screen. Having this single source of truth is great to ensure consistency,
but it implies a lot of unnecessary processing because 99% of the time a state change will only have an impact locally,
not globally, hence it would be better to only re-evaluate the local view hierarchy.

This idea is known as "components": you can see them as some kind of mini-apps managing their own local state
that can trigger re-evaluation on their own and that can be composed together to make an actual Fabulous application.

Despite quite a lot of prior arts (SwiftUI "View" protocol, React components, FuncUI components, Vide builders, etc.),
it has been difficult to come up with a component approach in Fabulous due to the unique set of constraints: mobile & F#.
While the implementation is straightforward in the other F# libraries (FuncUI, Vide), they make heavy use of closures
which allocate of lot of memory; something Fabulous cannot afford because GC would keep freezing the app
on lower end Android smartphones due to limited memory. Hence it is better to avoid closures and make heavy use
of structs instead of classes.

Also another aspect why it has been difficult to come up with anything is the opinionated ergonomics wanted for Fabulous.
Fabulous took a similar approach to SwiftUI: a builder pattern with handcrafted widgets and modifiers.
But contrary to Swift, in .NET (C# & F#) using interfaces (protocols in Swift) over struct will result in boxing because
a struct first need to be transformed into an object before being casted to the interface. This triggers a lot of memory
allocation, which is what we want to avoid in the first place with the structs, so a different approach is required.

type IComponent = interface end
type [<Struct>] TextWidget(value: string) = interface IComponent

let text = TextWidget("Hello")
let component = text :> IComponent // ----> let component = text >> box :> IComponent

Another point we want to take a look into is the ability to use any kind of state management, not only MVU.

With all those constraints in place, we want something that can easily be composed into Fabulous 2 DSL ergonomics, 
lets you choose your own state management, and almost allocation-free to be friendly with low end mobile devices.

This means we need to make heavy use of inlining and structs.
Computation expressions to the rescue.

## Implementation ideas

A component needs to somehow hold its own state and have a view description that can be evaluated at will everytime
the state changes.

let component =
    view {
        let! count = state 0
        
        VStack() {
            Text($"Count is {count.Value}")
            Button("Increment", fun () -> count.Set(count + 1))
            Button("Decrement", fun () -> count.Set(count - 1))
        }
    }
    
To achieve this, we can create a ViewBuilder computation expression that will store its body into a function.
The state is bound to variables by using `let!`.


builder.Run(
    builder.Delay(
        builder.Bind(state 0, fun count -> // this is for "let! count = state 0"
            builder.Yield( // this is an implicit yield
                VStack() { ... }
            )
        )
    )
)

The ViewBuilder makes use of the implicit yield capability of F# by implementing: "Yield", "Combine", and "Delay".
Contrary to what the F# documentation states, "Zero" is not required to have implicit yield.

- Yield: Widget -> Contextual
- Combine: [<InlineIfLambda>] Contextual * [<InlineIfLambda>] Contextual -> Contextual
- Delay: [<InlineIfLambda>] (unit -> Contextual) -> Contextual

Contextual is a composable delegate that take a Context (so we can pass it implicitly around the CE, mainly to be used
in "Bind" without making it visible in the user code) and return a Widget, which is the typical body of a component.

Why are we using a delegate here?
Delegates are basically lambdas, so combining this with inlined CE methods ("member inline Yield", etc.) and the attribute
[<InlineIfLambda>], we can flatten the whole body of the CE into a single Contextual lambda.

Example:

let result =
    (fun () -> // the Delay
        Contextual(fun ctx -> // the Bind
            let count = ctx.GetState(0)
            Contextual(fun ctx ->  // the Yield
                VStack() {
                    Text($"Count is {count.Value}")
                }
            )
        )
    )()

will become

let result =
    Contextual(fun ctx ->
        let count = ctx.GetState(0)
        VStack() {
            Text($"Count is {count.Value}")
        }
    )


Since we already get a "Contextual" at every step of the CE, "Run" doesn't need any specific implementation except
returning the latest Contextual function.

## How does state works and how everything gets re-evaluated on change

"let! count = state 0" is a request to the implicit context passed around in the CE to retrieve the previous state value
or initialize it with the default value "0"

inline state 0 // helper function to hide the default factory lambda
--> StateRequest<int>(fun () -> 0) // StateRequest is also an inlinable delegate
--> let! === ctx.TryGetValue() or ctx.SetValue(0)
--> struct State<int>(ctx, key, value)

- static member inline Bind(_: ViewBuilder, [<InlineIfLambda>] request: StateRequest<'T>, [<InlineIfLambda>] continuation: State<'T> -> Contextual)

Since we are passing the Context itself into the State<int> struct value given to the user, when the user calls "count.Set(newValue)",
it will mark the context as dirty, meaning a re-evaluation is needed.

This context is originated from the Component that hold both its own Context and the Contextual lambda created by the CE.
The Component listens to its context Dirtied event to know when to re-evaluate the body.

Another important point is, the context uses positional indexes to store and retrieve the states.

Say you have the following body:

let body =
    view {
        let! firstName = state "George"
        let! lastName = state "Roger"
        (...)
    }
    
behind the scene, when calling Bind for firstName, Context will switch to the index 0.
Then when calling Bind for lastName, Context will switch to index 1.
Resulting in

Context.values =
[0] = "George"
[1] = "Roger"

On subsequent reevaluations, Context switch back to index 0 to retrieve the values in order
let firstName = Context.values[0]
let lastName = Context.values[1]

This means conditional state is to be avoided

DONT:
let body =
    view {
        if someCondition then
            let! firstName = state "George"
            Text("First name is {firstName.Value}")
        else
            let! lastName = state "Roger"
            Text("Last name is {lastName.Value}")
    }
    
This will returning a confusing result.

// 1st execution - someCondition = true
First name is George

// 2nd execution - someCondition = false
Last name is George

As a user, you expect to have two independent states: one for FirstName, one for LastName.
But since Context uses positional access to retrieve the values, firstName and lastName make no difference for Context
since they will both have Position = 0.


###############

A nice thing about this approach is that we can share a context between several components.
This is useful is the context of controls repeated several times that actually represent a same thing
(eg the avatar picture in the chat message page that gets repeated in front of each message)

let sharedContext = Context()

let avatar1 = Component(sharedContext, Avatar())
let avatar2 = Component(sharedContext, Avatar())

avatar1.Background <- Blue
// Automatically triggers avator2.Background to become Blue

*)

type ComponentBody = delegate of EnvironmentContext * ComponentContext -> Widget

[<NoEquality; NoComparison>]
type ComponentData =
    { Body: ComponentBody
      Context: ComponentContext option }

type IComponent =
    inherit IBaseComponent
    abstract member SetData: ComponentData -> unit

module Component =
    /// TODO: This is actually broken. On every call of the parent, the body will be reassigned to the Component triggering a re-render because of the noCompare.
    /// This is not what was expected. The body should actually be invalidated based on its context.
    let Data =
        Attributes.defineSimpleScalar "Component_Data" ScalarAttributeComparers.noCompare (fun _ currOpt node ->
            let target = BaseComponent.getAttachedComponent(node.Target) :?> IComponent

            match currOpt with
            | ValueNone -> failwith "Component widget must have data"
            | ValueSome data -> target.SetData(data))

type Component(
    treeContext,
    envContext,
    context,
    body: ComponentBody
    ) =
    inherit BaseComponent(treeContext, envContext, context)
    
    let mutable _body = body
    let mutable _widget = Unchecked.defaultof<_>
    let mutable _view = null
        
    interface IComponent with
        member this.SetData(data: ComponentData) =
            _body <- data.Body
            
            let prevContext = this.Context
            (prevContext :> IDisposable).Dispose()
            
            this.Context <- context
            this.Context.AddDisposable("context", this.Context.RenderNeeded.Subscribe(this.Render))
            
            this.Render()

    member this.CreateView(componentWidget: Widget) =
        let widget = _body.Invoke(this.EnvironmentContext, this.Context)
        _widget <- widget

        // Inject the attributes added to the component directly into the root widget
        let scalars =
            match componentWidget.ScalarAttributes with
            | ValueNone -> ValueNone
            | ValueSome attrs ->
                ValueSome(Array.filter (fun (attr: ScalarAttribute) -> attr.Key <> Component.Data.Key) attrs)

        let widget: Widget =
            { Key = widget.Key
#if DEBUG
              DebugName = widget.DebugName
#endif
              ScalarAttributes =
                match struct (widget.ScalarAttributes, scalars) with
                | ValueNone, ValueNone -> ValueNone
                | ValueSome attrs, ValueNone
                | ValueNone, ValueSome attrs -> ValueSome attrs
                | ValueSome widgetAttrs, ValueSome componentAttrs -> ValueSome(Array.append widgetAttrs componentAttrs)
              WidgetAttributes =
                match struct (widget.WidgetAttributes, componentWidget.WidgetAttributes) with
                | ValueNone, ValueNone -> ValueNone
                | ValueSome attrs, ValueNone
                | ValueNone, ValueSome attrs -> ValueSome attrs
                | ValueSome widgetAttrs, ValueSome componentAttrs -> ValueSome(Array.append widgetAttrs componentAttrs)
              WidgetCollectionAttributes =
                match struct (widget.WidgetCollectionAttributes, componentWidget.WidgetCollectionAttributes) with
                | ValueNone, ValueNone -> ValueNone
                | ValueSome attrs, ValueNone
                | ValueNone, ValueSome attrs -> ValueSome attrs
                | ValueSome widgetAttrs, ValueSome componentAttrs -> ValueSome(Array.append widgetAttrs componentAttrs) }

        // Create the actual view
        let widgetDef = WidgetDefinitionStore.get widget.Key
        let struct (node, view) = widgetDef.CreateView(widget, treeContext, this.EnvironmentContext, ValueNone)
        _view <- view

        BaseComponent.setAttachedComponent view this
        
        this.Context.AddDisposable("context", this.Context.RenderNeeded.Subscribe(this.Render))

        struct (node, view)

    member this.Render() =
        let prevRootWidget = _widget
        let currWidget = _body.Invoke(this.EnvironmentContext, this.Context)
        _widget <- currWidget

        let viewNode = treeContext.GetViewNode _view

        Reconciler.update treeContext.CanReuseView (ValueSome prevRootWidget) currWidget viewNode

module ComponentWidget =
    let WidgetKey =
        let key = WidgetDefinitionStore.getNextKey()

        let definition =
            { Key = key
              Name = "Component"
              TargetType = typeof<Component>
              AttachView = fun _ -> failwith "Component widget cannot be attached"
              CreateView =
                fun (widget, treeContext, env, _) ->
                    match widget.ScalarAttributes with
                    | ValueNone -> failwith "Component widget must have a body and a context"
                    | ValueSome attrs ->
                        let data =
                            match Array.tryFind (fun (attr: ScalarAttribute) -> attr.Key = Component.Data.Key) attrs with
                            | Some attr -> attr.Value :?> ComponentData
                            | None -> failwith "Component widget must have data"

                        let context =
                            match data.Context with
                            | Some ctx -> ctx
                            | None -> new ComponentContext()
                            
                        let env = new EnvironmentContext(env)

                        let comp = new Component(treeContext, env, context, data.Body)
                        let struct (node, view) = comp.CreateView(widget)

                        struct (node, view) }

        WidgetDefinitionStore.set key definition

        key

/// This measure type is used to count the number of bindings in a component while building the computation expression
[<Measure>]
type binding

/// Delegate used by the ComponentBuilder to compose a component body
/// It will be aggressively inlined by the compiler leaving no overhead, only a pure function that returns a WidgetBuilder
type ComponentBodyBuilder<'marker> =
    delegate of
        bindings: int<binding> * environmentContext: EnvironmentContext * context: ComponentContext -> struct (int<binding> * WidgetBuilder<unit, 'marker>)

type ComponentBuilder() =
    
    member inline this.Yield(widgetBuilder: WidgetBuilder<unit, 'marker>) =
        ComponentBodyBuilder<'marker>(fun bindings env ctx -> struct (bindings, widgetBuilder))

    member inline this.Combine([<InlineIfLambda>] a: ComponentBodyBuilder<'marker>, [<InlineIfLambda>] b: ComponentBodyBuilder<'marker>) =
        ComponentBodyBuilder<'marker>(fun bindings env ctx ->
            let struct (bindingsA, _) = a.Invoke(bindings, env, ctx) // discard the previous widget in the chain but we still need to count the bindings
            let struct (bindingsB, resultB) = b.Invoke(bindings, env, ctx)

            // Calculate the total number of bindings between A and B
            let resultBindings = (bindingsA + bindingsB) - bindings

            struct (resultBindings, resultB))

    member inline this.Delay([<InlineIfLambda>] fn: unit -> ComponentBodyBuilder<'marker>) =
        ComponentBodyBuilder<'marker>(fun bindings env ctx ->
            let sub = fn()
            sub.Invoke(bindings, env, ctx))

    member inline this.Run([<InlineIfLambda>] body: ComponentBodyBuilder<'marker>) =
        let compiledBody =
            ComponentBody(fun env ctx ->
                let struct (_, result) = body.Invoke(0<binding>, env, ctx)
                result.Compile())
            
        let data =
            { Body = compiledBody
              Context = None }

        WidgetBuilder<unit, 'marker>(ComponentWidget.WidgetKey, Component.Data.WithValue(data))