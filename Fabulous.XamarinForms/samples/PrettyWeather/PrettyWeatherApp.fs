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
    // Fully-qualified name to avoid extending by mistake
    // another View class (like Xamarin.Forms.View)
    type Fabulous.XamarinForms.View with
        /// Describes a ABC in the view
        /// The inline keyword is important for performance
        static member inline PancakeView(?backgroundGradientStartColor,?backgroundGradientEndColor) =

            let attribCount = 0
            let attribCount = match backgroundGradientStartColor with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match backgroundGradientEndColor with Some _ -> attribCount + 1 | None -> attribCount
            let attribs = ViewBuilders.BuildView(attribCount)

            match backgroundGradientStartColor with None -> () | Some v -> attribs.Add(backgroundGradientStartColorAttribKey, v)
            match backgroundGradientEndColor with None -> () | Some v -> attribs.Add(backgroundGradientEndColorAttribKey, v)

            // The creation method
            let create () = new Xamarin.Forms.PancakeView.PancakeView()

            // The incremental update method
            let update (prev: ViewElement voption) (source: ViewElement) (target: Xamarin.Forms.PancakeView.PancakeView) =
                ViewBuilders.UpdateView(prev,source,target)
                source.UpdatePrimitive(prev, target, backgroundGradientStartColorAttribKey, (fun target v -> target.BackgroundGradientStartColor <- v))
                source.UpdatePrimitive(prev, target, backgroundGradientEndColorAttribKey, (fun target v -> target.BackgroundGradientEndColor <- v))
                

            ViewElement.Create<Xamarin.Forms.PancakeView.PancakeView>(create, update, attribs)
module App =
    type Operator = Add | Subtract | Multiply | Divide 

    /// Represents a calculator button press
    type Msg =
        | Refresh


    type Model =
        | Temp of int

    let update msg model =
        match msg with
        | Refresh -> Temp 10

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
            

        View.ContentPage(
            content=View.PancakeView(
                backgroundGradientStartColor=getColor true (match model with Temp i -> i), 
                backgroundGradientEndColor=getColor false (match model with Temp i -> i)
                ).Content(View.Grid())
            )

    let program = 
        Program.mkSimple (fun() -> Temp 60) update view
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
