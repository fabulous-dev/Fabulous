namespace FabulousWeather

open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.LiveUpdate
open Xamarin.Forms

module AppStyles =
    let coldStartColor = Color.FromHex("#BDE3FA")
    let coldEndColor = Color.FromHex("#A5C9FD")
    let WarmStartColor =  Color.FromHex("#F6CC66")
    let WarmEndColor    = Color.FromHex("#FCA184")
    let NightStartColor = Color.FromHex("#172941")
    let NightEndColor =   Color.FromHex("#3C6683")
    let MainTextColor =   Color.White
    let itemStartColor = Color.FromHex("#98FFFFFF")
    let itemEndColor = Color.FromHex("#60FFFFFF")

    let getGradientColor isStart temp =
        if temp > 60m then 
            if isStart then WarmStartColor else WarmEndColor
        else if temp = -100m then 
            if isStart then NightStartColor else NightEndColor
        else if isStart then 
            coldStartColor else coldEndColor

    let createLabel value =
        View.Label(text=value).FontSize(FontSize 100.).HorizontalOptions(LayoutOptions.Center).TextColor(MainTextColor)

module App =
    
    type DataItem = { Name:string
                      Value:obj }
    type Model = { Temp:decimal
                   Items: DataItem list
                   IsRefreshing: bool
                   Weather:string}
    type Msg =
           | RequestRefresh
           | WeatherRefreshed of Model
    let apiKey = "API KEY HERE"

    let kelvinToFahrenheit K = 9.0m / 5.0m * (K - 273.0m) + 32.0m

    type jsonProvider = FSharp.Data.JsonProvider<"https://samples.openweathermap.org/data/2.5/weather?q=London,uk&appid=b6907d289e10d714a6e88b30761fae22">

    let getOpenWeatherData apiKey = async {
                let url = sprintf "http://api.openweathermap.org/data/2.5/weather?q=seattle&APPID=%s" apiKey
                let! result = jsonProvider.AsyncLoad(url)
                let model = { Temp=result.Main.Temp |> kelvinToFahrenheit
                              Weather=(result.Weather |> Array.head).Main
                              Items=[ 
                                   { Name="Pressure";   Value=result.Main.Pressure }
                                   { Name="Humidity";   Value=result.Main.Humidity }
                                   { Name="Wind Speed"; Value=result.Wind.Speed }
                                   { Name="Min Temp";   Value=result.Main.TempMin |> kelvinToFahrenheit }
                                   { Name="Max Temp";   Value=result.Main.TempMax |> kelvinToFahrenheit } ]
                              IsRefreshing = false } 
                return WeatherRefreshed model } |> Cmd.ofAsyncMsg
                
    
    let initModel =   { Temp=61m
                        Weather="SUNNY"
                        Items=[ 
                            { Name="Pressure";   Value=10 }
                            { Name="Humidity";   Value=65 }
                            { Name="Wind Speed"; Value=0 }
                            { Name="Min Temp";   Value=50 }
                            { Name="Max Temp";   Value=80 } ] 
                        IsRefreshing = true }
    let initial() = initModel, getOpenWeatherData apiKey

    let update msg model =
        match msg with
        | RequestRefresh -> { model with IsRefreshing = true }, getOpenWeatherData apiKey
        | WeatherRefreshed newModel -> { newModel with IsRefreshing = false }, Cmd.none

    let view (model: Model) dispatch =
        
        let itemsView =
            [for r in model.Items -> 
                  View.PancakeView(content=
                            View.Label(sprintf "%s%s%O" r.Name System.Environment.NewLine r.Value,textColor=AppStyles.MainTextColor),
                            cornerRadius=CornerRadius(20.,20.,20.,0.),
                            backgroundGradientStartColor=AppStyles.itemStartColor,
                            backgroundGradientEndColor=AppStyles.itemEndColor,
                            padding=Thickness(8.),
                            backgroundGradientAngle=315
                        ) ]

        let grid =
            View.Grid(rowdefs=[ Auto; Star; Auto; Auto; Auto; Auto ])
                .RowSpacing(0.0)
                .Padding(if Device.RuntimePlatform = Device.Android then Thickness(0.0,24.0,0.0,0.0) else Thickness(0.,44.,0.,0.))
                .Children(
                    [
                        View.Label(text="SEATTLE",horizontalOptions=LayoutOptions.Center,fontSize=Named NamedSize.Large, textColor=AppStyles.MainTextColor)
                        View.Image( source=Path "spaceneedle.png",
                                    margin=Thickness(0.,0.,0.,-80.),
                                    opacity=0.8, 
                                    verticalOptions=LayoutOptions.FillAndExpand, 
                                    horizontalOptions=LayoutOptions.FillAndExpand
                                   ).Row(1)
                        View.Grid(columnSpacing=0.,coldefs=[Star;Auto;Star]).Row(2).Children(
                            [
                                (AppStyles.createLabel (model.Temp.ToString("n0"))).Column(1)
                                (AppStyles.createLabel "°").Column(2).HorizontalOptions(LayoutOptions.Start)
                            ]
                        )
                        View.Label(horizontalOptions=LayoutOptions.Center,text=model.Weather.ToUpper(),fontSize=Named NamedSize.Large,textColor=AppStyles.MainTextColor).Row(3)
                        View.Label(horizontalOptions=LayoutOptions.Center,text=System.DateTime.Now.ToString("D"),fontSize=Named NamedSize.Small,textColor=AppStyles.MainTextColor).Row(4)
                        View.ScrollView(
                                content=View.StackLayout(
                                        children=itemsView,
                                        orientation=StackOrientation.Horizontal
                                        ).Margin(Thickness(10.)),
                                orientation=ScrollOrientation.Horizontal
                                    )
                            .Row(5)

                    ]
                    )
                .GestureRecognizers([View.TapGestureRecognizer(command=(fun ()-> dispatch RequestRefresh))])

        let pancakeBackgroundPadding =
            match Device.RuntimePlatform with
            | Device.iOS -> new Thickness(0., 40., 0., 20.)
            | _ -> new Thickness(0.)
        
        View.ContentPage(
            created=(fun self -> Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(self, false)),
            content=View.PancakeView(
                padding=pancakeBackgroundPadding,
                backgroundGradientStartColor=AppStyles.getGradientColor true (model.Temp), 
                backgroundGradientEndColor=AppStyles.getGradientColor false (model.Temp),
                content=if model.IsRefreshing then View.ActivityIndicator(isRunning=true) else grid
                )
            )

    let program = 
        Program.mkProgram initial update view
        |> Program.withConsoleTrace

