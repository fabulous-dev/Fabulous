namespace FabulousContacts.Controls

open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.XamarinForms
open Xamarin.Forms.Maps
open System.Runtime.CompilerServices

type IPin =
    inherit IElement

type IMap =
    inherit IView

module Pin =
    let PinType =
        Attributes.defineBindableWithEquality<PinType> Pin.TypeProperty

    let Label =
        Attributes.defineBindableWithEquality<string> Pin.LabelProperty

    let Position =
        Attributes.defineBindableWithEquality<Position> Pin.PositionProperty

    let Address =
        Attributes.defineBindableWithEquality<string> Pin.AddressProperty

    let PinKey = Widgets.register<Pin>()

module Map =
    let RequestedRegion =
        Attributes.defineSimpleScalarWithEquality<MapSpan>
            "Map_RequestedRegion"
            (fun _ newValueOpt node ->
                let map = node.Target :?> Map

                match newValueOpt with
                | ValueNone -> ()
                | ValueSome mapSpan -> map.MoveToRegion(mapSpan))

    let Pins =
        Attributes.defineListWidgetCollection "Map_Pins" (fun target -> (target :?> Map).Pins)

    let HasZoomEnabled =
        Attributes.defineBindableBool Map.HasZoomEnabledProperty

    let HasScrollEnabled =
        Attributes.defineBindableBool Map.HasScrollEnabledProperty

    let MapKey = Widgets.register<Map>()

[<AutoOpen>]
module MapBuilders =

    type Fabulous.XamarinForms.View with
        static member inline Pin<'msg>(pinType, label, position) =
            WidgetBuilder<'msg, IPin>(
                Pin.PinKey,
                Pin.PinType.WithValue(pinType),
                Pin.Label.WithValue(label),
                Pin.Position.WithValue(position)
            )

        static member inline Map<'msg>(requestedRegion) =
            CollectionBuilder<'msg, IMap, IPin>(Map.MapKey, Map.Pins, Map.RequestedRegion.WithValue(requestedRegion))

[<Extension>]
type MapModifiers =
    [<Extension>]
    static member inline withZoom(this: WidgetBuilder<'msg, #IMap>, ?enabled: bool) =
        let value =
            match enabled with
            | None -> true
            | Some value -> value

        this.AddScalar(Map.HasZoomEnabled.WithValue(value))

    [<Extension>]
    static member inline withScroll(this: WidgetBuilder<'msg, #IMap>, ?enabled: bool) =
        let value =
            match enabled with
            | None -> true
            | Some value -> value

        this.AddScalar(Map.HasScrollEnabled.WithValue(value))

[<Extension>]
type PinExtensions =
    [<Extension>]
    static member inline address(this: WidgetBuilder<'msg, #IPin>, value: string) =
        this.AddScalar(Pin.Address.WithValue(value))

[<Extension>]
type CollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IPin>
        (
            _: CollectionBuilder<'msg, 'marker, IPin>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
