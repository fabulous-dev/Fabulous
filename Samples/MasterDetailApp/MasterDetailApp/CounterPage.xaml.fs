namespace MasterDetailApp

open Xamarin.Forms
open Xamarin.Forms.Xaml

type CounterPage() = 
    inherit ContentPage()
    let _ = base.LoadFromXaml(typeof<CounterPage>)
