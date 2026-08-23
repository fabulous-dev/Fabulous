namespace Gallery.Samples

open System.Collections.ObjectModel
open Fabulous.Maui
open Gallery
open Microsoft.Maui.Controls

open type Fabulous.Maui.View

module GroupedCollectionView =
    type Contact = { FirstName: string; LastName: string }

    type ContactGroup(name: string, contacts: Contact list) =
        inherit ObservableCollection<Contact>(contacts)
        member _.Name = name

    type Model =
        { Groups: ContactGroup list
          SelectionCount: int }

    type Msg = SelectionChanged of SelectionChangedEventArgs

    let init () =
        { Groups =
            [ ContactGroup(
                  "Friends",
                  [ { FirstName = "Ada"
                      LastName = "Lovelace" }
                    { FirstName = "Grace"
                      LastName = "Hopper" } ]
              )
              ContactGroup(
                  "Team",
                  [ { FirstName = "Alan"
                      LastName = "Turing" }
                    { FirstName = "Edsger"
                      LastName = "Dijkstra" } ]
              ) ]
          SelectionCount = 0 }

    let update msg model =
        match msg with
        | SelectionChanged args ->
            { model with
                SelectionCount = args.CurrentSelection.Count }

    let view model =
        VStack() {
            Label($"Selected across groups: {model.SelectionCount}")

            (View.GroupedCollectionView
                model.Groups
                (fun group -> Label(group.Name).font(size = 20.))
                (fun contact -> Label($"{contact.FirstName} {contact.LastName}"))
                (fun group -> Label($"End of {group.Name}")))
                .selectionMode(SelectionMode.Multiple)
                .itemSizingStrategy(ItemSizingStrategy.MeasureAllItems)
                .onSelectionChanged(SelectionChanged)
        }

    let sample =
        { Name = "GroupedCollectionView"
          Description = "Multiple selection remains independent across groups"
          Program = Helper.createProgram init update view }
