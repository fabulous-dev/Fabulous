// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace ShapesDemo

open System
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module App =
    type Samples =
        | RectangleDemoPage
        | EllipseDemoPage
        | LineDemoPage
        | PolygonDemoPage
        | PolylineDemoPage
        | BrushesDemoPage
        | ClipDemoPage
        | PathDemoPage
        | PathGeometryDemoPage
        | PathAspectDemoPage
        | PathRenderTransformDemoPage
        | PathRenderTransformExamplesDemoPage
        | AnalogClockDemoPage
        | BabyElephantDemoPage
        | CatDemoPage
        | ClipArtManDemoPage
        | FlowerDemoPage
        | HelloDemoPage
        | MonkeyFaceDemoPage
        | SpiralDemoPage
        | InvertedXamagonDemoPage

    type Msg =
        | NavigateTo of Samples
        | NavigatedBack
        | SampleMsg of obj

    type SampleModel =
        { Init: unit -> obj * Cmd<Msg>
          Update: obj -> obj -> obj * Cmd<Msg>
          View: obj -> Dispatch<Msg> -> DynamicViewElement
          Model: obj }

    let initSample sample =
        let viewOnly view =
            { Init = (fun () -> null, Cmd.none); Update = (fun _ _ -> null, Cmd.none); View = (fun _ _ -> view ()); Model = null }, Cmd.none

        let simple init update view =
            { Init = (fun () -> let m = init () in box m, Cmd.none); Update = (fun msg model -> box (update (unbox msg) (unbox model)), Cmd.none); View = (fun model dispatch -> view (unbox model) (box >> SampleMsg >> dispatch)); Model = box (init ()) }, Cmd.none

        let program init update view =
            let sModel, sCmd = init ()
            { Init = (fun () -> let m, c = init () in box m, Cmd.map (box >> SampleMsg) c); Update = (fun msg model -> let m, c = update (unbox msg) (unbox model) in box m, Cmd.map (box >> SampleMsg) c); View = (fun model dispatch -> view (unbox model) (box >> SampleMsg >> dispatch)); Model = box sModel }, (Cmd.map (box >> SampleMsg) sCmd)

        match sample with
        | RectangleDemoPage -> viewOnly RectangleDemoPage.view
        | EllipseDemoPage -> viewOnly EllipseDemoPage.view
        | LineDemoPage -> viewOnly LineDemoPage.view
        | PolygonDemoPage -> viewOnly PolygonDemoPage.view
        | PolylineDemoPage -> viewOnly PolylineDemoPage.view
        | BrushesDemoPage -> viewOnly BrushesDemoPage.view
        | ClipDemoPage -> viewOnly ClipDemoPage.view
        | PathDemoPage -> viewOnly PathDemoPage.view
        | PathGeometryDemoPage -> viewOnly PathGeometryDemoPage.view
        | PathAspectDemoPage -> viewOnly PathAspectDemoPage.view
        | PathRenderTransformDemoPage -> simple PathRenderTransformDemoPage.init PathRenderTransformDemoPage.update PathRenderTransformDemoPage.view
        | PathRenderTransformExamplesDemoPage -> viewOnly PathRenderTransformExamplesDemoPage.view
        | AnalogClockDemoPage -> program AnalogClockDemoPage.init AnalogClockDemoPage.update AnalogClockDemoPage.view
        | BabyElephantDemoPage -> viewOnly BabyElephantDemoPage.view
        | CatDemoPage -> viewOnly CatDemoPage.view
        | ClipArtManDemoPage -> viewOnly ClipArtManDemoPage.view
        | FlowerDemoPage -> viewOnly FlowerDemoPage.view
        | HelloDemoPage -> viewOnly HelloDemoPage.view
        | MonkeyFaceDemoPage -> viewOnly MonkeyFaceDemoPage.view
        | SpiralDemoPage -> program SpiralDemoPage.init SpiralDemoPage.update SpiralDemoPage.view
        | InvertedXamagonDemoPage -> viewOnly InvertedXamagonDemoPage.view

    type Model =
        { Sample: SampleModel option }

    let init () =
        { Sample = None }, Cmd.none

    let update msg model =
        match msg with
        | NavigateTo sample ->
            let sampleDef, sCmd = initSample sample
            { model with Sample = Some sampleDef }, sCmd
        | NavigatedBack -> { model with Sample = None }, Cmd.none
        | SampleMsg sampleMsg ->
            match model.Sample with
            | None -> model, Cmd.none
            | Some sample ->
                let sModel, sCmd = sample.Update sampleMsg sample.Model
                { model with Sample = Some { sample with Model = sModel } }, sCmd

    let mainPageView dispatch =
        View.ContentPage(
            title = "Shapes demo",
            content = View.TableView(
                intent = TableIntent.Menu,
                root = View.TableRoot([
                    View.TableSection(
                        title = "Basic Shapes",
                        items = [
                            View.TextCell("Rectangle demos", command = fun () -> dispatch (NavigateTo RectangleDemoPage))
                            View.TextCell("Ellipse demos", command = fun () -> dispatch (NavigateTo EllipseDemoPage))
                            View.TextCell("Line demos", command = fun () -> dispatch (NavigateTo LineDemoPage))
                            View.TextCell("Polygon demos", command = fun () -> dispatch (NavigateTo PolygonDemoPage))
                            View.TextCell("Polyline demos", command = fun () -> dispatch (NavigateTo PolylineDemoPage))
                            View.TextCell("Brushes demos", command = fun () -> dispatch (NavigateTo BrushesDemoPage))
                            View.TextCell("Clipping demos", command = fun () -> dispatch (NavigateTo ClipDemoPage))
                            View.TextCell("Path demos", command = fun () -> dispatch (NavigateTo PathDemoPage))
                            View.TextCell("Path geometry demos", command = fun () -> dispatch (NavigateTo PathGeometryDemoPage))
                            View.TextCell("Path aspect demos", command = fun () -> dispatch (NavigateTo PathAspectDemoPage))
                            View.TextCell("Path render transform demos", command = fun () -> dispatch (NavigateTo PathRenderTransformDemoPage))
                            View.TextCell("Path render transform examples", command = fun () -> dispatch (NavigateTo PathRenderTransformExamplesDemoPage))
                        ]
                    )
                    View.TableSection(
                        title = "More Advanced Shapes",
                        items = [
                            View.TextCell("Analog clock demo", command = fun () -> dispatch (NavigateTo AnalogClockDemoPage))
                            View.TextCell("Baby elephant demo", command = fun () -> dispatch (NavigateTo BabyElephantDemoPage))
                            View.TextCell("Cat demo", command = fun () -> dispatch (NavigateTo CatDemoPage))
                            View.TextCell("Clip art man demo", command = fun () -> dispatch (NavigateTo ClipArtManDemoPage))
                            View.TextCell("Flower demo", command = fun () -> dispatch (NavigateTo FlowerDemoPage))
                            View.TextCell("Hello demo", command = fun () -> dispatch (NavigateTo HelloDemoPage))
                            View.TextCell("Monkey face demo", command = fun () -> dispatch (NavigateTo MonkeyFaceDemoPage))
                            View.TextCell("Moving spiral demo", command = fun () -> dispatch (NavigateTo SpiralDemoPage))
                            View.TextCell("Inverted Xamagon demo", command = fun () -> dispatch (NavigateTo InvertedXamagonDemoPage))
                        ]
                    )
                ])
            )
        )

    let view model dispatch =
        View.Application(
            View.NavigationPage(
                popped = (fun _ -> dispatch NavigatedBack),
                pages = [
                    yield mainPageView dispatch

                    match model.Sample with
                    | None -> ()
                    | Some sample -> yield sample.View sample.Model dispatch
                ]
            )
        )

    // Note, this declaration is needed if you enable LiveUpdate
    let program = XamarinFormsProgram.mkProgram init update view

type App () as app =
    inherit Application ()

    let runner =
        App.program
#if DEBUG
        |> Program.withConsoleTrace
#endif
        |> XamarinFormsProgram.run app
