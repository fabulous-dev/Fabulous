namespace Fabulous.Maui.Maps

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui.Devices.Sensors
open Microsoft.Maui.Maps
open Microsoft.Maui.Controls.Maps

type IFabMap =
    inherit IFabView

module Map =
    let WidgetKey = Widgets.register<Map>()

    let MapType =
        Attributes.defineEnum<MapType> "Map_MapType" (fun _ newValueOpt node ->
            let map = node.Target :?> Map

            let value =
                match newValueOpt with
                | ValueNone -> MapType.Street
                | ValueSome v -> v

            map.MapType <- value)

    let IsShowingUser = Attributes.defineBindableBool Map.IsShowingUserProperty

    let IsTrafficEnabled = Attributes.defineBindableBool Map.IsTrafficEnabledProperty

    let IsScrollEnabled = Attributes.defineBindableBool Map.IsScrollEnabledProperty

    let IsZoomEnabled = Attributes.defineBindableBool Map.IsZoomEnabledProperty

    let RequestedRegion =
        Attributes.defineSimpleScalarWithEquality<MapSpan> "Map_RequestedRegion" (fun _ newValueOpt node ->
            let map = node.Target :?> Map

            match newValueOpt with
            | ValueNone -> ()
            | ValueSome mapSpan -> map.MoveToRegion(mapSpan))

    let Pins =
        Attributes.defineListWidgetCollection "Map_Pins" (fun target -> (target :?> Map).Pins)

    let MapElements =
        Attributes.defineListWidgetCollection "Map_MapElements" (fun target -> (target :?> Map).MapElements)

    let MapClicked =
        Attributes.defineEvent<MapClickedEventArgs> "Map_MapClicked" (fun target -> (target :?> Map).MapClicked)

[<AutoOpen>]
module MapBuilders =
    type Fabulous.Maui.View with

        /// <summary>The Map control is a cross-platform view for displaying and annotating maps</summary>
        /// <param name ="requestRegion">The region of a map to display when a map is loaded can be set by passing a MapSpan.</param>
        static member inline Map<'msg>(requestRegion: MapSpan) =
            WidgetBuilder<'msg, IFabMap>(Map.WidgetKey, AttributesBundle(StackList.one(Map.RequestedRegion.WithValue(requestRegion)), ValueNone, ValueNone))

        /// <summary>The Map control is a cross-platform view for displaying and annotating maps</summary>
        /// <param name ="requestRegion">The region of a map to display when a map is loaded can be set by passing a MapSpan.</param>
        static member inline MapWithPins<'msg>(requestRegion: MapSpan) =
            CollectionBuilder<'msg, IFabMap, IMapPin>(Map.WidgetKey, Map.Pins, Map.RequestedRegion.WithValue(requestRegion))

[<Extension>]
type MapModifiers =
    /// <summary>Determines whether the map is allowed to zoom.</summary>
    [<Extension>]
    static member inline isZoomEnabled(this: WidgetBuilder<'msg, #IFabMap>, value: bool) =
        this.AddScalar(Map.IsZoomEnabled.WithValue(value))

    /// <summary>Determines whether the map is allowed to scroll.</summary>
    [<Extension>]
    static member inline isScrollEnabled(this: WidgetBuilder<'msg, #IFabMap>, value: bool) =
        this.AddScalar(Map.IsScrollEnabled.WithValue(value))

    /// <summary>Indicates the display style of the map.</summary>
    [<Extension>]
    static member inline mapType(this: WidgetBuilder<'msg, #IFabMap>, value: MapType) =
        this.AddScalar(Map.MapType.WithValue(value))

    /// <summary>Indicates whether the map is showing the user's current location.</summary>
    [<Extension>]
    static member inline isShowingUser(this: WidgetBuilder<'msg, #IFabMap>, value: bool) =
        this.AddScalar(Map.IsShowingUser.WithValue(value))

    /// <summary>Indicates whether traffic data is overlaid on the map.</summary>
    [<Extension>]
    static member inline isTrafficEnabled(this: WidgetBuilder<'msg, #IFabMap>, value: bool) =
        this.AddScalar(Map.IsTrafficEnabled.WithValue(value))

    /// <summary>Event that is fired when the user interacts with the map.</summary>
    /// <param name="onMapClicked">Msg to dispatch when the user interacts with the map.</param>
    [<Extension>]
    static member inline onMapClicked(this: WidgetBuilder<'msg, #IFabMap>, onMapClicked: Location -> 'msg) =
        this.AddScalar(Map.MapClicked.WithValue(fun args -> onMapClicked args.Location |> box))

    /// <summary>Represents the list of elements on the map, such as polygons, circles and polylines.</summary>
    [<Extension>]
    static member inline mapElements<'msg, 'marker when 'marker :> IFabMap>(this: WidgetBuilder<'msg, 'marker>) =
        WidgetHelpers.buildAttributeCollection<'msg, 'marker, IMapElement> Map.MapElements this

    /// <summary>Link a ViewRef to access the direct Map control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMap>, value: ViewRef<Map>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type MapCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabMapElement>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IMapElement>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabMapElement>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IMapElement>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }


    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabMapPin>
        (
            _: CollectionBuilder<'msg, 'marker, IMapPin>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabMapPin>
        (
            _: CollectionBuilder<'msg, 'marker, IMapPin>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
