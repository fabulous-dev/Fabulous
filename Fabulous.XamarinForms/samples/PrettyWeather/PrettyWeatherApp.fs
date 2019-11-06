namespace PrettyWeather
open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.LiveUpdate
open Xamarin.Forms
[<AutoOpen>]
module PancakeViewExtensions =

    open Fabulous
    open Fabulous.XamarinForms

    // Define keys for the possible attributes
    
    let backgroundGradientStartColorAttribKey = AttributeKey "backgroundGradientStartColorAttribKey"
    let backgroundGradientEndColorAttribKey = AttributeKey "backgroundGradientEndColorAttribKey"
    let contentPancakeAttribKey = AttributeKey "contentkey"
    let paddingKey = AttributeKey "paddingKey"
    let cornerRadiusKey = AttributeKey "cornerRadiusKey"
    // Fully-qualified name to avoid extending by mistake
    // another View class (like Xamarin.Forms.View)
    type Fabulous.XamarinForms.View with
        /// Describes a ABC in the view
        /// The inline keyword is important for performance
        static member inline PancakeView(?backgroundGradientStartColor,?backgroundGradientEndColor,?content: ViewElement,
                                            ?cornerRadius,?padding,
                                            ?horizontalOptions, ?verticalOptions, ?margin, ?gestureRecognizers, ?anchorX, ?anchorY, ?backgroundColor,
                                            ?flowDirection, ?heightRequest, ?inputTransparent, ?isEnabled, ?isTabStop, ?isVisible, ?minimumHeightRequest, 
                                            ?minimumWidthRequest, ?opacity, ?rotation, ?rotationX, ?rotationY, ?scale, ?scaleX, ?scaleY, ?tabIndex, 
                                            ?style, ?translationX, ?translationY, ?visual, ?widthRequest, ?resources, ?styles, ?styleSheets, ?focused, 
                                            ?unfocused, ?classId, ?styleId, ?automationId, ?created, ?styleClass, ?effects, ?ref, ?tag,
                                            ?shellBackgroundColor, ?shellForegroundColor, ?shellDisabledColor, ?shellTabBarBackgroundColor,
                                            ?shellTabBarForegroundColor, ?shellTitleColor, ?shellUnselectedColor, ?shellBackButtonBehavior, 
                                            ?shellFlyoutBehavior, ?shellTabBarIsVisible, ?shellTitleView) =

            let attribCount = 0
            let attribCount = match backgroundGradientStartColor with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match backgroundGradientEndColor with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match content with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match cornerRadius with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match padding with Some _ -> attribCount + 1 | None -> attribCount
            let attribs = ViewBuilders.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin,
                                                    ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, 
                                                    ?backgroundColor=backgroundColor, ?flowDirection=flowDirection, ?heightRequest=heightRequest, 
                                                    ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isTabStop=isTabStop, 
                                                    ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, 
                                                    ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, 
                                                    ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?scaleX=scaleX, ?scaleY=scaleY, 
                                                    ?tabIndex=tabIndex, ?style=style, ?translationX=translationX, ?translationY=translationY,
                                                    ?visual=visual, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, 
                                                    ?styleSheets=styleSheets, ?focused=focused, ?unfocused=unfocused, ?classId=classId, 
                                                    ?styleId=styleId, ?automationId=automationId, ?created=created, ?styleClass=styleClass, 
                                                    ?effects=effects, ?ref=ref, ?tag=tag, ?shellBackgroundColor=shellBackgroundColor, 
                                                    ?shellForegroundColor=shellForegroundColor, ?shellDisabledColor=shellDisabledColor, 
                                                    ?shellTabBarBackgroundColor=shellTabBarBackgroundColor, 
                                                    ?shellTabBarForegroundColor=shellTabBarForegroundColor, ?shellTitleColor=shellTitleColor, 
                                                    ?shellUnselectedColor=shellUnselectedColor, ?shellBackButtonBehavior=shellBackButtonBehavior, 
                                                    ?shellFlyoutBehavior=shellFlyoutBehavior, ?shellTabBarIsVisible=shellTabBarIsVisible,
                                                    ?shellTitleView=shellTitleView)

            match backgroundGradientStartColor with None -> () | Some v -> attribs.Add(backgroundGradientStartColorAttribKey, v)
            match backgroundGradientEndColor with None -> () | Some v -> attribs.Add(backgroundGradientEndColorAttribKey, v)
            match content with None -> () | Some v -> attribs.Add(contentPancakeAttribKey, v)
            match padding with None -> () | Some v -> attribs.Add(paddingKey, v)
            match cornerRadius with None -> () | Some v -> attribs.Add(cornerRadiusKey, v)

            // The creation method
            let create () = new Xamarin.Forms.PancakeView.PancakeView()

            // The incremental update method
            let update (prev: ViewElement voption) (source: ViewElement) (target: Xamarin.Forms.PancakeView.PancakeView) =
                ViewBuilders.UpdateView(prev,source,target)
                source.UpdateElement(prev,target, contentPancakeAttribKey,(fun target -> target.Content), (fun target v -> target.Content <- v))
                source.UpdatePrimitive(prev, target, backgroundGradientStartColorAttribKey, (fun target v -> target.BackgroundGradientStartColor <- v))
                source.UpdatePrimitive(prev, target, backgroundGradientEndColorAttribKey, (fun target v -> target.BackgroundGradientEndColor <- v))
                source.UpdatePrimitive(prev, target, paddingKey, (fun target v -> target.Padding <- v))
                source.UpdatePrimitive(prev, target, cornerRadiusKey, (fun target v -> target.CornerRadius <- v))
                

            ViewElement.Create<Xamarin.Forms.PancakeView.PancakeView>(create, update, attribs)
