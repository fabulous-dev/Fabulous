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
          View = fun _ _ -> dependsOn () (fun _ _ -> view())
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
                              [ Sample (createViewOnlyDefinition "CarouselView" Controls.CarouselView.view)
                                Sample (createViewOnlyDefinition "CollectionView" Controls.CollectionView.view)
                                Sample
                                    ({ Title = "ScrollView"
                                       Init = Controls.ScrollView.init
                                       Update = Controls.ScrollView.update |> ignoreExternalMsg
                                       View = Controls.ScrollView.view
                                       MapToCmd = Controls.ScrollView.mapToCmd } |> boxSampleDefinition)
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
                              [ Sample (createViewOnlyDefinition "FFImageLoading" Extensions.FFImageLoading.view)
                                Sample (createViewOnlyDefinition "Maps" Extensions.Maps.view)
                                Sample (createViewOnlyDefinition "OxyPlot" Extensions.OxyPlot.view)
                                Sample
                                    ({ Title = "SkiaSharp"
                                       Init = Extensions.SkiaSharp.init
                                       Update = Extensions.SkiaSharp.update |> ignoreExternalMsg
                                       View = Extensions.SkiaSharp.view
                                       MapToCmd = Extensions.SkiaSharp.mapToCmd } |> boxSampleDefinition)
                                Sample (createViewOnlyDefinition "VideoManager" Extensions.VideoManager.view) ] }
                        
                    SampleChooser
                        { Title = "Pages"
                          Nodes = 
                              [ Sample
                                    ({ Title = "CarouselPage"
                                       Init = Pages.CarouselPage.init
                                       Update = Pages.CarouselPage.update |> ignoreExternalMsg
                                       View = Pages.CarouselPage.view
                                       MapToCmd = Pages.CarouselPage.mapToCmd } |> boxSampleDefinition)
                                Sample
                                    ({ Title = "NavigationPage"
                                       Init = Pages.NavigationPage.init
                                       Update = Pages.NavigationPage.update |> ignoreExternalMsg
                                       View = Pages.NavigationPage.view
                                       MapToCmd = Pages.NavigationPage.mapToCmd } |> boxSampleDefinition)
                                Sample
                                    ({ Title = "MasterDetailPage"
                                       Init = Pages.MasterDetailPage.init
                                       Update = Pages.MasterDetailPage.update |> ignoreExternalMsg
                                       View = Pages.MasterDetailPage.view
                                       MapToCmd = Pages.MasterDetailPage.mapToCmd } |> boxSampleDefinition)
                                Sample (createViewOnlyDefinition "Shell" Pages.Shell.view) 
                                Sample
                                    ({ Title = "TabbedPage1"
                                       Init = Pages.TabbedPage1.init
                                       Update = Pages.TabbedPage1.update |> ignoreExternalMsg
                                       View = Pages.TabbedPage1.view
                                       MapToCmd = Pages.TabbedPage1.mapToCmd } |> boxSampleDefinition)
                                Sample
                                    ({ Title = "TabbedPage2"
                                       Init = Pages.TabbedPage2.init
                                       Update = Pages.TabbedPage2.update |> ignoreExternalMsg
                                       View = Pages.TabbedPage2.view
                                       MapToCmd = Pages.TabbedPage2.mapToCmd } |> boxSampleDefinition)
                                Sample (createViewOnlyDefinition "TabbedPage3" Pages.TabbedPage3.view)] }
                        
                    SampleChooser
                        { Title = "Use cases"
                          Nodes =
                              [ Sample
                                    ({ Title = "Animations"
                                       Init = UseCases.Animations.init
                                       Update = UseCases.Animations.update |> ignoreExternalMsg
                                       View = UseCases.Animations.view
                                       MapToCmd = UseCases.Animations.mapToCmd } |> boxSampleDefinition)
                                Sample (createViewOnlyDefinition "CSS Styling" UseCases.CssStyling.view)
                                Sample (createViewOnlyDefinition "Effects" UseCases.Effects.view)
                                Sample
                                    ({ Title = "Infinite-scroll List"
                                       Init = UseCases.InfiniteScrollList.init
                                       Update = UseCases.InfiniteScrollList.update |> ignoreExternalMsg
                                       View = UseCases.InfiniteScrollList.view
                                       MapToCmd = UseCases.InfiniteScrollList.mapToCmd } |> boxSampleDefinition)
                                Sample
                                    ({ Title = "Pop-ups"
                                       Init = UseCases.PopUps.init
                                       Update = UseCases.PopUps.update |> ignoreExternalMsg
                                       View = UseCases.PopUps.view
                                       MapToCmd = UseCases.PopUps.mapToCmd } |> boxSampleDefinition)
                                Sample
                                    ({ Title = "WebCall"
                                       Init = UseCases.WebCall.init
                                       Update = UseCases.WebCall.update |> ignoreExternalMsg
                                       View = UseCases.WebCall.view
                                       MapToCmd = UseCases.WebCall.mapToCmd } |> boxSampleDefinition) ] } ] }
