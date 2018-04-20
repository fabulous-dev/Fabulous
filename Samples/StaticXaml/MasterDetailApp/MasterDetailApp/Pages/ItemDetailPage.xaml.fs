namespace MasterDetailApp

open Xamarin.Forms
open Xamarin.Forms.Xaml
open Elmish.XamarinForms

type ItemDetailPage() = 
    inherit ContentPage()
    do base.LoadFromXaml(typeof<ItemDetailPage>) |> ignore


module ItemDetailPage =

    type Model = Item

    type Msg = SetItem of Item

    let init () = 
        { Text = "Test1"; Description = "This is  a test item"}

    let update (msg: Msg) (model: Model) = 
        match msg with 
        | SetItem item -> item, NoCmd, NoNav

    let view () =
        ItemDetailPage(),
        [ "Text" |> Binding.oneWay (fun m -> m.Text)
          "Description" |> Binding.oneWay (fun m -> m.Description)
          "Title" |> Binding.oneWay (fun m -> "Item Detail")
        ]