type App () as app = 
    inherit Application ()

    let runner = App.program |> XamarinFormsProgram.run app

#if DEBUG
    do runner.EnableLiveUpdate ()
#endif


#if SAVE_MODEL_WITH_JSON
    let modelId = "model"
    override __.OnSleep() = 

        let json = Newtonsoft.Json.JsonConvert.SerializeObject(runner.CurrentModel)
        Debug.WriteLine("OnSleep: saving model into app.Properties, json = {0}", json)

        app.Properties.[modelId] <- json

    override __.OnResume() = 
        Debug.WriteLine "OnResume: checking for model in app.Properties"
        try 
            match app.Properties.TryGetValue modelId with
            | true, (:? string as json) -> 

                Debug.WriteLine("OnResume: restoring model from app.Properties, json = {0}", json)
                let model = Newtonsoft.Json.JsonConvert.DeserializeObject<App.Model>(json)

                Debug.WriteLine("OnResume: restoring model from app.Properties, model = {0}", (sprintf "%0A" model))
                runner.SetCurrentModel (model, Cmd.none)

            | _ -> ()
        with ex -> 
            App.program.onError("Error while restoring model found in app.Properties", ex)

    override this.OnStart() = 
        Debug.WriteLine "OnStart: using same logic as OnResume()"
        this.OnResume()

#endif
