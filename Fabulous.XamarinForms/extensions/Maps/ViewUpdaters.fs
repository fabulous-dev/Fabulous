namespace Fabulous.XamarinForms.Maps

open Fabulous.XamarinForms
open Xamarin.Forms.Maps

module ViewUpdaters =
    let updateMapRequestedRegion (prevOpt: Xamarin.Forms.Maps.MapSpan voption) (currOpt: Xamarin.Forms.Maps.MapSpan voption) (target: Xamarin.Forms.Maps.Map) =
        match prevOpt, currOpt with
        | ValueNone, ValueSome curr -> target.MoveToRegion(curr)
        | ValueSome prev, ValueSome curr when prev <> curr -> target.MoveToRegion(curr)
        | _ -> ()

    let updatePolygonGeopath (prevCollOpt: Position array voption) (currCollOpt: Xamarin.Forms.Maps.Position array voption) (target: Xamarin.Forms.Maps.Polygon) _ =
        Collections.updateItems prevCollOpt currCollOpt target.Geopath
            (fun _ -> ValueNone)
            (fun prev curr -> prev = curr)
            id
            (fun _ _ _ -> ())
            (fun _ _ _ -> ())

    let updatePolylineGeopath (prevCollOpt: Xamarin.Forms.Maps.Position array voption) (currCollOpt: Xamarin.Forms.Maps.Position array voption) (target: Xamarin.Forms.Maps.Polyline) _ =
        Collections.updateItems prevCollOpt currCollOpt target.Geopath
            (fun _ -> ValueNone)
            (fun prev curr -> prev = curr)
            id
            (fun _ _ _ -> ())
            (fun _ _ _ -> ())