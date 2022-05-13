namespace FabulousContacts.Controls

// open Fabulous
// open Fabulous.StackAllocatedCollections
// open Fabulous.XamarinForms
// open Xamarin.Forms.Maps
// open System.Runtime.CompilerServices

// module Pin =
//     let PinType =
//         Attributes.defineBindable<PinType> Pin.TypeProperty

//     let Label =
//         Attributes.defineBindable<string> Pin.LabelProperty

//     let Position =
//         Attributes.defineBindable<Position> Pin.PositionProperty

//     let Address =
//         Attributes.defineBindable<string> Pin.AddressProperty

//     let PinKey = Widgets.register<Pin> ()

// module Map =
//     let RequestedRegion =
//         Attributes.define<MapSpan>
//             "Map_RequestedRegion"
//             (fun (newValueOpt, node) ->
//                 let map = node.Target :?> Map

//                 match newValueOpt with
//                 | ValueNone -> ()
//                 | ValueSome mapSpan -> map.MoveToRegion(mapSpan))

//     let Pins =
//         Attributes.defineWidgetCollection<Pin> "Map_Pins" (fun target -> (target :?> Map).Pins)

//     let HasZoomEnabled =
//         Attributes.defineBindableBool Map.HasZoomEnabledProperty

//     let HasScrollEnabled =
//         Attributes.defineBindableBool Map.HasScrollEnabledProperty

//     let MapKey = Widgets.register<Map> ()

// module MapView =
//     type IPin =
//         inherit IMarker

//     type IMap =
//         inherit IView

//     type Fabulous.XamarinForms.View with
//         static member inline Pin<'msg>(pinType, label, position) =
//             WidgetBuilder<'msg, IPin>(
//                 Pin.PinKey,
//                 Pin.PinType.WithValue(pinType),
//                 Pin.Label.WithValue(label),
//                 Pin.Position.WithValue(position)
//             )

//         static member inline Map<'msg>(requestedRegion) =
//             CollectionBuilder<'msg, IMap, IPin>(Map.MapKey, Map.Pins, Map.RequestedRegion.WithValue(requestedRegion))

//     [<Extension>]
//     type MapExtensions =
//         [<Extension>]
//         static member inline address(this: WidgetBuilder<'msg, #IPin>, value: string) =
//             this.AddScalar(Pin.Address.WithValue(value))

//         [<Extension>]
//         static member inline hasZoomEnabled(this: WidgetBuilder<'msg, #IMap>, value: bool) =
//             this.AddScalar(Map.HasZoomEnabled.WithValue(value))

//         [<Extension>]
//         static member inline hasScrollEnabled(this: WidgetBuilder<'msg, #IMap>, value: bool) =
//             this.AddScalar(Map.HasScrollEnabled.WithValue(value))

//     [<Extension>]
//     type CollectionBuilderExtensions =
//         [<Extension>]
//         static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IPin>
//             (
//                 _: CollectionBuilder<'msg, 'marker, IPin>,
//                 x: WidgetBuilder<'msg, 'itemType>
//             ) : Content<'msg> =
//             { Widgets = MutStackArray1.One(x.Compile()) }
