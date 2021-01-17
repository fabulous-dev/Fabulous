namespace AllControls.Samples.Controls

open Xamarin.Forms
open Fabulous.XamarinForms
open AllControls.Helpers
open Xamarin.Forms.Internals
open Xamarin.Forms.Shapes

module RadioButton_ControlTemplates =
    let radioButtonTemplate =
        ControlTemplate(System.Func<obj>(fun () ->
            // content
            let frame = Frame()
            frame.BorderColor <- Color.FromHex("#F3F2F1")
            frame.BackgroundColor <- Color.FromHex("#F3F2F1")
            frame.HasShadow <- true
            frame.HeightRequest <- 100.
            frame.WidthRequest <- 100.
            frame.HorizontalOptions <- LayoutOptions.Start
            frame.VerticalOptions <- LayoutOptions.Start
            frame.Padding <- Thickness(0.)
                        
            let grid = Grid()
            grid.Margin <- Thickness(4.)
            grid.WidthRequest <- 100.
            frame.Content <- grid
            
            let subGrid = Grid()
            subGrid.WidthRequest <- 18.
            subGrid.HeightRequest <- 18.
            subGrid.HorizontalOptions <- LayoutOptions.End
            subGrid.VerticalOptions <- LayoutOptions.Start
            grid.Children.Add(subGrid)
            
            let contentPresenter = ContentPresenter()
            grid.Children.Add(contentPresenter)
            
            let ellipse = Ellipse()
            ellipse.Stroke <- SolidColorBrush(Color.Blue)
            ellipse.Fill <- SolidColorBrush(Color.White)
            ellipse.WidthRequest <- 16.
            ellipse.HeightRequest <- 16.
            ellipse.HorizontalOptions <- LayoutOptions.Center
            ellipse.VerticalOptions <- LayoutOptions.Center
            subGrid.Children.Add(ellipse)
            
            let checkEllipse = Ellipse()
            checkEllipse.Fill <- SolidColorBrush(Color.Blue)
            checkEllipse.WidthRequest <- 8.
            checkEllipse.HeightRequest <- 8.
            checkEllipse.HorizontalOptions <- LayoutOptions.Center
            checkEllipse.VerticalOptions <- LayoutOptions.Center
            subGrid.Children.Add(checkEllipse)
            
            NameScope.SetNameScope(frame, NameScope())
            (frame :> INameScope).RegisterName("check", checkEllipse)
            
            // Visual States
            let visualStateGroupList = VisualStateGroupList()
            VisualStateManager.SetVisualStateGroups(frame, visualStateGroupList)
            
            let checkedStates = VisualStateGroup()
            checkedStates.Name <- "CheckedStates"
            visualStateGroupList.Add(checkedStates)
            
            let checkedState = VisualState()
            checkedState.Name <- "Checked"
            checkedStates.States.Add(checkedState)
            
            let checkedStateBorderColorSetter = Setter()
            checkedStateBorderColorSetter.Property <- Frame.BorderColorProperty
            checkedStateBorderColorSetter.Value <- Color.FromHex("#FF3300")
            checkedState.Setters.Add(checkedStateBorderColorSetter)
            
            let checkedStateCheckOpacitySetter = Setter()
            checkedStateCheckOpacitySetter.TargetName <- "check"
            checkedStateCheckOpacitySetter.Property <- Ellipse.OpacityProperty
            checkedStateCheckOpacitySetter.Value <- 1
            checkedState.Setters.Add(checkedStateCheckOpacitySetter)
            
            let uncheckedState = VisualState()
            uncheckedState.Name <- "Unchecked"
            checkedStates.States.Add(uncheckedState)
            
            let uncheckedStateBackgroundColorSetter = Setter()
            uncheckedStateBackgroundColorSetter.Property <- Frame.BackgroundColorProperty
            uncheckedStateBackgroundColorSetter.Value <- Color.FromHex("#F3F2F1")
            uncheckedState.Setters.Add(uncheckedStateBackgroundColorSetter)
            
            let uncheckedStateBorderColorSetter = Setter()
            uncheckedStateBorderColorSetter.Property <- Frame.BorderColorProperty
            uncheckedStateBorderColorSetter.Value <- Color.FromHex("#F3F2F1")
            uncheckedState.Setters.Add(uncheckedStateBorderColorSetter)
            
            let uncheckedStateCheckOpacitySetter = Setter()
            uncheckedStateCheckOpacitySetter.TargetName <- "check"
            uncheckedStateCheckOpacitySetter.Property <- Ellipse.OpacityProperty
            uncheckedStateCheckOpacitySetter.Value <- 0
            uncheckedState.Setters.Add(uncheckedStateCheckOpacitySetter)
            
            frame :> obj
        ))

