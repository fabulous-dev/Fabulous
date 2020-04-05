namespace AllControls.Samples.Controls

open AllControls.Helpers

open Fabulous.XamarinForms
open Xamarin.Forms

module MediaView =
    let view() = 
        View.NonScrollingContentPage(
            title = "MediaView sample",
            content = View.MediaElement(
                source = Media.Uri "https://sec.ch9.ms/ch9/9888/66d91d60-565a-4854-9b2b-80a7148d9888/EliteKit_mid.mp4",
                autoPlay = true,
                showsPlaybackControls = true
            )
        )