namespace AllControls

open Helpers
open Samples

open Fabulous
open Fabulous.XamarinForms

module SampleChooser =
    type Msg =
        | NodeSelected of Node
        
    type ExternalMsg =
        | NavigateToNode of Node
        
    type Model =
        { Definition: SampleChooser }
    
    let mapToCmd _ = Cmd.none
    
    let init definition () =
        { Definition = definition }
        
    let update msg model =
        match msg with
        | NodeSelected node ->
            model, [], Some (NavigateToNode node)
        
    let view model dispatch =
        View.ScrollingContentPage(
            title = model.Definition.Title,
            content = View.StackLayout(
                [ for node in model.Definition.Nodes ->
                    let title =
                        match node with
                        | Sample definition -> definition.Title
                        | SampleChooser sampleChooser -> sampleChooser.Title
                    
                    View.Button(
                        text = title,
                        command = fun () -> dispatch (NodeSelected node)
                    )
                ]
            )
        )