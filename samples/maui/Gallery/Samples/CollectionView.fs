namespace Gallery.Samples

open Fabulous.Maui
open Gallery
open Microsoft.Maui.Controls

open type Fabulous.Maui.View

module CollectionView =
    type Animal = { Name: string; Species: string }

    type Model =
        { Animals: Animal list
          Selection: string }

    type Msg = SelectionChanged of SelectionChangedEventArgs

    let init () =
        { Animals =
            [ { Name = "Dog"
                Species = "Canis familiaris" }
              { Name = "Cat"
                Species = "Felis catus" }
              { Name = "Mouse"
                Species = "Mus musculus" } ]
          Selection = "None" }

    let update msg model =
        match msg with
        | SelectionChanged args ->
            let selection =
                args.CurrentSelection
                |> Seq.tryHead
                |> Option.map(fun value -> (value :?> Animal).Name)
                |> Option.defaultValue "None"

            { model with Selection = selection }

    let view model =
        VStack() {
            Label($"Selected: {model.Selection}")

            (View.CollectionView (model.Animals) (fun animal -> Label($"{animal.Name} ({animal.Species})")))
                .selectionMode(SelectionMode.Single)
                .itemSizingStrategy(ItemSizingStrategy.MeasureAllItems)
                .onSelectionChanged(SelectionChanged)
        }

    let sample =
        { Name = "CollectionView"
          Description = "An immutable CollectionView with selection handling"
          Program = Helper.createProgram init update view }
