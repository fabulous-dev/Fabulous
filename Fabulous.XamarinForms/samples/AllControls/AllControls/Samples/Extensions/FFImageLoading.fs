namespace AllControls.Samples.Extensions

open AllControls.Helpers

open Fabulous.XamarinForms
open Xamarin.Forms

module FFImageLoading =
    let cachedImageView () =
        View.ScrollingContentPage(
            title = "CachedImage Sample", 
            content = View.StackLayout([ 
                View.Label "Note, when last checked this did not work on Android"
                View.Label "However maybe the sample is not configured correctly"
                View.CachedImage(
                    source = Path "http://loremflickr.com/600/600/nature?filename=simple.jpg",
                    //loadingPlaceholder = Path "path/to/loading-placeholder.png",
                    //errorPlaceholder = Path "path/to/error-placeholder.png",
                    height = 600.,
                    width = 600.
                )
            ])
        )

    let view () =
        match Device.RuntimePlatform with
        | Device.Android  | Device.iOS  | Device.Tizen | Device.UWP | Device.macOS -> 
            cachedImageView ()
        | _ -> 
            View.ContentPage( 
                View.StackLayout [
                    View.Label(text="The version of FFImageLoading for XamarinForms does not support your platform")
                    View.Label(text="For status see https://github.com/luberda-molinet/FFImageLoading")
                ]
            )

