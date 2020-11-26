namespace AllControls.Samples

open AllControls
open AllControls.SampleDefinition

open Fabulous

module Samples =
    /// Create a Sample definition with just a view function
    let createViewOnlyDefinition title (view: unit -> DynamicViewElement) =
        { Title = title
          Init = ViewOnlySample.init
          Update = ViewOnlySample.update
          View = fun _ _ -> view()
          MapToCmd = ViewOnlySample.mapToCmd } |> boxSampleDefinition

    let ignoreCmdMsgs (init: unit -> 'Model) : unit -> 'Model * 'CmdMsg list =
        fun () ->
            let model = init ()
            model, []

    /// Convert an update function that doesn't use ExternalMsg to one that uses it, so it can be used in the definition
    let ignoreExternalMsg (update: 'Msg -> 'Model -> 'Model * 'CmdMsg list) : 'Msg -> 'Model -> 'Model * 'CmdMsg list * 'ExternalMsg option =
        fun msg model ->
            let newModel, cmdMsgs = update msg model
            newModel, cmdMsgs, None

    /// Convert an update function that doesn't use Msg & ExternalMsg to one that uses them, so it can be used in the definition
    let ignoreMsgAndExternalMsg (update: 'Msg -> 'Model -> 'Model) : 'Msg -> 'Model -> 'Model * 'CmdMsg list * 'ExternalMsg option =
        fun msg model ->
            let newModel = update msg model
            newModel, [], None

    /// Ignore the mapToCmd function for samples not needing it
    let ignoreMapToCmd _ = []

    /// All the samples to show in the application
    /// Use 'SampleChooser' to indicate an intermediate page where you can choose from several other choosers or samples
    /// Use 'Sample' with '|> boxSampleDefinition' to indicate a sample page
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
                                    ({ Title = "RadioButton"
                                       Init = Controls.RadioButton.init |> ignoreCmdMsgs
                                       Update = Controls.RadioButton.update |> ignoreMsgAndExternalMsg
                                       View = Controls.RadioButton.view
                                       MapToCmd = ignoreMapToCmd } |> boxSampleDefinition)
                                Sample
                                    ({ Title = "ScrollView"
                                       Init = Controls.ScrollView.init |> ignoreCmdMsgs
                                       Update = Controls.ScrollView.update |> ignoreExternalMsg
                                       View = Controls.ScrollView.view
                                       MapToCmd = Controls.ScrollView.mapToCmd } |> boxSampleDefinition)
                                Sample (createViewOnlyDefinition "SwipeView" Controls.SwipeView.view)
                                Sample
                                    ({ Title = "RefreshView"
                                       Init = Controls.RefreshView.init |> ignoreCmdMsgs
                                       Update = Controls.RefreshView.update |> ignoreExternalMsg
                                       View = Controls.RefreshView.view
                                       MapToCmd = Controls.RefreshView.mapToCmd } |> boxSampleDefinition) ] }

                    SampleChooser
                        { Title = "Extensions"
                          Nodes =
                              [ Sample (createViewOnlyDefinition "FFImageLoading" Extensions.FFImageLoading.view)
                                Sample (createViewOnlyDefinition "OxyPlot" Extensions.OxyPlot.view)
                                Sample
                                    ({ Title = "SkiaSharp"
                                       Init = Extensions.SkiaSharp.init |> ignoreCmdMsgs
                                       Update = Extensions.SkiaSharp.update |> ignoreExternalMsg
                                       View = Extensions.SkiaSharp.view
                                       MapToCmd = Extensions.SkiaSharp.mapToCmd } |> boxSampleDefinition)
                                Sample (createViewOnlyDefinition "VideoManager" Extensions.VideoManager.view) ] }

                    SampleChooser
                        { Title = "Pages"
                          Nodes =
                              [ Sample
                                    ({ Title = "CarouselPage"
                                       Init = Pages.CarouselPage.init |> ignoreCmdMsgs
                                       Update = Pages.CarouselPage.update |> ignoreExternalMsg
                                       View = Pages.CarouselPage.view
                                       MapToCmd = Pages.CarouselPage.mapToCmd } |> boxSampleDefinition)
                                Sample
                                    ({ Title = "NavigationPage"
                                       Init = Pages.NavigationPage.init |> ignoreCmdMsgs
                                       Update = Pages.NavigationPage.update |> ignoreExternalMsg
                                       View = Pages.NavigationPage.view
                                       MapToCmd = Pages.NavigationPage.mapToCmd } |> boxSampleDefinition)
                                Sample
                                    ({ Title = "FlyoutPage"
                                       Init = Pages.FlyoutPage.init |> ignoreCmdMsgs
                                       Update = Pages.FlyoutPage.update |> ignoreExternalMsg
                                       View = Pages.FlyoutPage.view
                                       MapToCmd = Pages.FlyoutPage.mapToCmd } |> boxSampleDefinition)
                                Sample (createViewOnlyDefinition "Shell" Pages.Shell.view)
                                Sample
                                    ({ Title = "TabbedPage1"
                                       Init = Pages.TabbedPage1.init |> ignoreCmdMsgs
                                       Update = Pages.TabbedPage1.update |> ignoreExternalMsg
                                       View = Pages.TabbedPage1.view
                                       MapToCmd = Pages.TabbedPage1.mapToCmd } |> boxSampleDefinition)
                                Sample
                                    ({ Title = "TabbedPage2"
                                       Init = Pages.TabbedPage2.init |> ignoreCmdMsgs
                                       Update = Pages.TabbedPage2.update |> ignoreExternalMsg
                                       View = Pages.TabbedPage2.view
                                       MapToCmd = Pages.TabbedPage2.mapToCmd } |> boxSampleDefinition)
                                Sample (createViewOnlyDefinition "TabbedPage3" Pages.TabbedPage3.view)] }

                    SampleChooser
                        { Title = "Use cases"
                          Nodes =
                              [ Sample
                                    ({ Title = "Animations"
                                       Init = UseCases.Animations.init |> ignoreCmdMsgs
                                       Update = UseCases.Animations.update |> ignoreExternalMsg
                                       View = UseCases.Animations.view
                                       MapToCmd = UseCases.Animations.mapToCmd } |> boxSampleDefinition)
                                Sample
                                    ({ Title = "AppTheming"
                                       Init = UseCases.AppTheming.init |> ignoreCmdMsgs
                                       Update = UseCases.AppTheming.update |> ignoreMsgAndExternalMsg
                                       View = UseCases.AppTheming.view
                                       MapToCmd = ignoreMapToCmd } |> boxSampleDefinition)
                                SampleChooser
                                    { Title = "Collections and Lists"
                                      Nodes =
                                          [ Sample
                                                ({ Title = "Infinite-scroll Collection"
                                                   Init = UseCases.InfiniteScrollCollection.init |> ignoreCmdMsgs
                                                   Update = UseCases.InfiniteScrollCollection.update |> ignoreExternalMsg
                                                   View = UseCases.InfiniteScrollCollection.view
                                                   MapToCmd = UseCases.InfiniteScrollCollection.mapToCmd } |> boxSampleDefinition)
                                            Sample
                                                ({ Title = "Infinite-scroll List"
                                                   Init = UseCases.InfiniteScrollList.init |> ignoreCmdMsgs
                                                   Update = UseCases.InfiniteScrollList.update |> ignoreExternalMsg
                                                   View = UseCases.InfiniteScrollList.view
                                                   MapToCmd = UseCases.InfiniteScrollList.mapToCmd } |> boxSampleDefinition)
                                            Sample
                                                ({ Title = "Collection with ViewRefs"
                                                   Init = UseCases.ViewRefsCollection.init
                                                   Update = UseCases.ViewRefsCollection.update |> ignoreExternalMsg
                                                   View = UseCases.ViewRefsCollection.view
                                                   MapToCmd = UseCases.ViewRefsCollection.mapToCmd } |> boxSampleDefinition) ] }
                                Sample (createViewOnlyDefinition "CSS Styling" UseCases.CssStyling.view)
                                Sample (createViewOnlyDefinition "Effects" UseCases.Effects.view)
                                Sample
                                    ({ Title = "Pop-ups"
                                       Init = UseCases.PopUps.init |> ignoreCmdMsgs
                                       Update = UseCases.PopUps.update |> ignoreExternalMsg
                                       View = UseCases.PopUps.view
                                       MapToCmd = UseCases.PopUps.mapToCmd } |> boxSampleDefinition)
                                Sample
                                    ({ Title = "WebCall"
                                       Init = UseCases.WebCall.init |> ignoreCmdMsgs
                                       Update = UseCases.WebCall.update |> ignoreExternalMsg
                                       View = UseCases.WebCall.view
                                       MapToCmd = UseCases.WebCall.mapToCmd } |> boxSampleDefinition) ] } ] }
