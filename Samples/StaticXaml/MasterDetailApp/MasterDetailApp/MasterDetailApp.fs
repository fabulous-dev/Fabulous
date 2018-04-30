// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.
namespace MasterDetailApp

open System
open Elmish
open Elmish.XamarinForms
open Elmish.XamarinForms.StaticViews
open FSharp.Control
open Xamarin.Forms
open Xamarin.Forms.Xaml

module MainPage =

    // Combine the init logic 
    let init = 
        Init.combo4 AboutPage.init ItemsPage.init NewItemPage.init ItemDetailPage.init

    // Combine the update logic and reconcile the external messages
    let update = 
        Update.combo4 AboutPage.update ItemsPage.update NewItemPage.update ItemDetailPage.update 
        |> Update.reconcile (fun msg ((m1,m2,m3,m4) as m) ->
            match msg with
            | NoNav -> m, NoCmd
            | NewItemRequest req     -> (m1, m2, NewItemPage.init(), m4), Nav.push req NewItemPageID 
            | NewItemResult (item, req) -> (m1, ItemsPage.addItem item m2, m3, m4), Nav.popToRoot req
            | ItemDetailsRequest (item, req) -> (m1, m2, m3, item), Nav.push req ItemDetailsPageID
        )

    // Combine the view logic 
    let view()  = 
        let (aboutPage, itemsPage, newItemPage, itemDetailPage), bindings = 
            StaticView.combo4 AboutPage.view ItemsPage.view NewItemPage.view ItemDetailPage.view

        let mainPage = 
            let p = TabbedPage()
            p.Children.Add(itemsPage)
            p.Children.Add(aboutPage)
            p

        let navMap = 
            [ (ItemsPageID, (itemsPage :> Page));
              (NewItemPageID, (newItemPage :> Page));
              (ItemDetailsPageID, (itemDetailPage :> Page)) ]

        mainPage, bindings, navMap


type MasterDetailApp () as self = 
    inherit Application ()

    do self.LoadFromXaml(typeof<MasterDetailApp>) |> ignore

    do
        let page = 
            Program.mkProgram (fun () -> MainPage.init(), NoCmd) MainPage.update MainPage.view
            |> Program.withConsoleTrace
            |> Program.withNavigation
            |> Program.withStaticView
            |> Program.run

        let mainPage = NavigationPage page
        do PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea((mainPage:> Page).On<PlatformConfiguration.iOS>(), true) |> ignore
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


