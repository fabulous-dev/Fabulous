namespace Fabimals.Components

open Fabulous.DynamicViews
open Fabimals.Models
open Fabimals.Components
open Xamarin.Forms

module AnimalList =
    type Msg =
        | SearchHandlerMsg of SearchHandlers.Msg
        | SelectAnimal of Animal
        
    type CmdMsg = NoOp
        
    type ExternalMsg =
        | NavigateToDetails of Animal

    type Model =
        { PageTitle: string
          IsTopBarDisplayed: bool
          AllAnimals: Animal list
          FilteredAnimals: Animal list }

    let init title isTopBarDisplayed data =
        { PageTitle = title; IsTopBarDisplayed = isTopBarDisplayed; AllAnimals = data; FilteredAnimals = [] }

    let update msg model : Model * CmdMsg list * ExternalMsg list =
        match msg with
        | SearchHandlerMsg (SearchHandlers.Msg.QueryChanged newValue) ->
            let filteredAnimals = model.AllAnimals |> List.filter (fun a -> a.Name.ToLower().Contains(newValue.ToLower()))
            { model with FilteredAnimals = filteredAnimals }, [], []
        | SearchHandlerMsg (SearchHandlers.Msg.AnimalSelected animal) ->
            model, [], [(NavigateToDetails animal)]
        | SelectAnimal animal ->
            model, [], [(NavigateToDetails animal)]

    let navigateToAfterSelectionChanged dispatch (args: SelectionChangedEventArgs) =
        match args.CurrentSelection |> Seq.tryHead with
        | None -> ()
        | Some item ->
            let data = item :?> ItemListElementData
            let animal = data.Key.GetAttributeKeyed(ViewAttributes.TagAttribKey) :?> Animal
            dispatch (SelectAnimal animal)

    let view model dispatch =
        dependsOn (model.PageTitle, model.IsTopBarDisplayed, model.AllAnimals, model.FilteredAnimals) (fun model (pageTitle, isTopBarDisplayed, allAnimals, filteredAnimals) ->
            let contentMargin =
                match isTopBarDisplayed, Xamarin.Forms.Device.RuntimePlatform with
                | true, Device.iOS -> Thickness(0., 40., 0., 0.)
                | _ -> Thickness(0.)

            View.ContentPage(
                title=pageTitle,
                shellSearchHandler=(SearchHandlers.animalSearchHandler filteredAnimals (SearchHandlerMsg >> dispatch)),
                content=View.CollectionView(
                    margin=contentMargin,
                    selectionMode=SelectionMode.Single,
                    selectionChanged=(navigateToAfterSelectionChanged dispatch),
                    items=(allAnimals |> List.map Templates.animalTemplate)
                )
            )
        )