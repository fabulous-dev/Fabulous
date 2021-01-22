namespace Fabulous.XamarinForms.Maps

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms.Maps

module ViewUpdaters =
    let updateMapRequestedRegion (_: ProgramDefinition) (prevOpt: Xamarin.Forms.Maps.MapSpan voption) (currOpt: Xamarin.Forms.Maps.MapSpan voption) (target: Xamarin.Forms.Maps.Map) =
        match prevOpt, currOpt with
        | ValueNone, ValueSome curr -> target.MoveToRegion(curr)
        | ValueSome prev, ValueSome curr when prev <> curr -> target.MoveToRegion(curr)
        | _ -> ()

    let updatePolygonGeopath (definition: ProgramDefinition) (prevCollOpt: Position array voption) (currCollOpt: Xamarin.Forms.Maps.Position array voption) (target: Xamarin.Forms.Maps.Polygon) _ =
        Collections.updateItems definition prevCollOpt currCollOpt target.Geopath
            (fun _ -> ValueNone)
            (fun prev curr -> prev = curr)
            (fun _ _ x -> x)
            (fun _ _ _ _ -> ())
            (fun _ _ _ _ -> ())

    let updatePolylineGeopath (definition: ProgramDefinition) (prevCollOpt: Xamarin.Forms.Maps.Position array voption) (currCollOpt: Xamarin.Forms.Maps.Position array voption) (target: Xamarin.Forms.Maps.Polyline) _ =
        Collections.updateItems definition prevCollOpt currCollOpt target.Geopath
            (fun _ -> ValueNone)
            (fun prev curr -> prev = curr)
            (fun _ _ x -> x)
            (fun _ _ _ _ -> ())
            (fun _ _ _ _ -> ())