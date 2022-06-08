namespace FabulousContacts

open System
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Essentials
open Xamarin.Forms.Maps

open FabulousContacts.Helpers
open FabulousContacts.Models
open FabulousContacts.Controls
open FabulousContacts.Components

open type Fabulous.XamarinForms.View

module MapPage =
    // Declarations
    type ContactPin =
        { Position: Position
          Label: string
          PinType: PinType
          Address: string }

    type Msg =
        | LoadPins of Contact list
        | RetrieveUserPosition
        | PinsLoaded of ContactPin list
        | UserPositionRetrieved of (double * double)

    type Model =
        { Pins: ContactPin list option
          UserPosition: (double * double) option }

    // Functions
    let tryGetUserPositionAsync () =
        async {
            try
                let! location =
                    Geolocation.GetLastKnownLocationAsync()
                    |> Async.AwaitTask

                return
                    location
                    |> Option.ofObj
                    |> Option.map(fun l -> UserPositionRetrieved(l.Latitude, l.Longitude))
            with
            | _ -> return None
        }
        |> Cmd.ofAsyncMsgOption

    let loadPinsAsync (contacts: Contact list) =
        async {
            try
                let geocoder = Geocoder()

                let gettingPositions =
                    contacts
                    |> List.filter(fun c -> c.Address |> (not << String.IsNullOrWhiteSpace))
                    |> List.map
                        (fun c ->
                            async {
                                try
                                    let! positions =
                                        geocoder.GetPositionsForAddressAsync(c.Address)
                                        |> Async.AwaitTask

                                    let position = positions |> Seq.tryHead
                                    return Some(c, position)
                                with
                                | _ -> return None
                            })
                    |> Async.Parallel

                let! contactsAndPositions = gettingPositions

                let pins =
                    contactsAndPositions
                    |> Array.filter Option.isSome
                    |> Array.map(fun v -> v.Value)
                    |> Array.filter(snd >> Option.isSome)
                    |> Array.map
                        (fun (c, p) ->
                            { Position = p.Value
                              Label = $"%s{c.FirstName} %s{c.LastName}"
                              PinType = PinType.Place
                              Address = c.Address })
                    |> Array.toList

                return Some(PinsLoaded pins)
            with
            | exn ->
                do! displayAlert(Strings.MapPage_MapLoadFailed, exn.Message, Strings.Common_OK)
                return None
        }
        |> Async.executeOnMainThread
        |> Cmd.ofAsyncMsgOption

    let paris = Position(48.8566, 2.3522)

    let getUserPositionOrDefault (userPosition: (double * double) option) =
        userPosition
        |> Option.map Position
        |> Option.defaultValue paris

    // Lifecycle
    let initModel = { Pins = None; UserPosition = None }

    let init () = initModel, Cmd.none

    let update msg model =
        match msg with
        | LoadPins contacts -> model, loadPinsAsync contacts

        | RetrieveUserPosition -> model, tryGetUserPositionAsync()

        | PinsLoaded pins -> { model with Pins = Some pins }, Cmd.none

        | UserPositionRetrieved location ->
            { model with
                  UserPosition = Some location },
            Cmd.none

    let view model =
        let map userPositionOpt pins =
            let requestedRegion =
                MapSpan.FromCenterAndRadius(getUserPositionOrDefault userPositionOpt, Distance.FromKilometers(25.))

            (Map(requestedRegion) {
                for pin in pins do
                    Pin(pin.PinType, pin.Label, pin.Position)
                        .address(pin.Address)
             })
                .withZoom()
                .withScroll()

        ContentPage(
            Strings.MapPage_Title,
            match model.Pins with
            | None -> AnyView(centralLabel Strings.MapPage_Loading)
            | Some pins -> AnyView(map model.UserPosition pins)
        )
            .icon("maptab.png")
            .onAppearing(RetrieveUserPosition)
