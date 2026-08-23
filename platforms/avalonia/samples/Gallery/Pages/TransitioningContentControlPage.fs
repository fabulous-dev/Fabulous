namespace Gallery

open System
open System.Diagnostics
open Avalonia.Animation
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous
open Avalonia.Animation.Easings


open type Fabulous.Avalonia.View

module TransitioningContentControlPage =
    type Model =
        { Images: string list
          SelectedImage: string
          PageTransition: IPageTransition
          IsReverse: bool
          Transitions: string list
          Duration: float
          ClipToBounds: bool }

    type Msg =
        | NextImage
        | PrevImage
        | TransitionChanged of SelectionChangedEventArgs
        | DurationChanged of float option
        | ClipToBoundsChanged of bool
        | ReverseChanged of bool

    let init () =
        { Images = [ "fabulous-icon.png"; "fsharp-icon.png"; "fabulous-icon.png" ]
          SelectedImage = "fabulous-icon.png"
          PageTransition = PageSlide(TimeSpan.FromSeconds(250.), PageSlide.SlideAxis.Horizontal)
          Transitions = [ "Slide"; "CrossFade"; "3D Rotation"; "Composite" ]
          Duration = 250.
          IsReverse = false
          ClipToBounds = false },
        Cmd.none

    let update msg model =
        match msg with
        | NextImage ->
            let index = model.Images |> List.findIndex(fun x -> x = model.SelectedImage)
            let index = (index + 1) % model.Images.Length

            { model with
                SelectedImage = model.Images.[index] },
            Cmd.none

        | PrevImage ->
            let index = model.Images |> List.findIndex(fun x -> x = model.SelectedImage)
            let index = (index - 1) % model.Images.Length
            let index = if index < 0 then model.Images.Length - 1 else index

            { model with
                SelectedImage = model.Images.[index] },
            Cmd.none

        | DurationChanged duration ->
            let duration = duration |> Option.defaultValue 500
            { model with Duration = duration }, Cmd.none

        | ClipToBoundsChanged clipToBounds ->
            { model with
                ClipToBounds = clipToBounds },
            Cmd.none

        | TransitionChanged selection ->
            let control = selection.Source :?> ComboBox
            let selectedItem = control.SelectedIndex
            let selection = control.Items.[selectedItem] :?> string

            let transition =
                match selection with
                | "Slide" -> PageSlide(TimeSpan.FromMilliseconds(model.Duration), PageSlide.SlideAxis.Horizontal) :> IPageTransition
                | "CrossFade" -> CrossFade(TimeSpan.FromSeconds(model.Duration))
                | "3D Rotation" -> Rotate3DTransition(TimeSpan.FromSeconds(model.Duration), PageSlide.SlideAxis.Horizontal)
                | "Composite" ->
                    let crossFade = CrossFade(TimeSpan.FromSeconds(model.Duration))
                    crossFade.FadeInEasing <- BounceEaseIn()
                    crossFade.FadeOutEasing <- BounceEaseOut()

                    let compositePageTransition = CompositePageTransition()
                    compositePageTransition.PageTransitions.Add(Rotate3DTransition(TimeSpan.FromSeconds(model.Duration), PageSlide.SlideAxis.Horizontal))
                    compositePageTransition.PageTransitions.Add(crossFade)
                    compositePageTransition

                | _ -> PageSlide(TimeSpan.FromSeconds(model.Duration), PageSlide.SlideAxis.Horizontal)

            { model with
                PageTransition = transition },
            Cmd.none

        | ReverseChanged isReverse -> { model with IsReverse = isReverse }, Cmd.none

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
        Component("TransitioningContentControlPage") {
            let! model = Context.Mvu program

            Dock(true) {
                TextBlock("The TransitioningContentControl control allows you to show a page transition whenever the Content changes.")
                    .classes([ "h2" ])
                    .dock(Dock.Top)

                ExperimentalAcrylicBorder(
                    (HStack(5.) {
                        HeaderedContentControl(
                            "Select a transition",
                            ComboBox(model.Transitions)
                                .selectedIndex(0)
                                .onSelectionChanged(TransitionChanged)
                                .verticalAlignment(VerticalAlignment.Center)
                        )

                        HeaderedContentControl(
                            "Duration",
                            NumericUpDown(100., 1000., Some model.Duration, DurationChanged)
                                .increment(250.)
                                .verticalAlignment(VerticalAlignment.Center)
                        )

                        HeaderedContentControl(
                            "Clip to Bounds",
                            ToggleSwitch(model.ClipToBounds, ClipToBoundsChanged)
                                .verticalAlignment(VerticalAlignment.Center)
                        )
                    })
                        .margin(5.)
                        .isSharedSizeScope(true)
                        .centerHorizontal()
                )
                    .material(
                        ExperimentalAcrylicMaterial()
                            .backgroundSource(AcrylicBackgroundSource.Digger)
                            .tintColor(Colors.Blue)
                    )
                    .dock(Dock.Bottom)
                    .margin(10.)
                    .cornerRadius(5.)

                Button("<", PrevImage).dock(Dock.Left)

                Button(">", NextImage).dock(Dock.Right)

                CheckBox("Reverse", model.IsReverse, ReverseChanged)
                    .dock(Dock.Bottom)
                    .margin(5.)

                Border(
                    TransitioningContentControl(Image($"avares://Gallery/Assets/Icons/{model.SelectedImage}"))
                        .pageTransition(model.PageTransition)
                        .isTransitionReversed(model.IsReverse)
                        .size(200., 200.)
                )
                    .margin(5.)
                    .clipToBounds(model.ClipToBounds)
            }
        }
