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
          SampleModel: obj }

    type Msg =
        | SampleMsg of obj
        | OpenBrowser of string
        
    let init index =
        let sample = Registry.getForIndex index
        { Sample = sample
          SampleModel = sample.Program.init() }, Cmd.none
        
    let update msg model =
        match msg with
        | SampleMsg sampleMsg ->
            let sampleModel = model.Sample.Program.update sampleMsg model.SampleModel
            { model with
                SampleModel = sampleModel }, Cmd.none
            
        | OpenBrowser url ->
            model, openBrowserCmd url
        
    let view model =
        ContentPage(
            model.Sample.Name,
            (VStack(spacing = 20.) {
                Label(model.Sample.Name)
                    .centerTextHorizontal()
                    .font(namedSize = NamedSize.Title)
                
                Label(model.Sample.Description)
                    .centerTextHorizontal()
                
                VStack(spacing = 10.) {
                    (HStack() {
                        Image(Aspect.AspectFit, "fabulous.png")
                            .size(width = 24., height = 24.)
                            
                        Label("Fabulous API Reference")
                            .centerTextVertical()
                    })
                        .gestureRecognizers() {
                            TapGestureRecognizer(OpenBrowser model.Sample.ApiRefLink)
                        }
                    
                    (HStack() {
                        Image(Aspect.AspectFit, "xamarin.png")
                            .size(width = 24., height = 24.)
                            
                        Label("Xamarin.Forms documentation")
                            .centerTextVertical()
                    })
                        .gestureRecognizers() {
                            TapGestureRecognizer(OpenBrowser model.Sample.XFDocLink)
                        }
                }
                
                ScrollView(
                    Frame(
                        View.map SampleMsg (model.Sample.Program.view model.SampleModel)
                    )
                        .borderColor
                )
                    .centerVertical(expand = true)
            })
                .padding(Thickness(20., 0.))
        )