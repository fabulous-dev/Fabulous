// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Calculator

open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.LiveUpdate
open Xamarin.Forms

module App =
  type Model = 
    { Text: string } 

  type Msg = 
    | Ignore

  let initModel = { Text = "Hello there" }

  let init () = initModel, Cmd.none

  let update msg model =
    match msg with
    | Ignore -> 
      model, Cmd.none

  let view (model: Model) dispatch =
    View.ContentPage(
      padding = Thickness(16.),
      content =
        View.StackLayout(
          spacing = 8.,
          orientation = StackOrientation.Vertical,
          children = [
            View.CollectionView(
              header = (StructuredItems.fromString model.Text),
              items = [View.Label("Test"); View.Label("Test")],
              footer = (StructuredItems.fromString model.Text)
            )
            View.CollectionView(
              header = (StructuredItems.fromElement (View.Label(model.Text))),
              items = [View.Label("Test")],
              footer = (StructuredItems.fromElement (View.Label(model.Text)))
            )
          ]
        )
    )

  // Note, this declaration is needed if you enable LiveUpdate
  let program = XamarinFormsProgram.mkProgram init update view

type CalculatorApp () as app =
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
