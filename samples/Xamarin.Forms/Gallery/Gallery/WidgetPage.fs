namespace Gallery

open System
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Essentials
open Gallery.Samples

open type Fabulous.XamarinForms.View

module WidgetPageStyles =
    open Xamarin.Forms.Internals
    
    let radioButtonStyle =
        let controlTemplate =
            ControlTemplate(fun () ->
                let vsmGroupList = VisualStateGroupList()
                let vsmGroup = VisualStateGroup(Name = "CheckedStates")
                
                let vsmChecked = VisualState(Name = "Checked")
                vsmChecked.Setters.Add(Setter(TargetName = "Frame", Property = Frame.BorderColorProperty, Value = Color.Black))
                vsmChecked.Setters.Add(Setter(TargetName = "Frame", Property = Frame.BackgroundColorProperty, Value = Color.LightGray))
                vsmChecked.Setters.Add(Setter(TargetName = "Label", Property = Label.TextColorProperty, Value = Color.White))
                vsmGroup.States.Add(vsmChecked)
                
                let vsmUnchecked = VisualState(Name = "Unchecked")
                vsmUnchecked.Setters.Add(Setter(TargetName = "Frame", Property = Frame.BorderColorProperty, Value = Color.LightGray))
                vsmUnchecked.Setters.Add(Setter(TargetName = "Frame", Property = Frame.BackgroundColorProperty, Value = Color.White))
                vsmUnchecked.Setters.Add(Setter(TargetName = "Label", Property = Label.TextColorProperty, Value = Color.LightGray))
                vsmGroup.States.Add(vsmUnchecked)
                
                vsmGroupList.Add(vsmGroup)
                
                let frame = Xamarin.Forms.Frame(HasShadow = false, WidthRequest = 36., HeightRequest = 36., Padding = Thickness(0.))
                let label = Xamarin.Forms.Label(HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, FontFamily = "Icomoon")
                label.SetBinding(Xamarin.Forms.Label.TextProperty, Binding(Path = "Content", Source = RelativeBindingSource.TemplatedParent))
                frame.Content <- label
                
                let namescope = NameScope()
                (namescope :> INameScope).RegisterName("Frame", frame)
                (namescope :> INameScope).RegisterName("Label", label)
                
                NameScope.SetNameScope(frame, namescope)
                VisualStateManager.SetVisualStateGroups(frame, vsmGroupList)
                frame :> obj
            )
        
        let style = Style(typeof<RadioButton>)
        style.Setters.Add(RadioButton.ControlTemplateProperty, controlTemplate)
        style

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
          CodeShown: bool }

    type Msg =
        | SampleMsg of obj
        | ShowCode of bool
        | OpenBrowser of string
        
    let init index =
        let sample = Registry.getForIndex index
        { Sample = sample
          SampleModel = sample.Program.init()
          CodeShown = false }
        
    let update msg model =
        match msg with
        | SampleMsg sampleMsg ->
            let sampleModel = model.Sample.Program.update sampleMsg model.SampleModel
            { model with
                SampleModel = sampleModel }, Cmd.none
            
        | ShowCode value ->
            { model with CodeShown = value }, Cmd.none
            
        | OpenBrowser url ->
            model, openBrowserCmd url
        
    let view model =
        ContentPage(
            model.Sample.Name,
            ScrollView(
                (VStack(spacing = 20.) {
                    HStack() {
                        Label(model.Sample.Name)
                            .font(NamedSize.Title)
                            .padding(top = 20.)
                        
                        (HStack() {
                            RadioButton(
                                "\uEA1C",
                                model.CodeShown = false,
                                (ShowCode false)
                            )
                                .style(WidgetPageStyles.radioButtonStyle)
                            
                            RadioButton(
                                "\uEA80",
                                model.CodeShown = true,
                                (ShowCode true)
                            )
                                .style(WidgetPageStyles.radioButtonStyle)
                        })
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
                        .height(2.)
                    
                    Grid() {
                        (View.map SampleMsg (model.Sample.Program.view model.SampleModel))
                            .isVisible(model.CodeShown = false)
                            
                        (View.map SampleMsg (model.Sample.SampleCodeFormatted ()))
                            .isVisible(model.CodeShown = true)
                    }
                })
                    .padding(Thickness(20., 0.))
            )
        )