namespace AllControls

open Fabulous
    
module Samples =
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
        
    let createViewOnlyDefinition title (view: unit -> ViewElement) =
        { Title = title
          Init = ViewOnlySample.init
          Update = ViewOnlySample.update
          View = fun _ _ -> view()
          MapToCmd = ViewOnlySample.mapToCmd } |> boxSampleDefinition
        
    let ignoreExternalMsg (update: 'Msg -> 'Model -> 'Model * 'CmdMsg list) : 'Msg -> 'Model -> 'Model * 'CmdMsg list * 'ExternalMsg option =
        fun msg model ->
            let newModel, cmdMsgs = update msg model
            newModel, cmdMsgs, None
            
    let root =
        SampleChooser
            { Title = "AllControls samples"
              Nodes =
                  [ SampleChooser
                        { Title = "Controls"
                          Nodes =
                              [ Sample (createViewOnlyDefinition "Effects" Controls.Effects.view)
                                Sample (createViewOnlyDefinition "SwipeView" Controls.SwipeView.view)
                                Sample
                                    ({ Title = "RefreshView"
                                       Init = Controls.RefreshView.init
                                       Update = Controls.RefreshView.update |> ignoreExternalMsg
                                       View = Controls.RefreshView.view
                                       MapToCmd = Controls.RefreshView.mapToCmd } |> boxSampleDefinition) ] }
                        
                    SampleChooser
                        { Title = "Extensions"
                          Nodes = 
                              [ Sample
                                    ({ Title = "SkiaSharp"
                                       Init = Extensions.SkiaSharp.init
                                       Update = Extensions.SkiaSharp.update |> ignoreExternalMsg
                                       View = Extensions.SkiaSharp.view
                                       MapToCmd = Extensions.SkiaSharp.mapToCmd } |> boxSampleDefinition)
                                Sample (createViewOnlyDefinition "OxyPlot" Extensions.OxyPlot.view)
                                Sample (createViewOnlyDefinition "Maps" Extensions.Maps.view) ] } ] }
