namespace MasterDetailApp

open Xamarin.Forms
open Xamarin.Forms.Xaml
open Elmish.XamarinForms
open Elmish.XamarinForms.StaticViews

type AboutPage() = 
    inherit ContentPage()
    do base.LoadFromXaml(typeof<AboutPage>) |> ignore

module AboutPage = 

    type Msg = OpenAboutPage

    let init () = NoModel

    let update (msg: Msg) model = 
        match msg with 
        | OpenAboutPage -> model, NoCmd, NoNav

    let view () =
        AboutPage (),
        [ "OpenWebCommand" |> Binding.msg OpenAboutPage
          "Title" |> Binding.oneWay (fun m -> "About") ]

    let page = ("About", init, update, view, AboutPage)

