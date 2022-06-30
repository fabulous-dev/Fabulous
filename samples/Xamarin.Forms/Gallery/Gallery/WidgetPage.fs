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
                vsmChecked.Setters.Add(Setter(TargetName = "Frame", Property = Frame.BackgroundColorProperty, Value = Color.Gray))
                vsmChecked.Setters.Add(Setter(TargetName = "Label", Property = Label.TextColorProperty, Value = Color.Black))
                vsmGroup.States.Add(vsmChecked)
                
                let vsmUnchecked = VisualState(Name = "Unchecked")
                vsmUnchecked.Setters.Add(Setter(TargetName = "Frame", Property = Frame.BorderColorProperty, Value = Color.Gray))
                vsmUnchecked.Setters.Add(Setter(TargetName = "Frame", Property = Frame.BackgroundColorProperty, Value = Color.LightGray))
                vsmUnchecked.Setters.Add(Setter(TargetName = "Label", Property = Label.TextColorProperty, Value = Color.White))
                vsmGroup.States.Add(vsmUnchecked)
                
                vsmGroupList.Add(vsmGroup)
                
                
                let frame = Xamarin.Forms.Frame(HasShadow = false, WidthRequest = 36., HeightRequest = 36., Padding = Thickness(0.))
                let label = Xamarin.Forms.Label(HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center)
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
          CodeShown = false }, Cmd.none
        
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
                    Label(model.Sample.Name)
                        .font(namedSize = NamedSize.Title)
                        .padding(top = 20.)
                    
                    Label(model.Sample.Description)
                    
                    VStack() {
                        Label("Source")
                            .textTransform(TextTransform.Uppercase)
                            .font(namedSize = NamedSize.Caption, attributes = FontAttributes.Bold)
                            
                        Label(model.Sample.SourceFilename)
                            .gestureRecognizers() {
                                TapGestureRecognizer(OpenBrowser model.Sample.SourceLink)
                            }
                    }
                
                    VStack() {
                        Label("Documentation")
                            .textTransform(TextTransform.Uppercase)
                            .font(namedSize = NamedSize.Caption, attributes = FontAttributes.Bold)
                            
                        Label(model.Sample.DocumentationName)
                            .gestureRecognizers() {
                                TapGestureRecognizer(OpenBrowser model.Sample.DocumentationLink)
                            }
                    }
                    
                    Rectangle(1., SolidColorBrush(Color.Gray))
                        .height(1.)
                    
                    Frame(
                        Grid() {
                            (View.map SampleMsg (model.Sample.Program.view model.SampleModel))
                                .isVisible(model.CodeShown = false)
                                .centerVertical()
                                .margin(Thickness(0., 46., 0., 0.))
                                
                            (View.map SampleMsg (model.Sample.SampleCodeFormatted ()))
                                .isVisible(model.CodeShown = true)
                                .centerVertical()
                                .margin(Thickness(0., 46., 0., 0.))
                            
                            (HStack() {                                
                                RadioButton(
                                    "🪥",
                                    model.CodeShown = true,
                                    (ShowCode true)
                                )
                                    .style(WidgetPageStyles.radioButtonStyle)
                                    
                                RadioButton(
                                    "🏮",
                                    model.CodeShown = false,
                                    (ShowCode false)
                                )
                                    .style(WidgetPageStyles.radioButtonStyle)
                            })
                                .alignEndHorizontal()
                                .alignStartVertical()
                        }
                    )
                        .hasShadow(false)
                        .padding(10.)
                        .borderColor(Color.Gray.ToFabColor())
                })
                    .padding(Thickness(20., 0.))
            )
        )