namespace AllControls.Samples.Controls

open AllControls.Helpers

open Fabulous.XamarinForms
open Xamarin.Forms

module MediaView =
    let view() = 
        View.NonScrollingContentPage(
            title = "MediaView sample",
            content = View.MediaElement(
                source = Media.Uri "http://sec.ch9.ms/ch9/5d93/a1eab4bf-3288-4faf-81c4-294402a85d93/XamarinShow_mid.mp4"
            )
        )