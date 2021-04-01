// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabimals.Components

open Fabulous.XamarinForms
open Xamarin.Forms
open Fabimals.Models
open Fabulous

module SearchHandlers =
    type Msg =
        | QueryChanged of string
        | AnimalSelected of Animal

    let animalSearchHandler animals dispatch =
        View.SearchHandler(
            placeholder="Enter search term",
            showsResults=true,
            queryChanged=(fun (_, newValue) -> dispatch (QueryChanged newValue)),
            itemSelected=(fun itemOpt ->
                match itemOpt with
                | Some (:? DynamicViewElement as item) ->
                    let animal = item.TryGetTag<Animal>().Value
                    dispatch (AnimalSelected animal)
                | _ -> ()),
            items=[
                for animal in animals do
                    yield View.Grid(
                        tag=animal,
                        padding=Thickness 10.,
                        coldefs=[ Stars 0.15; Stars 0.85],
                        children=[
                            View.Image(
                                source=Image.fromPath animal.ImageUrl,
                                aspect=Aspect.AspectFill,
                                height=40.,
                                width=40.
                            )
                            View.Label(
                                text=animal.Name,
                                fontAttributes=FontAttributes.Bold
                            ).Column(1)
                        ]
                    )
            ]
        )