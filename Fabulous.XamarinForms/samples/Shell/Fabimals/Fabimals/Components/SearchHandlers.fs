// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabimals.Components

open Fabulous.DynamicViews
open Xamarin.Forms
open Fabimals.Models

module SearchHandlers =
    type Msg =
        | QueryChanged of string
        | AnimalSelected of Animal

    let animalSearchHandler animals dispatch =
        View.SearchHandler(
            placeholder="Enter search term",
            showsResults=true,
            queryChanged=(fun (_, newValue) -> dispatch (QueryChanged newValue)),
            itemSelected=(fun item ->
                let data = item :?> ItemListElementData
                let animal = data.Key.GetAttributeKeyed(ViewAttributes.TagAttribKey) :?> Animal
                dispatch (AnimalSelected animal)),
            items=[
                for animal in animals do
                    yield View.Grid(
                        tag=animal,
                        padding=Thickness(10.),
                        coldefs=["0.15*"; "0.85*"],
                        children=[
                            View.Image(
                                source=animal.ImageUrl,
                                aspect=Aspect.AspectFill,
                                heightRequest=40.,
                                widthRequest=40.
                            )
                            View.Label(
                                text=animal.Name,
                                fontAttributes=FontAttributes.Bold
                            ).GridColumn(1)
                        ]
                    )
            ]
        )