namespace FabulousContacts.Controls

open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.Widgets
open Fabulous.XamarinForms.XFAttributes
open Xamarin.Forms
open Xamarin.Forms.Maps
open System.Runtime.CompilerServices

type IPinWidgetBuilder<'msg> = inherit IWidgetBuilder<'msg>

module Pin =
    let PinType = Attributes.defineBindable<PinType> Xamarin.Forms.Maps.Pin.TypeProperty
    let Address = Attributes.defineBindable<string> Xamarin.Forms.Maps.Pin.AddressProperty

module Map =
    let RequestedRegion = Attributes.define<MapSpan> "Map_RequestedRegion" (fun () -> Unchecked.defaultof<MapSpan>) (fun (newValueOpt, target) ->
        let map = target :?> Xamarin.Forms.Maps.Map
        match newValueOpt with
        | ValueNone -> ()
        | ValueSome mapSpan -> map.MoveToRegion(mapSpan)
    )
    let Pins = Attributes.defineWidgetCollection<Xamarin.Forms.Maps.Pin> ViewNode.getViewNode "Map_Pins" (fun target -> (target :?> Xamarin.Forms.Maps.Map).Pins)
    let HasZoomEnabled = Attributes.defineBindable<bool> Xamarin.Forms.Maps.Map.HasZoomEnabledProperty
    let HasScrollEnabled = Attributes.defineBindable<bool> Xamarin.Forms.Maps.Map.HasScrollEnabledProperty

type [<Struct>] PinWidgetBuilder<'msg>(scalarAttributes: ScalarAttribute[], widgetAttributes: WidgetAttribute[], widgetCollectionAttributes: WidgetCollectionAttribute[]) =
    static let key = Widgets.register<Xamarin.Forms.Maps.Pin>()

    static member Create(pinType: PinType, label: string, position: Position) =
        PinWidgetBuilder<'msg>(
            [| Pin.PinType.WithValue(pinType) |],
            [||],
            [||]
        )
        
    interface IPinWidgetBuilder<'msg> with
        member _.ScalarAttributes = scalarAttributes
        member _.WidgetAttributes = widgetAttributes
        member _.WidgetCollectionAttributes = widgetCollectionAttributes
        member _.Compile() =
            { Key = key
              ScalarAttributes = scalarAttributes
              WidgetAttributes = widgetAttributes
              WidgetCollectionAttributes = widgetCollectionAttributes }

type [<Struct>] MapWidgetBuilder<'msg> (scalarAttributes: ScalarAttribute[], widgetAttributes: WidgetAttribute[], widgetCollectionAttributes: WidgetCollectionAttribute[]) =
    static let key = Widgets.register<Xamarin.Forms.Maps.Map>()

    static member Create(requestedRegion: MapSpan, pins: #seq<IPinWidgetBuilder<'msg>>) =
        MapWidgetBuilder<'msg>(
            [| Map.RequestedRegion.WithValue(requestedRegion) |],
            [||],
            [| Map.Pins.WithValue(ViewHelpers.compileSeq pins) |]
        )
        
    interface IViewWidgetBuilder<'msg> with
        member _.ScalarAttributes = scalarAttributes
        member _.WidgetAttributes = widgetAttributes
        member _.WidgetCollectionAttributes = widgetCollectionAttributes
        member _.Compile() =
            { Key = key
              ScalarAttributes = scalarAttributes
              WidgetAttributes = widgetAttributes
              WidgetCollectionAttributes = widgetCollectionAttributes }

module MapView =
    [<Extension>]
    type MapExtensions =
        [<Extension>]
        static member inline address(this: #IPinWidgetBuilder<_>, value: string) =
            this.AddScalarAttribute(Pin.Address.WithValue(value))
        [<Extension>]
        static member inline hasZoomEnabled(this: MapWidgetBuilder<_>, value: bool) =
            this.AddScalarAttribute(Map.HasZoomEnabled.WithValue(value))
        [<Extension>]
        static member inline hasScrollEnabled(this: MapWidgetBuilder<_>, value: bool) =
            this.AddScalarAttribute(Map.HasScrollEnabled.WithValue(value))

    type Fabulous.XamarinForms.View with
        static member inline Pin<'msg>(pinType, label, position) = PinWidgetBuilder<'msg>.Create(pinType, label, position)
        static member inline Map<'msg>(requestedRegion, pins) = MapWidgetBuilder<'msg>.Create(requestedRegion, pins)