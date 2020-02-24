namespace AllControls.Samples.Extensions

open AllControls.Helpers

open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.Maps

module Maps =    
    let mapView () = 
        let sample1 = View.Map(hasZoomEnabled = true, hasScrollEnabled = true)

        let sample2 = 
            let timbuktu = Position(16.7666, -3.0026)
            View.Map(
                hasZoomEnabled = true,
                hasScrollEnabled = true,
                requestedRegion = MapSpan.FromCenterAndRadius(timbuktu, Distance.FromKilometers(1.0))
            )

        let sample3 = 
            let paris = Position(48.8566, 2.3522)
            let london = Position(51.5074, -0.1278)
            let calais = Position(50.9513, 1.8587)
            View.Map(
                hasZoomEnabled = true,
                hasScrollEnabled = true, 
                pins = [
                    View.Pin(paris, label = "Paris", pinType = PinType.Place)
                    View.Pin(london, label = "London", pinType = PinType.Place)
                ] ,
                requestedRegion = MapSpan.FromCenterAndRadius(calais, Distance.FromKilometers(300.0))
            )

        View.ScrollingContentPage(
            title = "Map Samples",
            content = View.StackLayout([
                yield View.Label "Note, may require setup to access maps, see "
                yield View.Label "https://fsprojects.github.io/Fabulous/Fabulous.XamarinForms/views-maps.html"
                yield View.Label ""
                yield View.Label "Android - put your Google Maps API Key in AllControls\Droid\Properties\AndroidManifest.xml"
                for map in [ sample1; sample2; sample3 ] do
                    yield map
            ])
        )

    let view() = 
        match Device.RuntimePlatform with
        | Device.GTK -> 
            View.ContentPage( 
                View.StackLayout [
                    View.Label(text="When last tested Xamarin.Forms.Maps on GTK does not work correctly")
                    View.Label(text="Please uncomment the code in AllControls.fs and try again")
                  ])
        | _ -> 
            mapView ()

