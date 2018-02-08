namespace MasterDetailApp

open Xamarin.Forms
open Xamarin.Forms.Xaml

type AboutPage() = 
    inherit ContentPage()
    do base.LoadFromXaml(typeof<AboutPage>) |> ignore
