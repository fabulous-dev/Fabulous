namespace Fabulous

open System

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
// Automatically triggers avatar2.Background to become Blue

*)

/// This measure type is used to count the number of bindings in a component while building the computation expression
[<Measure>]
type binding

type ComponentBody = delegate of ComponentContext -> struct (ComponentContext * Widget)

[<Struct; NoEquality; NoComparison>]
type ComponentData = { Body: ComponentBody }

type Component(treeContext: ViewTreeContext, body: ComponentBody, context: ComponentContext) =
    let mutable _body = body
    let mutable _context = context
    let mutable _widget = Unchecked.defaultof<_>
    let mutable _view = null
    let mutable _contextSubscription: IDisposable = null

    member private this.MergeAttributes(rootWidget: Widget, componentWidgetOpt: Widget voption) =
        match componentWidgetOpt with
        | ValueNone -> struct (rootWidget.ScalarAttributes, rootWidget.WidgetAttributes, rootWidget.WidgetCollectionAttributes)

        | ValueSome componentWidget ->
            let componentScalars =
                match componentWidget.ScalarAttributes with
                | ValueNone -> ValueNone
                | ValueSome attrs -> ValueSome(Array.skip 1 attrs) // skip the first attribute which is the component data

            let scalars =
                match struct (rootWidget.ScalarAttributes, componentScalars) with
                | ValueNone, ValueNone -> ValueNone
                | ValueSome attrs, ValueNone
                | ValueNone, ValueSome attrs -> ValueSome attrs
                | ValueSome widgetAttrs, ValueSome componentAttrs -> ValueSome(Array.append componentAttrs widgetAttrs)

            let widgets =
                match struct (rootWidget.WidgetAttributes, componentWidget.WidgetAttributes) with
                | ValueNone, ValueNone -> ValueNone
                | ValueSome attrs, ValueNone
                | ValueNone, ValueSome attrs -> ValueSome attrs
                | ValueSome widgetAttrs, ValueSome componentAttrs -> ValueSome(Array.append componentAttrs widgetAttrs)

            let widgetColls =
                match struct (rootWidget.WidgetCollectionAttributes, componentWidget.WidgetCollectionAttributes) with
                | ValueNone, ValueNone -> ValueNone
                | ValueSome attrs, ValueNone
                | ValueNone, ValueSome attrs -> ValueSome attrs
                | ValueSome widgetAttrs, ValueSome componentAttrs -> ValueSome(Array.append componentAttrs widgetAttrs)

            struct (scalars, widgets, widgetColls)

    member this.CreateView(componentWidget: Widget voption) =
        let struct (context, rootWidget) = _body.Invoke(_context)
        _widget <- rootWidget
        _context <- context

        let struct (scalars, widgets, widgetColls) =
            this.MergeAttributes(rootWidget, componentWidget)

        let rootWidget: Widget =
            { Key = rootWidget.Key
#if DEBUG
              DebugName = rootWidget.DebugName
#endif
              ScalarAttributes = scalars
              WidgetAttributes = widgets
              WidgetCollectionAttributes = widgetColls }

        // Create the actual view
        let widgetDef = WidgetDefinitionStore.get rootWidget.Key
        let struct (node, view) = widgetDef.CreateView(rootWidget, treeContext, ValueNone)

        _view <- view
        _contextSubscription <- _context.RenderNeeded.Subscribe(this.Render)

        struct (node, view)

    member this.AttachView(componentWidget: Widget, view: obj) =
        let struct (context, rootWidget) = _body.Invoke(_context)
        _widget <- rootWidget
        _context <- context

        let struct (scalars, widgets, widgetColls) =
            this.MergeAttributes(rootWidget, ValueSome componentWidget)

        let rootWidget: Widget =
            { Key = rootWidget.Key
#if DEBUG
              DebugName = rootWidget.DebugName
#endif
              ScalarAttributes = scalars
              WidgetAttributes = widgets
              WidgetCollectionAttributes = widgetColls }

        // Attach the widget to the existing view
        let widgetDef = WidgetDefinitionStore.get rootWidget.Key
        let node = widgetDef.AttachView(rootWidget, treeContext, ValueNone, view)

        _view <- view
        _contextSubscription <- _context.RenderNeeded.Subscribe(this.Render)

        node

    member private this.RenderInternal() =
        let prevRootWidget = _widget
        let prevContext = _context
        let struct (context, currRootWidget) = _body.Invoke(_context)
        _widget <- currRootWidget

        if prevContext <> context then
            _contextSubscription.Dispose()
            _contextSubscription <- context.RenderNeeded.Subscribe(this.Render)
            _context <- context

        let viewNode = treeContext.GetViewNode _view

        Reconciler.update treeContext.CanReuseView (ValueSome prevRootWidget) currRootWidget viewNode

    member this.Dispose() =
        if _contextSubscription <> null then
            _contextSubscription.Dispose()

        if _context <> null then
            _context.Dispose()

        _body <- null
        _widget <- Unchecked.defaultof<_>
        _view <- null
        _contextSubscription <- null
        _context <- null

    interface IDisposable with
        member this.Dispose() = this.Dispose()

    member this.Render(_) =
        treeContext.SyncAction(this.RenderInternal)

module Component =
    let Data =
        Attributes.defineSimpleScalar<ComponentData> "Component_Data" ScalarAttributeComparers.noCompare (fun _ _ _ -> ())

    let WidgetKey =
        let key = WidgetDefinitionStore.getNextKey()

        let definition =
            { Key = key
              Name = "Component"
              TargetType = typeof<Component>
              CreateView =
                fun (widget, treeContext, _) ->
                    match widget.ScalarAttributes with
                    | ValueNone -> failwith "Component widget must have a body"
                    | ValueSome attrs ->
                        let data =
                            let scalarAttrsOpt =
                                attrs |> Array.tryFind(fun scalarAttr -> scalarAttr.Key = Data.Key)

                            match scalarAttrsOpt with
                            | Some attr -> attr.Value :?> ComponentData
                            | None -> failwith "Component widget must have a body"

                        let ctx = new ComponentContext()
                        let comp = new Component(treeContext, data.Body, ctx)
                        let struct (node, view) = comp.CreateView(ValueSome widget)

                        treeContext.SetComponent comp view

                        struct (node, view)
              AttachView =
                fun (widget, treeContext, _, view) ->
                    match widget.ScalarAttributes with
                    | ValueNone -> failwith "Component widget must have a body"
                    | ValueSome attrs ->
                        let data =
                            let scalarAttrsOpt =
                                attrs |> Array.tryFind(fun scalarAttr -> scalarAttr.Key = Data.Key)

                            match scalarAttrsOpt with
                            | Some attr -> attr.Value :?> ComponentData
                            | None -> failwith "Component widget must have a body"

                        let ctx = new ComponentContext()
                        let comp = new Component(treeContext, data.Body, ctx)
                        let node = comp.AttachView(widget, view)

                        treeContext.SetComponent comp view

                        node }

        WidgetDefinitionStore.set key definition
        key

/// Delegate used by the ComponentBuilder to compose a component body
/// It will be aggressively inlined by the compiler leaving no overhead, only a pure function that returns a WidgetBuilder
type ComponentBodyBuilder<'marker> = delegate of bindings: int<binding> * context: ComponentContext -> struct (int<binding> * WidgetBuilder<unit, 'marker>)

type ComponentBuilder<'parentMsg when 'parentMsg : equality>() =
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

        let data = { Body = compiledBody }

        WidgetBuilder<'parentMsg, 'marker>(Component.WidgetKey, Component.Data.WithValue(data))
