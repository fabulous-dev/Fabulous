namespace AllControls.Controls

open AllControls.Helpers
open AllControls.Effects

open Fabulous.XamarinForms
open Xamarin.Forms

module Effects =
    let effectsView () =
        View.ScrollingContentPage(
            title = "Effects sample",
            content = View.StackLayout([
                View.Label("Focus effect (no properties)", fontSize=Named NamedSize.Large)
                View.Label("Classic Entry field", margin=Thickness (0., 15., 0., 0.))
                View.Entry()
                View.Label("Entry field with Focus effect", margin=Thickness (0., 15., 0., 0.))
                View.Entry(effects = [
                    View.Effect("FabulousXamarinForms.FocusEffect")
                ])

                View.Label("Shadow effect (with properties)", fontSize=Named NamedSize.Large, margin=Thickness (0., 30., 0., 0.))
                View.Label("Classic Label field", margin=Thickness (0., 15., 0., 0.))
                View.Label("This is a label without shadows")
                View.Label("Label field with Shadow effect", margin=Thickness (0., 15., 0., 0.))
                View.Label("This is a label with shadows", effects = [
                    View.ShadowEffect(color=Color.Red, radius=15., distanceX=10., distanceY=10.)
                ])
            ])
        )
    
    let view () =
        match Device.RuntimePlatform with
        | Device.iOS | Device.Android -> 
            effectsView()
        | _ -> 
            View.ContentPage(
                View.StackLayout([
                    View.Label(text="Effects samples available on iOS and Android only")
                ])
            )

