namespace AllControls

open Xamarin.Forms
open Fabulous
open Fabulous.XamarinForms

module Helpers =
    type Fabulous.XamarinForms.View with 
        static member ScrollingContentPage(title, children) =
            View.ContentPage(title=title, content=View.ScrollView(View.StackLayout(padding=Thickness 20.0, children=children) ), useSafeArea=true)
            
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

        static member NonScrollingContentPage(title, children, ?gestureRecognizers) =
            View.ContentPage(title=title, content=View.StackLayout(padding=Thickness 20.0, children=children, ?gestureRecognizers=gestureRecognizers), useSafeArea=true)
