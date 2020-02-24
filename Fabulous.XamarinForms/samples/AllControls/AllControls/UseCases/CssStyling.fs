namespace AllControls.UseCases

open AllControls.TestLabel

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module CssStyling =
    let view () =
        View.ContentPage(
            title = "About",
            useSafeArea = true, 
            padding = Thickness (10.0, 20.0, 10.0, 5.0), 
            content = View.StackLayout([ 
                View.TestLabel(text = "Fabulous, version " + string (typeof<ViewElement>.Assembly.GetName().Version))
                View.Label(
                    text = "Now with CSS styling",
                    styleClasses = [ "cssCallout" ]
                )
            ])
        )

