namespace MasterDetailApp

open FSharp.Control
open Xamarin.Forms
open Xamarin.Forms.Xaml
open Elmish.XamarinForms

type ItemsPage() = 
    inherit ContentPage()
    do base.LoadFromXaml(typeof<ItemsPage>) |> ignore

module ItemsPage = 

    type Model = 
        { Items : Item[]
          IsUpdating: bool }

    type Msg = 
        | UpdateItems
        | UpdateItemsReceived of Item []
        | UpdateItemsComplete
        | SelectItem of obj
        | AddItem
        | NewItem

    let init () = 
        let firstItem = { Text = "Text1"; Description = "Description1"  }
        { Items = [| firstItem |]; IsUpdating = false }

    let getFreshItems =
        cmd { do! Async.Sleep 500
              yield UpdateItemsReceived [| { Text = "AsyncLoad1"; Description = "AsyncDescription1"  } |]
              do! Async.Sleep 500
              yield UpdateItemsReceived [| { Text = "AsyncLoad2"; Description = "AsyncDescription2"  } |]
              do! Async.Sleep 500 
              yield UpdateItemsComplete }

    let canon items = items |> Array.sortBy (fun i -> i.Text)

    let addItem newItem model = 
        let newItems = [| yield! model.Items; yield newItem |]
        { model with Items = canon newItems  }

    let addItems newItems model = 
        let newItems = [| yield! model.Items; yield! newItems |]
        { model with Items = canon newItems  }

    let update msg model =
        match msg with
        | UpdateItemsReceived newItems ->
            addItems newItems model, NoCmd, NoNav
        | UpdateItemsComplete -> 
            { model with IsUpdating = false }, NoCmd, NoNav
        | AddItem -> 
            let n = model.Items.Length 
            let newItem = { Text = "Text" + string n; Description = "Description" + string n }
            addItem newItem model, NoCmd, NoNav
        | SelectItem item -> 
            model, NoCmd, (match item with :? Item as i -> ItemDetailsRequest(i, ItemsPageID) | _ -> NoNav) 
        | UpdateItems  -> 
            { model with IsUpdating = true }, getFreshItems, NoNav 
        | NewItem  -> 
            model, NoCmd, NewItemRequest ItemsPageID

    let view () =
        ItemsPage (),
        [ "Items" |> Binding.oneWay (fun m -> m.Items)
          "IsRefreshing" |> Binding.oneWay (fun m -> m.IsUpdating)
          "Title" |> Binding.oneWay (fun m -> "Items")
          "SelectedItem"|> Binding.oneWayFromView SelectItem
          "LoadItemsCommand" |> Binding.msg UpdateItems
          "NewItemCommand" |> Binding.msg NewItem
          "AddItemCommand" |> Binding.msg AddItem
        ]


