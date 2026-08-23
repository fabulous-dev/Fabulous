namespace Fabulous.Maui

open System

[<Struct>]
type Route<'route> =
    private
        { IdValue: string
          ValueValue: 'route }

    member this.Id = this.IdValue
    member this.Value = this.ValueValue

[<RequireQualifiedAccess>]
module Route =
    let create id value =
        if String.IsNullOrWhiteSpace(id) then
            invalidArg (nameof id) "A route ID cannot be empty."

        { IdValue = id; ValueValue = value }

[<Sealed>]
type NavigationStack<'route> internal (routes: Route<'route> list) =
    member _.Routes = routes
    member _.Current = List.last routes
    member _.Count = List.length routes

[<RequireQualifiedAccess>]
module NavigationStack =
    let private validateRoutes argumentName (routes: Route<'route> list) =
        if List.isEmpty routes then
            invalidArg argumentName "A navigation stack requires at least one route."

        match routes |> Seq.countBy _.Id |> Seq.tryFind(fun (_, count) -> count > 1) with
        | Some(routeId, _) -> invalidArg argumentName $"The route ID '{routeId}' occurs more than once."
        | None -> ()

    let ofRoutes routes =
        validateRoutes (nameof routes) routes
        NavigationStack(routes)

    let create root = NavigationStack([ root ])

    let routes (stack: NavigationStack<'route>) = stack.Routes

    let current (stack: NavigationStack<'route>) = stack.Current

    let push route (stack: NavigationStack<'route>) =
        let routes = stack.Routes @ [ route ]
        validateRoutes (nameof route) routes
        NavigationStack(routes)

    let pop (stack: NavigationStack<'route>) =
        match List.rev stack.Routes with
        | _ :: (_ :: _ as remaining) -> NavigationStack(List.rev remaining)
        | _ -> stack

    let replaceTop route (stack: NavigationStack<'route>) =
        let routes =
            match List.rev stack.Routes with
            | _ :: remaining -> List.rev(route :: remaining)
            | [] -> [ route ]

        validateRoutes (nameof route) routes
        NavigationStack(routes)

    let replacePath routes (_: NavigationStack<'route>) = ofRoutes routes

    let tryUpdate routeId update (stack: NavigationStack<'route>) =
        if String.IsNullOrWhiteSpace(routeId) then
            invalidArg (nameof routeId) "A route ID cannot be empty."

        let mutable found = false

        let routes =
            stack.Routes
            |> List.map(fun route ->
                if route.Id = routeId then
                    found <- true
                    Route.create route.Id (update route.Value)
                else
                    route)

        if found then Some(NavigationStack(routes)) else None
