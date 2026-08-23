namespace Fabulous.Maui.Maps

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui.Controls.Maps
open Microsoft.Maui.Devices.Sensors

type IFabMapPolyline =
    inherit IFabMapElement

module MapPolyline =
    let WidgetKey = Widgets.register<Polyline>()

    let GeoPathList =
        Attributes.defineSimpleScalarWithEquality<Location list> "Polyline_GeoPath" (fun _ newValueOpt node ->
            let polyline = node.Target :?> Polyline

            match newValueOpt with
            | ValueNone -> polyline.Geopath.Clear()
            | ValueSome geoPaths -> geoPaths |> List.iter polyline.Geopath.Add)

[<AutoOpen>]
module MapPolylineBuilders =

    type Fabulous.Maui.View with

        /// <summary>A Polyline object can be added to a map by instantiating it and adding it to the map's MapElements collection.</summary>
        /// <param name ="geoPaths">Contains a list of Location objects defining the geographic coordinates of the polyline points. A Polyline object is rendered on the map once it has been added to the MapElements collection of the Map.</param>
        static member inline MapPolyline<'msg>(geoPaths: Location list) =
            WidgetBuilder<'msg, IFabMapPolyline>(
                MapPolyline.WidgetKey,
                AttributesBundle(StackList.one(MapPolyline.GeoPathList.WithValue(geoPaths)), ValueNone, ValueNone)
            )

[<Extension>]
type MapPolylineModifiers =
    /// <summary>Link a ViewRef to access the direct Polyline control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMapPolyline>, value: ViewRef<Polyline>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
