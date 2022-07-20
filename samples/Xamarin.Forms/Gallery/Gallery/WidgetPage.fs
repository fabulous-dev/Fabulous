namespace Gallery

open System
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Essentials
open Gallery.Samples

open type Fabulous.XamarinForms.View

module WidgetPage =    
    let openBrowserCmd url =
        async {
            do!
                Browser.OpenAsync(Uri url, BrowserLaunchMode.SystemPreferred)
                |> Async.AwaitTask
        }
        |> Async.executeOnMainThread
        |> Cmd.performAsync
    
    type Model =
        { Sample: Sample
          SampleModel: obj
          SelectedSampleView: SampleViewType }

    type Msg =
        | SampleMsg of obj
        | SampleViewChanged of SampleViewType
        | OpenBrowser of string
        
    let init index =
        let sample = Registry.getForIndex index
        { Sample = sample
          SampleModel = sample.Program.init()
          SelectedSampleView = Run }
        
    let update msg model =
        match msg with
        | SampleMsg sampleMsg ->
            let sampleModel = model.Sample.Program.update sampleMsg model.SampleModel
            { model with
                SampleModel = sampleModel }, Cmd.none
            
        | SampleViewChanged value ->
            { model with SelectedSampleView = value }, Cmd.none
            
        | OpenBrowser url ->
            model, openBrowserCmd url
        
    let sampleViews =
        [ { Value = Run
            Text = "\uEA1C" }
          { Value = Code
            Text = "\uEA80" } ]
        
    let view model =
        ContentPage(
            model.Sample.Name,
            ScrollView(
                (VStack(spacing = 20.) {
                    HStack() {
                        Label(model.Sample.Name)
                            .font(NamedSize.Title)
                            .padding(top = 20.)
                        
                        SampleViewSelector(sampleViews, model.SelectedSampleView, SampleViewChanged)
                            .alignEndHorizontal(expand = true)
                            .alignEndVertical()
                    }
                    
                    Label(model.Sample.Description)
                    
                    VStack(spacing = 5.) {
                        Label("Source")
                            .font(NamedSize.Micro)
                            .textTransform(TextTransform.Uppercase)
                            .textColor(FabColor.fromHex "#A4A4A4")
                            
                        Label(model.Sample.SourceFilename)
                            .font(NamedSize.Small)
                            .gestureRecognizers() {
                                TapGestureRecognizer(OpenBrowser model.Sample.SourceLink)
                            }
                    }
                
                    VStack(spacing = 5.) {
                        Label("Documentation")
                            .font(NamedSize.Micro)
                            .textTransform(TextTransform.Uppercase)
                            .textColor(FabColor.fromHex "#A4A4A4")
                            
                        Label(model.Sample.DocumentationName)
                            .font(NamedSize.Small)
                            .gestureRecognizers() {
                                TapGestureRecognizer(OpenBrowser model.Sample.DocumentationLink)
                            }
                    }
                    
                    Rectangle(1., SolidColorBrush(Color.Gray))
                        .height(if Device.RuntimePlatform = Device.iOS then 1. else 2.)
                    
                    
                    Grid() {
                        (View.map SampleMsg (model.Sample.Program.view model.SampleModel))
                            .isVisible(model.SelectedSampleView = Run)
                            
                        ScrollView(
                            (View.map SampleMsg (model.Sample.SampleCodeFormatted ()))
                                .margin(Thickness(0., 0., 0., 10.))
                        )
                            .orientation(ScrollOrientation.Horizontal)
                            .isVisible(model.SelectedSampleView = Code)
                    }
                })
                    .padding(Thickness(20., 0.))
            )
        )