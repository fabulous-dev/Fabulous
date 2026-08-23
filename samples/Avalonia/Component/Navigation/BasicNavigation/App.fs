namespace BasicNavigation

open Avalonia.Themes.Fluent
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View
open type Fabulous.Context

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

    let content () =
        Component("BasicNavigation") {
            let! currentStep = State(Step.PageA)

            (VStack() {
                Grid(coldefs = [ Star; Star; Star ], rowdefs = [ Auto; Star ]) {
                    Button("Page A", (fun _ -> currentStep.Set(Step.PageA)))
                        .gridColumn(0)

                    Button("Page B", (fun _ -> currentStep.Set(Step.PageB)))
                        .gridColumn(1)

                    Button("Page C", (fun _ -> currentStep.Set(Step.PageC)))
                        .gridColumn(2)

                    (match currentStep.Current with
                     | Step.PageA -> PageA.content()
                     | Step.PageB -> PageB.content()
                     | Step.PageC -> PageC.content())
                        .gridRow(1)
                        .gridColumnSpan(3)
                }
            })
                .center()
        }

    let view () =
#if MOBILE
        SingleViewApplication(content())
#else
        DesktopApplication() { Window(content()) }
#endif
    let create () =
        FabulousAppBuilder.Configure(FluentTheme, view)
