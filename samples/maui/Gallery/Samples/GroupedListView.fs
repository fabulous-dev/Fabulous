namespace Gallery.Samples

open System.Collections.ObjectModel
open Fabulous.Maui
open Gallery

open type Fabulous.Maui.View

module GroupedListView =
    type Contact = { FirstName: string; LastName: string }

    type ContactGroup(name: string, contacts: Contact list) =
        inherit ObservableCollection<Contact>(contacts)
        member _.Name = name

    let groups =
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

    let view () =
        (View.GroupedListView (groups) (fun group -> TextCell(group.Name)) (fun contact -> TextCell($"{contact.FirstName} {contact.LastName}")))
            .hasUnevenRows(true)

    let sample =
        { Name = "GroupedListView"
          Description = "A ListView with reusable group and item templates"
          Program = Helper.createStatelessProgram view }