module RadioButton =
    type TransportMode =
        | Car
        | Bike
        | Train
        | Walking
        
    type PetKind =
        | PetCat
        | PetDog
        | NoPet
        
    type AnimalKind =
        | Cat
        | Dog
        | Elephant
        | Monkey
    
    type Msg =
        | SelectTransportMode of TransportMode
        | SelectPetKind of PetKind
        | SelectAnimal of AnimalKind
        | SelectAnimalTemplate of AnimalKind
        
    type Model =
        { TransportMode: TransportMode option
          PetKind: PetKind option
          FavoriteAnimal: AnimalKind option
          FavoriteAnimalTemplate: AnimalKind option }
        
    let init () =
        { TransportMode = None
          PetKind = None
          FavoriteAnimal = None
          FavoriteAnimalTemplate = None }
    
    let update msg model =
        match msg with
        | SelectTransportMode mode -> { model with TransportMode = Some mode }
        | SelectPetKind kind -> { model with PetKind = Some kind }
        | SelectAnimal animal -> { model with FavoriteAnimal = Some animal }
        | SelectAnimalTemplate animal -> { model with FavoriteAnimalTemplate = Some animal }
        
    let radioButtonView model dispatch =
        let onTransportModeChecked mode (args: CheckedChangedEventArgs) =
            if args.Value then
                dispatch (SelectTransportMode mode)
                
        let onPetKindChecked kind (args: CheckedChangedEventArgs) =
            if args.Value then
                dispatch (SelectPetKind kind)
                
        let onAnimalChecked kind (args: CheckedChangedEventArgs) =
            if args.Value then
                dispatch (SelectAnimal kind)
                
        let onAnimalTemplateChecked kind (args: CheckedChangedEventArgs) =
            if args.Value then
                dispatch (SelectAnimalTemplate kind)
        
        View.ScrollingContentPage(
            title = "RadioButton sample",
            content =
                View.StackLayout([
                    View.Label(
                        text = "What's your favorite mode of transport?"
                    )
                    View.Label(
                        text =
                            match model.TransportMode with
                            | None -> "Please select one below"
                            | Some mode -> sprintf "You selected: %A" mode
                    )
                    View.RadioButton(
                        content = Content.fromString "Car",
                        checkedChanged = onTransportModeChecked Car
                    )
                    View.RadioButton(
                        content = Content.fromString "Bike",
                        checkedChanged = onTransportModeChecked Bike
                    )
                    View.RadioButton(
                        content = Content.fromString "Train",
                        checkedChanged = onTransportModeChecked Train
                    )
                    View.RadioButton(
                        content = Content.fromString "Walking",
                        checkedChanged = onTransportModeChecked Walking
                    )
                    
                    View.Label(
                        text = "Which kind of pet do you have?",
                        margin = Thickness(0., 30., 0., 0.)
                    )
                    View.Label(
                        text =
                            match model.PetKind with
                            | None -> "Please select one below"
                            | Some mode -> sprintf "You selected: %A" mode
                    )
                    View.RadioButton(
                        content = Content.fromString "Cat",
                        groupName = "Pet",
                        isChecked = (model.PetKind = Some PetCat),
                        checkedChanged = onPetKindChecked PetCat
                    )
                    View.RadioButton(
                        content = Content.fromString "Dog",
                        groupName = "Pet",
                        isChecked = (model.PetKind = Some PetDog),
                        checkedChanged = onPetKindChecked PetDog
                    )
                    View.RadioButton(
                        content = Content.fromString "I don't have pets",
                        groupName = "Pet",
                        isChecked = (model.PetKind = Some NoPet),
                        checkedChanged = onPetKindChecked NoPet
                    )
                    View.Button(
                        text = "Cats rulez!",
                        command = (fun () -> dispatch (SelectPetKind PetCat))
                    )
                    
                    
                    View.Label("What's your favorite animal? (Content = Image)")
                    View.StackLayout([
                        View.RadioButton(
                            content = Content.fromElement(
                                View.Image(
                                    source = Image.fromPath "cat.png"
                                )
                            ),
                            checkedChanged = onAnimalChecked Cat
                        )
                        View.RadioButton(
                            content = Content.fromElement(
                                View.Image(
                                    source = Image.fromPath "dog.png"
                                )
                            ),
                            checkedChanged = onAnimalChecked Dog
                        )
                        View.RadioButton(
                            content = Content.fromElement(
                                View.Image(
                                    source = Image.fromPath "elephant.png"
                                )
                            ),
                            checkedChanged = onAnimalChecked Elephant
                        )
                        View.RadioButton(
                            content = Content.fromElement(
                                View.Image(
                                    source = Image.fromPath "monkey.png"
                                )
                            ),
                            checkedChanged = onAnimalChecked Monkey
                        )
                    ])
                    View.Label(
                        match model.FavoriteAnimal with
                        | None -> "Please select one above"
                        | Some animal -> sprintf "You have chosen: %A" animal
                    )
                    
                    
                    View.Label("What's your favorite animal? (ControlTemplate)")
                    View.StackLayout(
                        orientation = StackOrientation.Horizontal,
                        children = [
                            View.RadioButton(
                                controlTemplate = RadioButton_ControlTemplates.radioButtonTemplate,
                                content = Content.fromElement(
                                    View.StackLayout([
                                        View.Image(
                                            source = Image.fromPath "cat.png",
                                            horizontalOptions = LayoutOptions.Center,
                                            verticalOptions = LayoutOptions.CenterAndExpand
                                        )
                                        View.Label(
                                            text = "Cat",
                                            horizontalOptions = LayoutOptions.Center,
                                            verticalOptions = LayoutOptions.End
                                        )
                                    ])
                                ),
                                checkedChanged = onAnimalTemplateChecked Cat
                            )
                            View.RadioButton(
                                controlTemplate = RadioButton_ControlTemplates.radioButtonTemplate,
                                content = Content.fromElement(
                                    View.StackLayout([
                                        View.Image(
                                            source = Image.fromPath "dog.png",
                                            horizontalOptions = LayoutOptions.Center,
                                            verticalOptions = LayoutOptions.CenterAndExpand
                                        )
                                        View.Label(
                                            text = "Dog",
                                            horizontalOptions = LayoutOptions.Center,
                                            verticalOptions = LayoutOptions.End
                                        )
                                    ])
                                ),
                                checkedChanged = onAnimalTemplateChecked Dog
                            )
                            View.RadioButton(
                                controlTemplate = RadioButton_ControlTemplates.radioButtonTemplate,
                                content = Content.fromElement(
                                    View.StackLayout([
                                        View.Image(
                                            source = Image.fromPath "elephant.png",
                                            horizontalOptions = LayoutOptions.Center,
                                            verticalOptions = LayoutOptions.CenterAndExpand
                                        )
                                        View.Label(
                                            text = "Elephant",
                                            horizontalOptions = LayoutOptions.Center,
                                            verticalOptions = LayoutOptions.End
                                        )
                                    ])
                                ),
                                checkedChanged = onAnimalTemplateChecked Elephant
                            )
                            View.RadioButton(
                                controlTemplate = RadioButton_ControlTemplates.radioButtonTemplate,
                                content = Content.fromElement(
                                    View.StackLayout([
                                        View.Image(
                                            source = Image.fromPath "monkey.png",
                                            horizontalOptions = LayoutOptions.Center,
                                            verticalOptions = LayoutOptions.CenterAndExpand
                                        )
                                        View.Label(
                                            text = "Monkey",
                                            horizontalOptions = LayoutOptions.Center,
                                            verticalOptions = LayoutOptions.End
                                        )
                                    ])
                                ),
                                checkedChanged = onAnimalTemplateChecked Monkey
                            )
                        ]
                    )
                    View.Label(
                        match model.FavoriteAnimalTemplate with
                        | None -> "Please select one above"
                        | Some animal -> sprintf "You have chosen: %A" animal
                    )
                ])
        ) 
    
    let view model dispatch =
        match Device.RuntimePlatform with
        | Device.iOS | Device.Android ->
            radioButtonView model dispatch

        | _ -> 
            View.ContentPage(
                View.StackLayout [
                    View.Label(text = "Your Platform does not support RadioButton")
                ]
            )

