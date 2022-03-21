namespace FabulousContacts

open Fabulous
open Fabulous.XamarinForms
open FabulousContacts.Components
open FabulousContacts.Models
open FabulousContacts.Style
open Xamarin.Forms

open type Fabulous.XamarinForms.View
open System.Collections.ObjectModel

module ContactsListPage =
    type ContactGroup(name: string, contacts: Contact list) =
        inherit ObservableCollection<Contact>(contacts)
        member _.ShortName = name.[0]
        member _.Name = name

    // Declarations
    type Msg =
        | AboutTapped
        | AddNewContactTapped
        | UpdateFilterText of string
        | Search
        | ContactsLoaded of Contact list
        | ContactSelected of int

    type ExternalMsg =
        | NoOp
        | NavigateToAbout
        | NavigateToNewContact
        | NavigateToDetail of Contact

    type Model =
        { Contacts: Contact list
          FilterText: string
          ContactGroups: ObservableCollection<ContactGroup> }

    // Functions
    let filterContacts filterText (contacts: Contact list) =
        let filteredContacts =
            match filterText with
            | null
            | "" -> contacts
            | s ->
                contacts
                |> List.filter (fun c -> c.FirstName.Contains s || c.LastName.Contains s)

        filteredContacts
        |> List.groupBy (fun c -> c.LastName.[0].ToString().ToUpper())
        |> List.map (fun (k, cs) -> ContactGroup(k, cs |> List.sortBy (fun c -> c.FirstName)))
        |> List.sortBy (fun cg -> cg.Name)
        |> ObservableCollection<_>

    let findContactIn (groupedContacts: ObservableCollection<ContactGroup>) (index: int) =
        let mutable i = index
        let mutable foundContact = Unchecked.defaultof<Contact>

        for group in groupedContacts do
            i <- i - 1

            for contact in group do
                if i = 0 then foundContact <- contact
                i <- i - 1

        foundContact

    // Lifecycle
    let initModel =
        { Contacts = []
          FilterText = ""
          ContactGroups = ObservableCollection<ContactGroup>() }

    let init () = initModel, Cmd.none

    let update msg model =
        match msg with
        | AboutTapped -> model, Cmd.none, ExternalMsg.NavigateToAbout

        | AddNewContactTapped -> model, Cmd.none, ExternalMsg.NavigateToNewContact

        | UpdateFilterText filterText ->
            let contactGroups = filterContacts filterText model.Contacts

            let m =
                { model with
                      FilterText = filterText
                      ContactGroups = contactGroups }

            m, Cmd.none, ExternalMsg.NoOp

        | ContactsLoaded contacts ->
            let contactGroups = filterContacts model.FilterText contacts

            let m =
                { model with
                      Contacts = contacts
                      ContactGroups = contactGroups }

            m, Cmd.none, ExternalMsg.NoOp

        | ContactSelected index ->
            let contact = findContactIn model.ContactGroups index
            model, Cmd.none, ExternalMsg.NavigateToDetail(contact)

        | Search -> model, Cmd.none, ExternalMsg.NoOp

    let view title model =
        ContentPage(
            title,
            (VStack(spacing = 0.) {
                SearchBar(model.FilterText, UpdateFilterText, Search)
                    .backgroundColor(accentColor)
                    .cancelButtonColor (accentTextColor)

                (GroupedListView
                    (model.ContactGroups)
                    (fun group -> groupView group.Name)
                    (fun contact ->
                        cellView
                            contact.Picture
                            $"{contact.FirstName} {contact.LastName}"
                            contact.Address
                            contact.IsFavorite))
                    .rowHeight(60)
                    .selectionMode(ListViewSelectionMode.None)
                    .onItemTapped(ContactSelected)
                    .fillVertical (expand = true)
             })
        )
            .toolbarItems () {
            ToolbarItem(Strings.Common_About, AboutTapped)
            ToolbarItem("+", AddNewContactTapped)
        }
