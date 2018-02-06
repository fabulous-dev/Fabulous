namespace MasterDetailApp

open System
open Elmish
open Elmish.XamarinForms
open Xamarin.Forms

type Model = 
  { Count : int }

type Msg = 
    | OpenedUri of Uri
    //| Decrement 
    //| Reset
    //| SetStep of int

type MasterDetailApp () as self = 
    inherit Application ()

    let init () = { Count = 0 }

    let update msg model =
        match msg with
        | OpenedUri uri -> { model with Count = model.Count + 1 }
        //| Decrement -> { model with Count = model.Count - model.Step }
        //| Reset -> init ()
        //| SetStep n -> { model with Step = n }

    let view _ _ =
        [ "OpenWebCommand" |> Binding.cmd (fun m -> let uri = Uri("https://xamarin.com/platform") in Device.OpenUri(uri); OpenedUri uri ) 
          "Title" |> Binding.oneWay (fun m -> "TTRTTTitle")

          //"CounterValue" |> Binding.oneWay (fun m -> m.Count)
          //"CounterValue2" |> Binding.oneWay (fun m -> m.Count + 1)
          //"IncrementCommand" |> Binding.cmd (fun _ -> Increment)
          //"DecrementCommand" |> Binding.cmd (fun _ -> Decrement)
          //"ResetCommand" |> Binding.cmdIf (fun _ -> Reset) (fun m -> m <> init ())
          //"ResetVisible" |> Binding.oneWay (fun m ->  m <> init ())
          //"StepValue" |> Binding.twoWay (fun m -> double m.Step) (fun v m -> v |> ((+)0.5) |> int |> SetStep) 
        ]

    do global.Xamarin.Forms.Xaml.Extensions.LoadFromXaml(self, typeof<MasterDetailApp>) |> ignore

    do
        let page = MasterDetailApp.AboutPage ()
        Program.mkSimple init update view
        |> Program.withConsoleTrace
        |> Program.runPage page

        base.MainPage <- page

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


