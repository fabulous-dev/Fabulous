namespace AllControls.Samples.Extensions

open AllControls.Helpers

open Fabulous.XamarinForms

module VideoManager =
    let view() = 
        View.ScrollingContentPage(
            title = "VideoManager Sample",
            content = View.StackLayout([
                View.VideoView(
                    source = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4",
                    showControls = true,
                    height = 500.,
                    width = 200.
                )
            ])
        )

