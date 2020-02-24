namespace AllControls

open Fabulous

module SampleDefinition =
    type SampleDefinition =
        { Title: string
          Init: unit -> obj
          Update: obj -> obj -> obj * obj list * obj option
          View: obj -> (obj -> unit) -> ViewElement
          MapToCmd: obj -> Cmd<obj> }
        
    type SampleChooser =
        { Title: string
          Nodes: Node list }
          
    and Node =
        | Sample of SampleDefinition
        | SampleChooser of SampleChooser
        
    type Sample<'Msg, 'CmdMsg, 'ExternalMsg, 'Model> =
        { Title: string
          Init: unit -> 'Model
          Update: 'Msg -> 'Model -> 'Model * 'CmdMsg list * 'ExternalMsg option
          View: 'Model -> ('Msg -> unit) -> ViewElement
          MapToCmd: 'CmdMsg -> Cmd<'Msg> }
        
    let boxSampleDefinition (sample: Sample<'Msg, 'CmdMsg, 'ExternalMsg, 'Model>): SampleDefinition =
        { Title = sample.Title
          Init = sample.Init >> box
          Update = fun msg model ->
              let newModel, cmdMsgs, externalMsg = sample.Update (unbox msg) (unbox model)
              (box newModel), (cmdMsgs |> List.map box), (externalMsg |> Option.map box)
          View = fun model dispatch ->
              sample.View (unbox model) (fun msg -> dispatch (unbox msg))
          MapToCmd = fun cmdMsg -> sample.MapToCmd (unbox cmdMsg) |> Cmd.map box }

