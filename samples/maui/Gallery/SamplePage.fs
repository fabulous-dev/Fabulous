namespace Gallery

open Fabulous
open Fabulous.Maui
open type Fabulous.Maui.View

module SamplePage =
    let view (pop: 'msg) mapMsg index model =
        let sample = RegisteredSamples.samples[index]

        ScrollView(
            (VStack(spacing = 20.) {
                Button("Go back", pop).alignStartHorizontal()

                Label(sample.Name).style(Styles.title).centerHorizontal()

                Label(sample.Description).style(Styles.subtitle).centerHorizontal()

                View.map mapMsg (sample.Program.view model)
            })
                .margin(20.)
        )
            .automationId("sample")
