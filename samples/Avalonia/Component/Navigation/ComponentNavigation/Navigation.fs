namespace ComponentNavigation

open Fabulous

/// This is the centerpiece of navigating through paths:
/// A single enum regrouping all the navigation routes with their arguments
[<RequireQualifiedAccess>]
type NavigationRoute =
    | PageA
    | PageB of initialCount: int
    | PageC of someArgs: string * stepCount: int

/// The NavigationController is used to notify the intention to navigate to a new page (or go back).
/// We listen to it in a Cmd that will dispatch a message to the root of the application to trigger the actual navigation.
type NavigationController() =
    let navigationRequested = Event<NavigationRoute>()
    let backNavigationRequested = Event<unit>()

    member this.NavigationRequested = navigationRequested.Publish
    member this.BackNavigationRequested = backNavigationRequested.Publish

    member this.NavigateTo(path: NavigationRoute) = navigationRequested.Trigger(path)

    member this.NavigateBack() = backNavigationRequested.Trigger()

/// The Navigation module is a set of helper functions that will wrap the call to NavigationController into a Cmd.
/// We do that because navigation is a side-effect and we want to keep it in a Cmd.
module Navigation =
    let private navigateTo (nav: NavigationController) path : Cmd<'msg> = [ fun _ -> nav.NavigateTo(path) ]

    let navigateBack (nav: NavigationController) : Cmd<'msg> = [ fun _ -> nav.NavigateBack() ]

    let navigateToPageA nav = navigateTo nav NavigationRoute.PageA

    let navigateToPageB nav initialCount =
        navigateTo nav (NavigationRoute.PageB initialCount)

    let navigateToPageC nav someArgs stepCount =
        navigateTo nav (NavigationRoute.PageC(someArgs, stepCount))

/// The NavigationStack represents the history of the navigation.
/// This is a simple stack of pages that the app will use to remember and display the pages needed.
type NavigationStack =
    { BackStack: NavigationRoute list
      CurrentPage: NavigationRoute
      ForwardStack: NavigationRoute list }

    static member Init(path: NavigationRoute) =
        { BackStack = []
          CurrentPage = path
          ForwardStack = [] }

    member this.Push(path: NavigationRoute) =
        { BackStack = this.CurrentPage :: this.BackStack
          CurrentPage = path
          ForwardStack = [] }

    member this.Pop() =
        match this.BackStack with
        | [] -> this
        | head :: tail ->
            { BackStack = tail
              CurrentPage = head
              ForwardStack = [] }

    member this.UpdateCurrentPage(path: NavigationRoute) = { this with CurrentPage = path }
