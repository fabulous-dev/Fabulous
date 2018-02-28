namespace MasterDetailApp

open Xamarin.Forms
open Xamarin.Forms.Xaml

type ItemDetailPage() = 
    inherit ContentPage()
    do base.LoadFromXaml(typeof<ItemDetailPage>) |> ignore


