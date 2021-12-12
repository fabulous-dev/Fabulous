namespace FabulousContacts

open Fabulous
open Fabulous.XamarinForms
open FabulousContacts.Models
open FabulousContacts.Style
open type Fabulous.XamarinForms.View

module ContactsListPage =
    // Declarations
    type Msg =
        | AboutTapped
        | AddNewContactTapped
        | UpdateFilterText of string
        | Search
        | ContactsLoaded of Contact list
        | ContactSelected of Contact

    type ExternalMsg =
        | NoOp
        | NavigateToAbout
        | NavigateToNewContact
        | NavigateToDetail of Contact

    type Model =
        { Contacts: Contact list
          FilterText: string
          FilteredContacts: Contact list }

    // Functions
    let filterContacts filterText (contacts: Contact list) =
        match filterText with
        | null | "" ->
            contacts
        | s ->
            contacts
            |> List.filter (fun c -> c.FirstName.Contains s || c.LastName.Contains s)

    let groupContacts contacts =
        contacts
        |> List.groupBy (fun c -> c.LastName.[0].ToString().ToUpper())
        |> List.map (fun (k, cs) -> (k, cs |> List.sortBy (fun c -> c.FirstName)))
        |> List.sortBy (fun (k, _) -> k)

    let findContactIn (groupedContacts: (string * Contact list) list) (gIndex: int, iIndex: int) =
        groupedContacts.[gIndex]
        |> (fun (_, items) -> items.[iIndex])

    // Lifecycle
    let initModel =
        { Contacts = []
          FilterText = ""
          FilteredContacts = [] }
    
    let init () =
        initModel, Cmd.none

    let update msg model =
        match msg with
        | AboutTapped ->
            model, Cmd.none, ExternalMsg.NavigateToAbout

        | AddNewContactTapped ->
            model, Cmd.none, ExternalMsg.NavigateToNewContact

        | UpdateFilterText filterText ->
            let filteredContacts = filterContacts filterText model.Contacts
            let m = { model with FilterText = filterText; FilteredContacts = filteredContacts }
            m, Cmd.none, ExternalMsg.NoOp

        | ContactsLoaded contacts ->
            let filteredContacts = filterContacts model.FilterText contacts
            let m = { model with Contacts = contacts; FilteredContacts = filteredContacts }
            m, Cmd.none, ExternalMsg.NoOp

        | ContactSelected contact ->
            model, Cmd.none, ExternalMsg.NavigateToDetail contact

        | Search ->
            model, Cmd.none, ExternalMsg.NoOp

    let view title model =
        ContentPage(title,
            (VerticalStackLayout(spacing = 0.) {
                SearchBar(model.FilterText, UpdateFilterText, Search)
                    .backgroundColor(accentColor)
                    .cancelButtonColor(accentTextColor)
                    
                //ListViewGrouped(groupedContacts, fun (groupName, items) ->
                    
                //)
                //    .rowHeight(60)
                //    .showJumpList(model.Contacts.Length > 10)
                //    .selectionMode(ListViewSelectionMode.None)
                //    .itemTapped(ContactSelected)
                //    .verticalOptions(LayoutOptions.FillAndExpand)

                    //items = [
                    //    for (groupName, items) in groupedContacts do
                    //        yield groupName, groupView groupName, [
                    //            for contact in items do
                    //                let address = contact.Address.Replace("\n", " ")
                    //                yield cachedCell contact address
                    //            ]
                    //]
            })
        )
            .toolbarItems() {
                ToolbarItem(Strings.Common_About, AboutTapped)
                ToolbarItem("+", AddNewContactTapped)
            }