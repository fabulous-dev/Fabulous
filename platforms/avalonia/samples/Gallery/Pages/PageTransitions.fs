namespace Gallery

open System
open System.Diagnostics
open Avalonia.Animation
open Avalonia.Animation.Easings
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module PageTransitionsPage =
    type DataType =
        { Name: string
          Desc: string
          Image: string }

    type Model =
        { SampleData: DataType seq
          Transition: IPageTransition
          Transitions: string list }

    type Msg =
        | Next
        | Previous
        | TransitionChanged of SelectionChangedEventArgs

    let init () =
        { Transition = PageSlide(TimeSpan.FromSeconds(1.), PageSlide.SlideAxis.Horizontal)
          SampleData =
            [ { Name = "Fabulous"
                Desc = "Fabulous is a library to write cross-platform mobile and desktop applications with F# and Avalonia."
                Image = "fabulous-icon" }
              { Name = "F#"
                Desc = "F# is a cross-platform, open source, functional-first programming language."
                Image = "fsharp-icon" }
              { Name = "GitHib"
                Desc = "GitHub is a web-based hosting service for version control using Git."
                Image = "github-icon" } ]
          Transitions = [ "Slide"; "CrossFade"; "3D Rotation"; "Composite" ] },
        Cmd.none

    let carouselController = CarouselController()

    let update msg model =
        match msg with
        | Next ->
            carouselController.DoNext()
            model, Cmd.none
        | Previous ->
            carouselController.DoPrevious()
            model, Cmd.none

        | TransitionChanged selection ->
            let control = selection.Source :?> ComboBox
            let selectedItem = control.SelectedIndex
            let selection = control.Items.[selectedItem] :?> string

            let transition =
                match selection with
                | "Slide" -> PageSlide(TimeSpan.FromSeconds(1.), PageSlide.SlideAxis.Horizontal) :> IPageTransition
                | "CrossFade" -> CrossFade(TimeSpan.FromSeconds(1.))
                | "3D Rotation" -> Rotate3DTransition(TimeSpan.FromSeconds(1.), PageSlide.SlideAxis.Horizontal)
                | "Composite" ->
                    let crossFade = CrossFade(TimeSpan.FromSeconds(1.))
                    crossFade.FadeInEasing <- BounceEaseIn()
                    crossFade.FadeOutEasing <- BounceEaseOut()

                    let compositePageTransition = CompositePageTransition()
                    compositePageTransition.PageTransitions.Add(Rotate3DTransition(TimeSpan.FromSeconds(2.), PageSlide.SlideAxis.Horizontal))
                    compositePageTransition.PageTransitions.Add(crossFade)
                    compositePageTransition

                | _ -> PageSlide(TimeSpan.FromSeconds(1.), PageSlide.SlideAxis.Horizontal)

            { model with Transition = transition }, Cmd.none

    let program =
        Program.statefulWithCmd init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component("PageTransitionsPage") {
            let! model = Context.Mvu program

            VStack(16.) {
                (Grid(coldefs = [ Auto; Star; Auto ], rowdefs = [ Auto ]) {
                    Button(
                        Previous,
                        Path("M20,11V13H8L13.5,18.5L12.08,19.92L4.16,12L12.08,4.08L13.5,5.5L8,11H20Z")
                            .fill(SolidColorBrush(Colors.Black))
                    )
                        .gridColumn(0)
                        .verticalAlignment(VerticalAlignment.Center)
                        .padding(10., 20.)
                        .margin(4.)

                    Carousel(
                        model.SampleData,
                        (fun x ->
                            VStack() {
                                TextBlock(x.Name)
                                    .fontSize(20.)
                                    .textWrapping(TextWrapping.Wrap)
                                    .textAlignment(TextAlignment.Center)
                                    .horizontalAlignment(HorizontalAlignment.Center)

                                TextBlock(x.Desc)
                                    .fontSize(14.)
                                    .textWrapping(TextWrapping.Wrap)
                                    .textAlignment(TextAlignment.Center)
                                    .horizontalAlignment(HorizontalAlignment.Center)

                                Image($"avares://Gallery/Assets/Icons/{x.Image}.png")

                            })
                    )
                        .pageTransition(model.Transition)
                        .margin(16)
                        .gridColumn(1)
                        .controller(carouselController)
                        .centerHorizontal()
                        .centerVertical()

                    Button(
                        Next,
                        Path("M4,11V13H16L10.5,18.5L11.92,19.92L19.84,12L11.92,4.08L10.5,5.5L16,11H4Z")
                            .fill(SolidColorBrush(Colors.Black))
                    )
                        .gridColumn(2)
                        .verticalAlignment(VerticalAlignment.Center)
                        .padding(10., 20.)
                        .margin(4.)

                })
                    .maxWidth(500.)
                    .horizontalAlignment(HorizontalAlignment.Stretch)

                (HStack(16.) {
                    TextBlock("Transition")
                        .verticalAlignment(VerticalAlignment.Center)

                    ComboBox(model.Transitions)
                        .selectedIndex(0)
                        .onSelectionChanged(TransitionChanged)
                        .verticalAlignment(VerticalAlignment.Center)
                })
                    .margin(4.)
                    .centerHorizontal()
            }
        }
