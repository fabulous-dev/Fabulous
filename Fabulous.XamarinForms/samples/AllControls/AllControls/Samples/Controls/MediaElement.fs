namespace AllControls.Samples.Controls

open AllControls.Helpers

open Fabulous.XamarinForms
open Xamarin.Forms

module MediaElement =
    let mediaElementView() = 
        View.NonScrollingContentPage(
            title = "MediaElement sample",
            content =
                View.MediaElement(
                    source = MediaPath "https://sec.ch9.ms/ch9/9888/66d91d60-565a-4854-9b2b-80a7148d9888/EliteKit_mid.mp4",
                    autoPlay = true,
                    showsPlaybackControls = true
                )
        ) 
    
    let view () =
        match Device.RuntimePlatform with
        | Device.iOS | Device.Android | Device.UWP
        | Device.WPF | Device.macOS ->
            mediaElementView()

        | _ -> 
            View.ContentPage(
                View.StackLayout [
                    View.Label(text = "Your Platform does not support MediaElement")
                ]
            )