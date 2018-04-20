
namespace MasterDetailApp

open Xamarin.Forms
open Xamarin.Forms.Xaml
open Elmish.XamarinForms

type NewItemPage() = 
    inherit ContentPage()
    do base.LoadFromXaml(typeof<NewItemPage>) |> ignore

module NewItemPage =

    type Model = Item 

    type Msg = 
        | Save 
        | SetText of string
        | SetDescription of string
        | Reset

    let initialData = { Text = "Test1"; Description = "This is  a test item"}

    let init () = initialData

    let update msg model =
        match msg with
        | Save -> model, NoCmd, NewItemResult (model, NewItemPageID)
        | SetText t -> { model with Text = t }, NoCmd, NoNav
        | SetDescription t -> { model with Description = t }, NoCmd, NoNav
        | Reset -> initialData, NoCmd, NoNav

    let view () =
        NewItemPage(),
        [ "Text" |> Binding.twoWay (fun m -> m.Text) SetText
          "Description" |> Binding.twoWay (fun m -> m.Description) SetDescription
          "Save" |> Binding.msg Save
          "Title" |> Binding.oneWay (fun m -> "New Item")
        ]

