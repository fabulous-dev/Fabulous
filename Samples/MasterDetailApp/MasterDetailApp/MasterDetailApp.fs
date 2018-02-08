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

    let update msg model = model

    let view _ dispatch =
        [ "OpenWebCommand" |> Binding.cmd (fun _ m -> Device.OpenUri(Uri("https://xamarin.com/platform")); ()) 
          "Title" |> Binding.oneWay (fun m -> "About") ]

module ItemsPg = 

    type Model = 
        { Items : Item[]
          IsBusy: bool }

    type Msg = 
        | LoadItemsStart 
        | LoadItemsComplete
        | AddItem
        | Ignore

    let init () = { Items  = [| { Text = "Text1"; Description = "Description1"  } |]; IsBusy = false }

    let update msg model =
        match msg with
        | LoadItemsStart -> { model with IsBusy = true }
        | LoadItemsComplete -> { model with Items = [| { Text = "Text1"; Description = "Description1"  } |]; IsBusy = false }
        | AddItem -> { model with Items = Array.append model.Items [| { Text = "Text" + string model.Items.Length; Description = "Description1" + string model.Items.Length } |]  }
        | Ignore -> model

    let view _ dispatch =
        [ "Items" |> Binding.oneWay (fun m -> m.Items )
          "IsBusy" |> Binding.oneWay (fun m -> m.IsBusy )
          "Title" |> Binding.oneWay (fun m -> "Items")
          "SelectedItem"|> Binding.oneWayFromView (fun (v:obj) m -> if isNull v then Ignore else Device.OpenUri(Uri("http://fsharp.org")); Ignore ) 
          "LoadItemsCommand" |> Binding.cmd (fun _ _ -> 
              async { 
                do! Async.Sleep 2000; 
                dispatch LoadItemsComplete 
              } |> Async.StartImmediate
              LoadItemsStart)
          "AddItemCommand" |> Binding.cmd (fun _ _ -> AddItem)
        ]


module ItemDetailsPg =
    type Model = Item 

    let init () = { Text = "Test1"; Description = "This is  a test item"}

    let update msg model = model

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

    let init () = { Text = "Test1"; Description = "This is  a test item"}

    let update msg model =
        match msg with
        | Save -> model // { model with Items = Array.append model.Items [| { Text = "Text" + string model.Items.Length; Description = "Description1" + string model.Items.Length } |]  }
        | SetText t -> { model with Text = t }
        | SetDescription t -> { model with Description = t } 

    let view _ dispatch =
        [ "Text" |> Binding.twoWay (fun m -> m.Text ) (fun v m -> SetText v )
          "Description" |> Binding.twoWay (fun m -> m.Description ) (fun v m -> SetDescription v)
          "Save" |> Binding.cmd (fun m _ -> Save)
        ]


type MasterDetailApp () as self = 
    inherit Application ()

    do self.LoadFromXaml(typeof<MasterDetailApp>) |> ignore

    do
        let aboutPage = MasterDetailApp.AboutPage ()
        let itemsPage = MasterDetailApp.ItemsPage ()
        let itemDetailPage = MasterDetailApp.ItemDetailPage ()
        let newItemPage = MasterDetailApp.NewItemPage ()

        let mainPage = TabbedPage()
        mainPage.Children.Add(itemsPage)
        mainPage.Children.Add(aboutPage)
        mainPage.Children.Add(itemDetailPage)

        let aboutProgram = Program.mkSimple AboutPg.init AboutPg.update AboutPg.view
        let itemsProgram = Program.mkSimple ItemsPg.init ItemsPg.update ItemsPg.view
        let itemDetailProgram = Program.mkSimple ItemDetailsPg.init ItemDetailsPg.update ItemDetailsPg.view
        Program.combine3 aboutProgram itemsProgram itemDetailProgram
        |> Program.withConsoleTrace
        |> Program.runPages3 aboutPage itemsPage itemDetailPage

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


