# Components API architecture

- Introduction (What are today's limitations, what's a component, what's the goals: seamless integration, performance (low memory allocation, localized reevaluation), state management agnostic, environment support)
- Components
  - Component basic ideas (seamless integration into current API, holds its own state, internal loop with reevaluation on context change, communication from and to the parent, state management agnostic)
  - Component building blocks (CE builder, delegates, aggressive inlining, backing context, context invalidation)
  - Implementation details of ComponentContext, Component, and ComponentBuilder (context uses incremental indices, builder makes use of F# compiler capabilities to calculate while inlining)
- State management
  - State basic ideas (top -> down only, stored on the backing context, let! to access the context implicitly, invalidation on context change)
  - Implementation details of State<'T> and StateValue<'T> with Bind extension to ComponentBuilder (how to avoid capturing short lived StateValue)
  - Implementation details of Binding<'T> and BindingValue<'T> with Bind extension to ComponentBuilder (how to avoid capturing short lived BindingValue)
  - Implementation details of MvuComponent (compatibility with non-dispatch existing API)
- Environment
  - Environment basic ideas (Implicit context, localized overrides, can invalidate component on system changes, top -> down only)
  - Implementation details of EnvironmentKey, EnvironmentContext, Environment<'T>, EnvironmentValue<'T>


This document aims to describe in details the new Components API that we are introducing for Fabulous 2.

Please note this new API is still Work in Progress and might differ consequently before it becomes stable.

## Introduction

### Why introduce a new Components API?

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

```fs
type IComponent =
    interface end
    
type [<Struct>] TextWidget(value: string) =
    interface IComponent

let component: IComponent = TextWidget("Hello")
 // => let component = box(TextWidget(...)) :> IComponent
```

Another point we want to take a look into is the ability to use any kind of state management, not only MVU.

With all those constraints in place, we want something that can easily be composed into Fabulous 2 DSL ergonomics,
lets you choose your own state management, and almost allocation-free to be friendly with low end mobile devices.

This means we need to make heavy use of inlining and structs.
Computation expressions to the rescue.

### What are the goals of the new Components API?

With this new API, we hope to achieve several goals:
- Seamless integration into the existing View DSL
- Faster updates via localized diffing
- Support for different state managements, in addition to MVU

We also hope to finally bring the concept of environment to enable access to values between components, without having to pass them explicitly through each layer.

#### Seamless integration into View DSL

The primary UI building block in Fabulous is the `Widget` struct. It is a very simple description of what should be shown on the screen, and can be easily composed together to create a whole UI tree.
It is therefore cheap to recreate the whole widget tree on each update. Due to this ephemeral nature, a widget cannot hold any mutating state by itself.

This role is achieved by `Runner`. It takes care of the MVU loop and retains the current state of the app over each update.

Like explained above, components are meant to be similar to `Runner`, but are only in charge of one part of the UI contrary to `Runner`.

A typical Fabulous application will be composed of a lot of different components, so they need to be easily composable with the existing View DSL.

```fs
let costLists() =
    Component() {
        let! costs = (...)
        
        VStack() {
            Label("List of costs")
            ListView(costs) (fun item -> (...))
        }
    }

let costSummary() =
    Component() {
        let! summary = (...)

        HStack() {
            Label("Cost summary")
            Label(...)
        }
    }

let view() =
    VStack() {
        Label("My Counter app")
        costLists()
        costSummary()
    }
```

### Faster updates via localized diffing

Because Fabulous uses a single source of truth for the whole UI state, it needs to diff the whole widget tree on each update. This results in a lot of unnecessary processing when most typical user interactions have an impact locally on the UI, rather than globally.

Despite doing as much performance optimizations as we could, we are still wasting a lot of CPU cycles toward processing the whole UI tree, potentially just to update a deeply nested text.

This is where the new Components API comes in.

It brings local sources of truth (the component state) and allow for localized updates.

When used properly, the Components API can drastically improve performance of apps.

```fs
let counter() =
    Component() {
        // Updating this count will only reevaluate
        // the current component and its children.
        // Parent widgets won't be reevaluated
        let! count = State(0)

        Button(
            $"Count is {count.Current}",
            fun() -> count.Set(count.Current + 1)
        )
    }

let view() =
    Application() {
        VStack() {
            VStack() {
                (...) {
                    // Somewhere very deep
                    counter()
                }
            }
        }
    }
```

### Support for different state managements

From the start, Fabulous was modeled after Elm. It was meant to be used exclusively with MVU because it was fitting very nicely into the whole architectural model wanted with Fabulous.

As nice as MVU is, over time its flaws became really apparent, especially in bigger apps where manually composing the init, updates and view functions can be really annoying and very verbose.

The new Components API opens up the possibilities in terms of state management.

Components have their own internal context which when updated triggers a reevaluation of the component.

This can be levied by most existing state management approach, such as MVU, MVVM, MVC, and so on.

```fs
let stateCounter () =
    Component() {
        let! count = State(0)

        VStack() {
            Label($"Count is {count.Current}")
            Button("Increment", fun () -> count.Set(count.Current + 1))
            Button("Decrement", fun () -> count.Set(count.Current - 1))
        }
    }

let mvvmCounter () =
    Component() {
        let! vm = CounterViewModel()

        VStack() {
            Label($"Count is {vm.Count}")
            Button("Increment", fun () -> vm.Increment())
            Button("Decrement", fun () -> vm.Decrement())
        }
    }

let mvuCounter() =
    MvuComponent(init, update) {
        let! model = Mvu.State

        VStack() {
            Label($"Count is {model.Count}")
            Button("Increment", Msg.Increment)
            Button("Decrement", Msg.Decrement)
        }
    }
```

### Environment context

_Declaring an Environment value_

```fs
type Service() =
    member this.DoSomething() = ()

let ServiceKey = EnvironmentKey("Service", Service())

type EnvironmentContext with
    member this.Service
        with get () = this[ServiceKey]
        and set value = this[ServiceKey] <- value
```

_Reading an Environment value_

```fs
let view() =
    Component() {
        let! service = Environment(ServiceKey)
        Button("Do Something", fun () -> service.DoSomething())
    }
```

_Overriding an Environment value_

```fs
let view() =
    (Component() {
        (...)
    })
        .environment(ServiceKey, CustomService())
```

_Updating an Environment value with an Observable_
```fs
let ThemeKey = EnvironmentKey(AppInfo.RequestedTheme)

type EnvironmentContext with
    member this.Theme
        with get () = this[ThemeKey.GetType()] :?> AppTheme
        and set value = this[ThemeKey.GetType] <- value

module Theme =
    let register (env: EnvironmentContext) =
        let fromSource =
            Application.Current.RequestedThemeChanged.Subscribe(fun args ->
                env.Theme <- args.Value
            )

        let toSource =
            env.ValueChanged.Subscribe(fun args ->
                if args.Key = ThemeKey.GetType() then
                    Application.Current.RequestedTheme <- args.Value
            )

        { new System.IDisposable() with
            member this.Dispose() =
                fromSource.Dispose()
                toSource.Dispose() }

let view() =
    (Component() {
        let! theme = Environment(EnvironmentKeys.Theme)

        Label("Theme is %A{theme.Current}")
    })
        .onInit(Theme.register)
```

## Components API

### Core ideas

- Holds its own state
- Internal loop with reevaluation on context change
- Communication from and to the parent
- How state management agnostic is achieved

### Building blocks

- CE builder
- Delegates
- Aggressive inlining
- Backing context
- Context invalidation

### Implementation

- ComponentContext
- Component
- ComponentBuilder
- Context uses incremental indices
- Builder makes use of F# compiler capabilities to calculate while inlining

## State management

### Core ideas

- Top -> down only
- Stored on the backing context
- `let!` to access the context implicitly
  - Request struct objects in user code
  - Response struct returned after bind. contains current value and potential updater
  - to avoid capturing structs in closures, inline all members
- Invalidation on context change

### Local state with State<'T>

- Usage
- State<'T>
- StateValue<'T>
- Bind extension to ComponentBuilder
- How to avoid capturing short lived StateValue

### Shared state between parent and child with Binding<'T>

- Usage
- Binding<'T>
- BindingValue<'T>
- Bind extension to ComponentBuilder
- How to avoid capturing short lived BindingValue

### Supporting MVU with the specialized MvuComponent

- Usage
- Compatibility with non-dispatch existing API

## Environment

### Core ideas

- Implicit context
- Localized overrides
- Can invalidate component on system changes
- Top -> down only

### Ambient state with Environment<'T>

- Usage
- EnvironmentKey
- EnvironmentContext
- Environment<'T>
- EnvironmentValue<'T>
- Bind extension to ComponentBuilder

### Implementation