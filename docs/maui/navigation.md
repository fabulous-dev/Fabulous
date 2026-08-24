# Route-based navigation

`NavigationStack<'route>` is an immutable, non-empty path for .NET MAUI applications. It keeps navigation in application state instead of an external mutable router, so the same API can be used from an MVU program or a component.

## Design

Each `Route<'route>` has two parts:

* `Id` is a stable, caller-supplied identity for one occurrence in the stack.
* `Value` is application-defined route data, usually a discriminated union containing the page arguments or page model.

Distinct IDs allow several instances of the same page type or route value to coexist. IDs must be non-empty and unique within one stack. The library does not generate IDs because persisted and restored navigation must remain deterministic.

Routes are ordered from root to current page. A stack always contains at least one route.

```fsharp
type Page =
    | Home
    | Details of productId: int

let stack =
    NavigationStack.create(Route.create "home" Home)
    |> NavigationStack.push(Route.create "details-42-a" (Details 42))
    |> NavigationStack.push(Route.create "details-42-b" (Details 42))
```

The operations are pure:

* `push` appends a route.
* `pop` removes the current route and is a no-op at the root.
* `replaceTop` replaces only the current route.
* `replacePath` atomically replaces the complete root-to-current path, which is the deep-link operation.
* `tryUpdate` updates route data by instance ID and returns `None` when the ID is absent.

`ofRoutes` and `replacePath` reject empty paths. Operations reject duplicate IDs with `ArgumentException`; treat that as a model construction error rather than a navigation outcome.

## Rendering in MVU

Store the stack and the next deterministic ID in the model. Render every route through the existing `NavigationPage` computation expression.

```fsharp
type Model =
    { Navigation: NavigationStack<Page>
      NextRouteId: int }

let viewPage route =
    match route with
    | Home -> AnyPage(HomePage.view())
    | Details productId -> AnyPage(DetailsPage.view productId)

let view model =
    Application(
        (NavigationPage() {
            for route in NavigationStack.routes model.Navigation do
                viewPage route.Value
        })
            .onBackNavigated(BackNavigated)
    )
```

Handle `BackNavigated` by storing `NavigationStack.pop model.Navigation`. For programmatic navigation, create a unique route ID and store the result of `push`, `replaceTop`, or `replacePath` in the next model.

The complete MVU example is in `samples/maui/Navigation/NavigationPath`.

## Rendering in a component

A component binds an MVU program with `Context.Mvu` and renders the same stack. No component-specific navigation object is required.

```fsharp
let content program =
    Component("Navigation") {
        let! model = Context.Mvu(program)

        NavigationPage() {
            for route in NavigationStack.routes model.Navigation do
                viewPage route.Value
        }
    }
```

The complete component example is in `samples/maui/Navigation/ComponentNavigation`.

## Lifecycle semantics

`NavigationStack` owns no controls, subscriptions, dispatchers, or events. A route value lives as long as the application model keeps it. Popping a route or replacing the path discards that value unless the application stores it elsewhere.

`NavigationPage` remains responsible for native page reconciliation. Pushed pages receive the normal mounted lifecycle, removed pages receive unmounted and are disposed, and surviving pages are updated according to normal Fabulous widget reconciliation. A route ID identifies application state; changing an ID alone does not force a native page remount.

Native back navigation does not mutate `NavigationStack`. Handle `onBackNavigated` or `onBackButtonPressed`, dispatch a message, and update the model. This preserves replayable MVU behavior and applies equally to components using `Context.Mvu`.

## Migrating existing navigation

Older samples commonly define `BackStack`, `CurrentPage`, and `ForwardStack`, or keep a mutable controller that raises push and pop events. Replace those records with `NavigationStack<'route>` and keep navigation intent as messages or commands.

Use `NavigationStack.routes` instead of reversing `BackStack` and then appending `CurrentPage`. Use `replacePath` for a deep link rather than issuing several timed pushes. Forward-history behavior is intentionally outside this API; model it separately if the application requires browser-style forward navigation.

The draft implementation from `Fabulous.MauiControls#23` is not the basis of this API. In particular, this design does not store boxed page models in a mutable stack or depend on stack events to trigger rendering.