// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.
namespace Elmish.XamarinForms.DynamicViews 

open Xamarin.Forms

open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews
open System.Runtime.CompilerServices
open System.Collections.Generic
open System.Windows.Input

[<AutoOpen>]
module SimplerHelpers = 

    let rowdef h = Xaml.RowDefinition(height=makeGridLength h)
    let coldef h = Xaml.ColumnDefinition(width=makeGridLength h)

    let rows rds (els: XamlElement list) = 
        let children = els |> List.mapi (fun i x -> x.GridRow i)
        Xaml.Grid(rowdefs=rds, children=children)

    let cols cds (els: XamlElement list) = 
        let children = els |> List.mapi (fun i x -> x.GridColumn i)
        Xaml.Grid(coldefs=cds, children=children)

    type internal Amortizations() = 
       static let t = Dictionary<obj,System.WeakReference<obj>>(HashIdentity.Structural)
       static member T = t

    type DoNotUseModelInsideDependsOn = | DoNotUseModelInsideDependsOn

    /// Memoize part of a view model computation and prevent the use of the model inside
    /// the computation except where explicitly de-referenced.
    ///
    /// Usage: "dependsOn model.Count <| fun model count -> ..."
    ///
    /// Note, this function uses "f.GetType()" to get a unique code location.
    let dependsOn key (f: DoNotUseModelInsideDependsOn -> 'Key -> 'Value) : 'Value = 
        let bkey = (key, f.GetType())
        let mutable res = null
        match Amortizations.T.TryGetValue(bkey) with 
        | true, weak when weak.TryGetTarget(&res) -> unbox res
        | _ ->
             let res = f DoNotUseModelInsideDependsOn key
             Amortizations.T.[bkey] <- System.WeakReference<obj>(box res)
             res
        
    /// Memoize a callback that has no interesting dependencies.
    /// NOTE: use with caution. The function must not capture any values.
    let fix (f: unit -> 'Value) = 
        let key = f.GetType()
        let mutable res = null
        match Amortizations.T.TryGetValue(key) with 
        | true, weak when weak.TryGetTarget(&res) -> unbox res
        | _ ->
             // Note: we do this check once only per syntactic closure occurrence that is passed to 'fix'
             let flds = key.GetFields(System.Reflection.BindingFlags.NonPublic) |> Array.filter (fun fld -> fld.Name <> "dispatch")
             if flds.Length > 0 then failwithf "the closure '%s' has a dependency '%s', you can't use 'fix' with such a closure" key.Name flds.[0].Name
             let res = f()
             Amortizations.T.[key] <- System.WeakReference<obj>(box res)
             res

    let fixf (f: 'Args -> 'Value) = 
        let key = f.GetType()
        let mutable res = null
        match Amortizations.T.TryGetValue(key) with 
        | true, weak when weak.TryGetTarget(&res) -> unbox res
        | _ ->
             // Note: we do this check once only per syntactic closure occurrence that is passed to 'fix'
             let flds = key.GetFields(System.Reflection.BindingFlags.NonPublic) |> Array.filter (fun fld -> fld.Name <> "dispatch")
             if flds.Length > 0 then failwithf "the closure '%s' has a dependency '%s', you can't use 'fix' with such a closure" key.Name flds.[0].Name
             let res = f
             Amortizations.T.[key] <- System.WeakReference<obj>(box res)
             res
        
