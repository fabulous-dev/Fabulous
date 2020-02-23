namespace AllControls

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module Helpers =
    type Fabulous.XamarinForms.View with 
        static member ScrollingContentPage(title, children) =
            View.ContentPage(title=title, content=View.ScrollView(View.StackLayout(padding=Thickness 20.0, children=children) ), useSafeArea=true)
            
        static member ScrollingContentPage(title, goBack, (content: ViewElement)) =
            View.ContentPage(
                title = title,
                useSafeArea = true,
                content = View.ScrollView(
                    padding = Thickness 20.0,
                    content = View.StackLayout(
                        orientation = StackOrientation.Vertical,
                        children = [
                            content.VerticalOptions(LayoutOptions.FillAndExpand)
                            
                            View.Button(
                                horizontalOptions = LayoutOptions.Center,
                                text = "Go back",
                                command = goBack
                            )
                        ]
                    )
                )
            )
            
        static member NonScrollingContentPage(title, goBack, (content: ViewElement)) =
            View.ContentPage(
                title = title,
                useSafeArea = true,
                content = View.StackLayout(
                    orientation = StackOrientation.Vertical,
                    padding = Thickness 20.0,
                    children = [
                        content.VerticalOptions(LayoutOptions.FillAndExpand)
                        
                        View.Button(
                            horizontalOptions = LayoutOptions.Center,
                            text = "Go back",
                            command = goBack
                        )
                    ]
                )
            )

        static member NonScrollingContentPage(title, children, ?gestureRecognizers) =
            View.ContentPage(title=title, content=View.StackLayout(padding=Thickness 20.0, children=children, ?gestureRecognizers=gestureRecognizers), useSafeArea=true)
