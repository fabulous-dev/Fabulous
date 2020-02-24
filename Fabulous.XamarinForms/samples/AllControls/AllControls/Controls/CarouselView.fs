namespace AllControls.Controls

open AllControls.Helpers

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module CarouselView =
    let carouselRef = ViewRef<CustomCarouselView>()
        
    let carouselViewView () =
        View.NonScrollingContentPage(
            title = "CarouselView & IndicatorView sample",
            content = View.StackLayout([
                View.CarouselView(
                    ref = carouselRef,
                    margin = Thickness 10.,
                    verticalOptions = LayoutOptions.FillAndExpand,
                    items = [
                        for i = 0 to 15 do
                            yield View.StackLayout(
                                backgroundColor = randomColor(),
                                children = [
                                    View.Label(
                                        horizontalOptions = LayoutOptions.Center,
                                        verticalOptions = LayoutOptions.CenterAndExpand,
                                        text = sprintf "Person %i" i
                                    )
                                ]
                            )
                    ]
                )
                View.IndicatorView(itemsSourceBy = carouselRef)
            ])
        )
    
    let view () =
        match Device.RuntimePlatform with
        | Device.iOS | Device.Android -> 
            carouselViewView()

        | _ -> 
            View.ContentPage(
                View.StackLayout [
                    View.Label(text = "Your Platform does not support CarouselView")
                ]
            )