// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.
namespace Elmish.XamarinForms.DynamicViews 

open Xamarin.Forms

open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews
open System.Collections.Generic

[<AutoOpen>]
module SimplerHelpers = 

    type internal Memoizations() = 
       static let t = Dictionary<obj,System.WeakReference<obj>>(HashIdentity.Structural)
       static member T = t

    type DoNotUseModelInsideDependsOn = | DoNotUseModelInsideDependsOn

    /// Memoize part of a view model computation. Also prevent the use of the model inside
    /// the computation except where explicitly de-referenced.
    ///
    /// Usage: "dependsOn model.Count (fun model count -> ...)"
    ///
    /// Note, this function uses "f.GetType()" to get a unique code location.
    let dependsOn key (f: DoNotUseModelInsideDependsOn -> 'Key -> 'Value) : 'Value = 
        let bkey = (key, f.GetType())
        let mutable res = null
        match Memoizations.T.TryGetValue(bkey) with 
        | true, weak when weak.TryGetTarget(&res) -> unbox res
        | _ ->
             let res = f DoNotUseModelInsideDependsOn key
             Memoizations.T.[bkey] <- System.WeakReference<obj>(box res)
             res
        
    /// Dispatch a message via the currently running Elmish program
    [<System.Obsolete("The global dispatch routine should no longer be used as it is not type safe, please use the dispatch routine passed to the 'view' function", error=true)>]
    let dispatch _msg : unit = failwith "??"

    /// Memoize a callback that has no interesting dependencies.
    /// NOTE: use with caution. The function must not capture any values besides "dispatch"
    let fix (f: unit -> 'Value) = 
        let key = f.GetType()
        let mutable res = null
        match Memoizations.T.TryGetValue(key) with 
        | true, weak when weak.TryGetTarget(&res) -> unbox res
        | _ ->
             // Note: we do this check once only per syntactic closure occurrence that is passed to 'fix'
             let flds = key.GetFields(System.Reflection.BindingFlags.NonPublic) |> Array.filter (fun fld -> fld.Name <> "dispatch")
             if flds.Length > 0 then failwithf "the closure '%s' has a dependency '%s', you can't use 'fix' with such a closure" key.Name flds.[0].Name
             let res = f()
             Memoizations.T.[key] <- System.WeakReference<obj>(box res)
             res

    /// Memoize a callback that has explicit dependencies.
    /// NOTE: use with caution. The function must not capture any values besides "dispatch"
    let fixf (f: 'Args -> 'Value) = 
        let key = f.GetType()
        let mutable res = null
        match Memoizations.T.TryGetValue(key) with 
        | true, weak when weak.TryGetTarget(&res) -> unbox res
        | _ ->
             // Note: we do this check once only per syntactic closure occurrence that is passed to 'fix'
             let flds = key.GetFields(System.Reflection.BindingFlags.NonPublic) |> Array.filter (fun fld -> fld.Name <> "dispatch")
             if flds.Length > 0 then failwithf "the closure '%s' has a dependency '%s', you can't use 'fix' with such a closure" key.Name flds.[0].Name
             let res = f
             Memoizations.T.[key] <- System.WeakReference<obj>(box res)
             res

    type ViewElement with 
        member x.With(?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, 
                      ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, 
                      ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, 
                      ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, 
                      ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, 
                      ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 
            let x = match horizontalOptions with None -> x | Some opt -> x.HorizontalOptions(opt)
            let x = match verticalOptions with None -> x | Some opt -> x.VerticalOptions(opt)
            let x = match margin with None -> x | Some opt -> x.Margin(opt)
            let x = match gestureRecognizers with None -> x | Some opt -> x.GestureRecognizers(opt)
            let x = match anchorX with None -> x | Some opt -> x.AnchorX(opt)
            let x = match anchorY with None -> x | Some opt -> x.AnchorY(opt)
            let x = match backgroundColor with None -> x | Some opt -> x.BackgroundColor(opt)
            let x = match heightRequest with None -> x | Some opt -> x.HeightRequest(opt)
            let x = match inputTransparent with None -> x | Some opt -> x.InputTransparent(opt)
            let x = match isEnabled with None -> x | Some opt -> x.IsEnabled(opt)
            let x = match isVisible with None -> x | Some opt -> x.IsVisible(opt)
            let x = match minimumHeightRequest with None -> x | Some opt -> x.MinimumHeightRequest(opt)
            let x = match minimumWidthRequest with None -> x | Some opt -> x.MinimumWidthRequest(opt)
            let x = match opacity with None -> x | Some opt -> x.Opacity(opt)
            let x = match rotation with None -> x | Some opt -> x.Rotation(opt)
            let x = match rotationX with None -> x | Some opt -> x.RotationX(opt)
            let x = match rotationY with None -> x | Some opt -> x.RotationY(opt)
            let x = match scale with None -> x | Some opt -> x.Scale(opt)
            let x = match style with None -> x | Some opt -> x.Style(opt)
            let x = match translationX with None -> x | Some opt -> x.TranslationX(opt)
            let x = match translationY with None -> x | Some opt -> x.TranslationY(opt)
            let x = match widthRequest with None -> x | Some opt -> x.WidthRequest(opt)
            let x = match resources with None -> x | Some opt -> x.Resources(opt)
            let x = match styles with None -> x | Some opt -> x.Styles(opt)
            let x = match styleSheets with None -> x | Some opt -> x.StyleSheets(opt)
            let x = match styleSheets with None -> x | Some opt -> x.StyleSheets(opt)
            let x = match classId with None -> x | Some opt -> x.ClassId(opt)
            let x = match styleId with None -> x | Some opt -> x.StyleId(opt)
            x
