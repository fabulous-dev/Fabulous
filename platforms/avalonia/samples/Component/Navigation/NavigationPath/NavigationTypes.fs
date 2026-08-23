namespace NavigationSample

open Fabulous

/// This is the centerpiece of navigating through paths:
/// A single enum regrouping all the navigation routes with their arguments
[<RequireQualifiedAccess>]
type NavigationPath =
    | PageA
    | PageB of initialCount: int
    | PageC of someArgs: string * stepCount: int

/// The NavigationController is used to notify the intention to navigate to a new page (or go back).
/// We listen to it in a Cmd that will dispatch a message to the root of the application to trigger the actual navigation.
type NavigationController() =
    let navigated = Event<NavigationPath>()
    let backNavigated = Event<unit>()

    member this.Navigated = navigated.Publish
    member this.BackNavigated = backNavigated.Publish

    member this.NavigateTo(path: NavigationPath) = navigated.Trigger(path)

    member this.NavigateBack() = backNavigated.Trigger()

/// The Navigation module is a set of helper functions that will wrap the call to NavigationController into a Cmd.
/// We do that because navigation is a side-effect and we want to keep it in a Cmd.
module Navigation =
    let private navigateTo (nav: NavigationController) path : Cmd<'msg> = [ fun _ -> nav.NavigateTo(path) ]

    let navigateBack (nav: NavigationController) : Cmd<'msg> = [ fun _ -> nav.NavigateBack() ]

    let navigateToPageA nav = navigateTo nav NavigationPath.PageA

    let navigateToPageB nav initialCount =
        navigateTo nav (NavigationPath.PageB initialCount)

    let navigateToPageC nav someArgs stepCount =
        navigateTo nav (NavigationPath.PageC(someArgs, stepCount))
