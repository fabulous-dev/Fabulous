// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabimals.Components

open Fabulous.DynamicViews
open Xamarin.Forms
open Fabimals.Models

module AnimalDetails =
    type Msg = NoOp
    type CmdMsg = NoOp
    type ExternalMsg = NoOp
    
    type Model =
        { Type: AnimalType
          Name: string
          Location: string
          ImageUrl: string
          Details: string }
    
    let init (animal: Animal)=
        { Type = animal.Type
          Name = animal.Name
          Location = animal.Location
          ImageUrl = animal.ImageUrl
          Details = animal.Details }
    
    let view model =
        dependsOn (model.Name, model.Location, model.ImageUrl, model.Details) (fun model (name, location, imageUrl, details) ->
            // Currently Fabulous needs to handle its own ContentPage to support Routing inside Shell
            // This is a limitation of Xamarin.Forms. Might change in the future (https://github.com/xamarin/Xamarin.Forms/issues/5166)
            // So for now, we only declare the content of the page

            View.ScrollView(
                View.StackLayout(
                    margin=Thickness(20.),
                    children=[
                        View.Label(
                            text=name,
                            horizontalOptions=LayoutOptions.Center,
                            style=Device.Styles.TitleStyle
                        )
                        View.Label(
                            text=location,
                            fontAttributes=FontAttributes.Italic,
                            horizontalOptions=LayoutOptions.Center
                        )
                        View.Image(
                            source=imageUrl,
                            widthRequest=200.,
                            heightRequest=200.,
                            horizontalOptions=LayoutOptions.CenterAndExpand
                        )
                        View.Label(
                            text=details,
                            style=Device.Styles.BodyStyle
                        )
                    ]
                )
            )
        )