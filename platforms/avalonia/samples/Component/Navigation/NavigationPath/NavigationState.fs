namespace NavigationSample

open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

/// MVU is a very explicit but also very verbose pattern.
/// Everything needs to be explicitly written out.
///
/// This NavigationState file acts as the glue between the different pages.
/// Relying on the NavigationPath DU, we call the init, update and view functions of the different pages.
/// Like this, everything is centralized and the root of the app doesn't have to know about the other pages.
module NavigationState =
    type Model =
        | PageAModel of PageA.Model
        | PageBModel of PageB.Model
        | PageCModel of PageC.Model

    type Msg =
        | PageAMsg of PageA.Msg
        | PageBMsg of PageB.Msg
        | PageCMsg of PageC.Msg

    let init path =
        match path with
        | NavigationPath.PageA -> PageAModel(PageA.init())
        | NavigationPath.PageB initialCount -> PageBModel(PageB.init initialCount)
        | NavigationPath.PageC(someArgs, stepCount) -> PageCModel(PageC.init someArgs stepCount)

    let update nav (msg: Msg) (model: Model) =
        match msg, model with
        | PageAMsg msg, PageAModel model ->
            let m, c = PageA.update nav msg model
            PageAModel m, Cmd.map PageAMsg c

        | PageBMsg msg, PageBModel model ->
            let m, c = PageB.update nav msg model
            PageBModel m, Cmd.map PageBMsg c

        | PageCMsg msg, PageCModel model ->
            let m, c = PageC.update nav msg model
            PageCModel m, Cmd.map PageCMsg c

        | _ -> model, Cmd.none

    let view model =
        match model with
        | PageAModel model -> AnyView(View.map PageAMsg (PageA.view model))
        | PageBModel model -> AnyView(View.map PageBMsg (PageB.view model))
        | PageCModel model -> AnyView(View.map PageCMsg (PageC.view model))

    let updateBackButton nav model =
        match model with
        | PageAModel model -> update nav (PageAMsg PageA.BackButtonPressed) (PageAModel model)
        | _ -> model, Cmd.none

/// The NavigationStack represents the history of the navigation.
/// This is a simple stack of pages that the app will use to remember and display the pages needed.
type NavigationStack =
    { BackStack: NavigationState.Model list
      CurrentPage: NavigationState.Model
      ForwardStack: NavigationState.Model list }

    static member Init(model: NavigationState.Model) =
        { BackStack = []
          CurrentPage = model
          ForwardStack = [] }

    member this.Push(model: NavigationState.Model) =
        { BackStack = this.CurrentPage :: this.BackStack
          CurrentPage = model
          ForwardStack = [] }

    member this.Pop() =
        match this.BackStack with
        | [] -> this
        | head :: tail ->
            { BackStack = tail
              CurrentPage = head
              ForwardStack = [] }

    member this.UpdateCurrentPage(newPage: NavigationState.Model) = { this with CurrentPage = newPage }
