namespace Fabulous.XamarinForms.Maps

open Fabulous.XamarinForms

module ViewUpdaters =
    let updateMapRequestedRegion (prevOpt: Xamarin.Forms.Maps.MapSpan voption) (currOpt: Xamarin.Forms.Maps.MapSpan voption) (target: Xamarin.Forms.Maps.Map) =
        match prevOpt, currOpt with
        | ValueNone, ValueSome curr -> target.MoveToRegion(curr)
        | ValueSome prev, ValueSome curr when prev <> curr -> target.MoveToRegion(curr)
        | _ -> ()

    let updatePolygonGeopath (prevCollOpt: Xamarin.Forms.Maps.Position array voption) (currCollOpt: Xamarin.Forms.Maps.Position array voption) (target: Xamarin.Forms.Maps.Polygon) _ =
        ViewUpdaters.updateCollectionGeneric prevCollOpt currCollOpt target.Geopath
            id
            (fun _ _ _ -> ())
            (fun prev curr -> prev = curr)
            (fun _ _ -> Map.empty)
            (fun _ _ _ -> ())

    let updatePolylineGeopath (prevCollOpt: Xamarin.Forms.Maps.Position array voption) (currCollOpt: Xamarin.Forms.Maps.Position array voption) (target: Xamarin.Forms.Maps.Polyline) _ =
        ViewUpdaters.updateCollectionGeneric prevCollOpt currCollOpt target.Geopath
            id
            (fun _ _ _ -> ())
            (fun prev curr -> prev = curr)
            (fun _ _ -> Map.empty)
            (fun _ _ _ -> ())