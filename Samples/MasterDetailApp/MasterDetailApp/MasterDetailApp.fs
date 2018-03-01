namespace MasterDetailApp

open System
open Elmish
open Elmish.XamarinForms
open FSharp.Control
open Xamarin.Forms
open Xamarin.Forms.Xaml

type Item = 
    { Text: string; Description: string }

type NavigationMsg = 
    | NoNav
    | GoToItemDetailsPage of Item
    | GoToNewItemPage 

module AboutPg = 

    type Msg = | OpenAboutPage

    let init () = NoModel

    let update (msg: Msg) NoModel = 
        match msg with 
        | OpenAboutPage -> NoModel, cmd { Device.OpenUri(Uri("https://xamarin.com/platform")) }, NoNav

    let view _ dispatch =
        [ "OpenWebCommand" |> Binding.msg OpenAboutPage
          "Title" |> Binding.oneWay (fun m -> "About") ]

module ItemsPg = 

    type Model = 
        { Items : Item[]
          IsUpdating: bool }

    type Msg = 
        | UpdateItems
        | UpdateItemsReceived of Item []
        | UpdateItemsComplete
        | AddItem
        | SelectItem of obj
        | NewItem

    let init () = 
        let firstItem = { Text = "Text1"; Description = "Description1"  }
        { Items = [| firstItem |]; IsUpdating = false }

    let updateItemsCmd =
        cmd { 
              try
                do! Async.Sleep 2000; 
                yield UpdateItemsReceived [| { Text = "Text1"; Description = "Description1"  } |]
                do! Async.Sleep 2000; 
                yield UpdateItemsReceived [| { Text = "Text1"; Description = "Description1"  } |]
                do! Async.Sleep 2000; 
              with _ -> 
                yield UpdateItemsComplete
            }

    let update msg model =
        match msg with
        | UpdateItemsReceived items ->
            { model with Items = [| yield! model.Items; yield! items |] }, Cmd.none, NoNav
        | UpdateItemsComplete -> 
            { model with IsUpdating = false }, Cmd.none, NoNav
        | AddItem -> 
            let n = model.Items.Length 
            let newItem = { Text = "Text" + string n; Description = "Description" + string n }
            let newItems = [| yield! model.Items; yield newItem |]
            { model with Items = newItems  }, Cmd.none, NoNav
        | SelectItem item -> 
            model, Cmd.none, (match item with :? Item as i -> GoToItemDetailsPage i | _ -> NoNav) 
        | UpdateItems  -> 
            { model with IsUpdating = true }, updateItemsCmd, NoNav 
        | NewItem  -> 
            model, Cmd.none, GoToNewItemPage

    let view _ _ =
        [ "Items" |> Binding.oneWay (fun m -> m.Items)
          "IsRefreshing" |> Binding.oneWay (fun m -> m.IsUpdating)
          "Title" |> Binding.oneWay (fun m -> "Items")
          "SelectedItem"|> Binding.oneWayToSource SelectItem
          "LoadtemsCommand" |> Binding.msg UpdateItems
          "NewItemCommand" |> Binding.msg NewItem
          "AddItemCommand" |> Binding.msg AddItem
        ]

module ItemDetailsPg =

    type Model = Item

    type Msg = SetItem of Item

    let init () = { Text = "Test1"; Description = "This is  a test item"}

    let update (msg: Msg) (model: Model) = 
        match msg with 
        | SetItem item -> item, Cmd.none, NoNav

    let view _ dispatch =
        [ "Text" |> Binding.oneWay (fun m -> m.Text)
          "Description" |> Binding.oneWay (fun m -> m.Description)
          "Title" |> Binding.oneWay (fun m -> "Item Detail")
        ]

module NewItemPg =

    type Model = Item 

    type Msg = 
        | Save 
        | SetText of string
        | SetDescription of string
        | Reset

    let init () = { Text = "Test1"; Description = "This is  a test item"}

    let update msg model =
        match msg with
        | Save -> model, Cmd.none, NoNav
            //let newItems = Array.append model.Items [| item |] 
            //{ model with Items = newItems }, Cmd.none
        | SetText t -> { model with Text = t }, Cmd.none, NoNav
        | SetDescription t -> { model with Description = t }, Cmd.none, NoNav
        | Reset -> init(), Cmd.none, NoNav

    let view _ dispatch =
        [ "Text" |> Binding.twoWay (fun m -> m.Text) SetText
          "Description" |> Binding.twoWay (fun m -> m.Description) SetDescription
          "Save" |> Binding.msg Save
          "Title" |> Binding.oneWay (fun m -> "New Item")
        ]

module Nav =

    type Model = Item 

    type Msg = 
        | OpenNewItem  
        | OpenItemDetails of Item

    let init () = { Text = "Test1"; Description = "This is  a test item"}

    let update (itemsPage: Page, newItemPage, itemDetailPage) embed msg model =
        match msg with
        | OpenNewItem          -> model, Cmd.batch [Navigation.pushPage itemsPage.Navigation (newItemPage()); Cmd.ofMsg (Choice4Of5 NewItemPg.Reset)]
        | OpenItemDetails item -> model, Cmd.batch [Navigation.pushPage itemsPage.Navigation (itemDetailPage()); Cmd.ofMsg (Choice3Of5 (ItemDetailsPg.SetItem item))]

    let view _ dispatch = []


type MasterDetailApp () as self = 
    inherit Application ()

    do self.LoadFromXaml(typeof<MasterDetailApp>) |> ignore

    let aboutPage = AboutPage ()
    let itemsPage = ItemsPage ()
    let itemDetailPage  = ItemDetailPage ()
    let newItemPage = NewItemPage ()

    let program, pages = 
         Pages.compose4 
              "About" AboutPg.init AboutPg.update AboutPg.view aboutPage
              "Items" ItemsPg.init ItemsPg.update ItemsPg.view itemsPage
              "NewItemPg" NewItemPg.init NewItemPg.update NewItemPg.view newItemPage
              "ItemDetailsPg" ItemDetailsPg.init ItemDetailsPg.update ItemDetailsPg.view itemDetailPage
              (fun msg ((m1,m2,m3,m4) as m) ->  
                  match msg with
                  | NoNav -> m 
                  | GoToNewItemPage _ -> itemsPage.Navigation.PushAsync newItemPage |> ignore; (m1, m2, NewItemPg.init(), m4)  
                  | GoToItemDetailsPage i -> itemsPage.Navigation.PushAsync itemDetailPage |> ignore; (m1, m2, m3, ItemDetailsPg.init())  
              )

    do
        program
        |> Program.withConsoleTrace
        |> Program.runPages pages

        let mainPage = TabbedPage()
        mainPage.Children.Add(itemsPage)
        mainPage.Children.Add(aboutPage)

        base.MainPage <- NavigationPage mainPage

(*
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new MainPage());
        }

    
            public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page itemsPage, aboutPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    itemsPage = new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse"
                    };

                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "About"
                    };
                    itemsPage.Icon = "tab_feed.png";
                    aboutPage.Icon = "tab_about.png";
                    break;
                default:
                    itemsPage = new ItemsPage()
                    {
                        Title = "Browse"
                    };

                    aboutPage = new AboutPage()
                    {
                        Title = "About"
                    };
                    break;
            }

            Children.Add(itemsPage);
            Children.Add(aboutPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
*)


