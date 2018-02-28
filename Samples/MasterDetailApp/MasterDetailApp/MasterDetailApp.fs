namespace MasterDetailApp

open System
open Elmish
open Elmish.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.Xaml

type Item = 
    { Text: string; Description: string }

module AboutPg = 
    type Model = unit
    type Msg = unit

    let init () = ()

    let update embed (msg: Msg) (model: Model) = model, Cmd.none

    let view _ dispatch =
        [ "OpenWebCommand" |> Binding.cmd (fun _ m -> Device.OpenUri(Uri("https://xamarin.com/platform")); Cmd.none)
          "Title" |> Binding.oneWay (fun m -> "About") ]

module ItemsPg = 

    type Model = 
        { Items : Item[]
          IsBusy: bool }

    type Msg = 
        | LoadItems
        | LoadItemsComplete of Item []
        | AddItem
        | SelectItem of Item
        | NewItem

    let init () = { Items  = [| { Text = "Text1"; Description = "Description1"  } |]; IsBusy = false }

    let update onSelectItem onNewItem embed msg model =
        match msg with
        | LoadItemsComplete items -> { model with Items = items; IsBusy = false }, Cmd.none
        | AddItem -> { model with Items = [| yield! model.Items; yield let n = model.Items.Length in { Text = "Text" + string n; Description = "Description" + string n } |]  }, Cmd.none
        | SelectItem item -> 
            Device.OpenUri(Uri("http://fsharp.org"))
            model, onSelectItem item 
        | LoadItems  -> 
            { model with IsBusy = true }, 
            [ fun dispatch -> 
                async { 
                  do! Async.Sleep 2000; 
                  dispatch (LoadItemsComplete [| { Text = "Text1"; Description = "Description1"  } |])
                } |> Async.StartImmediate ] |> Cmd.map embed
        | NewItem  -> 
            model, onNewItem

    let view _ dispatch =
        [ "Items" |> Binding.oneWay (fun m -> m.Items )
          "IsBusy" |> Binding.oneWay (fun m -> m.IsBusy )
          "Title" |> Binding.oneWay (fun m -> "Items")
          "SelectedItem"|> Binding.oneWayFromView (fun (v:obj) m -> match v with :? Item as i -> Cmd.ofMsg (SelectItem i)| _ -> Cmd.none) 
          "LoadItemsCommand" |> Binding.cmd (fun _ _ -> Cmd.ofMsg LoadItems)
          "NewItemCommand" |> Binding.cmd (fun _ _ -> Cmd.ofMsg NewItem)
          "AddItemCommand" |> Binding.cmd (fun _ _ -> Cmd.ofMsg AddItem)
        ]


module ItemDetailsPg =
    type Model = Item
    type Msg = SetItem of Item

    let init () = { Text = "Test1"; Description = "This is  a test item"}

    let update embed (msg: Msg) (model: Model) = 
        match msg with 
        | SetItem item -> item, Cmd.none

    let view _ dispatch =
        [ "Text" |> Binding.oneWay (fun m -> m.Text )
          "Description" |> Binding.oneWay (fun m -> m.Description )
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

    let update embed msg model =
        match msg with
        | Save -> model, Cmd.none // { model with Items = Array.append model.Items [| { Text = "Text" + string model.Items.Length; Description = "Description1" + string model.Items.Length } |]  }
        | SetText t -> { model with Text = t }, Cmd.none
        | SetDescription t -> { model with Description = t } , Cmd.none
        | Reset -> init() , Cmd.none

    let view _ dispatch =
        [ "Text" |> Binding.twoWay (fun m -> m.Text ) (fun v m -> SetText v |> Cmd.ofMsg )
          "Description" |> Binding.twoWay (fun m -> m.Description ) (fun v m -> SetDescription v |> Cmd.ofMsg)
          "Save" |> Binding.cmd (fun m _ -> Save |> Cmd.ofMsg)
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

    do
        let aboutPage = AboutPage ()
        let itemsPage = ItemsPage ()
        let itemDetailPage () = 
            //let program = Page. ItemDetailsPg.init ItemDetailsPg.update ItemDetailsPg.view
            ItemDetailPage ()

        let newItemPage = NewItemPage ()

        let mainPage = TabbedPage()
        mainPage.Children.Add(itemsPage)
        mainPage.Children.Add(aboutPage)
        // Not a child, only accessed via navigation
        //mainPage.Children.Add(itemDetailPage)
        //mainPage.Children.Add(newItemPage)
        let navMainPage = NavigationPage mainPage
        let nav = navMainPage.Navigation
        let onSelectItem item = Cmd.ofMsg (Choice5Of5 (Nav.OpenItemDetails item))
        let onNewItem = Cmd.ofMsg (Choice5Of5 Nav.OpenNewItem)

        let program, pages = 
             Pages.compose5 
                  "About"       AboutPg.init       AboutPg.update                                        AboutPg.view       aboutPage
                  "Items"       ItemsPg.init       (ItemsPg.update onSelectItem onNewItem)               ItemsPg.view       itemsPage
                  "ItemDetails" ItemDetailsPg.init ItemDetailsPg.update                                  ItemDetailsPg.view null
                  "NewItem"     NewItemPg.init     NewItemPg.update                                      NewItemPg.view     null
                  "Nav"         Nav.init           (Nav.update (itemsPage, NewItemPage, ItemDetailPage)) View.none          null

        program
        |> Program.withConsoleTrace
        |> Program.runPages pages

        base.MainPage <- NavigationPage mainPage
//        await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));


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