module App =
    type Operator = Add | Subtract | Multiply | Divide 

    /// Represents a calculator button press
    type Msg =
        | Refresh

    
    type DataItem = {Name:string;Value:int}
    type Model = {Temp:int;Items: DataItem list}

    let initial = {Temp=61;Items=[
        {Name="Pressure";Value=10}
        {Name="UV Index";Value=3}
        {Name="Wind Speed";Value=0}
        {Name="Humidity";Value=65}
        {Name="Min Temp";Value=50}
        {Name="Max Temp";Value=80}
        ]}
     
    let update msg model =
        match msg with
        | Refresh -> initial

    let view (model: Model) dispatch =
        let coldStartColor = Color.FromHex("#BDE3FA")
        let coldEndColor = Color.FromHex("#A5C9FD")
        let WarmStartColor =  Color.FromHex("#F6CC66")
        let WarmEndColor    = Color.FromHex("#FCA184")
        let NightStartColor = Color.FromHex("#172941")
        let NightEndColor =   Color.FromHex("#3C6683")
        let MainTextColor =   Color.White


        

        let createLabel value =
            View.Label(text=value;).FontSize(100).HorizontalOptions(LayoutOptions.Center).TextColor(MainTextColor)

        let getColor isStart temp =
            if temp > 60 then 
                if isStart then WarmStartColor else WarmEndColor
            else if temp = -100 then 
                if isStart then NightStartColor else NightEndColor
            else if isStart then 
                coldStartColor else coldEndColor
        

        let dataView =
            View.CollectionView(heightRequest=80.,verticalOptions=LayoutOptions.End).GridRow(5).Margin(new Thickness(0.,20.))
                .ItemsLayout(new LinearItemsLayout(ItemsLayoutOrientation.Horizontal))
                .Children(
                    [for r in model.Items -> 
                        View.Grid(padding=new Thickness(10.),children=[
                            View.PancakeView(
                                backgroundGradientStartColor=Color.FromHex("#98FFFFFF"),
                                backgroundGradientEndColor=Color.FromHex("#60FFFFFF"),
                                content=View.StackLayout(spacing=0.,verticalOptions=LayoutOptions.Center,children=[
                                    View.Label(text=r.Name)
                                    View.Label(text=r.Value.ToString())
                                    ]),
                                padding=new Thickness(8.),
                                cornerRadius=new CornerRadius(20.,20.,20.,0.))])
                                ]
                        )

        let grid =
            View.Grid(rowdefs=[ "auto"; "*"; "auto"; "auto"; "auto"; "auto" ])
                .RowSpacing(0.0)
                .Padding(if Device.RuntimePlatform = Device.Android then new Thickness(0.0,24.0,0.0,0.0) else new Thickness(0.,44.,0.,0.))
                .Children(
                    [
                        View.Label(text="SEATTLE",horizontalOptions=LayoutOptions.Center,fontSize="Large", textColor=MainTextColor)
                        View.Image(source="spaceneedle.png",margin=new Thickness(0.,0.,0.,-80.),opacity=0.8, verticalOptions=LayoutOptions.FillAndExpand, horizontalOptions=LayoutOptions.FillAndExpand).GridRow(1)
                        View.Grid(columnSpacing=0.,coldefs=["*";"auto";"*"]).GridRow(2).Children(
                            [
                                (createLabel (model.Temp.ToString())).GridColumn(1)
                                (createLabel "°").GridColumn(2).HorizontalOptions(LayoutOptions.Start)
                            ]
                            )
                        View.Label(horizontalOptions=LayoutOptions.Center,text="SUNNY",fontSize="Large",textColor=MainTextColor).GridRow(3)
                        View.Label(horizontalOptions=LayoutOptions.Center,text="FRIDAY, SEPTEMBER 13",fontSize="Small",textColor=MainTextColor).GridRow(4)
                        dataView
                    ]
                    )
                .GestureRecognizers([View.TapGestureRecognizer(command=(fun ()-> dispatch Refresh))])



        View.ContentPage(
            content=View.PancakeView(
                backgroundGradientStartColor=getColor true (model.Temp), 
                backgroundGradientEndColor=getColor false (model.Temp),
                content=grid
                )
            )

    let program = 
        Program.mkSimple (fun() -> initial) update view
        |> Program.withConsoleTrace

type PrettyWeatherApp () as app = 
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
