namespace FabulousContacts

open System
open Xamarin.Forms
open Xamarin.Essentials
open Fabulous
open Fabulous.XamarinForms
open FabulousContacts.Components
open FabulousContacts.Helpers
open FabulousContacts.Models
open FabulousContacts.Style

module DetailPage =
    // Declarations
    type Msg =
        | EditTapped
        | CallTapped
        | SmsTapped
        | EmailTapped
        | ContactUpdated of Contact

    type ExternalMsg =
        | NoOp
        | EditContact of Contact

    type Model =
        { Contact: Contact }

    // Functions
    let hasSetField = not << String.IsNullOrWhiteSpace

    let tryDialNumberAsync phoneNumber = async {
        try
            PhoneDialer.Open(phoneNumber)
        with
        | :? FeatureNotSupportedException ->
            do! displayAlert(Strings.DetailPage_DialNumberFailed, Strings.DetailPage_CapabilityNotSupported "Phone Dialer", Strings.Common_OK)
        | _ ->
            do! displayAlert(Strings.DetailPage_DialNumberFailed, Strings.Common_Error, Strings.Common_OK)
    }

    let tryComposeSmsAsync (phoneNumber: string) = async {
        try
            let message = SmsMessage("", phoneNumber)
            do! Sms.ComposeAsync(message) |> Async.AwaitTask
        with
        | :? FeatureNotSupportedException ->
            do! displayAlert(Strings.DetailPage_ComposeSmsFailed, Strings.DetailPage_CapabilityNotSupported "SMS", Strings.Common_OK)
        | _ ->
            do! displayAlert(Strings.DetailPage_ComposeSmsFailed, Strings.Common_Error, Strings.Common_OK)
    }

    let tryComposeEmailAsync emailAddress = async {
        try
            let message = EmailMessage("", "", [| emailAddress |])
            do! Email.ComposeAsync(message) |> Async.AwaitTask
        with
        | :? FeatureNotSupportedException ->
            do! displayAlert(Strings.DetailPage_ComposeEmailFailed, Strings.DetailPage_CapabilityNotSupported "Email", Strings.Common_OK)
        | _ ->
            do! displayAlert(Strings.DetailPage_ComposeEmailFailed, Strings.Common_Error, Strings.Common_OK)
    }

    // Lifecycle
    let init (contact: Contact) =
        { Contact = contact }, Cmd.none

    let update msg model =
        match msg with
        | EditTapped ->
            model, Cmd.none, ExternalMsg.EditContact model.Contact
        | CallTapped ->
            let dialCmd = Cmd.performAsync (tryDialNumberAsync model.Contact.Phone)
            model, dialCmd, ExternalMsg.NoOp
        | SmsTapped ->
            let smsCmd = Cmd.performAsync (tryComposeSmsAsync model.Contact.Phone)
            model, smsCmd, ExternalMsg.NoOp
        | EmailTapped ->
            let emailCmd = Cmd.performAsync (tryComposeEmailAsync model.Contact.Email)
            model, emailCmd, ExternalMsg.NoOp
        | ContactUpdated contact ->
            { model with Contact = contact }, Cmd.none, ExternalMsg.NoOp

    let header contact callContact sendSmsToContact sendEmailToContact =
        let contactPicture = contact.Picture |> getImageValueOrDefault "addphoto.png"
            
        View.StackLayout(
            backgroundColor = Color.FromHex("#448cb8"),
            padding = Thickness(20., 10., 20., 10.),
            spacing = 10.,
            children = [
                View.Label(
                    text = contact.FirstName + " " + contact.LastName,
                    fontSize = FontSize.fromValue 20.,
                    fontAttributes = FontAttributes.Bold,
                    textColor = accentTextColor,
                    horizontalOptions = LayoutOptions.Center
                )

                View.Grid(
                    width = 125.,
                    height = 125.,
                    backgroundColor = Color.White,
                    horizontalOptions = LayoutOptions.Center,
                    children = [
                        View.Image(
                            source = contactPicture,
                            aspect = Aspect.AspectFill
                        )
                        
                        View.Image(
                            source = Image.fromPath "star.png",
                            isVisible = contact.IsFavorite,
                            height = 35.,
                            width = 35.,
                            horizontalOptions = LayoutOptions.Start,
                            verticalOptions = LayoutOptions.Start
                        )
                    ]
                )

                View.StackLayout(
                    horizontalOptions = LayoutOptions.Center,
                    orientation = StackOrientation.Horizontal,
                    margin = Thickness(0., 10., 0., 10.),
                    spacing = 20.,
                    children = [
                        if hasSetField contact.Phone then
                            yield detailActionButton "call.png" callContact
                            yield detailActionButton "sms.png" sendSmsToContact
                        if hasSetField contact.Email then
                            yield detailActionButton "email.png" sendEmailToContact
                    ]
                )
            ]
        )
            
    let body contact =
        View.StackLayout(
            padding = Thickness(20., 10., 20., 20.),
            spacing = 10.,
            children = [
                detailFieldTitle "Email"
                optionalLabel contact.Email
                detailFieldTitle "Phone"
                optionalLabel contact.Phone
                detailFieldTitle "Address"
                optionalLabel contact.Address
            ]
        )

    let view model dispatch =
        dependsOn model.Contact (fun model contact ->
            // Actions
            let editContact = fun () -> dispatch EditTapped
            let callContact = fun () -> dispatch CallTapped
            let sendSmsToContact = fun () -> dispatch SmsTapped
            let sendEmailToContact = fun () -> dispatch EmailTapped
            
            // View
            View.ContentPage(
                toolbarItems = [
                    View.ToolbarItem(
                        order = ToolbarItemOrder.Primary,
                        text = Strings.DetailPage_Toolbar_EditContact,
                        command = editContact
                    )
                ],
                content = View.ScrollView(
                    content = View.StackLayout(
                        spacing = 0.,
                        children = [
                            header contact callContact sendSmsToContact sendEmailToContact
                            body contact
                        ]
                    )
                )
            )
        )