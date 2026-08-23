namespace Gallery.Samples

open Fabulous.Maui
open Gallery

open type Fabulous.Maui.View

module ListView =
    type Animal = { Name: string; Species: string }

    type Model =
        { Animals: Animal list
          SelectedIndex: int }

    type Msg = Selected of int

    let init () =
        { Animals =
            [ { Name = "Dog"
                Species = "Canis familiaris" }
              { Name = "Cat"
                Species = "Felis catus" }
              { Name = "Mouse"
                Species = "Mus musculus" } ]
          SelectedIndex = -1 }

    let update msg model =
        match msg with
        | Selected index -> { model with SelectedIndex = index }

    let view model =
        VStack() {
            Label($"Selected index: {model.SelectedIndex}")
            (View.ListView (model.Animals) (fun animal -> TextCell($"{animal.Name} ({animal.Species})"))).onItemSelected(Selected)
        }

    let sample =
        { Name = "ListView"
          Description = "An immutable list rendered with reusable cell templates"
          Program = Helper.createProgram init update view }
