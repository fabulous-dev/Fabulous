namespace Fabulous.Maui.Maps

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui
open Microsoft.Maui.Controls.Maps
open Microsoft.Maui.Devices.Sensors

type IFabMapPin =
    inherit IFabElement

module MapPin =
    let WidgetKey = Widgets.register<Pin>()

    let PinType = Attributes.defineBindableWithEquality<PinType> Pin.TypeProperty

    let Location = Attributes.defineBindableWithEquality<Location> Pin.LocationProperty

    let Address = Attributes.defineBindableWithEquality<string> Pin.AddressProperty

    let Label = Attributes.defineBindableWithEquality<string> Pin.LabelProperty

    let MarkerClicked =
        Attributes.defineEvent<PinClickedEventArgs> "Pin_MarkerClicked" (fun target -> (target :?> Pin).MarkerClicked)

    let InfoWindowClicked =
        Attributes.defineEvent<PinClickedEventArgs> "Pin_InfoWindowClicked" (fun target -> (target :?> Pin).InfoWindowClicked)

[<AutoOpen>]
module MapPinBuilders =
    type Fabulous.Maui.View with

        /// <summary>Map control allows locations to be marked with Pin objects. A Pin is a map marker that opens an information window.</summary>
        /// <param name ="location">Represents the latitude and longitude of the pin.</param>
        static member inline MapPin<'msg>(location: Location) =
            WidgetBuilder<'msg, IFabMapPin>(MapPin.WidgetKey, MapPin.Location.WithValue(location))

[<Extension>]
type MapPinModifiers =
    /// <summary>Represents the address for the pin location.</summary>
    /// <param name ="value">It can be any string content, not just an address.</param>
    [<Extension>]
    static member inline address(this: WidgetBuilder<'msg, #IFabMapPin>, value: string) =
        this.AddScalar(MapPin.Address.WithValue(value))

    /// <summary>Represents the pin title.</summary>
    [<Extension>]
    static member inline label(this: WidgetBuilder<'msg, #IFabMapPin>, value: string) =
        this.AddScalar(MapPin.Label.WithValue(value))

    /// <summary>Represents the type of pin.</summary>
    [<Extension>]
    static member inline pinType(this: WidgetBuilder<'msg, #IFabMapPin>, value: PinType) =
        this.AddScalar(MapPin.PinType.WithValue(value))

    /// <summary>Event that is fired when the user presses the map marker.</summary>
    /// <param name="onMarkerClicked">Msg to dispatch when the user presses the map marker.</param>
    [<Extension>]
    static member inline onMarkerClicked(this: WidgetBuilder<'msg, #IFabMapPin>, onMarkerClicked: bool -> 'msg) =
        this.AddScalar(MapPin.MarkerClicked.WithValue(fun args -> onMarkerClicked args.HideInfoWindow |> box))

    /// <summary>Event that is fired when the user presses the map marker info window.</summary>
    /// <param name="onInfoWindowClicked">Msg to dispatch when the user presses the map marker info window.</param>
    [<Extension>]
    static member inline onInfoWindowClicked(this: WidgetBuilder<'msg, #IFabMapPin>, onInfoWindowClicked: bool -> 'msg) =
        this.AddScalar(MapPin.InfoWindowClicked.WithValue(fun args -> onInfoWindowClicked args.HideInfoWindow |> box))

    /// <summary>Link a ViewRef to access the direct Pin control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMapPin>, value: ViewRef<Pin>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
