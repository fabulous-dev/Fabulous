namespace HelloMap

open Fabulous
open Microsoft.Maui.Controls.Maps
open Microsoft.Maui.Devices.Sensors
open Microsoft.Maui.Graphics
open Microsoft.Maui.Maps
open Fabulous.Maui.Maps
open Fabulous.Maui

open type Fabulous.Maui.View

module App =

    type Model = { Position: Location }

    type Msg =
        | MapClicked of Location
        | MarkerClicked of bool

    let init () =
        { Position = Location(36.9628066, -122.0194722) }, Cmd.none

    let update msg model =
        match msg with
        | MapClicked _ -> model, Cmd.none
        | MarkerClicked _ -> model, Cmd.none

    let mapWithRegion () =
        Map(MapSpan.FromCenterAndRadius(Location(47.640663, -122.1376177), Distance.FromMiles(250.)))

    let mapWithPins () =
        let position = Location(36.9628066, -122.0194722)
        let mapSpan = MapSpan(position, 0.01, 0.01)

        (MapWithPins(mapSpan) {
            MapPin(position)
                .address("My Address1")
                .label("I'm a marker1")
                .pinType(PinType.Place)
                .onMarkerClicked(MarkerClicked)
                .onInfoWindowClicked(MarkerClicked)

            MapPin(Location(36.9641949, -122.0177232))
                .address("My Address2")
                .label("I'm a marker1")
                .pinType(PinType.Place)
                .onMarkerClicked(MarkerClicked)
                .onInfoWindowClicked(MarkerClicked)
        })

    let mapWithPolylineElement () =
        Map(MapSpan.FromCenterAndRadius(Location(47.640663, -122.1376177), Distance.FromMiles(1.)))
            .mapElements() {
            MapPolyline(
                [ Location(47.6381401, -122.1317367)
                  Location(47.6381473, -122.1350841)
                  Location(47.6382847, -122.1353094)
                  Location(47.6384582, -122.1354703)
                  Location(47.6401136, -122.1360819)
                  Location(47.6403883, -122.1364681)
                  Location(47.6407426, -122.1377019)
                  Location(47.6412558, -122.1404056)
                  Location(47.6414148, -122.1418647)
                  Location(47.6414654, -122.1432702) ]
            )
                .strokeColor(Colors.Blue)
                .strokeWidth(12.)
        }

    let mapWihCircleElement () =
        Map(MapSpan(Location(37.79752, -122.40183), 0.01, 0.01)).mapElements() {
            MapCircle(Location(37.79752, -122.40183), Distance(250.))
                .fillColor(Color.FromArgb("#88FFC0CB"))
                .strokeColor(Color.FromArgb("#88FF0000"))
                .strokeWidth(8.)
        }

    let mapWithPolygonElement () =
        Map(MapSpan.FromCenterAndRadius(Location(47.640663, -122.1376177), Distance.FromMiles(1.)))
            .mapElements() {
            MapPolygon(
                [ Location(47.6458676, -122.1356007)
                  Location(47.6458097, -122.142789)
                  Location(47.6367593, -122.1428104)
                  Location(47.6368027, -122.1398707)
                  Location(47.6380172, -122.1376177)
                  Location(47.640663, -122.1352359)
                  Location(47.6426148, -122.1347209)
                  Location(47.6458676, -122.1356007) ]
            )
                .strokeWidth(8.)
                .fillColor(Colors.Red)
                .strokeColor(Colors.Blue)

            MapPolygon(
                [ Location(47.6458676, -122.1356007)
                  Location(47.6458097, -122.142789)
                  Location(47.6367593, -122.1428104)
                  Location(47.6368027, -122.1398707)
                  Location(47.6380172, -122.1376177)
                  Location(47.640663, -122.1352359)
                  Location(47.6426148, -122.1347209)
                  Location(47.6458676, -122.1356007) ]
            )
                .strokeWidth(8.)
                .fillColor(Colors.Yellow)
                .strokeColor(Colors.Black)

            MapPolygon(
                [ Location(47.6381401, -122.1317367)
                  Location(47.6381473, -122.1350841)
                  Location(47.6382847, -122.1353094)
                  Location(47.6384582, -122.1354703)
                  Location(47.6401136, -122.1360819)
                  Location(47.6403883, -122.1364681)
                  Location(47.6407426, -122.1377019)
                  Location(47.6412558, -122.1404056)
                  Location(47.6414148, -122.1418647)
                  Location(47.6414654, -122.1432702) ]
            )
                .strokeWidth(12.)
                .strokeColor(Colors.Black)
        }


    let view (_: Model) =
        Application(
            (TabbedPage() {
                ContentPage(mapWithRegion()).title("Region")
                ContentPage(mapWithPins()).title("Pins")
                ContentPage(mapWihCircleElement()).title("Circle")
                ContentPage(mapWithPolylineElement()).title("Polyline")

                ContentPage(
                    mapWithPolygonElement()
                        .isZoomEnabled(true)
                        .isScrollEnabled(true)
                        .mapType(MapType.Street)
                        .isShowingUser(true)
                        .isTrafficEnabled(true)
                        .onMapClicked(MapClicked)
                )
                    .title("Polygons")
            })
                .ignoreSafeArea()
        )

    let program = Program.statefulWithCmd init update view
