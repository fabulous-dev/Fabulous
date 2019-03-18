Fabulous - Guide
=======

{% include_relative contents.md %}

Models
--------

### Messages and Validation

Validation is generally done on updates to the model storing error messages from validation logic in the model so they can be correctly and simply displayed to the user. Here is an example of a typical pattern noting that you likely need to store the original input value as well as an error message:

```fsharp
    type Temperature = DegC of float
    type InputString = InputString of string
    type ValidationError = ValidationError of string
    type Model = { Temperature : Result<Temperature,InputString * ValidationError> }
    type Msg = SetTemp of string

    /// Validate a temperature - can be shared between client/server
    let validate temperatureStr =
        match Double.TryParse temperatureStr with
        | true, temp -> Ok (DegC temp)
        | false, _ -> Error (InputString temperatureStr, ValidationError "Could not parse temperature string" )

    let update msg model =
        match msg with
        | SetTemp tempStr -> { model with Temperature = validate tempStr }, Cmd.none

    let view model dispatch =
        match model.Temperature with
        | Ok validTemp -> ... // View render logic for when the temperature is valid
        | Error (invalidTempStr, error) -> ... // View render logic for when the temperature is invalid

```

Note that the same validation logic can be used in both your app and a service back-end.

### Saving Application State

Application state is very simple to save by serializing the model into `app.Properties`. For example, you can store as JSON as follows using `Json.NET`:
```fsharp

type Application() =
    ....
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
```

