namespace AllControls

open Fabulous
open Fabulous.XamarinForms
open Samples
open Xamarin.Forms

module SampleHelpers =
    let getSampleDefinitionFromNode (node: Node) =
        match node with
        | Sample sample -> sample
        | SampleChooser sampleChooser ->
            { Title = sampleChooser.Title
              Init = (SampleChooser.init sampleChooser)
              Update = SampleChooser.update
              View = SampleChooser.view
              MapToCmd = SampleChooser.mapToCmd } |> boxSampleDefinition

module App =
    type Msg =
        | SampleMsg of obj
        | NavigateToRequested of Node
        | NavigationPopped
        | LowMemoryWarningReceived
    
    type SampleState =
        { Definition: SampleDefinition
          Model: obj }
    
    type Model =
        { SampleStates: SampleState list }
            
    let displayMemoryWarningMessage() =
        Application.Current.MainPage.DisplayAlert("Low memory!", "Cleaning up data...", "OK") |> ignore
                
    let init () =
        let definition = SampleHelpers.getSampleDefinitionFromNode Samples.root
        let sampleState =
            { Definition = definition
              Model = definition.Init() }
        
        { SampleStates = [sampleState] }, []
        
    let mapExternalMsg (externalMsg: obj option) =
        match externalMsg with
        | Some (:? SampleChooser.ExternalMsg as msg) ->
            match msg with
            | SampleChooser.ExternalMsg.NavigateToNode node ->
                Cmd.ofMsg (NavigateToRequested node)
        | _ ->
            Cmd.none
        
    let update msg model =
        match msg with
        | SampleMsg sampleMsg ->
            match model.SampleStates with
            | [] -> model, []
            | sampleState::rest ->
                let newSampleModel, newCmdMsgs, externalMsg = sampleState.Definition.Update sampleMsg sampleState.Model
                let newSampleState = { sampleState with Model = newSampleModel }
                let newCmd = newCmdMsgs |> List.map (sampleState.Definition.MapToCmd >> (Cmd.map SampleMsg)) |> Cmd.batch
                let newExternalCmd = mapExternalMsg externalMsg
                { model with SampleStates = newSampleState :: rest }, Cmd.batch [newCmd; newExternalCmd]
            
        | NavigateToRequested node ->
            let definition = SampleHelpers.getSampleDefinitionFromNode node
            let sampleState =
                { Definition = definition
                  Model = definition.Init() }
            { model with SampleStates = sampleState :: model.SampleStates }, []
                
        | NavigationPopped ->
            { model with SampleStates = model.SampleStates.Tail }, []
            
        | LowMemoryWarningReceived ->
            displayMemoryWarningMessage()
            model, []
            
    let view model dispatch =
        View.NavigationPage(
            popped = (fun _ -> dispatch NavigationPopped),
            pages = [
                for sampleState in List.rev model.SampleStates ->
                    sampleState.Definition.View sampleState.Model (SampleMsg >> dispatch)
            ]
        )
    
type App () as app = 
    inherit Application ()
    //do app.Resources.Add(Xamarin.Forms.StyleSheets.StyleSheet.FromResource("styles.css", System.Reflection.Assembly.GetExecutingAssembly()))
    
    let runner = 
        Program.mkProgram App.init App.update App.view
        |> Program.withConsoleTrace
        |> XamarinFormsProgram.run app

    member __.Program = runner