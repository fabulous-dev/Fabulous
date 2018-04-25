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

    type internal Amortizations<'Key,'Value when 'Key : equality and 'Value : not struct>() = 
       static let t = Dictionary<'Key,System.WeakReference<'Value>>(HashIdentity.Structural)
       static member T = t

    type DoNotUseModelInsideAmortize = | DoNotUseModelInsideAmortize

    /// Amortize part of a view model computation and prevent the use of the model inside
    /// the amortized computation except where explicitly de-referenced.
    ///
    /// Usage: "amortize model.Count <| fun model count -> ..."
    ///
    /// Note, this function uses "f.GetType()" to get a unique code location.
    let amortize key f = 
        let bkey = (key, f.GetType())
        let mutable res = Unchecked.defaultof<'Value>
        match Amortizations<('Key * System.Type),'Value>.T.TryGetValue(bkey) with 
        | true, weak when weak.TryGetTarget(&res) -> 
             //printfn "amortized key = %A --> %A" bkey res
             res
        | _ ->
             let res = f DoNotUseModelInsideAmortize key
             Amortizations<('Key * System.Type),'Value>.T.[bkey] <- System.WeakReference<'Value>(res)
             //printfn "calculated key = %A --> %A" bkey res
             res
        
    // Helper page for the TicTacToe sample
    // Need to generlize the HeightRequest phase of the XF content digestion process...
    type HelperPage(?viewAllocatedSizeFixup) as self =
        inherit ContentPage()
        do Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(self, true)

        // painful.... It is unfortunately not possible to simpy recreate the whole
        // view here, you have to mutate the content in-place.
        override this.OnSizeAllocated(width, height) =
            base.OnSizeAllocated(width, height)
            match viewAllocatedSizeFixup with 
            | Some f -> f self.Content (width, height)
            | None -> ()

