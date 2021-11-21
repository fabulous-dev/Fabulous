namespace FabulousContacts

open System
open Xamarin.Forms
open Xamarin.Essentials
open Fabulous
open Fabulous.XamarinForms
open type Fabulous.XamarinForms.View
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

    let header contact =            
        VerticalStackLayout(
            spacing = 10.,
            children = [
                Label(contact.FirstName + " " + contact.LastName)
                    .font(size = 20., attributes = FontAttributes.Bold)
                    .textColor(accentTextColor)
                    .centerHorizontal()

                Grid([
                    getImageValueOrDefault "addphoto.png" Aspect.AspectFit contact.Picture
                        
                    Image("star.png", Aspect.AspectFit)
                        .isVisible(contact.IsFavorite)
                        .size(height = 35., width = 35.)
                        .alignStartHorizontal()
                        .alignStartVertical()
                ])
                    .size(height = 125., width = 125.)
                    .backgroundColor(Color.White)
                    .centerHorizontal()

                HorizontalStackLayout(
                    spacing = 20.,
                    children = [
                        if hasSetField contact.Phone then
                            detailActionButton "call.png" CallTapped
                            detailActionButton "sms.png" SmsTapped
                        if hasSetField contact.Email then
                            detailActionButton "email.png" EmailTapped
                    ]
                )
                    .centerHorizontal()
                    .margin(0., 10., 0., 10.)
            ]
        )
            .backgroundColor(Color.FromHex("#448cb8"))
            .paddingLayout(20., 10., 20., 10.)
            
    let body contact =
        VerticalStackLayout(
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
            .paddingLayout(20., 10., 20., 20.)

    let view model =
        ContentPage("Detail page",
            ScrollView(
                VerticalStackLayout(
                    spacing = 0.,
                    children = [
                        header model.Contact
                        body model.Contact
                    ]
                )
            )
        )
            .toolbarItems([
                ToolbarItem(Strings.DetailPage_Toolbar_EditContact, EditTapped)
                    .order(ToolbarItemOrder.Primary)
            ])