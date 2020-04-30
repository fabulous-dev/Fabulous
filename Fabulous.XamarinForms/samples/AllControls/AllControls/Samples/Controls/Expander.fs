namespace AllControls.Samples.Controls

open Xamarin.Forms
open Fabulous.XamarinForms
open AllControls.Helpers

module Expander =    
    type Msg =
        | ToggleExpand
        
    type Model =
        { IsExpanded: bool }
    
    let init () =
        { IsExpanded = false }
    
    let update msg model =
        match msg with
        | ToggleExpand -> { model with IsExpanded = not model.IsExpanded }
        
    let expanderView model dispatch =
        let loadEmbeddedImage path =
            ImageSrc (ImageSource.FromResource((sprintf "AllControls.%s" path), typeof<Msg>.Assembly))
        
        View.NonScrollingContentPage(
            title = "Expander sample",
            content =
                View.StackLayout([
                    View.Expander(
                        isExpanded = model.IsExpanded,
                        tapped = (fun _ -> dispatch ToggleExpand),
                        header =
                            View.Grid([
                                View.Label(
                                    text = "Baboon",
                                    fontAttributes = FontAttributes.Bold,
                                    fontSize = Named NamedSize.Medium
                                )
                                View.Image(
                                    source = (if model.IsExpanded then loadEmbeddedImage "collapse.png" else loadEmbeddedImage "expand.png"),
                                    horizontalOptions = LayoutOptions.End,
                                    verticalOptions = LayoutOptions.Start
                                )
                            ]),
                        content =
                            View.Grid(
                                padding = Thickness(10.),
                                coldefs = [ Auto; Auto ],
                                children = [
                                    View.Image(
                                        source = ImagePath "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg",
                                        aspect = Aspect.AspectFill,
                                        height = 120.,
                                        width = 120.
                                    )
                                    View.Label(
                                        text = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
                                        fontAttributes = FontAttributes.Italic
                                    ).Column(1)
                                ]
                            )
                    )
                ])
        ) 
    
    let view model dispatch =
        match Device.RuntimePlatform with
        | Device.iOS | Device.Android ->
            expanderView model dispatch

        | _ -> 
            View.ContentPage(
                View.StackLayout [
                    View.Label(text = "Your Platform does not support Expander")
                ]
            )

