## Maps for Fabulous.MauiControls

[![build](https://github.com/fsharp-mobile/Fabulous.MauiControls.Maps/actions/workflows/build.yml/badge.svg)](https://github.com/fsharp-mobile/Fabulous.MauiControls.Maps/actions/workflows/dotnet.yml) [![Fabulous.MauiControls.Maps NuGet version](https://badge.fury.io/nu/Fabulous.MauiControls.Maps.svg)](https://badge.fury.io/nu/Fabulous.MauiControls.Maps) [![Discord](https://img.shields.io/discord/716980335593914419?label=discord&logo=discord)](https://discord.gg/bpTJMbSSYK)

The Map control is a cross-platform view for displaying and annotating maps. You can find all the details about this control on the [.NET MAUI Maps documentation](https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/appmodel/maps).

### How to use

1. Add the [Fabulous.MauiControls.Maps package](https://www.nuget.org/packages/Fabulous.MauiControls.Maps) to your project.

2. Add `.UseFabulousMaps()` to your `MauiProgram` after `.UseFabulousApp()`.

```f#
open Fabulous.Maui.Maps

type MauiProgram =
    static member CreateMauiApp() =
        MauiApp
            .CreateBuilder()
            .UseFabulousApp(App.program)
            .UseFabulousMaps()
            (...)
            .Build()
```

2. Open Fabulous.Maui.Maps at the top of the file where you declare your Fabulous program (eg. Program.stateful).

```f#
open Fabulous.Maui.Maps
```

3. Depending on which platform you're targeting, you might need to do some configuration before the map widget will work. See "Initialization and Configuration" down below.

### Initialization and Configuration
The Map widget will be rendered by the native map controls of each platform depending on the device you're running on. Some of those platforms require that you make some configuration before being able to use the `Map` widget.

Please follow the .NET MAUI documentation to learn about the requirements: [.NET MAUI Map Get Started](https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/appmodel/maps#get-started)

### Usage
This package adds several widgets for you to use:
- `Map(region: MapSpan)` : Displays a map centered on the position specified
- `MapWithPins(region: MapSpan) { MapPin; MapPin; ... }` : Displays a map with some pins on it

To learn more about the capabilities of the Map and MapWithPins widgets, see [.NET MAUI Map Control](https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/appmodel/maps).

```f#
Map(MapSpan.FromCenterAndRadius(Position(47.640663, -122.1376177), Distance.FromMiles(250.)))
    .hasZoomEnabled(true)
    .hasScrollEnabled(true)
    .mapType(MapType.Street)
    .isShowingUser(true)
    .isTrafficEnabled(true)
    .onMapClicked (MapClicked)
```
```f#
let position = Position(36.9628066, -122.0194722)
let mapSpan = MapSpan(position, 0.01, 0.01)

(MapWithPins(mapSpan) {
    MapPin(position)
        .address("My Address1")
        .label("I'm a marker1")
        .pinType(PinType.Place)
        .onMarkerClicked(MarkerClicked)
        .onInfoWindowClicked (MarkerClicked)

    MapPin(Position(36.9641949, -122.0177232))
        .address("My Address2")
        .label("I'm a marker1")
        .pinType(PinType.Place)
        .onMarkerClicked(MarkerClicked)
        .onInfoWindowClicked (MarkerClicked)
})
```
It is also possible to draw shapes directly on the map using the `.mapElements() { ... }` modifier.  
It supports several shapes: `MapCircle`, `MapPolygon`, `MapPolyline`.

```f#
Map(MapSpan.FromCenterAndRadius(Position(47.640663, -122.1376177), Distance.FromMiles(1.)))
    .mapElements () {
        // Draw a polygon on the map
        MapPolygon(
            [ Position(47.6458676, -122.1356007)
              Position(47.6458097, -122.142789)
              Position(47.6367593, -122.1428104)
              Position(47.6368027, -122.1398707)
              Position(47.6380172, -122.1376177)
              Position(47.640663, -122.1352359)
              Position(47.6426148, -122.1347209)
              Position(47.6458676, -122.1356007) ]
        )
            .strokeWidth(8.)
            .fillColor(Color.Red.ToFabColor())
            .strokeColor (Color.Blue.ToFabColor())
            
        // Draw a circle on the map
        MapCircle(Position(37.79752, -122.40183), Distance(250.))
            .fillColor(Color.FromHex("#88FFC0CB").ToFabColor())
            .strokeColor(Color.FromHex("#88FF0000").ToFabColor())
            .strokeWidth (8.)
            
        // Draw a polyline on the map
        MapPolyline(
            [ Position(47.6381401, -122.1317367)
              Position(47.6381473, -122.1350841)
              Position(47.6382847, -122.1353094)
              Position(47.6384582, -122.1354703)
              Position(47.6401136, -122.1360819)
              Position(47.6403883, -122.1364681)
              Position(47.6407426, -122.1377019)
              Position(47.6412558, -122.1404056)
              Position(47.6414148, -122.1418647)
              Position(47.6414654, -122.1432702) ]
        )
            .strokeColor(Color.Blue.ToFabColor())
            .strokeWidth (12.)
    }
```

## Other useful links:
- [The official Fabulous website](https://fabulous.dev)
- [Get started](https://fabulous.dev/maui.controls/get-started)
- [Contributor Guide](CONTRIBUTING.md)

Additionally, we have the [Fabulous Discord server](https://discord.gg/bpTJMbSSYK) where you can ask any of your Fabulous related questions.

## Supporting Fabulous

The simplest way to show us your support is by giving this project and the [Fabulous project](https://github.com/fabulous-dev/Fabulous) a star.

You can also support us by becoming our sponsor on the GitHub Sponsors program.  
This is a fantastic way to support all the efforts going into making Fabulous the best declarative UI framework for dotnet.

If you need support see Commercial Support section below.

## Contributing

Have you found a bug or have a suggestion of how to enhance Fabulous? Open an issue and we will take a look at it as soon as possible.

Do you want to contribute with a PR? PRs are always welcome, just make sure to create it from the correct branch (main) and follow the [Contributor Guide](CONTRIBUTING.md).

For bigger changes, or if in doubt, make sure to talk about your contribution to the team. Either via an issue, GitHub discussion, or reach out to the team either using the [Discord server](https://discord.gg/bpTJMbSSYK).

## Commercial support

If you would like us to provide you with:

- training and workshops,
- support services,
- and consulting services.

Feel free to contact us: [support@fabulous.dev](mailto:support@fabulous.dev)
