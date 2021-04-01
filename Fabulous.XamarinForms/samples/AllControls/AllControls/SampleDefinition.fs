namespace AllControls

open Fabulous

/// More details on the implementation here: https://github.com/fsprojects/Fabulous/issues/678#issuecomment-591974304
module SampleDefinition =
    /// A loosely-typed definition of a Sample, so multiple samples can be stored in the same list
    type SampleDefinition =
        { Title: string
          Init: unit -> obj * obj list
          Update: obj -> obj -> obj * obj list * obj option
          View: obj -> (obj -> unit) -> DynamicViewElement
          MapToCmd: obj -> Cmd<obj> }

    /// An intermediate page allowing to choose from several samples
    type SampleChooser =
        { Title: string
          Nodes: Node list }

    /// A node of the samples tree
    and Node =
        | Sample of SampleDefinition
        | SampleChooser of SampleChooser

    /// A strongly-typed definition of a Sample, so that the types are checked at compile-time
    type Sample<'Msg, 'CmdMsg, 'ExternalMsg, 'Model> =
        { Title: string
          Init: unit -> 'Model * 'CmdMsg list
          Update: 'Msg -> 'Model -> 'Model * 'CmdMsg list * 'ExternalMsg option
          View: 'Model -> ('Msg -> unit) -> DynamicViewElement
          MapToCmd: 'CmdMsg -> Cmd<'Msg> }

    /// Downcast the strongly-typed Sample definition to a loosely-typed one, while still making sure it's usable
    let boxSampleDefinition (sample: Sample<'Msg, 'CmdMsg, 'ExternalMsg, 'Model>): SampleDefinition =
        { Title = sample.Title
          Init = fun () ->
              let model, cmdMsgs = sample.Init()
              (box model, List.map box cmdMsgs)
          Update = fun msg model ->
              let newModel, cmdMsgs, externalMsg = sample.Update (unbox msg) (unbox model)
              (box newModel), (cmdMsgs |> List.map box), (externalMsg |> Option.map box)
          View = fun model dispatch ->
              sample.View (unbox model) (fun msg -> dispatch (unbox msg))
          MapToCmd = fun cmdMsg -> sample.MapToCmd (unbox cmdMsg) |> Cmd.map box }

