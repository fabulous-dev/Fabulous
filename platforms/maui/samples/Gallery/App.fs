namespace Gallery

open Fabulous.Maui.SmallScalars
open Microsoft.FSharp.Core
open Fabulous
open Fabulous.Maui
open Microsoft.Maui.Controls

open type Fabulous.Maui.View

module App =
    type Path =
        | Overview
        | Sample of sampleIndex: int * sampleModel: obj

    type Model = { Paths: Path list }

    type Msg =
        | SampleMsg of obj
        | GoToSample of int
        | GoBack

    let init () = { Paths = [ Overview ] }

    let update msg model =
        match msg with
        | SampleMsg sMsg ->
            match List.tryHead model.Paths with
            | Some(Sample(index, sampleModel)) ->
                let newSampleModel =
                    RegisteredSamples.samples[index].Program.update sMsg sampleModel

                { Paths = Sample(index, newSampleModel) :: List.tail model.Paths }
            | _ -> model

        | GoToSample index ->
            let sampleModel = RegisteredSamples.samples[index].Program.init()
            let paths = Sample(index, sampleModel) :: model.Paths
            { Paths = paths }

        | GoBack -> { Paths = List.tail model.Paths }

    let view model =
        Application(
            TabbedPage() {
                ContentPage(
                    match List.head model.Paths with
                    | Overview -> AnyView(Overview.view GoToSample)
                    | Sample(index, sampleModel) -> AnyView(SamplePage.view GoBack SampleMsg index sampleModel)
                )
                    .title("Samples")

                ContentPage(
                    VStack() {
                        Label("Fabulous.Maui Gallery")
                            .horizontalOptions(LayoutOptions.Center)
                            .verticalOptions(LayoutOptions.Center)
                    }
                )
                    .title("Info")
            }
        )

    let program = Program.stateful init update |> Program.withView view
