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
        if temp > 60 then 
            if isStart then WarmStartColor else WarmEndColor
        else if temp = -100 then 
            if isStart then NightStartColor else NightEndColor
        else if isStart then 
            coldStartColor else coldEndColor

    let createLabel value =
        View.Label(text=value).FontSize(FontSize 100.).HorizontalOptions(LayoutOptions.Center).TextColor(MainTextColor)

module App =
    type Msg =
        | Refresh

    
    type DataItem = { Name:string
                      Value:int }
    type Model = { Temp:int
                   Items: DataItem list }

    let initial = { Temp=61
                    Items=[ 
                        { Name="Pressure";   Value=10 }
                        { Name="UV Index";   Value=3 }
                        { Name="Wind Speed"; Value=0 }
                        { Name="Humidity";   Value=65 }
                        { Name="Min Temp";   Value=50 }
                        { Name="Max Temp";   Value=80 } ] }
     
    let update msg model =
        match msg with
        | Refresh -> initial

    let view (model: Model) dispatch =
        
        let itemsView =
            [for r in model.Items -> 
                  View.PancakeView(content=
                            View.Label(sprintf "%s%s%i" r.Name System.Environment.NewLine r.Value,textColor=AppStyles.MainTextColor),
                            cornerRadius=new CornerRadius(20.,20.,20.,0.),
                            backgroundGradientStartColor=AppStyles.itemStartColor,
                            backgroundGradientEndColor=AppStyles.itemEndColor,
                            padding=new Thickness(8.),
                            backgroundGradientAngle=315
                        ) ]

        let grid =
            View.Grid(rowdefs=[ Auto; Star; Auto; Auto; Auto; Auto ])
                .RowSpacing(0.0)
                .Padding(if Device.RuntimePlatform = Device.Android then new Thickness(0.0,24.0,0.0,0.0) else new Thickness(0.,44.,0.,0.))
                .Children(
                    [
                        View.Label(text="SEATTLE",horizontalOptions=LayoutOptions.Center,fontSize=Named NamedSize.Large, textColor=AppStyles.MainTextColor)
                        View.Image( source=Path "spaceneedle.png",
                                    margin=new Thickness(0.,0.,0.,-80.),
                                    opacity=0.8, 
                                    verticalOptions=LayoutOptions.FillAndExpand, 
                                    horizontalOptions=LayoutOptions.FillAndExpand
                                   ).Row(1)
                        View.Grid(columnSpacing=0.,coldefs=[Star;Auto;Star]).Row(2).Children(
                            [
                                (AppStyles.createLabel (model.Temp.ToString())).Column(1)
                                (AppStyles.createLabel "°").Column(2).HorizontalOptions(LayoutOptions.Start)
                            ]
                        )
                        View.Label(horizontalOptions=LayoutOptions.Center,text="SUNNY",fontSize=Named NamedSize.Large,textColor=AppStyles.MainTextColor).Row(3)
                        View.Label(horizontalOptions=LayoutOptions.Center,text="FRIDAY, SEPTEMBER 13",fontSize=Named NamedSize.Small,textColor=AppStyles.MainTextColor).Row(4)
                        View.ScrollView(
                                content=View.StackLayout(
                                        children=itemsView,
                                        orientation=StackOrientation.Horizontal
                                        ).Margin(new Thickness(10.)),
                                orientation=ScrollOrientation.Horizontal
                                    )
                            .Row(5)

                    ]
                    )
                .GestureRecognizers([View.TapGestureRecognizer(command=(fun ()-> dispatch Refresh))])



        View.ContentPage(
            content=View.PancakeView(
                backgroundGradientStartColor=AppStyles.getGradientColor true (model.Temp), 
                backgroundGradientEndColor=AppStyles.getGradientColor false (model.Temp),
                content=grid
                )
            )

    let program = 
        Program.mkSimple (fun() -> initial) update view
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
