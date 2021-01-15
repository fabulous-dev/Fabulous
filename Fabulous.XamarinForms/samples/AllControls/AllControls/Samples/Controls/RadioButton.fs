namespace AllControls.Samples.Controls

open Xamarin.Forms
open Fabulous.XamarinForms
open AllControls.Helpers

module RadioButton =
    type TransportMode =
        | Car
        | Bike
        | Train
        | Walking
        
    type PetKind =
        | Cat
        | Dog
        | NoPet
    
    type Msg =
        | SelectTransportMode of TransportMode
        | SelectPetKind of PetKind
        
    type Model =
        { TransportMode: TransportMode option
          PetKind: PetKind option }
    
    let init () =
        { TransportMode = None
          PetKind = None }
    
    let update msg model =
        match msg with
        | SelectTransportMode mode -> { model with TransportMode = Some mode }
        | SelectPetKind kind -> { model with PetKind = Some kind }
        
    let radioButtonView model dispatch =
        let onTransportModeChecked mode (args: CheckedChangedEventArgs) =
            if args.Value then
                dispatch (SelectTransportMode mode)
                
        let onPetKindChecked kind (args: CheckedChangedEventArgs) =
            if args.Value then
                dispatch (SelectPetKind kind)
        
        View.NonScrollingContentPage(
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
                        content = "Car",
                        checkedChanged = onTransportModeChecked Car
                    )
                    View.RadioButton(
                        content = "Bike",
                        checkedChanged = onTransportModeChecked Bike
                    )
                    View.RadioButton(
                        content = "Train",
                        checkedChanged = onTransportModeChecked Train
                    )
                    View.RadioButton(
                        content = "Walking",
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
                        content = "Cat",
                        groupName = "Pet",
                        isChecked = (model.PetKind = Some Cat),
                        checkedChanged = onPetKindChecked Cat
                    )
                    View.RadioButton(
                        content = "Dog",
                        groupName = "Pet",
                        isChecked = (model.PetKind = Some Dog),
                        checkedChanged = onPetKindChecked Dog
                    )
                    View.RadioButton(
                        content = "I don't have pets",
                        groupName = "Pet",
                        isChecked = (model.PetKind = Some NoPet),
                        checkedChanged = onPetKindChecked NoPet
                    )
                    View.Button(
                        text = "Cats rulez!",
                        command = (fun () -> dispatch (SelectPetKind Cat))
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

