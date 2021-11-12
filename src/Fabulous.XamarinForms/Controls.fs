namespace Fabulous.XamarinForms

open Xamarin.Forms
open Xamarin.Forms.PlatformConfiguration
open Xamarin.Forms.PlatformConfiguration.iOSSpecific

type FabulousContentPage() as this =
    inherit ContentPage()
    do this.On<iOS>().SetUseSafeArea(true) |> ignore