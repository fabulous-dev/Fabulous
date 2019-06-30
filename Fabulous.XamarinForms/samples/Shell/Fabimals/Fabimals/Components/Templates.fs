// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabimals.Components

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Fabimals.Models

module Templates =
    let animalTemplate animal =
        dependsOn animal (fun _ animal ->
            View.Grid(
                tag=animal,
                padding=Thickness(10.),
                coldefs=["auto"; "auto"],
                rowdefs=["auto"; "auto"],
                children=[
                    View.Image(
                        source=animal.ImageUrl,
                        aspect=Aspect.AspectFill,
                        heightRequest=40.,
                        widthRequest=40.
                    ).GridRowSpan(2)
                    View.Label(
                        text=animal.Name,
                        fontAttributes=FontAttributes.Bold
                    ).GridColumn(1)
                    View.Label(
                        text=animal.Location,
                        fontAttributes=FontAttributes.Italic,
                        verticalOptions=LayoutOptions.End
                    ).GridRow(1).GridColumn(1)
                ]
            )
        )