namespace BasicNavigation

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Themes.Fluent
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

/// The most basic navigation with Fabulous is done by swapping widgets.
///
/// In this sample, we have three pages, and we swap between them by changing the "current step" (represented by a discriminated union).
/// All three pages' models are loaded at the same time, but only the current page is rendered.
///
/// NOTE: This approach is not using any official navigation system.
/// Hence, there is no back button, no navigation history, no animations, etc. by default.
/// Fabulous will only give the illusion of navigation by swapping the pages.
module App =
    [<RequireQualifiedAccess>]
    type Step =
        | PageA
        | PageB
        | PageC

    type Model =
        { CurrentStep: Step
          PageAModel: PageA.Model
          PageBModel: PageB.Model
          PageCModel: PageC.Model }

    type Msg =
        | PageAMsg of PageA.Msg
        | PageBMsg of PageB.Msg
        | PageCMsg of PageC.Msg
        | GoToPageA
        | GoToPageB
        | GoToPageC

    let init () =
        { CurrentStep = Step.PageA
          PageAModel = PageA.init()
          PageBModel = PageB.init()
          PageCModel = PageC.init() }

    let update msg model =
        match msg with
        | PageAMsg msg ->
            { model with
                PageAModel = PageA.update msg model.PageAModel }
        | PageBMsg msg ->
            { model with
                PageBModel = PageB.update msg model.PageBModel }
        | PageCMsg msg ->
            { model with
                PageCModel = PageC.update msg model.PageCModel }
        | GoToPageA -> { model with CurrentStep = Step.PageA }
        | GoToPageB -> { model with CurrentStep = Step.PageB }
        | GoToPageC -> { model with CurrentStep = Step.PageC }

    let program =
        Program.stateful init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let content () =
        Component("BasicNavigation") {
            let! model = Context.Mvu program

            Dock(false) {
                let content =
                    match model.CurrentStep with
                    | Step.PageA -> View.map PageAMsg (PageA.view model.PageAModel)
                    | Step.PageB -> View.map PageBMsg (PageB.view model.PageBModel)
                    | Step.PageC -> View.map PageCMsg (PageC.view model.PageCModel)

                content |> _.dock(Dock.Top)

                HStack(16.) {
                    Button("Page A", GoToPageA)

                    Button("Page B", GoToPageB)

                    Button("Page C", GoToPageC)
                }
                |> _.centerHorizontal()
                |> _.dock(Dock.Bottom)
            }
        }

    let view () =
#if MOBILE
        SingleViewApplication(content())
#else
        DesktopApplication() { Window(content()) }
#endif
    let create () =
        FabulousAppBuilder.Configure(FluentTheme, view)
