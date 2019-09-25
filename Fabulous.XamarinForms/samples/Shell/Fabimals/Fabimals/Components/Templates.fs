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
                padding=Thickness.Uniform 10.,
                coldefs=[ RowOrColumn.Auto; RowOrColumn.Auto],
                rowdefs=[ RowOrColumn.Auto; RowOrColumn.Auto ],
                children=[
                    View.Image(
                        source=Image.Path animal.ImageUrl,
                        aspect=Aspect.AspectFill,
                        height=40.,
                        width=40.
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