namespace AllControls

open Xamarin.Forms
open Fabulous
open Fabulous.XamarinForms

module Helpers =
    let randomColor() =
        let rand = System.Random()
        Color.FromRgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255))
    
    type Fabulous.XamarinForms.View with            
        static member ScrollingContentPage(title, (content: ViewElement)) =
            View.ContentPage(
                title = title,
                useSafeArea = true,
                content = View.ScrollView(
                    padding = Thickness 20.0,
                    content = content
                )
            )
            
        static member NonScrollingContentPage(title, (content: ViewElement)) =
            View.ContentPage(
                title = title,
                useSafeArea = true,
                padding = Thickness 20.0,
                content = content
            )